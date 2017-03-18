using EnvDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecByExample.T4
{
    /// <summary>
    /// Helpers to work on a DTE instance.
    /// </summary>
    public static class DteHelperExtensions
    {
        /// <summary>
        /// Access the current project and get a value from one of its properties
        /// </summary>
        /// <param name="dte">Reference to the DTE</param>
        /// <param name="propertyName">Name of the property to lookup</param>
        /// <returns>Value of the property or null if not found.</returns>
        public static string GetProjectPropertyValue(this _DTE dte, string propertyName)
        {
            var projects = dte.ActiveSolutionProjects as Array;
            if (projects.Length > 0)
            {
                Project currentproject = projects.GetValue(0) as Project;
                var fullFilename = currentproject.FullName;
                foreach (var prop in currentproject.Properties)
                {
                    var p = (prop as Property);
                    if (p.Name == propertyName)
                        return p.Value.ToString();
                }
            }
            return null;
        }

        /// <summary>
        /// Get the current Visual Studio project
        /// </summary>
        /// <returns></returns>
        public static Project GetCurrentProject(this _DTE dte)
        {
            var projects = dte.ActiveSolutionProjects as Array;
            if (projects.Length > 0)
            {
                Project currentproject = projects.GetValue(0) as Project;
                return currentproject;
            }
            return null;
        }

        /// <summary>
        /// Derive the Root Namespace.
        /// </summary>
        /// <param name="dte">Reference to the Development environment itself.</param>
        /// <param name="dictionary">All key/value pairs to use for replacement.</param>
        /// <returns>Root namespace to use for a given situation.</returns>
        public static string GetRootNamespace(this _DTE dte, Dictionary<string, string> dictionary)
        {
            string rootNamespace;
            if (dictionary.ContainsKey(PlaceholdersName.SafeProjectName))
            {
                // For project templates
                string projectname = dictionary[PlaceholdersName.SafeProjectName];
                var posDot = projectname.IndexOf('.');
                rootNamespace = projectname.Substring(0, posDot);
            }
            else
            {
                // For item templates: Use the namespace set in the project
                rootNamespace = dte.GetProjectPropertyValue("RootNamespace");
            }
            return rootNamespace;
        }
    }
}
