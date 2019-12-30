using JCommon.SD.Core.Data;
using JCommon.SD.Core.Interfaces;
using System;

namespace JCommon.SD.Core.Events
{
    public class SDCancelledEventArgs : SDEventArgs
    {
        public SDCancelledEventArgs()
        {
        }

        public SDCancelledEventArgs(ISD download, Exception exception)
        {
            this.Download = download;
            this.Exception = exception;
        }

        public Exception Exception { get; set; }
    }
}
