namespace JCommon.SD.Core.Interfaces
{
    public interface ISDObserver
    {
        void Attach(ISD download);

        void Detach(ISD download);

        void DetachAll();
    }
}