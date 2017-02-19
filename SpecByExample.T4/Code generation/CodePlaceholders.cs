using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SpecByExample.T4
{
    /// <summary>
    /// Defines the names of the code placeholders to be used to inject values from the DTE.
    /// </summary>
    public static class PlaceholdersName
    {
        public const string Basename = "$basename$";
        public const string RootNamespace = "$rootnamespace$";
        public const string BasePageclass = "$basepageclass$";
        public const string TableControlName = "$tablecontrolname$";
        public const string EntityName = "$entityname$";

        public const string TargetFilename = "$targetfilename$";
        public const string PageClassname = "$pageclass$";
        public const string SpecFlowStepsClass = "$specflowstepsclass$";
        public const string SafeProjectName = "$safeprojectname$";
        public const string RootName = "$rootname$";
    }

    /// <summary>
    /// Container for the settings to be entered in the form.
    /// </summary>
    /// <remarks>
    /// Each element will initially get the name of its placeholder, after serialization this will be replaced with its real value by the transformation.
    /// Or when deserializing it will be replaced with the value from the file
    /// </remarks>
    [Serializable]
    public class CodePlaceholders
    {
        /// <summary>
        /// Base projectname. First part of the projectname, like Google  in Google.Pages.
        /// </summary>
        public string Basename { get; set; } = PlaceholdersName.Basename;

        /// <summary>
        /// Namespace to use for the Page class.
        /// </summary>
        public string RootNamespace { get; set; } = PlaceholdersName.RootNamespace;

        /// <summary>
        /// Name of the baseclass page to inherit from.
        /// </summary>
        public string BasePageclass { get; set; } = PlaceholdersName.BasePageclass;

        /// <summary>
        /// Only for tables. Name of the control representing the table to create an adapter for.
        /// </summary>
        public string TableControlName { get; set; } = PlaceholdersName.TableControlName;

        /// <summary>
        /// Only for tables. Name assigned to the entity representing one row of that table.
        /// </summary>
        public string EntityName { get; set; } = PlaceholdersName.EntityName;

        /// <summary>
        /// Helper to retrieve the content of this object as a dictionary so we can use it.
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, string> ReplacementDictionary
        {
            get
            {
                // Get the replacement variables from the model
                var replacementsDictionary = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(Basename)) replacementsDictionary.Add(PlaceholdersName.Basename, Basename);
                if (!string.IsNullOrEmpty(BasePageclass)) replacementsDictionary.Add(PlaceholdersName.BasePageclass, BasePageclass);
                if (!string.IsNullOrEmpty(EntityName)) replacementsDictionary.Add(PlaceholdersName.EntityName, EntityName);
                if (!string.IsNullOrEmpty(TableControlName)) replacementsDictionary.Add(PlaceholdersName.TableControlName, TableControlName);
                if (!string.IsNullOrEmpty(RootNamespace)) replacementsDictionary.Add(PlaceholdersName.RootNamespace, RootNamespace);
                
                return replacementsDictionary;
            }
        }
    }
}
