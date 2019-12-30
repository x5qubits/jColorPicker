using System;
using System.Runtime.InteropServices;

namespace JCommon.FileDatabase.IO
{
    public class DataBuffer
    {
        private byte[] m_Buffer;
        private const int k_InitialSize = 64;
        private const float k_GrowthFactor = 1.5f;
        private const int k_BufferSizeWarning = 1024 * 1024 * 128;

        public uint Position { get; private set; }
        public int Length { get { return m_Buffer.Length; } }

        public DataBuffer()
        {
            m_Buffer = new byte[k_InitialSize];
        }

        // this does NOT copy the buffer
        public DataBuffer(byte[] buffer)
        {
            m_Buffer = buffer;
        }

        public byte ReadByte()
        {
            if (Position >= m_Buffer.Length)
            {
                throw new IndexOutOfRangeException("DataBuffer:ReadByte out of range:" + ToString());
            }

            return m_Buffer[Position++];
        }

        public void ReadBytes(byte[] buffer, uint count)
        {
            if (Position + count > m_Buffer.Length)
            {
                throw new IndexOutOfRangeException("DataBuffer:ReadBytes out of range: (" + count + ") " + ToString());
            }

            for (ushort i = 0; i < count; i++)
            {
                buffer[i] = m_Buffer[Position + i];
            }
            Position += count;
        }

        internal ArraySegment<byte> AsArraySegment()
        {
            return new ArraySegment<byte>(m_Buffer, 0, (int)Position);
        }

        public void WriteByte(byte value)
        {
            WriteCheckForSpace(1);
            m_Buffer[Position] = value;
            Position += 1;
        }

        public void WriteByte2(byte value0, byte value1)
        {
            WriteCheckForSpace(2);
            m_Buffer[Position] = value0;
            m_Buffer[Position + 1] = value1;
            Position += 2;
        }

        public void WriteByte4(byte value0, byte value1, byte value2, byte value3)
        {
            WriteCheckForSpace(4);
            m_Buffer[Position] = value0;
            m_Buffer[Position + 1] = value1;
            m_Buffer[Position + 2] = value2;
            m_Buffer[Position + 3] = value3;
            Position += 4;
        }

        public void WriteByte8(byte value0, byte value1, byte value2, byte value3, byte value4, byte value5, byte value6, byte value7)
        {
            WriteCheckForSpace(8);
            m_Buffer[Position] = value0;
            m_Buffer[Position + 1] = value1;
            m_Buffer[Position + 2] = value2;
            m_Buffer[Position + 3] = value3;
            m_Buffer[Position + 4] = value4;
            m_Buffer[Position + 5] = value5;
            m_Buffer[Position + 6] = value6;
            m_Buffer[Position + 7] = value7;
            Position += 8;
        }

        // every other Write() function in this class writes implicitly at the end-marker m_Pos.
        // this is the only Write() function that writes to a specific location within the buffer
        public void WriteBytesAtOffset(byte[] buffer, ushort targetOffset, ushort count)
        {
            uint newEnd = (uint)(count + targetOffset);

            WriteCheckForSpace((ushort)newEnd);

            if (targetOffset == 0 && count == buffer.Length)
            {
                buffer.CopyTo(m_Buffer, (int)Position);
            }
            else
            {
                //CopyTo doesnt take a count :(
                for (int i = 0; i < count; i++)
                {
                    m_Buffer[targetOffset + i] = buffer[i];
                }
            }

            // although this writes within the buffer, it could move the end-marker
            if (newEnd > Position)
            {
                Position = newEnd;
            }
        }

        public void WriteBytes(byte[] buffer, ushort count)
        {
            WriteCheckForSpace(count);

            if (count == buffer.Length)
            {
                buffer.CopyTo(m_Buffer, (int)Position);
            }
            else
            {
                //CopyTo doesnt take a count :(
                for (int i = 0; i < count; i++)
                {
                    m_Buffer[Position + i] = buffer[i];
                }
            }
            Position += count;
        }

        private void WriteCheckForSpace(ushort count)
        {
            if (Position + count < m_Buffer.Length)
                return;

            int newLen = (int)Math.Ceiling(m_Buffer.Length * k_GrowthFactor);
            while (Position + count >= newLen)
            {
                newLen = (int)Math.Ceiling(newLen * k_GrowthFactor);
                if (newLen > k_BufferSizeWarning)
                {
                    Log.Error("FileDatabase :: Size is " + newLen + " bytes!");
                }
            }

            // only do the copy once, even if newLen is increased multiple times
            byte[] tmp = new byte[newLen];
            m_Buffer.CopyTo(tmp, 0);
            m_Buffer = tmp;
        }

        public void FinishMessage()
        {
            // two shorts (size and msgType) are in header.
            ushort sz = (ushort)(Position - (sizeof(ushort) * 2));
            m_Buffer[0] = (byte)(sz & 0xff);
            m_Buffer[1] = (byte)((sz >> 8) & 0xff);
        }

        public void SeekZero()
        {
            Position = 0;
        }

        public void Replace(byte[] buffer)
        {
            m_Buffer = buffer;
            Position = 0;
        }

        public override string ToString()
        {
            return String.Format("NetBuf sz:{0} pos:{1}", m_Buffer.Length, Position);
        }
    } // end NetBuffer
      // -- helpers for float conversion --
    [StructLayout(LayoutKind.Explicit)]
    internal struct JHSUIntFloat
    {
        [FieldOffset(0)]
        public float floatValue;

        [FieldOffset(0)]
        public uint intValue;

        [FieldOffset(0)]
        public double doubleValue;

        [FieldOffset(0)]
        public ulong longValue;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct JHSUIntDecimal
    {
        [FieldOffset(0)]
        public ulong longValue1;

        [FieldOffset(8)]
        public ulong longValue2;

        [FieldOffset(0)]
        public decimal decimalValue;
    }

    internal class JHSFloatConversion
    {
        public static float ToSingle(uint value)
        {
            JHSUIntFloat uf = new JHSUIntFloat
            {
                intValue = value
            };
            return uf.floatValue;
        }

        public static double ToDouble(ulong value)
        {
            JHSUIntFloat uf = new JHSUIntFloat
            {
                longValue = value
            };
            return uf.doubleValue;
        }

        public static decimal ToDecimal(ulong value1, ulong value2)
        {
            JHSUIntDecimal uf = new JHSUIntDecimal
            {
                longValue1 = value1,
                longValue2 = value2
            };
            return uf.decimalValue;
        }
    }
}
