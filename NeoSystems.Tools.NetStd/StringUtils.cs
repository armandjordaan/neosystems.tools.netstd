/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace NeoSystems.Tools
{
    /// <summary>
    /// neo Systems String utilities
    /// </summary>
    public class StringUtils
    {
        /// <summary>
        /// return only the numerics from dirty string 
        /// </summary>
        /// <param name="dirtystring">The string containng all kinds of chars</param>
        /// <returns>Clean string</returns>
        public static string StringToNumericsOnly(string dirtystring)
        {
            string cleanstring = Regex.Replace(dirtystring, @"[^0-9]", "").Trim(".".ToCharArray());
            return cleanstring;
        }

        /// <summary>
        /// Returns the text string from a string between two other string markers
        /// </summary>
        /// <param name="origtext">Original Text to search in</param>
        /// <param name="marker1">Text marker 1 to look for</param>
        /// <param name="marker2">Text marker 2 to look for</param>
        /// <returns>Text between markers (or empty string if nothing found)</returns>
        public static string GetTextBetweenMarkers(string origtext, string marker1, string marker2)
        {
            string res = "";

            int p1 = origtext.IndexOf(marker1);
            int p2 = origtext.IndexOf(marker2,p1+marker1.Length);
            p1 += marker1.Length;
            res = origtext.Substring(p1,p2-p1);
            return res;
        }

        /// <summary>
        /// Remove a comment from a line, 
        /// </summary>
        /// <param name="s">string to remove comment from</param>
        /// <param name="commentchar">character that starts the comment</param>
        /// <returns>the string with the comment removed</returns>
        public static string RemoveComment(string s, char commentchar)
        {
            string res = s;
            int p = res.IndexOf(commentchar);

            if (p != (-1))
            {
                res = res.Substring(0,p);
            }
            return res;
        }

        /// <summary>
        /// Fill a string s to length l, using char c
        /// </summary>
        /// <param name="s">string to fill</param>
        /// <param name="c">character to fill with</param>
        /// <param name="l">length to fill to</param>
        /// <returns>filled up string</returns>
        public static string FillToLength(string s, char c, int l)
        {
            string fillstr = ConstCharStr(c,l - s.Length);
            return s + fillstr;
        }

        /// <summary>
        /// Convert a software version represented in a word to a version string
        /// (ie 12345 = V 1.23.45)
        /// </summary>
        /// <param name="version">word representing the version</param>
        /// <returns></returns>
        public static string VersionString(ushort version)
        {
            StringBuilder s = new StringBuilder(100);

            int ver = (int)version;

            int major = ver / 10000;
            int minor = ver % 100;

            ver = ver / 100;
            int mid = ver % 100;

            s.Append("V ");
            s.Append(major.ToString() + ".");
            s.Append(mid.ToString("D2") + ".");
            s.Append(minor.ToString("D2"));

            return s.ToString();
        }

        /// <summary>
        /// Method to create and return a constant character array of a specified length
        /// </summary>
        /// <param name="c">character to use in the initialisation of the array</param>
        /// <param name="length">number of elemenets in the array</param>
        /// <returns></returns>
        public static char[] ConstCharArray(char c,int length)
        {
            char[] ca = new char[length];

            for(int i=0; i<length; i++)
            {
                ca[i] = c;
            }
            return ca;
        }

        // ********************************************************************
        /// <summary>
        /// Convert the text to a float, within the parameters given
        /// </summary>
        /// <param name="str">string to convert to a float</param>
        /// <param name="min">minimum allowed value. If the string is less than this value, this value will be used</param>
        /// <param name="def">default value. If an invalid value is entered, the answer will be equal to the default</param>
        /// <param name="max">maximum allowed value. If the string is more than this value, this value will be used</param>
        /// <returns></returns>
        // ********************************************************************
        public static float TextToFloat(string str, float min, float def, float max)
        {
            float temp;

            try
            {
                temp = (float)Convert.ToDouble(str);

                if (temp < min) temp = min;
                if (temp > max) temp = max;
            }
            catch
            {
                temp = def;
            }

            return temp;
        }

        // ********************************************************************
        /// <summary>
        /// Convert a boolean value to a string
        /// </summary>
        /// <param name="Value">Boolean to display</param>
        /// <param name="truestring">String to return for a value that is true</param>
        /// <param name="falsestring">String to return for a value that is false</param>
        public static string BoolToString(bool Value, string truestring = "True", string falsestring = "False")
        {
            if (Value)
            {
                return truestring;
            }
            else
            {
                return falsestring;
            }
        }

        // ********************************************************************
        /// <summary>
        /// Returns a true/false string for a masked bit in a u32 (uint in C#, or System.UInt32) value
        /// </summary>
        /// <param name="value">Bitmasked value</param>
        /// <param name="mask">Mask to test for</param>
        /// <param name="truestring">Text for a value of non zero (Default = "True")</param>
        /// <param name="falsestring">Text for a value of zero (Default = "False")</param>
        /// <returns>string containg truestring or falsestring </returns>
        public static string MaskedBoolToStr(uint value, uint mask, string truestring = "True", string falsestring = "False")
        {
            if ((value & mask) != 0)
            {
                return truestring;
            }
            else
            {
                return falsestring;
            }
        }

        // ********************************************************************
        /// <summary>
        /// Returns a "Yes"/"No" string for a masked bit in a u32 (uint in C#, or System.UInt32) value
        /// </summary>
        /// <param name="value">Bitmasked value</param>
        /// <param name="mask">Mask to test for</param>
        /// <returns>string containg "Yes" or "No"</returns>
        public static string MaskedBoolToYesNo(uint value, uint mask)
        {
            return MaskedBoolToStr(value,mask,"Yes","No");
        }

        // ********************************************************************
        /// <summary>
        /// Returns a "Active"/"Inactive" string for a masked bit in a u32 (uint in C#, or System.UInt32) value
        /// </summary>
        /// <param name="value">Bitmasked value</param>
        /// <param name="mask">Mask to test for</param>
        /// <returns>string containg "Active" or "Inactive"</returns>
        public static string MaskedBoolToActiveInactive(uint value, uint mask)
        {
            return MaskedBoolToStr(value, mask, "Active", "Inactive");
        }

        /// <summary>
        /// Replace multiple characters in a string with a particaluar character
        /// </summary>
        /// <param name="old_multichars">a string containg the characters to be replaced</param>
        /// <param name="newchar">the new character to replace with</param>
        /// <param name="str">the result string where characters hace been replaced</param>
        /// <returns></returns>
        public static string MultiCharReplace(string old_multichars, char newchar, string str)
        {
            string res = str;
            foreach(char c in old_multichars)
            {
                res = res.Replace(c,newchar);
            }

            return res;
        }

        /// <summary>
        /// Convert a string so that it can be used as a identifier
        /// </summary>
        /// <param name="str">string description</param>
        /// <returns>string to be used as an identifier</returns>
        public static string StringToIdentifier(string str)
        {
            string t = MultiCharReplace(@" `¬!""£$%^&*()+=-;'#:@~,./<>?\|",'_',str);
            try
            {
                if (Char.IsNumber(t[0]))
                {
                    t = "a" + t;
                }
            }
            catch
            {
            }
            return t;
        }

        /// <summary>
        /// Returns a string filled with count x the specified char
        /// </summary>
        /// <param name="c">char to use</param>
        /// <param name="count">number of chars</param>
        /// <returns>string contain count x specified char</returns>
        public static string ConstCharStr(char c, int count)
        {
            StringBuilder sb = new StringBuilder(count+2);

            for(int i=0; i<count; i++)
            {
                sb.Append(c);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Options for the SplitOnSize method
        /// </summary>
        [Flags]
        public enum SplitOnSizeOptions 
        {
            /// <summary>
            /// When splitting, make sure whole words are kept together
            /// </summary>
            WholeWords = 1
        }

        /// <summary>
        /// Split a string into seperate string not bigger than a specified size
        /// </summary>
        /// <param name="str">string to split</param>
        /// <param name="maxsize">maximum string size</param>
        /// <param name="opt">split options</param>
        /// <returns>array of strings</returns>
        public static string[] SplitOnSize(string str, int maxsize, SplitOnSizeOptions opt)
        {
            List<string>strs = new List<string>();
            SplitOnSizeOptions options = opt;

            while(str.Length > maxsize)
            {
                int ls = maxsize;

                // note cannot use HasFlag because HasFlag is for .NET framework >= 4.0
                if ((options & SplitOnSizeOptions.WholeWords) != 0)
                {
                    if  (ls < (str.Length-1))
                    {
                        if (str[ls] != ' ')
                        {
                            ls++;
                        }
                    }
                }
                string temp = str.Substring(0,ls);
                str = str.Substring(ls);
                strs.Add(temp);
            }

            if (str.Length != 0)
            {
                strs.Add(str);
            }
            return strs.ToArray();
        }

        /// <summary>
        /// Count the number of occurences of the leading char c in string s
        /// </summary>
        /// <param name="s">string s to look in</param>
        /// <param name="c">leading char c</param>
        /// <returns>the number of leading characters c in string s</returns>
        public static int CountLeading(string s, char c)
        {
            int res = 0;

            for(int i=0; i<s.Length; i++)
            {
                if (s[i] != c) return res;
                res++;
            }

            return res;
        }

        /// <summary>
        /// Trim all the text in s to the end from the last occurence of c
        /// </summary>
        /// <param name="s">string to trim</param>
        /// <param name="c">c - last character to trim from onwards</param>
        /// <returns>new trimmed string</returns>
        public static string TrimFromLast(string s, char c)
        {
            int idx = s.LastIndexOf(c);

            if (idx == 0)
            {
                return s;
            }
            else
            {
                return s.Substring(0,idx);
            }
        }

        /// <summary>
        /// Tests if a string is a South African cellphone number
        /// </summary>
        /// <param name="num">Phone Number string</param>
        /// <returns>true if cellphone number, false if not a cellphone number</returns>
        public static bool IsZARCellPhoneNumber(string num)
        {
            try
            {
                bool res = false;
                string s = num.Trim();
                s = s.Substring(0,3);

                if ((s.Contains("081")) ||
                    (s.Contains("082")) ||
                    (s.Contains("083")) ||
                    (s.Contains("084")) ||
                    (s.Contains("071")) ||
                    (s.Contains("072")) ||
                    (s.Contains("073")) ||
                    (s.Contains("074")) ||
                    (s.Contains("076"))
                    )
                {
                    res = true;
                }

                return res;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Compact white spaces
        /// </summary>
        /// <param name="s">string to compact</param>
        /// <returns></returns>
        public static String CompactWhitespaces(String s)
        {
            StringBuilder sb = new StringBuilder(s);

            CompactWhitespaces(sb);

            return sb.ToString();
        }

        /// <summary>
        /// Compact white spaces
        /// </summary>
        /// <param name="sb">Stringbuilder class instance</param>
        public static void CompactWhitespaces(StringBuilder sb)
        {
            if (sb.Length == 0)
                return;

            // set [start] to first not-whitespace char or to sb.Length

            int start = 0;

            while (start < sb.Length)
            {
                if (Char.IsWhiteSpace(sb[start]))
                    start++;
                else
                    break;
            }

            // if [sb] has only whitespaces, then return empty string

            if (start == sb.Length)
            {
                sb.Length = 0;
                return;
            }

            // set [end] to last not-whitespace char

            int end = sb.Length - 1;

            while (end >= 0)
            {
                if (Char.IsWhiteSpace(sb[end]))
                    end--;
                else
                    break;
            }

            // compact string

            int dest = 0;
            bool previousIsWhitespace = false;

            for (int i = start; i <= end; i++)
            {
                if (Char.IsWhiteSpace(sb[i]))
                {
                    if (!previousIsWhitespace)
                    {
                        previousIsWhitespace = true;
                        sb[dest] = ' ';
                        dest++;
                    }
                }
                else
                {
                    previousIsWhitespace = false;
                    sb[dest] = sb[i];
                    dest++;
                }
            }

            sb.Length = dest;
        }

        /// <summary>
        /// Convert a byte array to a string of hex chars
        /// </summary>
        /// <param name="ba">byte array to convert to a string</param>
        /// <returns>A string representing the byte array</returns>
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        /// <summary>
        /// Convert a byte array to a string of hex chars. If the offset goes beyond
        /// the boundary of the array the string will be cut short.
        /// </summary>
        /// <param name="ba">byte array to convert to a string</param>
        /// <param name="offs">offset where to convert</param>
        /// <param name="len">Number of bytes to convert</param>
        /// <returns>A string representing the byte array</returns>
        public static string ByteArrayToString(byte[] ba, int offs, int len)
        {
            StringBuilder hex = new StringBuilder(len * 2);
            for (int i = offs; (i<(ba.Length+offs)) && (i<(len+offs)); i++)
            {
                hex.AppendFormat("{0:x2}", ba[i]);
            }
            return hex.ToString();
        }

        /// <summary>
        /// convert a HEX character to a byte
        /// </summary>
        /// <returns></returns>
        public static byte HexCharToByte(char c)
        {
            byte result=0;

            if ((c >= '0') && (c <= '9'))
            {
                result = (byte)(c - '0');
            }
            else if ((c >= 'A') && (c <= 'F'))
            {
                result = (byte)(c - 'A');
                result += 10;
            }
            else if ((c >= 'a') && (c <= 'f'))
            {
                result = (byte)(c - 'a');
                result += 10;
            }

            return result;
        }
    }


}