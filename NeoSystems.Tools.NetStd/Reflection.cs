/* License: GLPLV3 - See License.txt */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace NeoSystems.Tools
{
    /// <summary>
    /// Refelection utility class
    /// </summary>
    public static class ReflectionUtils
    {
        /// <summary>
        /// Get a method's parameters
        /// </summary>
        /// <returns></returns>
        public static string[] GetMethodParameters()
        {
            throw new NotImplementedException("GetMethodParameters() is not implemented!");
        }

        /// <summary>
        /// get an array of strings with property names and values
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string[] GetClassPropertiesSimple(object obj)
        {
            List<string> d = new List<string>();

            foreach (var prop in obj.GetType().GetProperties())
            {
                if (prop.GetIndexParameters().Length > 0)
                {
                    for(int i=0; i< prop.GetIndexParameters().Length; i++)
                    {
                        string s1 = string.Format("[{0}]{1} = {2}",i,prop.Name, prop.GetValue(obj, new object[] { i }));
                        d.Add(s1);
                    }
                }
                else
                {
                    string s2 = string.Format("{0} = {1} : {2}", prop.Name, prop.GetValue(obj, null), prop.GetIndexParameters().Length);
                    d.Add(s2);
                }
            }

            return d.ToArray();
        }

#if false
        /// <summary>
        /// get class properties
        /// </summary>
        /// <param name="obj">object to check</param>
        /// <return>return value: string</return>
        public static void GetClassProperties(object obj)
        {
            Type type = obj.GetType();

            PropertyInfo[] properties = type.GetProperties();

            // if this obj has sub properties, apply this process to those rather than this.
            if (properties.Length > 0)
            {
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (prop.PropertyType.FindInterfaces((t, c) => t == typeof(IEnumerable), null).Length > 0)
                    {
                        MethodInfo accessor = prop.GetGetMethod();
                        MethodInfo[] accessors = prop.GetAccessors();

                        foreach (object item in (IEnumerable)obj)
                        {
                            GetClassProperties(item);
                        }
                    }
                    else if (prop.GetIndexParameters().Length > 0)
                    {
                        // get an integer count value, by incrementing a counter until the exception is thrown
                        int count = 0;
                        while (true)
                        {
                            try
                            {
                                prop.GetValue(obj, new object[] { count });
                                count++;
                            }
                            catch (TargetInvocationException) { break; }
                        }

                        for (int i = 0; i < count; i++)
                        {
                            // process the items value
                            GetClassProperties(prop.GetValue(obj, new object[] { i }));
                        }
                    }
                    else
                    {
                        // is normal type so.
                        GetClassProperties(prop.GetValue(obj, null));
                    }
                }
            }
            else
            {
                // process to be applied to each property
                Console.WriteLine("Property value: {0}", obj.ToString());
            }
        }
#endif

        /// <summary>
        /// Return a string desciption of the class properties
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>string</returns>
        public static string GetClassPropertiesString(object obj)
        {
            string[] propstr = GetClassPropertiesSimple(obj);

            StringBuilder str = new StringBuilder(4096);

            foreach(string s in propstr)
            {
                str.AppendLine(s);
            }

            return str.ToString();
        }
    }
}
