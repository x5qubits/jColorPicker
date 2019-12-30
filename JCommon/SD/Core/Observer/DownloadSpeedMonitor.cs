﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCommon.SD.Core.Interfaces;
using JCommon.SD.Core.Events;

namespace JCommon.SD.Core.Observer
{
    public class DownloadSpeedMonitor : SDAbstractObserver
    {
        private readonly int maxSampleCount;

        private readonly List<DownloadDataSample> samples = new List<DownloadDataSample>();

        public DownloadSpeedMonitor(int maxSampleCount)
        {
            if (maxSampleCount < 2)
                throw new ArgumentException("maxSampleCount < 2");

            this.maxSampleCount = maxSampleCount;
        }

        public int GetCurrentBytesPerSecond()
        {
            lock (this.monitor)
            {
                if (this.samples.Count < 2)
                {
                    return 0;
                }

                var sumOfBytesFromCalls = this.samples.Sum(s => s.Count);
                var ticksBetweenCalls = (DateTime.UtcNow - this.samples[0].Timestamp).Ticks;

                return (int)((double)sumOfBytesFromCalls / ticksBetweenCalls * 10000 * 1000);
            }
        }

        protected override void OnAttach(ISD download)
        {
            download.DataReceived += downloadDataReceived;
        }

        protected override void OnDetach(ISD download)
        {
            download.DataReceived -= downloadDataReceived;
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

        private void downloadDataReceived(SDDataReceivedEventArgs args)
        {
            AddSample(args.Count);
        }
    }
}