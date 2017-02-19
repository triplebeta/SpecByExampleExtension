using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;
using System.Text.RegularExpressions;

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
    public class ReplacementDictionaryHelper
    {
        Dictionary<string, string> dictionary = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rootNamespace">Namespace for the code.</param>
        /// <param name="dict">Set of replacement variables</param>
        public ReplacementDictionaryHelper(string rootNamespace, Dictionary<string, string> dict)
        {
            if (String.IsNullOrEmpty(rootNamespace)) throw new ArgumentNullException(nameof(rootNamespace));
            dictionary = dict;
            RootNamespace = rootNamespace;
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
                string pageName = (dictionary[PlaceholdersName.RootName] ?? "").Replace(".cs", "");
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
                string outputFile = dictionary[PlaceholdersName.RootName];
                if (Regex.IsMatch(PageName, "Page[0-9]*$", RegexOptions.IgnoreCase) == false)
                    outputFile = String.Format("{0}Page.cs", PageName);
                return outputFile;
            }
        }

        /// <summary>
        /// Root namespace for the code.
        /// </summary>
        internal string RootNamespace
        {
            get;
            set;
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
    }
}
