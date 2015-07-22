using System;
using System.Text;

namespace ICCProfReader
{
    class Utils
    {
        //uInt32Number is an unsigned 4-byte (32-bit) integer. 
        internal static uint uInt32Number(int index)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(ICCProfile.DataProfile, index, 4);
                return BitConverter.ToUInt32(ICCProfile.DataProfile, index);
            }
            else
            {
                return BitConverter.ToUInt32(ICCProfile.DataProfile, index);
            }
        }

        internal static string ASCIIString(int index, int length)
        {
            return Encoding.ASCII.GetString(ICCProfile.DataProfile, index, length);
        }

        //The Unicode strings in storage should be encoded as 16-bit big-endian, UTF-16BE
        internal static string UnicodeString(int index, int length)
        {
            return Encoding.BigEndianUnicode.GetString(ICCProfile.DataProfile, index, length);
        }
    }
}
