using JCommon.SD.Core.Data;
using System.Collections.Generic;

namespace JCommon.SD.Core.Utils
{
    public class SDDataContainerHelper
    {
        public bool RangesCollide(SDDC range1, SDDC range2)
        {
            return range1.Start <= range2.End && range2.Start <= range1.End;
        }

        public List<SDDC> RangeDifference(SDDC fullRange, SDDC range)
        {
            var result = new List<SDDC>();

            // no intersection
            if (!RangesCollide(fullRange, range))
            {
                result.Add(fullRange);
                return result;
            }

            // fullRange is part of range --> difference is empty
            if (fullRange.Start >= range.Start && fullRange.End <= range.End)
            {
                return result;
            }

            if (fullRange.Start < range.Start)
            {
                result.Add(new SDDC(fullRange.Start, range.Start - fullRange.Start));
            }

            if (fullRange.End > range.End)
            {
                result.Add(new SDDC(range.End + 1, fullRange.End - range.End));
            }

            return result;
        }
    }
}