using System;
using JCommon.SD.Core.Enums;
using JCommon.SD.Core.Events;

namespace JCommon.SD.Core.Interfaces
{
    public interface ISD : IDisposable
    {
        event SDDelegates.OnSDDataReceived DataReceived;

        event SDDelegates.OnSDStarted DownloadStarted;

        event SDDelegates.OnSDCompleted DownloadCompleted;

        event SDDelegates.OnSDStopped DownloadStopped;

        event SDDelegates.OnSDCancelled DownloadCancelled;

        SDState State { get; }

        void Start();

        void Stop();

        void DetachAllHandlers();
    }
}