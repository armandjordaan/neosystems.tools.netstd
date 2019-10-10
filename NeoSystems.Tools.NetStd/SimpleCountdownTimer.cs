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
    /// A very simple countdown timer. Drawback: it has to be polled.
    /// In future the class can be derived to give a more complex and fully featured timer
    /// (or it could be easier to inherit a new class from one of the .NET classes)
    /// </summary>
    public class SimpleCountDownTimer
    {
        private long CountDownSecs;
        private long StartSecs;

        // ************************************************************************
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Seconds">The number of seconds the countdown timer is to count down</param>
        SimpleCountDownTimer(long Seconds)
        {
            Reload(Seconds);
        }

        // ************************************************************************
        /// <summary>
        /// Timeout is a property that can be read to determine if teh countdown has expired.
        /// It is true if the set amount of time has passed, false otherwise
        /// </summary>
        public bool Timeout
        {
            get
            {
                long nowsecs = TimeUtils.DateTimeToSeconds(DateTime.Now);
                if ((nowsecs - StartSecs) > CountDownSecs)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // ************************************************************************
        /// <summary>
        /// Method to reload the timer with a new timeout value
        /// </summary>
        /// <param name="Seconds">Time to reload the timer with</param>
        public void Reload(long Seconds)
        {
            CountDownSecs = Seconds;
            StartSecs = TimeUtils.DateTimeToSeconds(DateTime.Now);
        }
    }

}
