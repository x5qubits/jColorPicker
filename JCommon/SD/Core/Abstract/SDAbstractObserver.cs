using System;
using System.Collections.Generic;
using JCommon.SD.Core.Interfaces;

namespace JCommon.SD.Core.Observer
{
    public abstract class SDAbstractObserver : ISDObserver, IDisposable
    {
        protected List<ISD> attachedDownloads = new List<ISD>();

        protected object monitor = new object();

        public void Attach(ISD download)
        {
            if (download == null)
                throw new ArgumentNullException("download");

            lock (this.monitor)
            {
                this.attachedDownloads.Add(download);
            }

            this.OnAttach(download);
        }

        public void Detach(ISD download)
        {
            lock (this.monitor)
            {
                this.attachedDownloads.Remove(download);
            }

            this.OnDetach(download);
        }

        public void DetachAll()
        {
            List<ISD> downloadsCopy;

            lock (this.monitor)
            {
                downloadsCopy = new List<ISD>(this.attachedDownloads);
            }

            foreach (var download in downloadsCopy)
            {
                this.Detach(download);
            }
        }

        public virtual void Dispose()
        {
            this.DetachAll();
        }

        protected virtual void OnAttach(ISD download)
        {
        }

        protected virtual void OnDetach(ISD download)
        {
        }
    }
}