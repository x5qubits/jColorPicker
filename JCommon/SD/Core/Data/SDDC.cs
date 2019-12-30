using System;

namespace JCommon.SD.Core.Data
{
    public class SDDC
    {
        public SDDC()
        {
        }

        public SDDC(long start, long length)
        {
            this.Start = start;
            this.Length = length;
        }

        public long Start { get; set; }

        public long Length { get; set; }

        public long End
        {
            get { return this.Start + this.Length - 1; }
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            SDDC r = obj as SDDC;

            return Equals(r);
        }

        public bool Equals(SDDC r)
        {
            if ((object)r == null)
            {
                return false;
            }

            return (this.Start == r.Start) && (this.Length == r.Length);
        }

        public override int GetHashCode()
        {
            return (int)(13 * this.Start * this.End);
        }

        public static bool operator ==(SDDC a, SDDC b)
        {
            if (object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return (object)a == null ? b.Equals(a) : a.Equals(b);
        }

        public static bool operator !=(SDDC a, SDDC b)
        {
            return !(a == b);
        }
    }
}