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
        public const string SafeProjectName = "$safeprojectname$";
        public const string SafeItemName = "$safeitemname$";

        public const string Basename = "$basename$";
        public const string RootNamespace = "$rootnamespace$"; // Namespace of the project
        public const string BasePageclass = "$basepageclass$";
        public const string TableControlName = "$tablecontrolname$";
        public const string EntityName = "$entityname$";

        public const string TargetFilename = "$targetfilename$";
        public const string SpecFlowStepsClass = "$specflowstepsclass$";
        public const string RootName = "$rootname$";
        public const string Namespace = "$namespace$";  // Full namespace for this file

        public static List<string> KnownPlaceholders = new List<string> {
            Basename, BasePageclass, RootName, RootNamespace, Namespace,
            SafeProjectName, SpecFlowStepsClass, TableControlName, TargetFilename};
    }

    [Serializable]
    public class Placeholder
    {
        public Placeholder() { }

        public Placeholder(string name, string value)
        {
            Name = name;
            Value = value;
        }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string Value { get; set; }
    }
}
