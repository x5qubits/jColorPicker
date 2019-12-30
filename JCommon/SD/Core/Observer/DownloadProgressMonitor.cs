using System.Collections.Generic;
using JCommon.SD.Core.Interfaces;
using JCommon.SD.Core.Events;

namespace JCommon.SD.Core.Observer
{
    public class DownloadProgressMonitor : SDAbstractObserver
    {
        private readonly Dictionary<ISD, long> downloadSizes = new Dictionary<ISD, long>();

        private readonly Dictionary<ISD, long> alreadyDownloadedSizes = new Dictionary<ISD, long>();

        public float GetCurrentProgressPercentage(ISD download)
        {
            lock (this.monitor)
            {
                if (!downloadSizes.ContainsKey(download) || !alreadyDownloadedSizes.ContainsKey(download) || downloadSizes[download] <= 0)
                {
                    return 0;
                }

                return (float)alreadyDownloadedSizes[download] / downloadSizes[download];
            }
        }

        public long GetCurrentProgressInBytes(ISD download)
        {
            if (download == null)
                return 0 ;
            lock (this.monitor)
            {
                if (!alreadyDownloadedSizes.ContainsKey(download))
                {
                    return 0;
                }

                return alreadyDownloadedSizes[download];
            }
        }

        public long GetTotalFilesizeInBytes(ISD download)
        {
            lock (this.monitor)
            {
                if (!downloadSizes.ContainsKey(download) || downloadSizes[download] <= 0)
                {
                    return 0;
                }

                return downloadSizes[download];
            }
        }

        protected override void OnAttach(ISD download)
        {
            download.DownloadStarted += OnDownloadStarted;
            download.DataReceived += OnDownloadDataReceived;
            download.DownloadCompleted += OnDownloadCompleted;
        }

        protected override void OnDetach(ISD download)
        {
            download.DownloadStarted -= OnDownloadStarted;
            download.DataReceived -= OnDownloadDataReceived;
            download.DownloadCompleted -= OnDownloadCompleted;

            lock (this.monitor)
            {
                if (this.downloadSizes.ContainsKey(download))
                {
                    this.downloadSizes.Remove(download);
                }

                if (this.alreadyDownloadedSizes.ContainsKey(download))
                {
                    this.alreadyDownloadedSizes.Remove(download);
                }
            }
        }

        private void OnDownloadStarted(SDStartedEventArgs args)
        {
            lock (this.monitor)
            {
                this.downloadSizes[args.Download] = args.CheckResult.Size;
                this.alreadyDownloadedSizes[args.Download] = args.AlreadyDownloadedSize;
            }
        }

        private void OnDownloadDataReceived(SDDataReceivedEventArgs args)
        {
            lock (this.monitor)
            {
                if (!alreadyDownloadedSizes.ContainsKey(args.Download))
                {
                    this.alreadyDownloadedSizes[args.Download] = 0;
                }

                this.alreadyDownloadedSizes[args.Download] += args.Count;
            }
        }

        private void OnDownloadCompleted(SDEventArgs args)
        {
            lock (this.monitor)
            {
                this.alreadyDownloadedSizes[args.Download] = this.downloadSizes[args.Download];
            }
        }
    }
}