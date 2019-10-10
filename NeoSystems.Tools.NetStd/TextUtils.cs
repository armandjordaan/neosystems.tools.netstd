/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NeoSystems.Tools;

namespace NeoSystems.Tools
{
    /// <summary>
    /// Text utlilities
    /// </summary>
    public class TextUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte HexCharTobyte(char s)
        {
            byte Result;

            if  ( (s >= '0') && (s <= '9') )
            {
                Result = (byte)(s - '0');
            }
            else if ((s >= 'A') && (s <= 'F'))
            {
                Result = (byte)((byte)s - (byte)'A');
                Result += 10;
            }
            else if ((s >= 'a') && (s <= 'f'))
            {
                Result = (byte)((byte)s - (byte)'a');
                Result += 10;
            }
            else
            {
                Result = 0;
            }

            return Result;
        }

        /// <summary>
        /// Get a byte from two chars representing a HEX value
        /// </summary>
        /// <param name="MS_Nibble"></param>
        /// <param name="LS_Nibble"></param>
        /// <returns>byte value</returns>
        public static byte ByteFromHexchars(char MS_Nibble, char LS_Nibble)
        {
            byte b;

            b = HexCharTobyte(LS_Nibble);
            b |= (byte)(HexCharTobyte(LS_Nibble) << 4);

            return b;
        }

        /// <summary>
        /// Convert a HEX string to byte array
        /// </summary>
        [Flags]
        public enum HexStringToByteArrayOptions
        {
            /// <summary>
            /// Values in the string is separated by spaces
            /// </summary>
            SpaceSeparated = 0x0001
        }

        /// <summary>
        /// Convert a HEX string to byte array
        /// </summary>
        /// <param name="s">string to convert</param>
        /// <param name="Opt">string and convert Options</param>
        /// <returns></returns>
        public static byte[] ConvertHEXStringToByteArray(string s, HexStringToByteArrayOptions Opt)
        {
            string temp;

            if (Opt == HexStringToByteArrayOptions.SpaceSeparated)
            {
                temp = s.RemoveAll(' ');
            }
            else
            {
                temp = s;
            }

            byte[] Result = new byte[s.Length/2 + 1];

            for(int i=0; i<(s.Length / 2); i++)
            {
                Result[i * 2] = ByteFromHexchars(s[i + 1], s[i]);
            }

            return Result;
        }
    }
}
