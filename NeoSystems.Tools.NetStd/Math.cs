/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSystems.Tools
{
    /// <summary>
    /// Neo Systems Math libraries
    /// </summary>
    public static class Math
    {
        /// <summary>
        /// Rotate a uint value right
        /// </summary>
        /// <param name="original">The value to rotate</param>
        /// <param name="bits">Number of bits to rotate by</param>
        /// <returns>uint value equals the rotated answer</returns>
        public static uint RotateRight(uint original, int bits)
        {
            return (original << bits) | (original >> (32 - bits));
        }

        /// <summary>
        /// Rotate a uint value left
        /// </summary>
        /// <param name="original">The value to rotate</param>
        /// <param name="bits">Number of bits to rotate by</param>
        /// <returns>uint value equals the rotated answer</returns>
        public static uint RotateLeft(uint original, int bits)
        {
            return (original >> bits) | (original << (32 - bits));
        }

        /// <summary>
        /// Perform an arithmetic shift right
        /// </summary>
        /// <param name="original">The value to arithmetically shift</param>
        /// <param name="bits">Number of bits to shift by</param>
        /// <returns>uint value equals the arithmetically shifted answer</returns>
        public static uint ArithmeticShiftRight(uint original, int bits)
        {
            uint msb = original & 0x80000000;
            uint result = original;

            for (int i = 0; i < bits; i++)
            {
                result >>= 1;
                result |= msb;
            }
            return result;
        }
    }

}
