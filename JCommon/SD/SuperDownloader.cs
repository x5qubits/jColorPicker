using JCommon.SD.Core.Builders;
using JCommon.SD.Core.Download;
using JCommon.SD.Core.Events;
using JCommon.SD.Core.Observer;
using JCommon.SD.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JCommon
{
    public class SuperDownloader
    {
        private static object s_Sync = new object();
        static volatile SuperDownloader s_Instance;
        public static SuperDownloader Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_Sync)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new SuperDownloader();
                        }
                    }
                }
                return s_Instance;
            }
        }

        private Uri dlUri;
        public static string TempDirectoryName = "SuperDownloads/Temp";
        public static string FinishedDirectoryName = "SuperDownloads";
        public static int timeForHeartbeat = 3000;
        public static int timeToRetry = 5000;
        public static int maxRetries = 9999;
        public static int bufferSize = 1024 * 8;
        public static int numberOfParts = 8;

        public static event SDDelegates.OnSDDataReceived OnProgress;

        public static event SDDelegates.OnSDDataReceived OnReceived;

        public static event SDDelegates.OnSDStarted OnStarted;

        public static event SDDelegates.OnSDCompleted OnCompleted;

        public static event SDDelegates.OnSDStopped OnStopped;

        public static event SDDelegates.OnSDCancelled OnCancelled;

        public static event SDDelegates.OnSDCancelled OnError;

        private SimpleWebRequestBuilder requestBuilder;
        private DownloadChecker dlChecker;
        private SimpleDownloadBuilder httpDlBuilder;

        private SDResumine rdlBuilder;

        private MultiPartDownload download;
        private DownloadProgressMonitor progressMonitor;
        private DownloadSpeedMonitor speedMonitor;
        private DownloadToFileSaver dlSaver;
        float lastSent = 0;
        float lastCalc = 0;

        List<int> AvrDownload = new List<int>();
        List<long> AvrTime = new List<long>();

        public static void Start(string DownloadUrl, string SavePath = null)
        {
            Instance.StartDownload(DownloadUrl, SavePath);
        }

        public static void Stop()
        {
            Instance.StopDownload();
        }

        public static long DownloadedSize => Instance.GetCurrentProgressInBytes();
        public static long TotalFileSize => Instance.GetTotalFilesizeInBytes();
        public static int DownloadSpeed = 0;
        public static int DownloadProgress => Instance.GetCurrentProgressPercentage();
        public static long RemainingTime = 0;

        #region Internal

        public void StartDownload(string DownloadUrl, string SavePath = null)
        {
            RemainingTime = DownloadSpeed = 0;
            AvrDownload = new List<int>() {0 };
            AvrTime = new List<long>(0) { 0 };
            dlUri = new Uri(DownloadUrl);
            TempDirectoryName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TempDirectoryName);
            FinishedDirectoryName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FinishedDirectoryName);
            requestBuilder = new SimpleWebRequestBuilder();
            dlChecker = new DownloadChecker();
            httpDlBuilder = new SimpleDownloadBuilder(requestBuilder, dlChecker);
            rdlBuilder = new SDResumine(timeForHeartbeat, timeToRetry, maxRetries, httpDlBuilder);
            download = new MultiPartDownload(dlUri, bufferSize, numberOfParts, rdlBuilder, requestBuilder, dlChecker, null);
            download.DownloadCompleted += DownloadCompleted;
            download.DataReceived += DataReceived;
            download.DownloadStopped += DataStopped;
            download.DownloadCancelled += DataCancelled;
            download.DownloadStarted += DataStarted;
            download.DownloadError += DataError;
            progressMonitor = new DownloadProgressMonitor();
            speedMonitor = new DownloadSpeedMonitor(128);
            speedMonitor.Attach(download);
            if(SavePath == null) {
                SavePath = Path.Combine(TempDirectoryName, Path.GetFileName(dlUri.ToString()));
            }
            dlSaver = new DownloadToFileSaver(SavePath, Path.Combine(FinishedDirectoryName, Path.GetFileName(dlUri.ToString())));
            dlSaver.Attach(download);
            progressMonitor.Attach(download);
            download.Start();
        }

        void StopDownload()
        {
            speedMonitor?.DetachAll();
            speedMonitor = null;
            dlSaver?.DetachAll();
            dlSaver = null;
            download?.Stop();
            download = null;
            requestBuilder = null;
            httpDlBuilder = null;
            rdlBuilder = null;
            dlChecker = null;
            httpDlBuilder = null;

            GC.Collect();
        }

        void DataStarted(SDStartedEventArgs args)
        {
            OnStarted?.Invoke(args);
        }

        void DataCancelled(SDCancelledEventArgs args)
        {
            OnCancelled?.Invoke(args);
        }

        void DataStopped(SDEventArgs args)
        {
            OnStopped?.Invoke(args);
        }

        void DownloadCompleted(SDEventArgs args)
        {
            OnCompleted?.Invoke(args);
        }

        private void DataError(SDCancelledEventArgs args)
        {
            OnError?.Invoke(args);
        }

        void DataReceived(SDDataReceivedEventArgs args)
        {
            OnReceived?.Invoke(args);
            if(lastSent < Time.time)
            {
               
                OnProgress?.Invoke(args);
                lastSent = Time.time + 0.1f;
                CalculateAvrage();
            }

        }

        long GetCurrentProgressInBytes()
        {
            if (progressMonitor != null)
            {
                return progressMonitor.GetCurrentProgressInBytes(download);

            }
            return 0;
        }

        long GetTotalFilesizeInBytes()
        {
            if (progressMonitor != null)
            {
                return progressMonitor.GetTotalFilesizeInBytes(download);

            }
            return 0;
        }
     
        void CalculateAvrage()
        {
            if(lastCalc > Time.time)
            {
                return;
            }
            lastCalc = Time.time + 0.5f;
            if (progressMonitor != null)
            {
                lock (AvrDownload)
                {
                    if (AvrDownload.Count > 128)
                    {
                        AvrDownload.Clear();
                    }
                    var s = speedMonitor.GetCurrentBytesPerSecond();
                    if (s > 0)
                        AvrDownload.Add(s);
                    DownloadSpeed = (int)AvrDownload.Average();
                }
            }
            if (progressMonitor != null)
            {
                lock (AvrDownload)
                {
                    long time = DownloadSpeed == 0 ? 0 : (GetTotalFilesizeInBytes() - GetCurrentProgressInBytes()) / DownloadSpeed;
                    if (AvrTime.Count > 128)
                    {
                        AvrTime.Clear();
                    }
                    AvrTime.Add(time);
                    RemainingTime = (long)AvrTime.Average();
                }
            }
        }

        int GetCurrentProgressPercentage()
        {
            if (progressMonitor != null)
            {
                float x = progressMonitor.GetCurrentProgressPercentage(download) * 100;
                return (int) x;

            }
            return 0;
        }

        #endregion
    }
}
