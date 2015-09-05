using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.T4
{
    /// <summary>
    /// Details of the page for which we will be creating some code.
    /// </summary>
    [Serializable]
    public class PageInfo
    {
        public Encoding PageEncoding { get; set; }

        private string pageTitle;
        public string PageTitle
        {
            get { return pageTitle ?? ""; }
            set { pageTitle = value; }
        }

        private string pageNumber;
        public string PageNumber
        {
            get { return pageNumber ?? ""; }
            set { pageNumber = value; }
        }

        private string codePageClass;
        public string CodePageClass
        {
            get { return codePageClass ?? ""; }
            set { codePageClass = value; }
        }
    }
}
