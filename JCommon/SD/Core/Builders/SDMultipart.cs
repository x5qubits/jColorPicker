using System;
using System.Collections.Generic;
using JCommon.SD.Core.Interfaces;
using JCommon.SD.Core.Download;
using JCommon.SD.Core.Data;

namespace JCommon.SD.Core.Builders
{
    internal class SDMultipart : ISDBuilder
    {
        int numberOfParts;
        ISDBuilder downloadBuilder;
        ISDRequestBuilder requestBuilder;
        ISDChecker downloadChecker;
        List<SDDC> alreadyDownloadedRanges;

        public SDMultipart(int numberOfParts, ISDBuilder downloadBuilder, ISDRequestBuilder requestBuilder, ISDChecker downloadChecker, List<SDDC> alreadyDownloadedRanges)
        {
            if (numberOfParts <= 0)
                throw new ArgumentException("numberOfParts <= 0");

            this.numberOfParts = numberOfParts;
            this.downloadBuilder = downloadBuilder ?? throw new ArgumentNullException("Download builder cannot be null!");

            this.requestBuilder = requestBuilder ?? throw new ArgumentNullException("Request builder cannot be null!");

            this.downloadChecker = downloadChecker ?? throw new ArgumentNullException("Request checker cannot be null!");

            this.alreadyDownloadedRanges = alreadyDownloadedRanges ?? new List<SDDC>();
        }

        public ISD Build(Uri url, int bufferSize, long? offset, long? maxReadBytes)
        {
            return new MultiPartDownload(url, bufferSize, this.numberOfParts, this.downloadBuilder, this.requestBuilder, this.downloadChecker, this.alreadyDownloadedRanges);
        }
    }
}