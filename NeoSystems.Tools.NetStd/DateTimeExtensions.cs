/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSystems.Tools
{
    /// <summary>
    /// Neo Systems Datetime Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Convert a string to a dateTime value
        /// example: var dt="2011-03-21 13:26".toDate("yyyy-MM-dd HH:mm");
        /// </summary>
        /// <param name="dateTimeStr">string to convert</param>
        /// <param name="dateFmt">date Format</param>
        /// <returns>DateTime struct</returns>
        public static DateTime? toDate(this string dateTimeStr, string dateFmt)
        {
            // example: var dt="2011-03-21 13:26".toDate("yyyy-MM-dd HH:mm");
            const DateTimeStyles style = DateTimeStyles.AllowWhiteSpaces;
            DateTime? result = null;
            DateTime dt;
            if (DateTime.TryParseExact(dateTimeStr, dateFmt,
                CultureInfo.InvariantCulture, style, out dt)) result = dt;
            return result;
        }
    }

}
