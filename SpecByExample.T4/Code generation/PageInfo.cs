using System;
using System.Collections.Generic;
using System.Text;

namespace SpecByExample.T4
{
    /// <summary>
    /// Details of the page for which we will be creating some code.
    /// </summary>
    [Serializable]
    public class PageInfo
    {
        private string pageTitle, pageNumber, codePageClass;

        public PageInfo(string url) { Url = url; }

        public string Url
        {
            get;
            set;
        }

        public Encoding PageEncoding
        {
            get;
            set;
        }

        public string PageTitle
        {
            get { return pageTitle ?? ""; }
            set { pageTitle = value; }
        }

        public string PageNumber
        {
            get { return pageNumber ?? ""; }
            set { pageNumber = value; }
        }

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
