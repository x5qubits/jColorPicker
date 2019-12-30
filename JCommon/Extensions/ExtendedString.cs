using System;
using System.Collections.Generic;
using System.Text;

namespace JCommon.Extensions
{
    public static class ExtendedString
    {
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static string Join<T>(this string s, IEnumerable<T> collection)
        {
            var iter = collection.GetEnumerator();
            if (!iter.MoveNext())
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(iter.Current);
            while (iter.MoveNext())
            {
                sb.Append(s);
                sb.Append(iter.Current);
            }

            return sb.ToString();
        }

        public static string Join<T>(this string s, IEnumerable<T> collection, Func<T, string> func)
        {
            var iter = collection.GetEnumerator();
            if (!iter.MoveNext())
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(func(iter.Current));
            while (iter.MoveNext())
            {
                sb.Append(s);
                sb.Append(func(iter.Current));
            }

            return sb.ToString();
        }

        public static string JoinParams(this string s, params string[] args)
        {
            return s.Join<string>(args);
        }

        public static IEnumerable<int> IndexOfAll(this string s, char c)
        {
            if (s.IsNullOrEmpty())
                yield break;

            int index = 0;
            foreach (char tt in s)
            {
                if (tt == c)
                    yield return index;
                ++index;
            }
        }

        public static bool IsNumber(this string s)
        {
            if (s.Length == 0)
                return false;
            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] < '0' || s[i] > '9') && (s[i] != '.' || (i == s.Length - 1) || s.IndexOf('.', i + 1) != -1) && (s[i] != '-' || i != 0))
                    return false;
            }
            return true;
        }

    }
}
