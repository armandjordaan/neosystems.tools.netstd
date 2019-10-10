/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace NeoSystems.Tools
{
    // ************************************************************************
    /// <summary>
    /// General file utilities
    /// </summary>
    public class FileUtils
    {
        /// <summary>
        /// Make a valid filename from a string with invalid filename chars
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string MakeValidFileName(string name)
        {
            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return Regex.Replace(name, invalidRegStr, "_");
        }

        /// <summary>
        /// Delegate method for repeated performing an operation on files
        /// </summary>
        /// <param name="Filename"></param>
        /// <returns>true if success, false if error occured</returns>
        public delegate bool DoForFile(string Filename);

        // ************************************************************************
        /// <summary>
        /// Repeat df for all files matching the pattern
        /// </summary>
        /// <param name="FolderPath">Folder to search for files</param>
        /// <param name="pattern">Pattern of files to look for</param>
        /// <param name="df">delegate to call</param>
        /// <param name="RecurseSubDirs">option to look in subfolders</param>
        public static void DoForAllFiles(string FolderPath, string pattern, DoForFile df, bool RecurseSubDirs = false)
        {
            SearchOption s;
            if (RecurseSubDirs)
            {
                s = SearchOption.AllDirectories;
            }
            else
            {
                s = SearchOption.TopDirectoryOnly;
            }

            string[] FileArray = Directory.GetFiles(FolderPath,pattern,s);
            //string[] DirArray = Directory.GetDirectories(FolderPath,"*.*",s);

            foreach(string file in FileArray)
            {
                df(file);
            }

            /*
            if (RecurseSubDirs)
            {
                foreach(string dir in DirArray)
                {
                    DoForAllFiles(FolderPath + Path.DirectorySeparatorChar + dir, pattern, df, RecurseSubDirs);
                }
            }*/
        }

        // ************************************************************************
        /// <summary>
        /// Get a unique filename based on the time and date
        /// </summary>
        /// <returns>a unique string usable as a filename</returns>
        public static string GetUniqueFilename()
        {
            string temp = DateTime.Now.ToString();
            temp = temp.Replace('/', '_');
            temp = temp.Replace(' ', '_');
            temp = temp.Replace(':', '_');
            return temp;
        }

        // ************************************************************************
        /// <summary>
        /// Method to get easy access to the current users my Documents
        /// </summary>
        /// <returns>Folder path to current user's "My Documents"</returns>
        public static string GetUserPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        // ************************************************************************
        /// <summary>
        /// Get the user data path for this app. If it does not exist then it is created
        /// </summary>
        /// <param name="AppPath">Name of the folder used to store files for the application</param>
        /// <returns>The full folder path is returned.</returns>
        public static string GetUserAppDataPath(string AppPath)
        {
            string path = GetUserPath();
            //path = path + "\\" + AppPath;
            path = path + Path.DirectorySeparatorChar + AppPath;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        /// <summary>
        /// returns the application filename
        /// </summary>
        /// <returns>filename of application</returns>
        public static string GetApplicationFilename()
        {
            return Process.GetCurrentProcess().MainModule.FileName;
        }

        /// <summary>
        /// returns the path to the application executable
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationPath()
        {
            return Path.GetFullPath(Process.GetCurrentProcess().MainModule.FileName);
        }

        /// <summary>
        /// Append text to any file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="text"></param>
        public static void AppendTextToFile(string filename,string text)
        {
            // This text is always added, making the file longer over time 
            // if it is not deleted. 
            using (StreamWriter sw = File.AppendText(filename)) 
            {
                sw.Write(text);
            }
        }

        /// <summary>
        /// append one file to another
        /// </summary>
        /// <param name="originalfile">original file</param>
        /// <param name="appendfile">file to append to original file</param>
        public static void AppendFileToFile(string originalfile, string appendfile)
        {
            using (StreamWriter w = File.AppendText(originalfile))
            {
                using (StreamReader r = File.OpenText(appendfile))
                {
                    while (!r.EndOfStream)
                    {
                        w.WriteLine(r.ReadLine());
                    }
                }
            }
        }
    }

    // ************************************************************************
    /// <summary>
    /// Various XML tools
    /// </summary>
    public class Xml<T>
    {
        // ************************************************************************
        /// <summary>
        /// Stream an object to an XML file.
        /// Note that this method might not work for derived classes
        /// </summary>
        /// <param name="o">Object reference</param>
        /// <param name="filename">File to save to</param>
        public static void SaveToXml(object o, string filename)
        {
            XmlSerializer writer = new XmlSerializer(o.GetType());
            StreamWriter file = new StreamWriter(filename);
            writer.Serialize(file, o);
            file.Close();
        }

        /// *******************************************************************
        /// <summary>
        /// Load the settings
        /// Note that this method might not work for derived classes
        /// </summary>
        /// <param name="t">Object reference (type T)</param>
        /// <param name="filename">File to save to</param>
        /// *******************************************************************
        public static void LoadFromXml(ref T t, string filename)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StreamReader reader = new StreamReader(filename);

                // serialize the object to disk
                t = (T)(serializer.Deserialize(reader));

                // close the writer to release the file resource
                reader.Close();
            }
            catch(Exception ex)
            {
                SaveToXml(t, filename);
                throw ex;
            }
        }
    }

    // ************************************************************************
    /// <summary>
    /// CSVWriter is based on StreamWriter and is used to write simple CSV files
    /// </summary>
    public class CSVWriter : StreamWriter
    {
        private char FSeparationCharacter;

        // ************************************************************************
        /// <summary>
        /// SeparationCharacter is the CSV separation character
        /// </summary>
        public char SeparationCharacter
        {
            get
            {
                return FSeparationCharacter;
            }
            set
            {
                FSeparationCharacter = value;
            }
        }

        // ************************************************************************
        /// <summary>
        /// Constructor for CSVWrite class to write to a CSV file
        /// </summary>
        /// <param name="path">filename to write to</param>
        public CSVWriter(string path)
            : base(path)
        {
            SeparationCharacter = ',';
        }

        // ************************************************************************
        /// <summary>
        /// Write a string value - the separation character will be added automatically
        /// </summary>
        /// <param name="x"></param>
        public void WriteField(string x)
        {
            Write(x + SeparationCharacter);
        }

        // ************************************************************************
        /// <summary>
        /// Write a newline to the CSV file
        /// </summary>
        public void WriteNewLine()
        {
            Write(Environment.NewLine);
        }
    }

    /// <summary>
    /// A simple logger class to log application events
    /// </summary>
    public static class SimpleLogger
    {
        /// <summary>
        /// LogLevel defines the different levels of logging (eg DEBUG, INFO etc)
        /// </summary>
        [Flags]
        public enum LogLevel : uint
        {
            /// <summary>
            /// No logging
            /// </summary>
            None        = 1,

            /// <summary>
            /// Log information 
            /// </summary>
            Information = 2,

            /// <summary>
            /// Log Warnings
            /// </summary>
            Warnings    = 4,

            /// <summary>
            /// Log Errors
            /// </summary>
            Errors      = 8,

            /// <summary>
            /// Log Debug info
            /// </summary>
            Debug       = 16,

            /// <summary>
            /// Log Critical info
            /// </summary>
            Critical    = 32,

            /// <summary>
            /// Log Trace information
            /// </summary>
            Trace       = 64,

            /// <summary>
            /// Log All
            /// </summary>
            All         = 0xFFFFFFFF 
        }
           
        private static LogLevel m_Level = LogLevel.Trace | LogLevel.Errors;
        private static string m_Filename = "log.txt";

        /// <summary>
        /// Current logger level property 
        /// </summary>
        public static LogLevel Level
        {
            get { return m_Level; }
            set { m_Level = value; }
        }

        /// <summary>
        /// Current logger filename property
        /// </summary>
        public static string Filename
        {
            get { return m_Filename; }
            set { m_Filename = value; }
        }

        private static Mutex mut = new Mutex();

        /// <summary>
        /// Simple logger static constructor 
        /// </summary>
        static SimpleLogger()
        {
            // AJTODO
            /* new command line log mechanism 
            NeoSystems.Tools.General.Commandline.SetStringParam("--logfile",ref m_Filename,
                "Set the logger filename");
                */
        }

        private static int m_MethodStrWidth   = 0;
        private static int m_FilenameStrWidth = 0;
        private static int m_lineNumStrWidth  = 0;

        /// <summary>
        /// Log data to the current log file
        /// </summary>
        /// <param name="l">Loglevel to log this message</param>
        /// <param name="s">message to log</param>
        public static void Log(LogLevel l, string s)
        {
            if ((Level & l) == 0) return;

            mut.WaitOne();
    
            StackTrace stackTrace = new StackTrace(true);
            StackFrame sf = stackTrace.GetFrame(1);

            string Methodstr   = sf.GetMethod().ToString();
            string Filenamestr = sf.GetFileName();
            string Linenumstr  = sf.GetFileLineNumber().ToString();

            if (Methodstr.Length > m_MethodStrWidth) m_MethodStrWidth       = Methodstr.Length;
            if (Filenamestr.Length > m_FilenameStrWidth) m_FilenameStrWidth = Filenamestr.Length;
            if (Linenumstr.Length > m_lineNumStrWidth) m_lineNumStrWidth    = Linenumstr.Length;

            Methodstr   = StringUtils.FillToLength(Methodstr,   ' ', m_MethodStrWidth);
            Filenamestr = StringUtils.FillToLength(Filenamestr, ' ', m_FilenameStrWidth);
            Linenumstr  = StringUtils.FillToLength(Linenumstr,  ' ', m_lineNumStrWidth);

            StreamWriter sw = new StreamWriter(Filename,true);            
            sw.WriteLine("M:" + Methodstr + "\tF:" +
                Filenamestr + "\tL:" +
                Linenumstr + "\tD:" + 
                DateTime.Now.ToShortDateString() + " " + 
                DateTime.Now.ToLongTimeString() + "\tT:" +
                s);
            sw.Close();

            mut.ReleaseMutex();
        }
    }

    /// <summary>
    /// class with file pattern match methods
    /// </summary>
    public static class PatternMatch
    {
        /// <summary>
        /// Find matching file patterns in an array
        /// </summary>
        /// <param name="pattern">pattern to find</param>
        /// <param name="names">file name array</param>
        /// <returns>string with matching names</returns>
        public static string[] FindMatchingFiles(string pattern, string[] names)
        {
            List<string> matches = new List<string>();
            Regex regex = FindFilesPatternToRegex.Convert(pattern);
            foreach (string s in names)
            {
                if (regex.IsMatch(s))
                {
                    matches.Add(s);
                }
            }
            return matches.ToArray();
        }
    }

    /// <summary>
    /// Class with method to convert a file pattern to a Regex value
    /// 
    /// Courtesy of user sprite on http://stackoverflow.com/questions/652037/how-do-i-check-if-a-filename-matches-a-wildcard-pattern
    /// 
    /// </summary>
    public static class FindFilesPatternToRegex
    {
        private static Regex HasQuestionMarkRegEx = new Regex(@"\?", RegexOptions.Compiled);
        private static Regex IllegalCharactersRegex = new Regex("[" + @"\/:<>|" + "\"]", RegexOptions.Compiled);
        private static Regex CatchExtentionRegex = new Regex(@"^\s*.+\.([^\.]+)\s*$", RegexOptions.Compiled);
        private static string NonDotCharacters = @"[^.]*";

        /// <summary>
        /// Convert a file pattern to a regex value
        /// </summary>
        /// <param name="pattern">File Pattern</param>
        /// <returns>Regex value</returns>
        public static Regex Convert(string pattern)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException();
            }
            pattern = pattern.Trim();
            if (pattern.Length == 0)
            {
                throw new ArgumentException("Pattern is empty.");
            }
            if (IllegalCharactersRegex.IsMatch(pattern))
            {
                throw new ArgumentException("Pattern contains illegal characters.");
            }
            bool hasExtension = CatchExtentionRegex.IsMatch(pattern);
            bool matchExact = false;
            if (HasQuestionMarkRegEx.IsMatch(pattern))
            {
                matchExact = true;
            }
            else if (hasExtension)
            {
                matchExact = CatchExtentionRegex.Match(pattern).Groups[1].Length != 3;
            }
            string regexString = Regex.Escape(pattern);
            regexString = "^" + Regex.Replace(regexString, @"\\\*", ".*");
            regexString = Regex.Replace(regexString, @"\\\?", ".");
            if (!matchExact && hasExtension)
            {
                regexString += NonDotCharacters;
            }
            regexString += "$";
            Regex regex = new Regex(regexString, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex;
        }
    }
}
