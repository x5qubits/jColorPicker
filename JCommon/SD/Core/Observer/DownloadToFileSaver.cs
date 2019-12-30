using System;
using System.IO;
using JCommon.SD.Core.Interfaces;
using JCommon.SD.Core.Events;

namespace JCommon.SD.Core.Observer
{
    public class DownloadToFileSaver : SDAbstractObserver
    {
        private FileInfo file;

        private FileStream fileStream;

        private string TPath;
        private string FPath;

        public DownloadToFileSaver(string filename, string finishfilename)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentException("filename");

            if (!Directory.Exists(filename))
                Directory.CreateDirectory(Path.GetDirectoryName(filename));

            if (string.IsNullOrEmpty(finishfilename))
                throw new ArgumentException("finishfilename");

            if (!Directory.Exists(finishfilename))
                Directory.CreateDirectory(Path.GetDirectoryName(finishfilename));

            TPath = filename;
            FPath = finishfilename;

            this.file = new FileInfo(filename);
        }

        public DownloadToFileSaver(FileInfo file)
        {
            if (file == null)
                throw new ArgumentNullException("file");

            this.file = file;
        }

        protected override void OnAttach(ISD download)
        {
            download.DownloadStarted += downloadStarted;
            download.DownloadCancelled += downloadCancelled;
            download.DownloadCompleted += downloadCompleted;
            download.DownloadStopped += downloadStopped;
            download.DataReceived += downloadDataReceived;
        }

        protected override void OnDetach(ISD download)
        {
            download.DownloadStarted -= downloadStarted;
            download.DownloadCancelled -= downloadCancelled;
            download.DownloadCompleted -= downloadCompleted;
            download.DownloadStopped -= downloadStopped;
            download.DataReceived -= downloadDataReceived;
        }

        private void OpenFileIfNecessary()
        {
            lock (this.monitor)
            {
                if (this.fileStream == null)
                {
                    this.fileStream = this.file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                }
            }
        }

        private void WriteToFile(byte[] data, long offset, int count)
        {
            lock (this.monitor)
            {
                this.OpenFileIfNecessary();

                this.fileStream.Position = offset;
                this.fileStream.Write(data, 0, count);
            }
        }

        public void CloseFile()
        {
            lock (this.monitor)
            {
                if (this.fileStream != null)
                {
                    this.fileStream.Flush();
                    this.fileStream.Close();
                    this.fileStream.Dispose();
                    this.fileStream = null;
                }
            }
        }

        private void downloadDataReceived(SDDataReceivedEventArgs args)
        {
            lock (this.monitor)
            {
                this.WriteToFile(args.Data, args.Offset, args.Count);
            }
        }

        private void downloadStarted(SDStartedEventArgs args)
        {
            lock (this.monitor)
            {
                this.OpenFileIfNecessary();
            }
        }

        private void downloadCompleted(SDEventArgs args)
        {
            lock (this.monitor)
            {
                this.CloseFile();
                if (File.Exists(TPath))
                {
                    if (File.Exists(FPath))
                        File.Delete(FPath);

                    File.Move(TPath, FPath);
                }
                    
            }
        }

        private void downloadStopped(SDEventArgs args)
        {
            lock (this.monitor)
            {
                this.CloseFile();
            }
        }

        private void downloadCancelled(SDCancelledEventArgs args)
        {
            lock (this.monitor)
            {
                this.CloseFile();
            }
        }

        public override void Dispose()
        {
            lock (this.monitor)
            {
                this.CloseFile();
            }

            base.Dispose();
        }
    }
}
