/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSystems.Tools
{
    // ********************************************************************
    /// <summary>
    /// TypeUtils contains various static methods to do type conversions and to extract
    /// data from other types.
    /// </summary>
    public class TypeUtils
    {
        // ********************************************************************
        /// <summary>
        /// Get the Low byte of a short value
        /// </summary>
        /// <param name="value">short int</param>
        /// <returns>lowest byte</returns>
        public static byte GetLowByte(short value)
        {
            byte temp = (byte)(value & 0xFF);
            return temp;
        }

        // ********************************************************************
        /// <summary>
        /// Get the high byte of a short int
        /// </summary>
        /// <param name="value">short int</param>
        /// <returns>highest byte</returns>
        public static byte GetHighByte(short value)
        {
            byte temp = (byte)((value >> 8) & 0xFF);
            return temp;
        }

        // ********************************************************************
        /// <summary>
        /// GetLowestByte returns the least signifacant of all 4 the bytes in an uint
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte GetLowestByte(uint value)
        {
            byte temp = (byte)(value & 0xFF);
            return temp;
        }

        // ********************************************************************
        /// <summary>
        /// GetLowerByte returns the second least signifacant of all 4 the bytes in an uint
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte GetLowerByte(uint value)
        {
            byte temp = (byte)((value >> 8) & 0xFF);
            return temp;
        }

        // ********************************************************************
        /// <summary>
        /// GetHigherByte returns the second most signifacant of all 4 the bytes in an uint
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte GetHigherByte(uint value)
        {
            byte temp = (byte)((value >> 16) & 0xFF);
            return temp;
        }

        // ********************************************************************
        /// <summary>
        /// GetHigherByte returns the most signifacant of all 4 the bytes in an uint
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte GetHighestByte(uint value)
        {
            byte temp = (byte)((value >> 24) & 0xFF);
            return temp;
        }
    }
}
