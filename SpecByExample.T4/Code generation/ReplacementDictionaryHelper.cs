using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;

namespace SpecByExample.T4
{
    /// <summary>
    /// Helper for creating $...$ variables for the replacement dictionary.
    /// Some of the variables will be implemented in multiple wizards and therefore this class will centralize their definitions.
    /// </summary>
    /// <remarks>
    /// Depends on the following items:
    ///     $safeprojectname$       Name of the project to be created
    ///     $rootname$              
    /// </remarks>
    internal class ReplacementDictionaryHelper
    {
        _DTE dte;
        Dictionary<string, string> dict = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dte">Reference to the IDE</param>
        /// <param name="pageType">Type of the page we are creating</param>
        /// <param name="dictionary">Set of replacement variables</param>
        internal ReplacementDictionaryHelper(_DTE dte, Dictionary<string, string> dictionary)
        {
            this.dte = dte;
            dict = dictionary;
        }



        /// <summary>
        /// 
        /// </summary>
        public string PageClassname
        {
            get
            {
                if (PageName.ToUpper().EndsWith("PAGE"))
                    return PageName;
                else
                    return PageName + "Page";
            }
        }


        /// <summary>
        /// Name of the codefile implementing the Steps.
        /// </summary>
        public string SpecFlowStepsClassname
        {
            get { return PageName + "Steps"; }
        }


        /// <summary>
        /// Name of the codefile implementing the Features
        /// </summary>
        public string SpecFlowFeatureClassname
        {
            get { return PageName + "Feature"; }
        }

        /// <summary>
        /// Name of the codefile implementing page.
        /// </summary>
        internal string PageName
        {
            get
            {
                // Return the name of the current item
                string pageName = (dict[PlaceholdersName.RootName] ?? "").Replace(".cs", "");
                return pageName;
            }
        }


        /// <summary>
        /// Name of the class, including the .cs extension
        /// </summary>
        internal string OutputFile
        {
            get
            {
                string outputFile = dict[PlaceholdersName.RootName];
                if (PageName.ToUpper().EndsWith("PAGE") == false)
                    outputFile = String.Format("{0}Page.cs", PageName);
                return outputFile;
            }
        }

        /// <summary>
        /// Namespace
        /// </summary>
        internal string RootNamespace
        {
            get
            {
                if (dict.ContainsKey(PlaceholdersName.SafeProjectName))
                {
                    // For project templates
                    string projectname = dict[PlaceholdersName.SafeProjectName];
                    var posDot = projectname.IndexOf('.');
                    return projectname.Substring(0, posDot);
                }
                else
                {
                    // For item templates: Use the namespace set in the project
                    string rootNamespace = GetProjectPropertyValue(dte, "RootNamespace");
                    return rootNamespace;
                }
            }
        }


        /// <summary>
        /// Base projectname. First part of the projectname, like Google  in Google.Pages.
        /// </summary>
        internal string BaseName
        {
            get
            {
                // Define two additional replacement variables to use in the code files
                // basepageclass: name of the base class to use when creating pages
                string baseName = RootNamespace.Replace(".Pages", "").Replace(".", "_");
                return baseName;
            }
        }


        /// <summary>
        /// Classname of the baseclass to use for the given typeof page.
        /// </summary>
        /// <param name="pageType">Type of page to be created.</param>
        /// <returns>Name of the baseclass.</returns>
        internal string GetPageBaseclass(PageTemplatesEnum pageType)
        {
            switch(pageType)
            {
                case PageTemplatesEnum.GenericPage: return String.Format("Base{0}Page", BaseName);
                case PageTemplatesEnum.TablePage: return String.Format("Base{0}ListPage", BaseName);
                default: throw new InvalidOperationException("Replacement Dictionary Helper does not know the baseclass for PageType " + pageType.ToString());
            }
        }


        /// <summary>
        /// Get the current Visual Studio project
        /// </summary>
        /// <returns></returns>
        public Project GetCurrentProject()
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
        /// Access the current project and get a value from one of its properties
        /// </summary>
        /// <param name="dte">Reference to the DTE</param>
        /// <param name="propertyName">Name of the property to lookup</param>
        /// <returns>Value of the property or null if not found.</returns>
        private static string GetProjectPropertyValue(_DTE dte, string propertyName)
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
    }
}
