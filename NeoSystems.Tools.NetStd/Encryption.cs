/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace NeoSystems.Tools
{
    /// <summary>
    /// A few utilities for use with MD5 hashing
    /// </summary>
    public class MD5Utils
    {
        /// <summary>
        /// get the MD5 hash of a string
        /// </summary>
        /// <param name="md5Hash">MD5 instance</param>
        /// <param name="input">string to be encrypted</param>
        /// <returns>encrypted string</returns>
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }        

        /// <summary>
        /// Verify a hash against a string. 
        /// </summary>
        /// <param name="md5Hash">MD5 class instance</param>
        /// <param name="input">string to be hashed</param>
        /// <param name="hash">has to verify against</param>
        /// <returns>true if match, false otherwise</returns>
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input. 
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
