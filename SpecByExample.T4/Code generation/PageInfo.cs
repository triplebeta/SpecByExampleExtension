using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SpecByExample.T4
{
    /// <summary>
    /// Details of the page for which we will be creating some code.
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(Encoding))]
    public class PageInfo
    {
        private string pageTitle, className;

        // Required for serialization
        public PageInfo()
        {
            TypeOfPage = PageTemplatesEnum.GenericPage;
            Placeholders = new List<Placeholder>();

            // Configure the default options
            CreateSpecFlowStepsFile = true;
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

        [XmlAttribute(AttributeName="Title")]
        public string PageTitle
        {
            get { return pageTitle ?? ""; }
            set { pageTitle = value; }
        }

        /// <summary>
        /// Name of the class to create for this page.
        /// </summary>
        [XmlAttribute(AttributeName = "ClassName")]
        public string Class
        {
            get { return className ?? ""; }
            set { className = value; }
        }

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

        /// <summary>
        /// Type of page.
        /// </summary>
        [XmlAttribute]
        public PageTemplatesEnum TypeOfPage { get; set; }

        /// <summary>
        /// Placeholder values to inject specific values that are available in the context of the T4 engine.
        /// </summary>
        [XmlArray("Placeholders"), XmlArrayItem(typeof(Placeholder), ElementName = "Placeholder")]
        public List<Placeholder> Placeholders { get; set; }

        /// <summary>
        /// Container for information about the table
        /// </summary>
        [XmlElement]
        public SeleniumTableInfo TableInfo { get; set; }

        /// <summary>
        /// The set of all HTML input elements on the page, the SelectedHtmlElements is a subset of this collection.
        /// This set will contain the elements you might want to use in testing.
        /// DIV's will not be included since we assume they will be used for scope only.
        /// </summary>
        public List<HtmlControlInfo> HtmlElements
        {
            get;
            set;
        }

        /// <summary>
        /// The set of all containers, like DIVs
        /// </summary>
        public List<HtmlControlInfo> HtmlContainers
        {
            get;
            set;
        }
    }
}
