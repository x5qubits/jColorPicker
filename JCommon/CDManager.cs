using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace JCommon
{
    /// <summary>
    /// Restrict the call to a function in milliseconds, using this class. This class is useful when you want to prevent a button.
    /// </summary>
    public class CDManager
    {
        /// <summary>
        /// Default cooldown
        /// </summary>
        public static float DefaultCd = 0.2f;
        private static object s_Sync = new object();
        static volatile CDManager s_Instance;
        public static CDManager Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_Sync)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new CDManager();
                        }
                    }
                }
                return s_Instance;
            }
        }

        Dictionary<string, float> AllCds = new Dictionary<string, float>();

        static string GetKey(params string[] data)
        {
            return Extensions.ExtendedString.Join("_", data);
        }

        /// <summary>
        /// Uses [CallerMemberName] and [CallerFilePath] attributes to generate a Key that is used to restrict the call to a function. DefaultCD field is used.
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsCoolingDown([CallerMemberName] string caller = "", [CallerFilePath] string path = "")
        {
            return Instance.IsCoolDown(DefaultCd, GetKey(caller, path));
        }

        /// <summary>
        /// Define your own key to restrict the call to your function. DefaultCD field is used.
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static bool IsCoolingDown(string Key)
        {
            return Instance.IsCoolDown(DefaultCd, Key);
        }

        public static bool IsCoolingDown(float CoolDownSeconds, string Key)
        {
            return Instance.IsCoolDown(CoolDownSeconds, Key);
        }

        public static bool IsCoolingDown(float CoolDownSeconds, [CallerMemberName] string caller = "", [CallerFilePath] string path = "")
        {
            return Instance.IsCoolDown(CoolDownSeconds, GetKey(caller, path));
        }

        /// <summary>
        /// Releases the previews lock on key
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static bool RemoveCoolDown(string Key)
        {
           return  Instance.Remove(Key);
        }

        bool Remove(string callerName)
        {
            bool ret = false;
            lock (AllCds)
            {
                if (AllCds.TryGetValue(callerName, out float value))
                {
                    ret = true;
                    AllCds[callerName] = 0;
                }
                else
                {
                    ret = true;
                    AllCds[callerName] = 0;
                }
            }
            return ret;
        }

        bool IsCoolDown(float CoolDownSeconds, string callerName)
        {        
            bool ret = false;
            lock (AllCds)
            {
                if (AllCds.TryGetValue(callerName, out float value))
                {
                    if (Time.time > value)
                    {
                        ret = false;
                        AllCds[callerName] = Time.time + CoolDownSeconds;
                    }
                    else
                    {
                        ret = true;
                    }
                }
                else
                {
                    ret = false;
                    AllCds[callerName] = Time.time + CoolDownSeconds;
                }
            }
            return ret;
        }
    }
}
