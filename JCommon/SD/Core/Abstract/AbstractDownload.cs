using System;
using System.Threading;
using JCommon.SD.Core.Enums;
using JCommon.SD.Core.Events;
using JCommon.SD.Core.Interfaces;

namespace JCommon.SD.Core.Download
{
    public abstract class AbstractDownload : ISD
    {
        public event SDDelegates.OnSDDataReceived DataReceived;

        public event SDDelegates.OnSDStarted DownloadStarted;

        public event SDDelegates.OnSDCompleted DownloadCompleted;

        public event SDDelegates.OnSDStopped DownloadStopped;

        public event SDDelegates.OnSDCancelled DownloadCancelled;

        public event SDDelegates.OnSDCancelled DownloadError;

        protected SDState state = SDState.Undefined;

        protected Uri url;

        protected int bufferSize;

        protected long? offset;

        protected long? maxReadBytes;

        protected ISDRequestBuilder requestBuilder;

        protected ISDChecker downloadChecker;

        protected bool stopping = false;

        protected readonly object monitor = new object();

        public AbstractDownload(Uri url, int bufferSize, long? offset, long? maxReadBytes, ISDRequestBuilder requestBuilder, ISDChecker downloadChecker)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            if (bufferSize < 0)
                throw new ArgumentException("bufferSize < 0");

            if (offset.HasValue && offset.Value < 0)
                throw new ArgumentException("offset < 0");

            if (maxReadBytes.HasValue && maxReadBytes.Value < 0)
                throw new ArgumentException("maxReadBytes < 0");

            this.url = url;
            this.bufferSize = bufferSize;
            this.offset = offset;
            this.maxReadBytes = maxReadBytes;
            this.requestBuilder = requestBuilder;
            this.downloadChecker = downloadChecker;

            this.state = SDState.Initialized;
        }

        public SDState State
        {
            get { return this.state; }
        }

        public virtual void Start()
        {
            lock (this.monitor)
            {
                if (this.state != SDState.Initialized)
                {
                    throw new InvalidOperationException("Invalid state: " + this.state);
                }

                this.state = SDState.Running;
            }

            this.OnStart();
        }

        public virtual void Stop()
        {
            this.DoStop(SDStopType.WithNotification);
        }

        protected virtual void DoStop(SDStopType stopType)
        {
            lock (this.monitor)
            {
                this.stopping = true;
            }

            this.OnStop();

            if (stopType == SDStopType.WithNotification)
            {
                this.OnDownloadStopped(new SDEventArgs(this));
            }
        }

        public virtual void Dispose()
        {
            this.Stop();
        }

        public virtual void DetachAllHandlers()
        {
            if (this.DataReceived != null)
            {
                foreach (var i in this.DataReceived.GetInvocationList())
                {
                    this.DataReceived -= (SDDelegates.OnSDDataReceived)i;
                }
            }

            if (this.DownloadCancelled != null)
            {
                foreach (var i in this.DownloadCancelled.GetInvocationList())
                {
                    this.DownloadCancelled -= (SDDelegates.OnSDCancelled)i;
                }
            }

            if (this.DownloadCompleted != null)
            {
                foreach (var i in this.DownloadCompleted.GetInvocationList())
                {
                    this.DownloadCompleted -= (SDDelegates.OnSDCompleted)i;
                }
            }

            if (this.DownloadStopped != null)
            {
                foreach (var i in this.DownloadStopped.GetInvocationList())
                {
                    this.DownloadStopped -= (SDDelegates.OnSDStopped)i;
                }
            }

            if (this.DownloadStarted != null)
            {
                foreach (var i in this.DownloadStarted.GetInvocationList())
                {
                    this.DownloadStarted -= (SDDelegates.OnSDStarted)i;
                }
            }

            if (this.DownloadError != null)
            {
                foreach (var i in this.DownloadError.GetInvocationList())
                {
                    this.DownloadError -= (SDDelegates.OnSDCancelled)i;
                }
            }
        }

        protected virtual void OnStart()
        {
            // Implementations should start their work here.
        }

        protected virtual void OnStop()
        {
            // This happens, when the Stop method is called.
            // Implementations should clean up and free their ressources here.
            // The stop event must not be triggered in here, it is triggered in the context of the Stop method.
        }

        protected virtual void StartThread(SDDelegates.VoidAction func, string name)
        {
            var thread = new Thread(new ThreadStart(func)) { Name = name };
            thread.Start();
        }

        protected virtual void OnDataReceived(SDDataReceivedEventArgs args)
        {
            if (this.DataReceived != null)
            {
                this.DataReceived(args);
            }
        }

        protected virtual void OnDownloadStarted(SDStartedEventArgs args)
        {
            if (this.DownloadStarted != null)
            {
                this.DownloadStarted(args);
            }
        }

        protected virtual void OnDownloadCompleted(SDEventArgs args)
        {
            if (this.DownloadCompleted != null)
            {
                this.DownloadCompleted(args);
            }
        }

        protected virtual void OnDownloadStopped(SDEventArgs args)
        {
            if (this.DownloadStopped != null)
            {
                this.DownloadStopped(args);
            }
        }

        protected virtual void OnDownloadCancelled(SDCancelledEventArgs args)
        {
            if (this.DownloadCancelled != null)
            {
                this.DownloadCancelled(args);
            }
        }

        protected virtual void OnDownloadError(SDCancelledEventArgs args)
        {
            if (this.DownloadError != null)
            {
                this.DownloadError(args);
            }
        }
    }
}