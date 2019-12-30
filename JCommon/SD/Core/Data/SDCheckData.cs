using System;

namespace JCommon.SD.Core.Data
{
    public class SDCheckData
    {
        public bool Success { get; set; }

        public long Size { get; set; }

        public int? StatusCode { get; set; }

        public bool SupportsResume { get; set; }

        public Exception Exception { get; set; }
    }
}