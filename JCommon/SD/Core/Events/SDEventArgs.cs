using JCommon.SD.Core.Interfaces;

namespace JCommon.SD.Core.Events
{
    public class SDEventArgs
    {
        public ISD Download { get; set; }

        public SDEventArgs()
        {
        }

        public SDEventArgs(ISD download)
        {
            this.Download = download;
        }
    }
}
