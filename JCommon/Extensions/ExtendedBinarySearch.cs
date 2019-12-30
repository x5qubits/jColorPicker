using System;
using System.Collections.Generic;
using System.Text;

namespace JCommon.Extensions
{
    public static class ExtendedBinarySearch
    {
        public static int BinarySearch<T>(this IList<T> list, int key, Func<T, int> extract)
        {
            if (null == list)
            {
                throw new ArgumentNullException("list is null");
            }

            int count = list.Count;
            int i = -1;
            int j = count;
            while (i + 1 != j)
            {
                int mid = i + (j - i >> 1);
                if (extract(list[mid]) < key)
                {
                    i = mid;
                }
                else
                {
                    j = mid;
                }
            }

            if (j == count || extract(list[j]) != key)
            {
                j = ~j;
            }

            return j;
        }

        public static int BinarySearch<T>(this IList<T> list, float key, Func<T, float> extract)
        {
            if (null == list)
            {
                throw new ArgumentNullException("list is null");
            }

            int count = list.Count;
            int i = -1;
            int j = count;
            while (i + 1 != j)
            {
                int mid = i + (j - i >> 1);
                if (extract(list[mid]) < key)
                {
                    i = mid;
                }
                else
                {
                    j = mid;
                }
            }

            if (j == count || !_IsEqual(extract(list[j]), key))
            {
                j = ~j;
            }

            return j;
        }

        public static int BinarySearch<T>(this T[] list, int key, Func<T, int> extract)
        {
            if (null == list)
            {
                throw new ArgumentNullException("list is null");
            }

            int count = list.Length;
            int i = -1;
            int j = count;
            while (i + 1 != j)
            {
                int mid = i + (j - i >> 1);
                if (extract(list[mid]) < key)
                {
                    i = mid;
                }
                else
                {
                    j = mid;
                }
            }

            if (j == count || extract(list[j]) != key)
            {
                j = ~j;
            }

            return j;
        }

        public static int BinarySearch<T>(this T[] list, float key, Func<T, float> extract)
        {
            if (null == list)
            {
                throw new ArgumentNullException("list is null");
            }

            int count = list.Length;
            int i = -1;
            int j = count;
            while (i + 1 != j)
            {
                int mid = i + (j - i >> 1);
                if (extract(list[mid]) < key)
                {
                    i = mid;
                }
                else
                {
                    j = mid;
                }
            }

            if (j == count || !_IsEqual(extract(list[j]), key))
            {
                j = ~j;
            }

            return j;
        }

        private static bool _IsEqual(float a, float b)
        {
            var delta = a - b;
            return delta < eps && delta > -eps;
        }

        public const float eps = 0.000001f;
    }
}
