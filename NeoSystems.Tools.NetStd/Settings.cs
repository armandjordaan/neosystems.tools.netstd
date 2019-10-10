/* License: GLPLV3 - See License.txt */

using System;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Reflection;
using System.Xml.Serialization;

namespace NeoSystems.Tools.Xml
{
    /// <summary>
    /// Serializable object - inherit to use
    /// WARNING - This class has never been tested! load Method is not completed!
    /// </summary>
	public abstract class XmlSerializable
	{
        /// <summary>
        /// Save method
        /// </summary>
        /// <param name="path">path to save to</param>
		public virtual void Save(string path)
		{
			StreamWriter w = new StreamWriter(path);
			XmlSerializer s = new XmlSerializer(this.GetType());
			s.Serialize(w, this);
			w.Close();
		}

        /// <summary>
        /// Load method - NOT IMPLEMENTED - To be done in future!
        /// </summary>
        /// <param name="path">Path to load from</param>
		public virtual void Load(string path)
		{
		}
	}
}