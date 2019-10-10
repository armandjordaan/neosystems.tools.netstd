/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace NeoSystems.Tools
{
    // ********************************************************************
    /// <summary>
    /// class with utilities to work with enums
    /// </summary>
    public static class EnumUtils
    {
        // ********************************************************************
        /// <summary>
        /// Method to get the number of elements in an enum
        /// IMPORTANT NOTE: this has not been tested at all. Not guearanteed to 
        /// work!!!!!!
        /// </summary>
        /// <param name="EnumName">string containing the enum name</param>
        /// <returns>number of elements in the enum name</returns>
        public static int GetNumberElements(string EnumName)
        {
            try
            {
                Type enumType = Type.GetType(EnumName);
                int numElementsInEnum = Enum.GetValues(enumType).Length;

                return numElementsInEnum;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // ********************************************************************
        /// <summary>
        /// Retrieve the description on the enum, e.g.
        /// [Description("Bright Pink")]
        /// BrightPink = 2,
        /// Then when you pass in the enum, it will retrieve the description
        /// </summary>
        /// <param name="en">The Enumeration</param>
        /// <returns>A string representing the friendly name</returns>
        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }

        // ********************************************************************
        /// <summary>
        /// Get an array of descriptions from a enumeration
        /// </summary>
        /// <param name="enumType">enumeration type to get the descriptions for</param>
        /// <returns>Array of strings containg the descriptions</returns>
        public static string[] GetDescriptions(Type enumType)
        {
            List<string> res = new List<string>();

            string[] enumnames = Enum.GetNames(enumType);

            foreach (string enumname in enumnames)
            {
                MemberInfo[] memInfo = enumType.GetMember(enumname);

                if (memInfo != null && memInfo.Length > 0)
                {
                    object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (attrs != null && attrs.Length > 0)
                    {
                        res.Add(((DescriptionAttribute)attrs[0]).Description);
                    }
                    else
                    {
                        res.Add(enumname);
                    }
                }
                else
                {
                    res.Add(enumname);
                }
            }
            return res.ToArray();
        }

    }

}
