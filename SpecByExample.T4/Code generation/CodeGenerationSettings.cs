using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.T4
{
    /// <summary>
    /// Container for the settings to be entered in the form.
    /// </summary>
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

            AllHtmlElements = new List<HtmlControlInfo>();
            AllHtmlContainers = new List<HtmlControlInfo>();
            SelectedHtmlElements = new List<HtmlControlInfo>();
            PageInfo = new T4.PageInfo();

            // Configure the default options
            CreateSpecFlowStepsFile = false;
            CreateSpecFlowFeatureFile = false;
            
            IsCancelled = false;
        }

        public string PageUrl { get; set; }
        public string PageName { get; set; }

        private string applicationModule;
        public string ApplicationModule
        {
            get { return applicationModule ?? "";  }
            set { applicationModule = value; }
        }

        public bool IsCancelled { get; set; }

        /// <summary>
        /// Defines the scope for finding controls within the webpage.
        /// By default, it will search the complete document but you can change this
        /// by assinging an HtmlAgilityPack XPath expression to a DIV to this field.
        /// In that case, the list of SelectedHtmlElements will only contain the elements
        /// WITHIN that DIV. Use this when all your pages use the same masterpage with a
        /// menu structure. You can then just use the Div with the page-specific content.
        /// </summary>
        public string HtmlRootNodeXPath { get; set; }

        /// <summary>
        /// All HTML elements of the current page.
        /// </summary>
        public List<HtmlControlInfo> SelectedHtmlElements
        {
            get;
            set;
        }

        /// <summary>
        /// The set of all HTML input elements on the page, the SelectedHtmlElements is a subset of this collection.
        /// This set will contain the elements you might want to use in testing.
        /// DIV's will not be included since we assume they will be used for scope only.
        /// </summary>
        internal List<HtmlControlInfo> AllHtmlElements
        {
            get;
            set;
        }

        /// <summary>
        /// The set of all containers, like DIVs
        /// </summary>
        internal List<HtmlControlInfo> AllHtmlContainers
        {
            get;
            set;
        }

        public PageInfo PageInfo { get; set; }

        /// <summary>
        /// Define how to parse the HTML
        /// </summary>
        public ParsingOptions Options { get; private set; }

        /// <summary>
        /// Type of page.
        /// </summary>
        public PageTemplatesEnum TypeOfPage { get; set; }

        /// <summary>
        /// Container for information about the table
        /// </summary>
        public SeleniumTableInfo TableInfo { get; set; }

        /// <summary>
        /// True to create a new SpecFlow Steps file.
        /// </summary>
        public bool CreateSpecFlowStepsFile { get; set; }

        /// <summary>
        /// True to create a new SpecFlow Feature file.
        /// </summary>
        public bool CreateSpecFlowFeatureFile { get; set; }

/*
 * For future usage
 * 
        /// <summary>
        /// When true: create a new line in the WellKnownUrls file for the new url, using the given name.
        /// </summary>
        public bool CreateWellKnownUrl { get; set; }
        public string WellKnownUrlName { get; set; }
*/
    }
}
