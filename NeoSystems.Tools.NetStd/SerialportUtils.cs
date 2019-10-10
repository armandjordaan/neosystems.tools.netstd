/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace NeoSystems.Tools
{
    /// <summary>
    /// Serial port utilities
    /// </summary>
    public class SerialportUtils
    {
        /// <summary>
        /// return the name of the first available serial port.
        /// If no serial ports are available the "COM1" is returned on all platforms
        /// </summary>
        /// <returns>First serila port name</returns>
        public static string GetFirstPortname()
        {
            string Comportname;
            
            try
            {
                string[] portnames = SerialPort.GetPortNames();

                if (portnames.Count() == 0)
                {
                    Comportname = "COM1";
                }
                else
                {
                    Comportname = portnames[0];
                }
            }
            catch
            {
                Comportname = "COM1";
            }

            return Comportname;
        }
    }
}
