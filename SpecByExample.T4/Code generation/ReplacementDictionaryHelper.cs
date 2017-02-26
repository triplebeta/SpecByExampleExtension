using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;
using System.Text.RegularExpressions;
using System.IO;

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
        /// Base name of the project, like Google in the project filename: Google.Pages.csproj
        /// This is the starting point for creating:
        ///     Name of the base class for all PageAdapter classes
        ///     .Specs project filename
        /// </summary>
        public string BaseName {
            get
            {
                string baseName = RootNamespace;
                if (RootNamespace.IndexOf(".Pages")>0) baseName = RootNamespace.Substring(0, RootNamespace.IndexOf(".Pages"));
                if (String.IsNullOrEmpty(baseName)) baseName = RootNamespace.Substring(0, RootNamespace.IndexOf("."));
                return baseName;
            }
        }

        /// <summary>
        /// Use the full path of the new file and of the projectfile to find out the namespace of the new file.
        /// </summary>
        /// <param name="projectDir">Root directory of the project</param>
        /// <param name="newFile">Full filename of the file to be created.</param>
        /// <returns>The full default namespace for the new to be created file</returns>
        internal string GetNamespaceForFile(string rootNamespace, string projectDir1, string newFile)
        {
            string newFilePath = Path.GetDirectoryName(newFile);
            if (newFilePath.StartsWith(projectDir1) == false)
                return rootNamespace; // Files are not in the same tree: just use the default namespace

            string difference = newFilePath.Replace(projectDir1, "");
            string suffix = difference.Replace('\\', '.').Trim(new[] {'.'});
            if (rootNamespace.EndsWith(".") == false) rootNamespace += ".";
            return rootNamespace + suffix;
        }

        /// <summary>
        /// Classname of the baseclass to use for the given typeof page.
        /// </summary>
        /// <param name="pageType">Type of page to be created.</param>
        /// <returns>Name of the baseclass.</returns>
        internal string GetPageBaseclass(PageTemplatesEnum pageType)
        {
            //var baseProjectName = RootNamespace.Replace(".", "_").Replace(".Pages", "");
            switch (pageType)
            {
                case PageTemplatesEnum.GenericPage: return String.Format("Base{0}Page", BaseName);
                case PageTemplatesEnum.TablePage: return String.Format("Base{0}ListPage", BaseName);
                default: throw new InvalidOperationException("Replacement Dictionary Helper does not know the baseclass for PageType " + pageType.ToString());
            }
        }
    }
}
