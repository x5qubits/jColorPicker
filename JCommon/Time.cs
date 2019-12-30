using System;
using System.Diagnostics;

namespace JCommon
{
    public class Time
    {
        private static readonly Stopwatch sw = Stopwatch.StartNew();

        public static long TimeStamp => (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

        public static float time => Convert.ToSingle(sw.Elapsed.TotalSeconds);

        public static string UtcNowFormated => DateTime.UtcNow.ToString("MM/dd/yyyy h:mm tt");
    }
}
