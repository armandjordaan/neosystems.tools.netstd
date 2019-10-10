/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSystems.Tools
{
    /// <summary>
    /// BCD utilities
    /// </summary>
    public static class BCDutils
    {
        /// <summary>
        /// Convert a value to a BCD (4 digits)
        /// </summary>
        /// <param name="val">Integer to convert to BCD</param>
        /// <returns>byte array (2 bytes)</returns>
        public static byte[] Int2Bcd4(int val)
        {
            if (val < 0 || val > 9999) throw new ArgumentException();
            int bcd = 0;
            for (int digit = 0; digit < 4; ++digit)
            {
                int nibble = val % 10;
                bcd |= nibble << (digit * 4);
                val /= 10;
            }
            return new byte[] { (byte)((bcd >> 8) & 0xff), (byte)(bcd & 0xff) };
        }
    }
}
