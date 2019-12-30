using JCommon.SD.Core.Data;
using JCommon.SD.Core.Interfaces;

namespace JCommon.SD.Core.Events
{
    public class SDStartedEventArgs : SDEventArgs
    {
        public SDStartedEventArgs()
        {
        }

        public SDStartedEventArgs(ISD download, SDCheckData checkResult, long alreadyDownloadedSize = 0)
        {
            this.Download = download;
            this.CheckResult = checkResult;
            this.AlreadyDownloadedSize = alreadyDownloadedSize;
        }

        public SDCheckData CheckResult { get; set; }

        public long AlreadyDownloadedSize { get; set; }
    }
}
