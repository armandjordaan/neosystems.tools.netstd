/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSystems.Tools
{
    /// <summary>
    /// Extension methods for TextWriter class
    /// </summary>
    public static class TextWriterExtensions
    {
        /// <summary>
        /// Write string array to TextWriter
        /// </summary>
        /// <param name="t">textwriter object</param>
        /// <param name="stringarr">string array</param>
        /// <param name="start">start index</param>
        public static void Write(this TextWriter t, string[] stringarr, int start)
        {
            foreach (string s in stringarr)
            {
                t.Write(s);
            }
        }

        /// <summary>
        /// WriteLine string array 
        /// </summary>
        /// <param name="t">textwriter object</param>
        /// <param name="stringarr">string array</param>
        /// <param name="start">start index</param>
        public static void WriteLine(this TextWriter t, string[] stringarr, int start)
        {
            foreach (string s in stringarr)
            {
                t.WriteLine(s);
            }
        }

    }
}
