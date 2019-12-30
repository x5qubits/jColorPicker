using System;
using System.Threading;
using JCommon.SD.Core.Data;
using JCommon.SD.Core.Enums;
using JCommon.SD.Core.Events;
using JCommon.SD.Core.Exceptions;
using JCommon.SD.Core.Interfaces;

namespace JCommon.SD.Core.Download
{
    public class ResumingDownload : AbstractDownload
    {
        private readonly int timeForHeartbeat;

        private readonly int timeToRetry;

        private readonly int? maxRetries;

        private readonly ISDBuilder downloadBuilder;

        private bool downloadStartedNotified;

        private long currentOffset;

        private long sumOfBytesRead;

        private ISD currentDownload;

        private DateTime lastHeartbeat;

        private int currentRetry = 0;

        public ResumingDownload(Uri url, int bufferSize, long? offset, long? maxReadBytes, int timeForHeartbeat, int timeToRetry, int? maxRetries, ISDBuilder downloadBuilder)
            : base(url, bufferSize, offset, maxReadBytes, null, null)
        {
            if (timeForHeartbeat <= 0)
                throw new ArgumentException("timeForHeartbeat <= 0");

            if (timeToRetry <= 0)
                throw new ArgumentException("timeToRetry <= 0");

            if (downloadBuilder == null)
                throw new ArgumentException("downloadBuilder");

            this.timeForHeartbeat = timeForHeartbeat;
            this.timeToRetry = timeToRetry;
            this.maxRetries = maxRetries;
            this.downloadBuilder = downloadBuilder;
        }

        protected override void OnStart()
        {
            StartThread(this.StartDownload, string.Format("ResumingDownload offset {0} length {1} Main", this.offset, this.maxReadBytes));
            StartThread(this.CheckHeartbeat, string.Format("ResumingDownload offset {0} length {1} Heartbeat", this.offset, this.maxReadBytes));
        }

        protected override void OnStop()
        {
            lock (this.monitor)
            {
                this.stopping = true;
                this.DoStopIfNecessary();
            }
        }

        private void StartDownload()
        {
            lock (this.monitor)
            {
                StartNewDownload();
            }
        }

        private void StartNewDownload()
        {
            this.currentOffset = this.offset.HasValue ? this.offset.Value : 0;
            BuildDownload();
        }

        private void CheckHeartbeat()
        {
            while (true)
            {
                Thread.Sleep(this.timeForHeartbeat);

                lock (this.monitor)
                {
                    if (this.DoStopIfNecessary())
                    {
                        return;
                    }

                    if (DateTime.Now - this.lastHeartbeat > TimeSpan.FromMilliseconds(this.timeForHeartbeat))
                    {
                        CountRetryAndCancelIfMaxRetriesReached();

                        if (this.currentDownload != null)
                        {
                            this.CloseDownload();
                            StartThread(this.BuildDownload, Thread.CurrentThread.Name + "-byHeartbeat");
                        }
                    }
                }
            }
        }

        private void CountRetryAndCancelIfMaxRetriesReached()
        {
            if (this.maxRetries.HasValue && this.currentRetry >= this.maxRetries)
            {
                this.state = SDState.Cancelled;
                this.OnDownloadCancelled(new SDCancelledEventArgs(this, new TooManyRetriesException()));
                this.DoStop(SDStopType.WithoutNotification);
            }

            this.currentRetry++;
        }

        private void BuildDownload()
        {
            lock (this.monitor)
            {
                if (this.DoStopIfNecessary())
                {
                    return;
                }

                long? currentMaxReadBytes = this.maxReadBytes.HasValue ? (long?)this.maxReadBytes.Value - this.sumOfBytesRead : null;

                this.currentDownload = this.downloadBuilder.Build(this.url, this.bufferSize, this.currentOffset, currentMaxReadBytes);
                this.currentDownload.DownloadStarted += downloadStarted;
                this.currentDownload.DownloadCancelled += downloadCancelled;
                this.currentDownload.DownloadCompleted += downloadCompleted;
                this.currentDownload.DataReceived += downloadDataReceived;
                StartThread(this.currentDownload.Start, Thread.CurrentThread.Name + "-buildDownload");
            }
        }

        private bool DoStopIfNecessary()
        {
            if (this.stopping)
            {
                this.CloseDownload();

                lock (this.monitor)
                {
                    this.state = SDState.Stopped;
                }
            }

            return this.stopping;
        }

        private void SleepThenBuildDownload()
        {
            Thread.Sleep(this.timeToRetry);
            BuildDownload();
        }

        private void CloseDownload()
        {
            if (this.currentDownload != null)
            {
                this.currentDownload.DetachAllHandlers();
                this.currentDownload.Stop();
                this.currentDownload = null;
            }
        }

        private void downloadDataReceived(SDDataReceivedEventArgs args)
        {
            var download = args.Download;
            var count = args.Count;
            var data = args.Data;
            long previousOffset = 0;

            lock (this.monitor)
            {
                if (this.currentDownload == download)
                {
                    if (this.DoStopIfNecessary())
                    {
                        return;
                    }

                    previousOffset = this.currentOffset;

                    this.lastHeartbeat = DateTime.Now;
                    this.currentOffset += count;
                    this.sumOfBytesRead += count;
                }
            }

            this.OnDataReceived(new SDDataReceivedEventArgs(this, data, previousOffset, count));
        }

        private void downloadStarted(SDStartedEventArgs args)
        {
            var download = args.Download;
            bool shouldNotifyDownloadStarted = false;

            lock (this.monitor)
            {
                if (download == this.currentDownload)
                {
                    if (!this.downloadStartedNotified)
                    {
                        shouldNotifyDownloadStarted = true;
                        this.downloadStartedNotified = true;
                    }
                }
            }

            if (shouldNotifyDownloadStarted)
            {
                this.OnDownloadStarted(new SDStartedEventArgs(this, args.CheckResult, args.AlreadyDownloadedSize));
            }
        }

        private void downloadCompleted(SDEventArgs args)
        {
            lock (this.monitor)
            {
                this.CloseDownload();
                this.state = SDState.Finished;
                this.stopping = true;
            }

            this.OnDownloadCompleted(new SDEventArgs(this));
        }

        private void downloadCancelled(SDCancelledEventArgs args)
        {
            var download = args.Download;

            lock (this.monitor)
            {
                if (download == this.currentDownload)
                {
                    CountRetryAndCancelIfMaxRetriesReached();

                    if (this.currentDownload != null)
                    {
                        this.currentDownload = null;
                        StartThread(this.SleepThenBuildDownload, Thread.CurrentThread.Name + "-afterCancel");
                    }
                }
            }
        }
    }
}