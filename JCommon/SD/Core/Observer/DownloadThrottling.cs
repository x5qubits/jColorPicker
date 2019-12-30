using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using JCommon.SD.Core.Interfaces;
using JCommon.SD.Core.Events;

namespace JCommon.SD.Core.Observer
{
    public class DownloadThrottling : ISDObserver, IDisposable
    {
        private readonly int maxBytesPerSecond;

        private readonly List<ISD> downloads = new List<ISD>();

        private readonly int maxSampleCount;

        private List<DownloadDataSample> samples;

        private double floatingWaitingTimeInMilliseconds = 0;

        private object monitor = new object();

        public DownloadThrottling(int maxBytesPerSecond, int maxSampleCount)
        {
            if (maxBytesPerSecond <= 0)
                throw new ArgumentException("maxBytesPerSecond <= 0");

            if (maxSampleCount < 2)
                throw new ArgumentException("sampleCount < 2");

            this.maxBytesPerSecond = maxBytesPerSecond;
            this.maxSampleCount = maxSampleCount;
            this.samples = new List<DownloadDataSample>();
        }

        public void Attach(ISD download)
        {
            if (download == null)
                throw new ArgumentNullException("download");

            download.DataReceived += this.downloadDataReceived;

            lock (this.monitor)
            {
                this.downloads.Add(download);
            }
        }

        public void Detach(ISD download)
        {
            if (download == null)
                throw new ArgumentNullException("download");

            download.DataReceived -= this.downloadDataReceived;

            lock (this.monitor)
            {
                this.downloads.Remove(download);
            }
        }

        public void DetachAll()
        {
            lock (this.monitor)
            {
                foreach (var download in this.downloads)
                {
                    this.Detach(download);
                }
            }
        }

        public void Dispose()
        {
            this.DetachAll();
        }

        private void AddSample(int count)
        {
            lock (this.monitor)
            {
                var sample = new DownloadDataSample()
                {
                    Count = count,
                    Timestamp = DateTime.UtcNow
                };

                this.samples.Add(sample);

                if (this.samples.Count > this.maxSampleCount)
                {
                    this.samples.RemoveAt(0);
                }
            }
        }

        private int CalculateWaitingTime()
        {
            lock (this.monitor)
            {
                if (this.samples.Count < 2)
                {
                    return 0;
                }

                var averageBytesPerCall = this.samples.Average(s => s.Count);
                double sumOfTicksBetweenCalls = 0;

                // 1 tick = 100 nano seconds, 1 ms ^= 10.000 ticks
                for (var i = 0; i < this.samples.Count - 1; i++)
                {
                    sumOfTicksBetweenCalls += (this.samples[i + 1].Timestamp - this.samples[i].Timestamp).Ticks;
                }

                var averageTicksBetweenCalls = sumOfTicksBetweenCalls / (this.samples.Count - 1);
                var timePerNetworkRequestInMilliseconds = averageTicksBetweenCalls / 10000 - floatingWaitingTimeInMilliseconds;

                var currentBytesPerMillisecond = averageBytesPerCall / averageTicksBetweenCalls * 10000;
                var maxBytesPerMillisecond = (double)this.maxBytesPerSecond / 1000;

                var waitingTimeInMilliseconds = averageBytesPerCall / maxBytesPerMillisecond - timePerNetworkRequestInMilliseconds;
                this.floatingWaitingTimeInMilliseconds = waitingTimeInMilliseconds * 0.6 + this.floatingWaitingTimeInMilliseconds * 0.4;

                return (int)waitingTimeInMilliseconds;
            }
        }

        private void downloadDataReceived(SDDataReceivedEventArgs args)
        {
            this.AddSample(args.Count);
            var waitingTime = this.CalculateWaitingTime();

            if (waitingTime > 0)
            {
                Thread.Sleep(waitingTime);
            }
        }
    }
}