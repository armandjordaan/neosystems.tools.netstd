/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeoSystems.Tools
{
    /// <summary>
    /// Ascii control characters
    /// </summary>
    public class AsciiControlCodes
    {
        /// <summary>
        /// 	^@ 	\0 	Null character
        /// </summary>
        public static readonly byte ASCII_NUL   = 0x00; 

        /// <summary>
        /// ^A 		Start of Header
        /// </summary>
        public static readonly byte ASCII_SOH   = 0x01;
 
        /// <summary>
        /// ^B 		Start of Text
        /// </summary>
        public static readonly byte ASCII_STX   = 0x02;

        /// <summary>
        /// ^C 		End of Text
        /// </summary>
        public static readonly byte ASCII_ETX   = 0x03;

        /// <summary>
        /// ^D 		End of Transmission
        /// </summary>
        public static readonly byte ASCII_EOT   = 0x04;

        /// <summary>
        /// ^E 		Enquiry
        /// </summary>
        public static readonly byte ASCII_ENQ   = 0x05;

        /// <summary>
        /// ^F 		Acknowledgment
        /// </summary>
        public static readonly byte ASCII_ACK   = 0x06;

        /// <summary>
        /// ^G 	\a 	Bell
        /// </summary>
        public static readonly byte ASCII_BEL   = 0x07;

        /// <summary>
        /// ^H 	\b 	Backspace[d][e]
        /// </summary>
        public static readonly byte ASCII_BS 	= 0x08;

        /// <summary>
        /// ^I 	\t 	Horizontal Tab[f]
        /// </summary>
        public static readonly byte ASCII_HT 	= 0x09;

        /// <summary>
        /// ^J 	\n 	Line feed
        /// </summary>
        public static readonly byte ASCII_LF 	= 0x0A;

        /// <summary>
        /// ^K 	\v 	Vertical Tab
        /// </summary>
        public static readonly byte ASCII_VT 	= 0x0B;

        /// <summary>
        /// ^L 	\f 	Form feed
        /// </summary>
        public static readonly byte ASCII_FF 	= 0x0C;

        /// <summary>
        /// ^M 	\r 	Carriage return[g]
        /// </summary>
        public static readonly byte ASCII_CR 	= 0x0D;

        /// <summary>
        /// ^N 		Shift Out
        /// </summary>
        public static readonly byte ASCII_SO 	= 0x0E;

        /// <summary>
        /// ^O 		Shift In
        /// </summary>
        public static readonly byte ASCII_SI 	= 0x0F;

        /// <summary>
        /// ^P 		Data Link Escape
        /// </summary>
        public static readonly byte ASCII_DLE   = 0x10;

        /// <summary>
        /// ^Q 		Device Control 1 (oft. XON)
        /// </summary>
        public static readonly byte ASCII_DC1   = 0x11;

        /// <summary>
        /// ^R 		Device Control 2
        /// </summary>
        public static readonly byte ASCII_DC2   = 0x12;

        /// <summary>
        /// ^S 		Device Control 3 (oft. XOFF)
        /// </summary>
        public static readonly byte ASCII_DC3   = 0x13;

        /// <summary>
        /// ^T 		Device Control 4
        /// </summary>
        public static readonly byte ASCII_DC4   = 0x14;

        /// <summary>
        /// ^U 		Negative Acknowledgement
        /// </summary>
        public static readonly byte ASCII_NAK   = 0x15;

        /// <summary>
        /// ^V 		Synchronous idle
        /// </summary>
        public static readonly byte ASCII_SYN   = 0x16;

        /// <summary>
        /// ^W 		End of Transmission Block
        /// </summary>
        public static readonly byte ASCII_ETB   = 0x17;

        /// <summary>
        /// ^X 		Cancel
        /// </summary>
        public static readonly byte ASCII_CAN   = 0x18;

        /// <summary>
        /// ^Y 		End of Medium
        /// </summary>
        public static readonly byte ASCII_EM 	= 0x19;

        /// <summary>
        /// ^Z 		Substitute
        /// </summary>
        public static readonly byte ASCII_SUB   = 0x1A;

        /// <summary>
        /// ^[ 	\e[h] 	Escape[i]
        /// </summary>
        public static readonly byte ASCII_ESC   = 0x1B;

        /// <summary>
        /// ^\ 		File Separator
        /// </summary>
        public static readonly byte ASCII_FS 	= 0x1C;
 
        /// <summary>
        /// ^] 		Group Separator
        /// </summary>
        public static readonly byte ASCII_GS 	= 0x1D;

        /// <summary>
        /// ^^[j] 	Record Separator
        /// </summary>
        public static readonly byte ASCII_RS 	= 0x1E;
 
        /// <summary>
        /// ^_ 		Unit Separator
        /// </summary>
        public static readonly byte ASCII_US 	= 0x1F;

        /// <summary>
        /// ^? 		Delete[k][e]
        /// </summary>
        public static readonly byte ASCII_DEL   = 0x7F;
    }
}
