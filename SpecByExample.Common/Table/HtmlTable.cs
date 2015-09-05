using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using SpecByExample.Common.Controls;
using System.Collections.ObjectModel;
using HtmlAgilityPack;

namespace SpecByExample.Common
{
    /// <summary>
    /// Wrapper for a HTML Table element
    /// </summary>
    public class HtmlTable : BaseSeleniumControl
    {
        private SeleniumTableHelper helper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="table"></param>
        public HtmlTable() {}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="table"></param>
        public HtmlTable(IWebDriver driver, IWebElement innerElement)
        {
            Initialize(driver, innerElement);
        }


        /// <summary>
        /// Constructor to use with just the ID of an HTML table.
        /// </summary>
        /// <param name="tableID">ID of the table to be found.</param>
        public HtmlTable(IWebDriver driver, string tableID)
        {
            var innerElement = driver.FindElement(By.Id(tableID));
            Initialize(driver, innerElement);
        }

        /// <summary>
        /// Initialize the table
        /// </summary>
        /// <param name="driver">WebDriver</param>
        /// <param name="innerElement">Selenium element being wrapped</param>
        public override void Initialize(IWebDriver driver, IWebElement innerElement)
        {
            base.Initialize(driver, innerElement);

            // Create an instance of the helper to access the table elements
            string xpath = String.Format("//table[@id='{0}']", IdOrName(innerElement));
            helper = new SeleniumTableHelper(CurrentWebDriver, xpath, true);
            helper.UseRowCaching = true;
        }


        /// <summary>
        /// Element being wrapped
        /// </summary>
        protected internal IWebElement InternalTableElement
        {
            get { return InnerWebElement; }
        }


        public ReadOnlyCollection<IWebElement> ElementsWithTag(string tagname)
        {
            // TODO Replace this implementation by one that uses the HtmlAgilityPack
            return InnerWebElement.FindElements(By.TagName(tagname));
        }

        /// <summary>
        /// Return ID or Name of the table.
        /// </summary>
        public string IdOrName(IWebElement tableElement)
        {
            // TODO Replace this implementation by one that uses the HtmlAgilityPack
            string id = tableElement.GetAttribute("ID");
            if (String.IsNullOrEmpty(id) == false)
                return id;
            else
                return InnerWebElement.GetAttribute("Name");
        }

        /// <summary>
        /// True if the first row of this table contains &lt;th&gt; elements.
        /// </summary>
        public bool HasHeaderRow
        {
            get
            {
                return helper.HasColumnHeaders;
            }
        }

        /// <summary>
        /// Number of rows (excludes the header row)
        /// </summary>
        public int TotalDataRows
        {
            get { return helper.TotalDataRows; }
        }

        /// <summary>
        /// Names of the columns of this table
        /// </summary>
        public List<string> Columnnames
        {
            get { return helper.Columnnames; }
        }


        /// <summary>
        /// Get a POCO object of the specified row
        /// </summary>
        public HtmlTableRow this[int i]
        {
            get { return TableRows[i]; }
        }


        /// <summary>
        /// Rows in this table
        /// </summary>
        public HtmlTableRow[] TableRows
        {
            get;
            private set;
        }

        /// <summary>
        /// Get the columns
        /// </summary>
        public string Caption
        {
            get
            {
                // TODO Replace this implementation by one that uses the HtmlAgilityPack
                var caption = InnerWebElement.FindElement(By.TagName("caption"));
                if (caption != null)
                    return caption.Text;
                else
                    return null;
            }
        }

        /// <summary>
        /// Read a value from a cell as a string
        /// </summary>
        public string ReadCellValueAsString(int rowIndex, int colIndex)
        {
            return helper.ReadStringValue(rowIndex,colIndex);
        }

        /// <summary>
        /// Read a value from a cell as an integer
        /// </summary>
        public int? ReadCellValueAsInt(int rowIndex, int colIndex)
        {
            return helper.ReadIntValue(rowIndex, colIndex);
        }

        /// <summary>
        /// Read a value from a cell as a string
        /// </summary>
        public DateTime? ReadCellValueAsDateTime(int rowIndex, int colIndex)
        {
            return helper.ReadDateValue(rowIndex, colIndex);
        }

        /// <summary>
        /// Read a value from a cell as an Url
        /// </summary>
        public Uri ReadCellValueAsUrl(int rowIndex, int colIndex)
        {
            return helper.ReadUrlValue(rowIndex, colIndex);
        }
    }
}
