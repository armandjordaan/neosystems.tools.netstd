/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NeoSystems.Tools.StringUtils;

namespace NeoSystems.Tools
{

    /// <summary>
    /// string class extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// case insensitive contains
        /// </summary>
        /// <param name="source">source class</param>
        /// <param name="toCheck">string to check for contains</param>
        /// <param name="comp">comparison type</param>
        /// <returns></returns>
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }

        /// <summary>
        /// test if a string contains ASCII characters only
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsASCIIOnly(this string source)
        {
            // ASCII encoding replaces non-ascii with question marks, so we use UTF8 to see if multi-byte sequences are there
            return Encoding.UTF8.GetByteCount(source) == source.Length;
        }

        /// <summary>
        /// Remove all occurences of the character r in the string
        /// </summary>
        /// <param name="s">string object ref</param>
        /// <param name="r">char to remove</param>
        /// <returns>string</returns>
        public static string RemoveAll(this string s, char r)
        {
            string t = r.ToString();

            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        public enum CommentType
        {
            /// <summary>
            /// Traditional C comments
            /// </summary>
            TraditionalC,

            /// <summary>
            /// Comments with Hash char
            /// </summary>
            HashCharComments,

            /// <summary>
            /// Traditional C comments
            /// </summary>
            Cplusplus,
        }

        /// <summary>
        /// Position of the comment, in front of all lines are after all lines
        /// </summary>
        public enum CommentPosition
        {
            /// <summary>
            /// add comment in front of the text
            /// </summary>
            Front,

            /// <summary>
            /// Add comment after the text
            /// </summary>
            After
        }

        /// <summary>
        /// add comments to a block represented by string arrays
        /// </summary>
        /// <param name="lines">array of strings to be commented</param>
        /// <param name="commentstringFront">comment text to be added in front</param>
        /// <param name="commentstringAfter">text to added afetr</param>
        /// <returns>string arrays with comments</returns>
        public static void Comment(this string[] lines, string commentstringFront, string commentstringAfter)
        {
            for (int i = 0; i < lines.Count(); i++)
            {
                lines[i] = commentstringFront + lines[i];
            }
        }

        /// <summary>
        /// add comments to a block represented by string arrays
        /// </summary>
        /// <param name="lines">array of strings to be commented</param>
        /// <param name="type">type of comment to be added</param>
        /// <param name="position">Where to add the comments</param>
        /// <returns></returns>
        public static void Comment(this string[] lines, CommentType type, CommentPosition position = CommentPosition.Front)
        {
            string commentstringFront = "";
            string commentstringBack = "";

            if (position == CommentPosition.Front)
            {
                switch (type)
                {
                    case CommentType.HashCharComments:
                        commentstringFront = "# ";
                        break;

                    case CommentType.TraditionalC:
                        commentstringFront = "/* ";
                        commentstringBack = " */";
                        break;

                    case CommentType.Cplusplus: // implicitly front and back
                        commentstringFront = "// ";
                        break;
                }
            }
            else
            {
                switch (type)
                {
                    case CommentType.HashCharComments:
                        commentstringBack = " #";
                        break;

                    case CommentType.TraditionalC:
                        commentstringFront = "/* ";
                        commentstringBack = " */";
                        break;


                    case CommentType.Cplusplus: // implicitly front and back
                        commentstringBack = " //";
                        break;
                }
            }

            Comment(lines, commentstringFront, commentstringBack);
        }

        /// <summary>
        /// string extension: return the text between two markers
        /// </summary>
        /// <param name="origtext"></param>
        /// <param name="marker1"></param>
        /// <param name="marker2"></param>
        /// <returns></returns>
        public static string GetTextBetweenMarkers(this string origtext, string marker1, string marker2)
        {
            return StringUtils.GetTextBetweenMarkers(origtext,marker1,marker2);
        }

        /// <summary>
        /// string extennsionreturn only the numerics from dirty string 
        /// </summary>
        /// <param name="dirtystring">The string containng all kinds of chars</param>
        /// <returns>Clean string</returns>
        public static string StringToNumericsOnly(this string dirtystring)
        {
            return StringUtils.StringToNumericsOnly(dirtystring);
        }

        /// <summary>
        /// string extension: Remove a comment from a line, 
        /// </summary>
        /// <param name="s">string to remove comment from</param>
        /// <param name="commentchar">character that starts the comment</param>
        /// <returns>the string with the comment removed</returns>
        public static string RemoveComment(this string s, char commentchar)
        {
            return StringUtils.RemoveComment(s,commentchar);
        }

        /// <summary>
        /// string extension: Fill a string s to length l, using char c
        /// </summary>
        /// <param name="s">string to fill</param>
        /// <param name="c">character to fill with</param>
        /// <param name="l">length to fill to</param>
        /// <returns>filled up string</returns>
        public static string FillToLength(this string s, char c, int l)
        {
            return StringUtils.FillToLength(s,c,l);
        }
        
        // ********************************************************************
        /// <summary>
        /// string extensions: Convert the text to a float, within the parameters given
        /// </summary>
        /// <param name="str">string to convert to a float</param>
        /// <param name="min">minimum allowed value. If the string is less than this value, this value will be used</param>
        /// <param name="def">default value. If an invalid value is entered, the answer will be equal to the default</param>
        /// <param name="max">maximum allowed value. If the string is more than this value, this value will be used</param>
        /// <returns></returns>
        // ********************************************************************
        public static float TextToFloat(this string str, float min, float def, float max)
        {
            return StringUtils.TextToFloat(str,min,def,max);
        }

        /// <summary>
        /// string extension: Replace multiple characters in a string with a particaluar character
        /// </summary>
        /// <param name="old_multichars">a string containg the characters to be replaced</param>
        /// <param name="newchar">the new character to replace with</param>
        /// <param name="str">the result string where characters have been replaced</param>
        /// <returns></returns>
        public static string MultiCharReplace(this string str, string old_multichars, char newchar)
        {
            return StringUtils.MultiCharReplace(old_multichars,newchar,str);
        }

        /// <summary>
        /// string extension: Convert a string so that it can be used as a identifier
        /// </summary>
        /// <param name="str">string description</param>
        /// <returns>string to be used as an identifier</returns>
        public static string StringToIdentifier(this string str)
        {
            return StringUtils.StringToIdentifier(str);
        }

        /// <summary>
        /// string extension: Split a string into seperate string not bigger than a specified size
        /// </summary>
        /// <param name="str">string to split</param>
        /// <param name="maxsize">maximum string size</param>
        /// <param name="opt">split options</param>
        /// <returns>array of strings</returns>
        public static string[] SplitOnSize(this string str, int maxsize, SplitOnSizeOptions opt)
        {
            return StringUtils.SplitOnSize(str,maxsize,opt);
        }

        /// <summary>
        /// string extension: Count the number of occurences of the leading char c in string s
        /// </summary>
        /// <param name="s">string s to look in</param>
        /// <param name="c">leading char c</param>
        /// <returns>the number of leading characters c in string s</returns>
        public static int CountLeading(this string s, char c)
        {
            return StringUtils.CountLeading(s,c);
        }

        /// <summary>
        /// string extension: Trim all the text in s to the end from the last occurence of c
        /// </summary>
        /// <param name="s">string to trim</param>
        /// <param name="c">c - last character to trim from onwards</param>
        /// <returns>new trimmed string</returns>
        public static string TrimFromLast(this string s, char c)
        {
            return StringUtils.TrimFromLast(s,c);
        }

        /// <summary>
        /// string extension: Tests if a string is a South African cellphone number
        /// </summary>
        /// <param name="num">Phone Number string</param>
        /// <returns>true if cellphone number, false if not a cellphone number</returns>
        public static bool IsZARCellPhoneNumber(this string num)
        {
            return StringUtils.IsZARCellPhoneNumber(num);;
        }     

        /// <summary>
        /// string extension: Compact white spaces
        /// </summary>
        /// <param name="s">string to compact</param>
        /// <returns></returns>
        public static String CompactWhitespaces(this string s)
        {
            return StringUtils.CompactWhitespaces(s);
        }
    }
}
