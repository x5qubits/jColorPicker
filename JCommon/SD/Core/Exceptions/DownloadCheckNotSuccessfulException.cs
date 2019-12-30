using JCommon.SD.Core.Data;
using System;

namespace JCommon.SD.Core.Exceptions
{
    public class DownloadCheckNotSuccessfulException : Exception
    {
        public DownloadCheckNotSuccessfulException(string message, Exception ex, SDCheckData downloadCheckResult) : base(message, ex)
        {
            this.DownloadCheckResult = downloadCheckResult;
        }

        public SDCheckData DownloadCheckResult { get; private set; }
    }
}
