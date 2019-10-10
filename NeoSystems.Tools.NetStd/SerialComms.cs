/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace NeoSystems.Tools
{
    // ********************************************************************
    /// <summary>
    /// General Serialcomms functions
    /// </summary>
    public class SerialComms
    {
        /// <summary>
        /// Baudrate flags
        /// </summary>
        [Flags]
        public enum BaudFlags : uint
        {
            /// <summary>75 bps</summary>
            BAUD_075 = 0x00000001, // 75 bps

            /// <summary>110 bps</summary>
            BAUD_110 = 0x00000002, // 110 bps

            /// <summary>134.5 bps</summary>
            BAUD_134_5 = 0x00000004, // 134.5 bps

            /// <summary>150 bps</summary>
            BAUD_150 = 0x00000008, // 150 bps

            /// <summary>300 bps</summary>
            BAUD_300 = 0x00000010, // 300 bps

            /// <summary>600 bps</summary>
            BAUD_600 = 0x00000020, // 600 bps

            /// <summary>1200 bps</summary>
            BAUD_1200 = 0x00000040, // 1200 bps

            /// <summary>1800 bps</summary>
            BAUD_1800 = 0x00000080, // 1800 bps

            /// <summary>2400 bps</summary>
            BAUD_2400 = 0x00000100, // 2400 bps

            /// <summary>4800 bps</summary>
            BAUD_4800 = 0x00000200, // 4800 bps

            /// <summary>7200 bps</summary>
            BAUD_7200 = 0x00000400, // 7200 bps

            /// <summary>9600 bps</summary>
            BAUD_9600 = 0x00000800, // 9600 bps

            /// <summary>14400 bps</summary>
            BAUD_14400 = 0x00001000, // 14400 bps

            /// <summary>19200 bps</summary>
            BAUD_19200 = 0x00002000, // 19200 bps

            /// <summary>38400 bps</summary>
            BAUD_38400 = 0x00004000, // 38400 bps

            /// <summary>56000 bps</summary>
            BAUD_56K = 0x00008000, // 56K bps

            /// <summary>57600 bps</summary>
            BAUD_57600 = 0x00040000, // 57600 bps

            /// <summary>115200 bps</summary>
            BAUD_115200 = 0x00020000, // 115200 bps

            /// <summary>128 kbps</summary>
            BAUD_128K = 0x00010000, // 128K bps

            /// <summary>User bps</summary>
            BAUD_USER = 0x10000000  // Programmable baud rate.
        }

        // ********************************************************************
        /// <summary>
        /// GetMaxBaudrate determines the maximum baudrate for portName
        /// </summary>
        /// <param name="portName">Name of com port</param>
        /// <returns>Maximum Buadrate or -1 if an error occurred</returns>
        public static int GetMaxBaudrate(string portName)
        {
            Int32 bv;

            try
            {
                SerialPort _port = new SerialPort(portName);
                _port.Open();
                object p = _port.BaseStream.GetType().GetField("commProp",
                    BindingFlags.Instance |
                    BindingFlags.NonPublic).GetValue(_port.BaseStream);
                bv = (Int32)p.GetType().GetField("dwSettableBaud",
                    BindingFlags.Instance |
                    BindingFlags.NonPublic | BindingFlags.Public).GetValue(p);
                _port.Close();
            }
            catch
            {
                bv = -1;
            }
            return bv;
        }

        // ********************************************************************
        /// <summary>
        /// Convert a baudrate mask to a string to display
        /// </summary>
        /// <param name="x">x = baudrate capability mask</param>
        /// <returns>string containing available baudrates</returns>
        public static string BuadrateMaskToString(int x)
        {
            BaudFlags t = (BaudFlags)x;
            StringBuilder s = new StringBuilder(2048);

            if ((t & BaudFlags.BAUD_075) != 0) s.Append("75 bps, ");
            if ((t & BaudFlags.BAUD_110) != 0) s.Append("110 bps, ");
            if ((t & BaudFlags.BAUD_134_5) != 0) s.Append("134.5 bps, ");
            if ((t & BaudFlags.BAUD_150) != 0) s.Append("150 bps, ");
            if ((t & BaudFlags.BAUD_300) != 0) s.Append("300 bps, ");
            if ((t & BaudFlags.BAUD_600) != 0) s.Append("600 bps, ");
            if ((t & BaudFlags.BAUD_1200) != 0) s.Append("1200 bps, ");
            if ((t & BaudFlags.BAUD_1800) != 0) s.Append("1800 bps, ");
            if ((t & BaudFlags.BAUD_2400) != 0) s.Append("2400 bps, ");
            if ((t & BaudFlags.BAUD_4800) != 0) s.Append("4800 bps, ");
            if ((t & BaudFlags.BAUD_7200) != 0) s.Append("7200 bps, ");
            if ((t & BaudFlags.BAUD_9600) != 0) s.Append("9600 bps, ");
            if ((t & BaudFlags.BAUD_14400) != 0) s.Append("14400 bps, ");
            if ((t & BaudFlags.BAUD_19200) != 0) s.Append("19200 bps, ");
            if ((t & BaudFlags.BAUD_38400) != 0) s.Append("38400 bps, ");
            if ((t & BaudFlags.BAUD_56K) != 0) s.Append("56 kbps, ");
            if ((t & BaudFlags.BAUD_57600) != 0) s.Append("57600 bps, ");
            if ((t & BaudFlags.BAUD_115200) != 0) s.Append("115200 bps, ");
            if ((t & BaudFlags.BAUD_128K) != 0) s.Append("128 kbps, ");
            if ((t & BaudFlags.BAUD_USER) != 0) s.Append("User bps, ");

            return s.ToString();
        }
    }

}
