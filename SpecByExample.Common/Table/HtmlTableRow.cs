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
    /// Wrapper for an HTML Table Row
    /// </summary>
    public class HtmlTableRow
    {
        public HtmlTableRow() : base() {}

        public HtmlTableRow(HtmlNode row)
        {
            InnerNodeElement = row;

            // Create instances for the rows
            var cells = row.Elements("td").ToList();
            TableCells = new ReadOnlyCollection<HtmlNode>(cells);
        }


        /// <summary>
        /// Element being wrapped
        /// </summary>
        protected HtmlNode InnerNodeElement 
        {
            get;
            private set;
        }


        public ReadOnlyCollection<HtmlNode> Elements
        {
            get
            {
                // Select all child nodes of the current node
                return new ReadOnlyCollection<HtmlNode>(InnerNodeElement.ChildNodes);
            }
        }

        public ReadOnlyCollection<HtmlNode> ElementsWithTag(string tagname)
        {
            return new ReadOnlyCollection<HtmlNode>(InnerNodeElement.SelectNodes(tagname));
        }


        public HtmlNode ElementWithTag(string tagname)
        {
            return InnerNodeElement.SelectSingleNode(tagname);
        }


        public ReadOnlyCollection<HtmlNode> TableCells
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns the type of INPUT control of InnerWebElement
        /// </summary>
        protected HtmlInputType InputType
        {
            get { return HtmlInputType.TableRow; }
        }
    }
}
