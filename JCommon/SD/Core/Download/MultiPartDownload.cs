using System;
using System.Collections.Generic;
using System.Linq;
using JCommon.SD.Core.Enums;
using JCommon.SD.Core.Interfaces;
using JCommon.SD.Core.Events;
using JCommon.SD.Core.Utils;
using JCommon.SD.Core.Exceptions;
using JCommon.SD.Core.Data;

namespace JCommon.SD.Core.Download
{
    public class MultiPartDownload : AbstractDownload
    {
        private readonly SDDataContainerHelper SDDataContainerHelper = new SDDataContainerHelper();

        private readonly int numberOfParts;

        private readonly ISDBuilder downloadBuilder;

        private readonly Dictionary<ISD, SDDC> downloads = new Dictionary<ISD, SDDC>();

        public MultiPartDownload(
            Uri url,
            int bufferSize,
            int numberOfParts,
            ISDBuilder downloadBuilder,
            ISDRequestBuilder requestBuilder,
            ISDChecker downloadChecker,
            List<SDDC> alreadyDownloadedRanges)
            : base(url, bufferSize, null, null, requestBuilder, downloadChecker)
        {
            if (numberOfParts <= 0)
                throw new ArgumentException("numberOfParts <= 0");

            if (downloadBuilder == null)
                throw new ArgumentNullException("downloadBuilder");

            this.numberOfParts = numberOfParts;
            this.downloadBuilder = downloadBuilder;
            this.AlreadyDownloadedRanges = alreadyDownloadedRanges ?? new List<SDDC>();

            if (System.Net.ServicePointManager.DefaultConnectionLimit < numberOfParts)
            {
                System.Net.ServicePointManager.DefaultConnectionLimit = numberOfParts;
            }
        }

        public List<SDDC> AlreadyDownloadedRanges { get; private set; }

        public List<SDDC> ToDoRanges { get; private set; }

        protected override void OnStart()
        {
            var downloadCheck = this.PerformInitialDownloadCheck();
            this.DetermineFileSizeAndStartDownloads(downloadCheck);
        }

        protected override void OnStop()
        {
            List<ISD> currentDownloads = new List<ISD>();

            lock (this.monitor)
            {
                if (this.downloads != null && this.downloads.Count > 0)
                {
                    currentDownloads = new List<ISD>(this.downloads.Keys);
                }
            }

            foreach (var download in currentDownloads)
            {
                download.DetachAllHandlers();
                download.Stop();
            }

            lock (this.monitor)
            {
                this.state = SDState.Stopped;
            }
        }

        private SDCheckData PerformInitialDownloadCheck()
        {
            var downloadCheck = this.downloadChecker.CheckDownload(this.url, this.requestBuilder);

            if (!downloadCheck.Success)
            {
                this.OnDownloadError(new SDCancelledEventArgs(this, downloadCheck.Exception));
                Stop();
                return new SDCheckData();

            }

            if (!downloadCheck.SupportsResume)
            {
                this.OnDownloadError(new SDCancelledEventArgs(this, downloadCheck.Exception));
                Stop();
                return new SDCheckData();

            }

            this.OnDownloadStarted(new SDStartedEventArgs(this, downloadCheck, this.AlreadyDownloadedRanges.Sum(x => x.Length)));

            return downloadCheck;
        }

        private void DetermineFileSizeAndStartDownloads(SDCheckData downloadCheck)
        {
            lock (this.monitor)
            {
                this.ToDoRanges = this.DetermineToDoRanges(downloadCheck.Size, this.AlreadyDownloadedRanges);
                this.SplitToDoRangesForNumberOfParts();

                for (int i = 0; i < this.numberOfParts; i++)
                {
                    var todoRange = this.ToDoRanges[i];
                    StartDownload(todoRange);
                }
            }
        }

        private void SplitToDoRangesForNumberOfParts()
        {
            while (this.ToDoRanges.Count < this.numberOfParts)
            {
                var maxRange = this.ToDoRanges.FirstOrDefault(r => r.Length == this.ToDoRanges.Max(r2 => r2.Length));
                this.ToDoRanges.Remove(maxRange);
                var range1Start = maxRange.Start;
                var range1Length = maxRange.Length / 2;
                var range2Start = range1Start + range1Length;
                var range2Length = maxRange.End - range2Start + 1;
                this.ToDoRanges.Add(new SDDC(range1Start, range1Length));
                this.ToDoRanges.Add(new SDDC(range2Start, range2Length));
            }
        }

        private void StartDownload(SDDC range)
        {
            var download = this.downloadBuilder.Build(this.url, this.bufferSize, range.Start, range.Length);
            download.DataReceived += downloadDataReceived;
            download.DownloadCancelled += downloadCancelled;
            download.DownloadCompleted += downloadCompleted;
            download.Start();

            lock (this.monitor)
            {
                this.downloads.Add(download, range);
            }
        }

        private List<SDDC> DetermineToDoRanges(long fileSize, List<SDDC> alreadyDoneRanges)
        {
            var result = new List<SDDC>();

            var initialRange = new SDDC(0, fileSize);
            result.Add(initialRange);

            if (alreadyDoneRanges != null && alreadyDoneRanges.Count > 0)
            {
                foreach (var range in alreadyDoneRanges)
                {
                    var newResult = new List<SDDC>(result);

                    foreach (var resultRange in result)
                    {
                        if (this.SDDataContainerHelper.RangesCollide(range, resultRange))
                        {
                            newResult.Remove(resultRange);
                            var difference = this.SDDataContainerHelper.RangeDifference(resultRange, range);
                            newResult.AddRange(difference);
                        }
                    }

                    result = newResult;
                }
            }

            return result;
        }

        private void StartDownloadOfNextRange()
        {
            SDDC nextRange = null;

            lock (this.monitor)
            {
                nextRange = this.ToDoRanges.FirstOrDefault(r => !this.downloads.Values.Any(r2 => SDDataContainerHelper.RangesCollide(r, r2)));
            }

            if (nextRange != null)
            {
                StartDownload(nextRange);
            }

            if (!this.downloads.Any())
            {
                lock (this.monitor)
                {
                    this.state = SDState.Finished;
                }

                this.OnDownloadCompleted(new SDEventArgs(this));
            }
        }

        private void downloadDataReceived(SDDataReceivedEventArgs args)
        {
            var offset = args.Offset;
            var count = args.Count;
            var data = args.Data;

            lock (this.monitor)
            {
                var justDownloadedRange = new SDDC(offset, count);

                var todoRange = this.ToDoRanges.Single(r => SDDataContainerHelper.RangesCollide(r, justDownloadedRange));
                this.ToDoRanges.Remove(todoRange);
                var differences = SDDataContainerHelper.RangeDifference(todoRange, justDownloadedRange);
                this.ToDoRanges.AddRange(differences);

                var alreadyDoneRange = this.AlreadyDownloadedRanges.FirstOrDefault(r => r.End + 1 == justDownloadedRange.Start);

                if (alreadyDoneRange == null)
                {
                    alreadyDoneRange = justDownloadedRange;
                    this.AlreadyDownloadedRanges.Add(alreadyDoneRange);
                }
                else
                {
                    alreadyDoneRange.Length += justDownloadedRange.Length;
                }

                var neighborRange = this.AlreadyDownloadedRanges.FirstOrDefault(r => r.Start == alreadyDoneRange.End + 1);

                if (neighborRange != null)
                {
                    this.AlreadyDownloadedRanges.Remove(alreadyDoneRange);
                    this.AlreadyDownloadedRanges.Remove(neighborRange);
                    var combinedRange = new SDDC(alreadyDoneRange.Start, alreadyDoneRange.Length + neighborRange.Length);
                    this.AlreadyDownloadedRanges.Add(combinedRange);
                }
            }

            this.OnDataReceived(new SDDataReceivedEventArgs(this, data, offset, count));
        }

        private void downloadCompleted(SDEventArgs args)
        {
            lock (this.monitor)
            {
                var resumingDownload = (ResumingDownload)args.Download;
                this.downloads.Remove(resumingDownload);
            }

            this.StartDownloadOfNextRange();
        }

        private void downloadCancelled(SDCancelledEventArgs args)
        {
            this.StartDownloadOfNextRange();
        }
    }
}