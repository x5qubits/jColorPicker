using System;
using JCommon.SD.Core.Interfaces;
using JCommon.SD.Core.Download;

namespace JCommon.SD.Core.Builders
{
    public class SDResumine: ISDBuilder
    {
        readonly int timeForHeartbeat;

        readonly int timeToRetry;

        readonly int? maxRetries;

        readonly ISDBuilder downloadBuilder;

        public SDResumine(int timeForHeartbeat, int timeToRetry, int? maxRetries, ISDBuilder downloadBuilder)
        {
            if (timeForHeartbeat <= 0)
                throw new ArgumentException("Keep Alive time must be bigger then 0!");

            if (timeToRetry <= 0)
                throw new ArgumentException("Retry time must be bigger then 0!");

            this.timeForHeartbeat = timeForHeartbeat;
            this.timeToRetry = timeToRetry;
            this.maxRetries = maxRetries;
            this.downloadBuilder = downloadBuilder ?? throw new ArgumentNullException("Download buider can't be null!");
        }

        public ISD Build(Uri url, int bufferSize, long? offset, long? maxReadBytes)
        {
            return new ResumingDownload(url, bufferSize, offset, maxReadBytes, this.timeForHeartbeat, this.timeToRetry, this.maxRetries, this.downloadBuilder);
        }
    }
}