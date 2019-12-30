using System;

namespace JCommon.Extensions
{
    public static class ExtendedArray
    {
        public static T[] Resize<T>(this T[] array, int newSize)
        {
            if (null == array)
            {
                var newArray = new T[newSize];
                return newArray;
            }

            if (array.Length != newSize)
            {
                var newArray = new T[newSize];
                Array.Copy(array, newArray, Math.Min(array.Length, newSize));
                return newArray;
            }

            return array;
        }

        public static T Get<T>(this T[] array, int index)
        {
            return array.Get(index, default(T));
        }

        public static T Get<T>(this T[] array, int index, T defaultValue)
        {
            if (null != array)
            {
                var length = array.Length;
                if (index >= 0 && index < length)
                {
                    return array[index];
                }
                else
                {
                    string s = string.Format("index out of range, index={0}, array.Length={1}", index.ToString(), length.ToString());
                    Log.Error(s);
                }
            }
            else
            {

                Log.Error("array is null");
            }

            return defaultValue;
        }
    }
}
