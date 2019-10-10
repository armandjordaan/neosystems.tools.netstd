/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Specialized;
using System.Text;
using System.Net;
using System.IO;

namespace NeoSystems.Tools
{
    /// <summary>
    /// Various web utilities
    /// </summary>
    public class WebUtils
    {
        /// <summary>
        /// Returns the content of a given web adress as string.
        /// </summary>
        /// <param name="Url">URL of the webpage</param>
        /// <returns>Website content</returns>
        public static string DownloadWebPage(string Url)
        {
            try
            {
                // Open a connection
                HttpWebRequest WebRequestObject = (HttpWebRequest)HttpWebRequest.Create(Url);
 
                // You can also specify additional header values like 
                // the user agent or the referer:
                WebRequestObject.UserAgent	= ".NET Framework/2.0";
                WebRequestObject.Referer	= "http://www.example.com/";
 
                // Request response:
                WebResponse Response = WebRequestObject.GetResponse();
 
                // Open data stream:
                Stream WebStream = Response.GetResponseStream();
 
                // Create reader object:
                StreamReader Reader = new StreamReader(WebStream);
 
                // Read the entire stream content:
                string PageContent = Reader.ReadToEnd();
 
                // Cleanup
                Reader.Close();
                WebStream.Close();
                Response.Close();
 
                return PageContent;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// structure to hold form POST data
        /// </summary>
        public struct FormData
        {
            /// <summary>
            /// Field name
            /// </summary>
            public string field;

            /// <summary>
            /// Field value
            /// </summary>
            public string value;
        }

        /// <summary>
        /// Do a post to a site and return the response in a string
        /// </summary>
        /// <param name="url">Website address</param>
        /// <param name="frmdat">Array of formdata</param>
        /// <returns>string response from website/service</returns>
        public static string DoPOST(string url, FormData[] frmdat)
        {
            WebClient webClient = new WebClient();

            NameValueCollection formData = new NameValueCollection();
            foreach(FormData f in frmdat)
            {
                formData[f.field] = f.value;
            }
            
            byte[] responseBytes = webClient.UploadValues(url, "POST", formData);
            string result = Encoding.UTF8.GetString(responseBytes);            

            webClient.Dispose();

            return result;
        }
    }


}
