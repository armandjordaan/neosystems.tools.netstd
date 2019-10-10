/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeoSystems.Tools
{
    /// <summary>
    /// Basic application interfaces
    /// </summary>
    public interface IBaseApplication
    {
        /// <summary>
        /// Apply settings
        /// </summary>
        void ApplySettings();

        /// <summary>
        /// Load settings
        /// </summary>
        void LoadSettings();

        /// <summary>
        /// Save settings
        /// </summary>
        void SaveSettings();

        /// <summary>
        /// Application start handler
        /// </summary>
        void OnApplicationStart();

        /// <summary>
        /// Application close handler
        /// </summary>
        void OnApplicationClose();
    }
}
