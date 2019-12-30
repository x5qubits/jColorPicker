using JCommon.SD.Core.Data;
using JCommon.SD.Core.Interfaces;

namespace JCommon.SD.Core.Events
{
    public class SDDataReceivedEventArgs : SDEventArgs
    {
        public SDDataReceivedEventArgs()
        {
        }

        public SDDataReceivedEventArgs(ISD download, byte[] data, long offset, int count)
        {
            this.Download = download;
            this.Data = data;
            this.Offset = offset;
            this.Count = count;
        }

        public byte[] Data { get; set; }

        public long Offset { get; set; }

        public int Count { get; set; }
    }
}
