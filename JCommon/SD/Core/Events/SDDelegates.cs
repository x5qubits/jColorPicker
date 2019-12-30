using JCommon.SD.Core.Data;

namespace JCommon.SD.Core.Events
{
    public class SDDelegates
    {
        public delegate void OnSDDataReceived(SDDataReceivedEventArgs args);

        public delegate void OnSDStarted(SDStartedEventArgs args);

        public delegate void OnSDCompleted(SDEventArgs args);

        public delegate void OnSDStopped(SDEventArgs args);

        public delegate void OnSDCancelled(SDCancelledEventArgs args);

        public delegate void VoidAction();
    }
}