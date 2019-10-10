/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeoSystems.Tools
{
    /// <summary>
    /// neo Systems specific console methods
    /// </summary>
    public static class NeoConsole
    {
        /// <summary>
        /// Write error (changes color to red for error text)
        /// </summary>
        /// <param name="s">Text to write</param>
        public static void WriteError(string s)
        {
            ConsoleColor t = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(s);
            Console.ForegroundColor = t;
        }

        /// <summary>
        /// Write Line error (changes color to red for error text)
        /// </summary>
        /// <param name="s">Text to write</param>
        public static void WriteLineError(string s)
        {
            ConsoleColor t = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ForegroundColor = t;
        }

        /// <summary>
        /// Write success (changes color to green for success text)
        /// </summary>
        /// <param name="s">Text to write</param>
        public static void WriteSuccess(string s)
        {
            ConsoleColor t = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s);
            Console.ForegroundColor = t;
        }

        /// <summary>
        /// Write Line success (changes color to green for success text)
        /// </summary>
        /// <param name="s">Text to write</param>
        public static void WriteLineSuccess(string s)
        {
            ConsoleColor t = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ForegroundColor = t;
        }
    }
}
