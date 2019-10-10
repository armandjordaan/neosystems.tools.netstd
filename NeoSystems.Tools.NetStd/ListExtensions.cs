/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSystems.Tools
{
    /// <summary>
    /// List extension methods
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Checks if a list contains any of the items in an array
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="list">list class ref</param>
        /// <param name="arr">array of items to check against</param>
        public static bool ContainsAnyOf<T>(this List<T> list, T[] arr)
        {
            bool Contains = false;

            foreach (T x in arr)
            {
                if (list.Contains(x))
                {
                    Contains = true;
                }
            }

            return Contains;
        }
    }
}
