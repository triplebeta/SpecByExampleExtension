using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SpecByExample.T4
{
    /// <summary>
    /// Container for the settings to be entered in the form.
    /// </summary>
    /// <remarks>This will be saved as a .webmodel file, capturing the characteristics of the page.</remarks>
    [Serializable]
    public class CodeGenerationSettings : MarshalByRefObject
    {
        public CodeGenerationSettings()
        {
            TypeOfPage = PageTemplatesEnum.GenericPage;
            Options = new ParsingOptions();
            Options.ExcludeNonUniqueControls = true;
            Options.PreferredIdentifications = new ControlIdentificationType[] {
                ControlIdentificationType.Id, 
                ControlIdentificationType.Name,
                ControlIdentificationType.LinkText,
                ControlIdentificationType.Cssclass };
            PageInfo = new PageInfo();
            Placeholders = new List<Placeholder>();

            // Configure the default options
            CreateSpecFlowStepsFile = true;
            CreateSpecFlowFeatureFile = false;
            
            IsCancelled = false;
        }

        [XmlAttribute]
        public string PageName { get; set; }

        /// <summary>
        /// True to create a new SpecFlow Steps file.
        /// </summary>
        [XmlAttribute]
        public bool CreateSpecFlowStepsFile { get; set; }

        [XmlElement]
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Placeholder values to inject specific values that are available in the context of the T4 engine.
        /// </summary>
        [XmlArray("Placeholders"), XmlArrayItem(typeof(Placeholder), ElementName = "Placeholder")]
        public List<Placeholder> Placeholders { get; set; }
        
        /// <summary>
        /// Defines the scope for finding controls within the webpage.
        /// By default, it will search the complete document but you can change this
        /// by assinging an HtmlAgilityPack XPath expression to a DIV to this field.
        /// In that case, the list of SelectedHtmlElements will only contain the elements
        /// WITHIN that DIV. Use this when all your pages use the same masterpage with a
        /// menu structure. You can then just use the Div with the page-specific content.
        /// </summary>
        [XmlAttribute]
        public string HtmlRootNodeXPath { get; set; }

        [XmlElement]
        public PageInfo PageInfo { get; set; }

        /// <summary>
        /// Define how to parse the HTML
        /// </summary>
        [XmlElement]
        public ParsingOptions Options { get; set; }

        /// <summary>
        /// Type of page.
        /// </summary>
        [XmlElement]
        public PageTemplatesEnum TypeOfPage { get; set; }

        /// <summary>
        /// Container for information about the table
        /// </summary>
        [XmlElement]
        public SeleniumTableInfo TableInfo { get; set; }

        
        /// <summary>
        /// True to create a new SpecFlow Feature file.
        /// </summary>
        /// <remarks>
        /// Used only for the wizard since the custom tool will not update the Feature file.
        /// </remarks>
        [XmlIgnore]
        public bool CreateSpecFlowFeatureFile { get; set; }

        /// <summary>
        /// For internal use by the Wizard to indicate that it was closed without the use of the Finish button.
        /// </summary>
        [XmlIgnore]
        public bool IsCancelled { get; set; }
    }
}
