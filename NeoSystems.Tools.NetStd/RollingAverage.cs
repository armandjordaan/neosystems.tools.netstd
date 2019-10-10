/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neolibs
{
    /// <summary>
    /// Rolling average class
    /// </summary>
    /// <typeparam name="T">type to use for rolling average calculation</typeparam>
    public class RollingAverage<T>
    {
        int idx;
        T[] Buf;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ra_size">Number of elements in rolling buffer</param>
        public RollingAverage(int ra_size)
        {
            Buf = new T[ra_size];
            idx = 0;
        }

        /// <summary>
        /// Constructor (defaults to 100 elements in buffer)
        /// </summary>
        public RollingAverage() : this(100)
        {
        }

        /// <summary>
        /// Add a new sample into the rolling buffer.
        /// </summary>
        /// <param name="val">Type of the buffer</param>
        public void Input(T val)
        {
            Buf[idx] = val;
            idx++;
            if (idx > Buf.GetUpperBound(0))
            {
                idx = 0;
            }
        }

        /// <summary>
        /// Returns the current value of the rolling average
        /// </summary>
        /// <returns>double = value of the average</returns>
        public double GetAverage()
        {
            double result = 0;
            for (int i = 0; i <= Buf.GetUpperBound(0); i++)
            {
                result += (double)Convert.ChangeType(Buf[i], typeof(double));
            }
            return result;
        }
    }

}
