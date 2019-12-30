using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCommon.SD.Core.Interfaces;
using JCommon.SD.Core.Download;

namespace JCommon.SD.Core.Builders
{
    public class SimpleDownloadBuilder : ISDBuilder
    {
        private readonly ISDRequestBuilder requestBuilder;

        private readonly ISDChecker downloadChecker;

        public SimpleDownloadBuilder(ISDRequestBuilder requestBuilder, ISDChecker downloadChecker)
        {
            if (requestBuilder == null)
                throw new ArgumentNullException("requestBuilder");

            if (downloadChecker == null)
                throw new ArgumentNullException("downloadChecker");

            this.requestBuilder = requestBuilder;
            this.downloadChecker = downloadChecker;
        }

        public ISD Build(Uri url, int bufferSize, long? offset, long? maxReadBytes)
        {
            return new SimpleDownload(url, bufferSize, offset, maxReadBytes, this.requestBuilder, this.downloadChecker);
        }
    }
}