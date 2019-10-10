/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Text;

namespace NeoSystems.Tools
{
    /// <summary>
    /// Neo Systems Array utilities
    /// </summary>
    public class ArrayUtils
    {
        /// <summary>
        /// Compare two arrays
        /// </summary>
        /// <param name="a1">array 1</param>
        /// <param name="a2">array 2</param>
        /// <returns>bool (true if arrays are equal)</returns>
        public static bool ArrayCompare(byte[] a1, byte[] a2)
        {
            if (a1.Length != a2.Length)
                return false;

            for (int i = 0; i < a1.Length; i++)
                if (a1[i] != a2[i])
                    return false;

            return true;
        }

        /// <summary>
        /// Fill a byte array with values (only tested for 2D array)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="value"></param>
        public static void Fill(byte[] x, byte value)
        {
            for (int i = 0; i <= x.GetUpperBound(0); i++)
            {
                x[i] = value;
            }
        }

        /// <summary>
        /// Sum all the elements of an array
        /// </summary>
        /// <param name="arr">array of which the elemnts should be summed</param>
        int SumArray(int[] arr)
        {
            try
            {
                Type arrtype  = arr.GetType();
                Type eltype   = arrtype.GetElementType();

                if (eltype.ToString() == "System.Int32")
                {
                    int result = 0;
                    for (int i = 0; i < arr.GetUpperBound(0); i++)
                    {
                        result += arr[i];
                    }
                    return result;
                }
                else
                {
                    throw new Exception("Cannot perform summing of array - element type not implemented.");
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.ToString() + "Cannot perform summing of array - general fail.");
            }
        }

        /// <summary>
        /// Converts a HEX string dump of a binary file back to a binary file<br />
        /// Converts lines of the form:<br />
        /// 00000000: 01 23 45 ...... EF<br />
        /// 00000010: 01 23 45 ...... EF<br />
        /// ...<br />
        /// ...<br />
        /// xxxxxxxx: 01 23 45 ...... EF<br />
        /// to a byte array<br />       
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="offs"></param>
        /// <param name="len"></param>
        /// <param name="splitchars"></param>
        /// <returns></returns>
        public static byte[] ByteArrayFromStringArray(string[] lines, int offs, int len, char[] splitchars = null)
        {
            try
            {
                if (splitchars == null)
                {
                    splitchars = new char[] { ' ' };
                }

                List<byte> result = new List<byte>();
                int i;

                for (i=offs; i<(len+offs); i++)
                {
                    string[] f = lines[i].Split(splitchars, StringSplitOptions.RemoveEmptyEntries);

                    for(int j=1; j<17; j++)
                    {
                        byte b = Convert.ToByte(f[j], 16);
                        result.Add(b);
                    }
                }

                return result.ToArray();
            }
            catch (Exception ex)
            {
                throw new NeoException("Could not convert string into binary array", ex);
            }
        }

        /// <summary>
        /// Convert a HEX string to a byte array
        /// 
        /// ie a string of 123456789abcdef will be converted to a byte array of :
        /// 
        /// 0x12
        /// 0x34
        /// 0x56
        /// ...
        /// ...
        /// 0xcd
        /// 0xef
        /// 
        /// String must be even length
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte[] ByteArrayFromHEXString(string s)
        {
            string tmp = s.ToUpper();

            if ((s.Length & 0x01) != 0)
            {
                throw new Exception("String lenght not even");
            }

            if (s.Length < 2)
            {
                throw new Exception("String too short");
            }

            byte[] result = new byte[tmp.Length / 2];
            int j = 0;
            for(int i=0; i<tmp.Length; i+=2)
            {
                result[j] = StringUtils.HexCharToByte(s[i]);
                result[j] <<= 4;
                result[j] |= StringUtils.HexCharToByte(s[i+1]);
                j++;
            }

            return result;
        }
    }
}
