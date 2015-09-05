using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using SpecByExample.Common.Controls;
using HtmlAgilityPack;

namespace SpecByExample.Common
{
    /// <summary>
    /// Wrapper for an HTML Table cell
    /// </summary>
    public class HtmlTableCell
    {        
        /// <summary>
        /// Constructor to use when directly instantiating this control.
        /// </summary>
        /// <param name="innerCell">HTML node being wrapped by this control</param>
        public HtmlTableCell(HtmlNode innerCell)
        {
            if (innerCell == null) throw new ArgumentNullException("innerCell");
            InnerNodeElement = innerCell;
        }


        public ReadOnlyCollection<HtmlNode> ElementsWithTag(string tagname)
        {
            return new ReadOnlyCollection<HtmlNode>(InnerNodeElement.Elements(tagname).ToList());
        }



        #region Protected items

        /// <summary>
        /// The web driver
        /// </summary>
        protected IWebDriver CurrentWebDriver
        {
            get;
            private set;
        }

        /// <summary>
        /// Node wrapped by this control
        /// </summary>
        protected HtmlNode InnerNodeElement
        {
            get;
            set;
        }

        /// <summary>
        /// Returns the type of INPUT control of InnerWebElement
        /// </summary>
        protected HtmlInputType InputType
        {
            get { return HtmlInputType.TableCell; }
        }

        #endregion



        public HtmlNode ElementWithTag(string tagname)
        {
            return InnerNodeElement.Element(tagname);
        }

        /// <summary>
        /// Get the OuterHTML of this element
        /// </summary>
        public string OuterHtml
        {
            get
            {
                string html = InnerNodeElement.GetAttributeValue("outerHtml",null);
                return html;
            }
        }

        public string Text
        {
            get
            {
                return InnerNodeElement.InnerText;
            }
        }
    }
}
