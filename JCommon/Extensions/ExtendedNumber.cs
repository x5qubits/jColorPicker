using System;
using System.Collections.Generic;
using System.Text;

namespace JCommon.Extensions
{
    public static class ExtendedNumber
    {
        public static bool IsInRange(this int dec, int min, int max, bool includesMin = true, bool includesMax = true)
        {
            return (includesMin ? (dec >= min) : (dec > min)) && (includesMax ? (dec <= max) : (dec < max));
        }
    }
}
