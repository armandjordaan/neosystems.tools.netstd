/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Text;

namespace NeoSystems.Tools
{
    /// <summary>
    /// NeoException is a Custom exception for Neo Systems appplications
    /// </summary>
    public class NeoException : Exception
    {
        /// <summary>
        /// A string containing the last error than was recorded
        /// </summary>
        public string LastError;

        /// <summary>
        /// NeoException Constructor
        /// </summary>
        /// <param name="Err">Last Error message</param>
        /// <param name="e">e is the inner exception that caused the problem</param>
        public NeoException(string Err, Exception e) 
            : base(Err, e)
        {
            LastError = Err;   
        }

        /// <summary>
        /// neoException Constructor
        /// </summary>
        /// <param name="Err">Last Error message</param>
        public NeoException(string Err)
            : base(Err)
        {
            LastError = Err;
        }
    }

}
