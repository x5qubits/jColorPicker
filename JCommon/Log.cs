using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace JCommon
{
    public class Log
    {
        static object s_Sync = new object();

        static volatile Log s_Instance;
        public static Log Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_Sync)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new Log();
                        }
                    }
                }
                return s_Instance;
            }
        }

        public static void Info(object msg = null, [CallerLineNumberAttribute] int lineNo = 0, [CallerMemberName] string caller = "", [CallerFilePath] string path = "")
        {
            if (msg != null)
                Instance.MLog("INFO", lineNo, caller, path, msg.ToString());
            else
                Instance.MLog("INFO", lineNo, caller, path, "NULL");
        }

        public static void Error(object msg = null, [CallerLineNumberAttribute] int lineNo = 0, [CallerMemberName] string caller = "", [CallerFilePath] string path = "")
        {
            if (msg != null)
                Instance.MLog("ERROR", lineNo, caller, path, msg.ToString());
            else
                Instance.MLog("ERROR", lineNo, caller, path, "NULL");
        }
        public static void Warning(object msg = null, [CallerLineNumberAttribute] int lineNo = 0, [CallerMemberName] string caller = "", [CallerFilePath] string path = "")
        {
            if (msg != null)
                Instance.MLog("WARNING", lineNo, caller, path, msg.ToString());
            else
                Instance.MLog("WARNING", lineNo, caller, path, "NULL");
        }

        public static void Debug(object msg = null, [CallerLineNumberAttribute] int lineNo = 0, [CallerMemberName] string caller = "", [CallerFilePath] string path = "")
        {
            if (msg != null)
                Instance.MLog("DEBUG", lineNo, caller, path, msg.ToString());
            else
                Instance.MLog("DEBUG", lineNo, caller, path, "NULL");
        }
        public static void Initialize(string path = null)
        {
            Instance.mInitialize(path);
        }

        protected bool Initiated = false;
        protected string CfgPath = "";
        protected Queue<string> writequeue = new Queue<string>();
        internal void mInitialize(string path = null)
        {
            if (path != null)
                CfgPath = path;
            else
                CfgPath = "JLog/Jlog.txt";

            CfgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CfgPath);
            string p = Path.GetDirectoryName(CfgPath);
            if (!Directory.Exists(p))
            {
                Directory.CreateDirectory(p);
            }
            Invoker.InvokeRepeating(Execute, 1f);
            Initiated = true;
        }

        internal void MLog(string type, int lineNo, string caller, string path, string msg)
        {
            if (!Initiated)
            {
                mInitialize();
                Error("Please call Initialize first - Starting with default path : " + CfgPath);
            }
            lock (writequeue)
            {
                string pathx = path;
                if(path.Contains("\\"))
                {
                    string[] sp = path.Split('\\');

                    pathx = sp[sp.Length-1];
                }
                writequeue.Enqueue(Time.UtcNowFormated + " - [" + type + "] - [" + Path.GetFileNameWithoutExtension(pathx) + "][" + lineNo + "][" + caller + "] - " + msg);
            }
        }

        internal void Execute()
        {
            if (!Initiated) return;

            lock (writequeue)
            {
                if (writequeue.Count > 0)
                {
                    File.AppendAllLines(CfgPath, writequeue);
                    writequeue.Clear();
                }
            }
        }
    }
}
