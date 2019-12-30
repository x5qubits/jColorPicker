using System;
using System.Collections.Generic;
using System.Text;

namespace JCommon.Extensions
{
    public static class ExtendedEnumerable
    {
#if NO_LINQ
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (null == collection)
            {
                return;
            }

            foreach (var item in collection)
            {
                action(item);
            }
        }

        public static IEnumerable<R> MapTo<T, R>(this IEnumerable<T> collection, Func<T, R> action)
        {
            if (null == collection)
            {
                yield break;
            }

            foreach (var item in collection)
            {
                yield return action(item);
            }
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Func<T, bool> action)
        {
            if (null == collection)
                yield break;

            foreach (var item in collection)
            {
                if (action(item))
                    yield return item;
            }
        }

        public static T[] ToArray<T>(this IEnumerable<T> collection)
        {
            if (null == collection)
                return null;

            return new List<T>(collection).ToArray();
        }

        public static T[] Sort<T>(this IEnumerable<T> collection, Comparison<T> action)
        {
            var array = collection.ToArray();
            Array.Sort(array, action);
            return array;
        }

        public static T[] OrderBy<T, R>(this IEnumerable<T> collection, Func<T, R> action) where R : IComparable<R>
        {
            var values = collection.ToArray();
            var keys = collection.MapTo(action).ToArray();
            Array.Sort(keys, values);
            return values;
        }

        public static T Max<T>(this IEnumerable<T> collection, Comparison<T> action)
        {
            T current = default(T);
            foreach (var item in collection)
            {
                if (action(current, item) < 0)
                    current = item;
            }
            return current;
        }

        public static T Max<T, R>(this IEnumerable<T> collection, Func<T, R> action) where R : IComparable<R>
        {
            var values = collection.ToArray();
            var keys = collection.MapTo(action).ToArray();
            Array.Sort(keys, values);
            return values[values.Length - 1];
        }

        public static T Min<T>(this IEnumerable<T> collection, Comparison<T> action)
        {
            T current = default(T);
            foreach (var item in collection)
            {
                if (action(item, current) < 0)
                    current = item;
            }
            return current;
        }

        public static T Min<T, R>(this IEnumerable<T> collection, Func<T, R> action) where R : IComparable<R>
        {
            var values = collection.ToArray();
            var keys = collection.MapTo(action).ToArray();
            Array.Sort(keys, values);
            return values[0];
        }

        public static int Count<T>(this IEnumerable<T> collection)
        {
            int len = 0;
            foreach (var item in collection)
                len++;
            return len;
        }

        public static int Count<T>(this IEnumerable<T> collection, Func<T, bool> action)
        {
            int len = 0;
            foreach (var item in collection)
            {
                if (action(item))
                    len++;
            }
            return len;
        }

        public static bool Any<T>(this IEnumerable<T> collection, Func<T, bool> action)
        {
            foreach (var item in collection)
            {
                if (action(item))
                    return true;
            }
            return false;
        }

        public static bool All<T>(this IEnumerable<T> collection, Func<T, bool> action)
        {
            foreach (var item in collection)
            {
                if (!action(item))
                    return false;
            }
            return true;
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> collection, T defaultValue = default(T))
        {
            T result = defaultValue;
            foreach (var item in collection)
            {
                result = item;
                break;
            }
            return result;
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> collection, Func<T, bool> predicate, T defaultValue = default(T))
        {
            T result = defaultValue;
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    result = item;
                    break;
                }
            }
            return result;
        }

        public static List<T> ToList<T>(this IEnumerable<T> collection)
        {
            List<T> res = new List<T>(collection);
            return res;
        }

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> collection)
        {
            HashSet<T> res = new HashSet<T>(collection);
            return res;
        }

        public static double Sum(this IEnumerable<double> collection)
        {
            double result = 0;
            foreach (var item in collection)
            {
                result += item;
            }
            return result;
        }

        public static double Sum(this IEnumerable<float> collection)
        {
            double result = 0;
            foreach (var item in collection)
            {
                result += item;
            }
            return result;
        }

        public static float Average(this IEnumerable<float> collection)
        {
            int len = 0;
            foreach (var item in collection)
                len++;
            if (len == 0)
                return 0;
            else
                return (float)(collection.Sum() / len);
        }

        public static long Sum(this IEnumerable<int> collection)
        {
            long result = 0;
            foreach (var item in collection)
            {
                result += item;
            }
            return result;
        }

        public static long Sum(this IEnumerable<long> collection)
        {
            long result = 0;
            foreach (var item in collection)
            {
                result += item;
            }
            return result;
        }

        public static long Sum(this IEnumerable<short> collection)
        {
            long result = 0;
            foreach (var item in collection)
            {
                result += item;
            }
            return result;
        }

        public static ulong Sum(this IEnumerable<ushort> collection)
        {
            ulong result = 0;
            foreach (var item in collection)
            {
                result += item;
            }
            return result;
        }

        public static ulong Sum(this IEnumerable<uint> collection)
        {
            ulong result = 0;
            foreach (var item in collection)
            {
                result += item;
            }
            return result;
        }

        public static ulong Sum(this IEnumerable<ulong> collection)
        {
            ulong result = 0;
            foreach (var item in collection)
            {
                result += item;
            }
            return result;
        }
#endif
    }
}
