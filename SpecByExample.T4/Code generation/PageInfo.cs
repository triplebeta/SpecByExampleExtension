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
        private string pageTitle, pageNumber, codePageClass;

        // Required for serialization
        public PageInfo() { }

        public PageInfo(string url) { Url = url; }

        /// <summary>
        /// Url from which the HTML was loaded.
        /// </summary>
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// String representation of the encoding used for this page.
        /// </summary>
        [XmlAttribute("Encoding")]
        public string PageEncoding
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


        [XmlAttribute(AttributeName = "PageNumber")]
        public string PageNumber
        {
            get { return pageNumber ?? ""; }
            set { pageNumber = value; }
        }

        /// <summary>
        /// Name of the class to create for this page.
        /// </summary>
        [XmlAttribute(AttributeName = "Classname")]
        public string CodePageClass
        {
            get { return codePageClass ?? ""; }
            set { codePageClass = value; }
        }

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
