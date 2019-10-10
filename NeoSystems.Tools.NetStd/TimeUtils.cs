/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSystems.Tools
{
    // ************************************************************************
    /// <summary>
    /// TimeUtils contain a number of time related functions
    /// </summary>
    public static class TimeUtils
    {
        // ********************************************************************
        /// <summary>
        /// Get the number of seconds since 1 Jan 0000, at 0:00:00 time
        /// </summary>
        /// <param name="t">Give a DateTime as parameter</param>
        /// <returns>Number of seconds</returns>
        public static long DateTimeToSeconds(DateTime t)
        {
            long ticks = t.Ticks;
            long secs = (ticks / 10000000);
            return secs;
        }
    }
}
