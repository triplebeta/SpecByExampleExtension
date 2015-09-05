using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace SpecByExample.Common.Controls
{
    /// <summary>
    /// Adapter control for standard HTML Tables.
    /// </summary>
    /// <remarks>
    /// For specific types of tables such as Infragistics or jqGrid tables, create specialized adapter classes.
    /// </remarks>
    public class WebTable : BaseSeleniumControl
    {
        public WebTable() : base() { }

        public WebTable(IWebDriver driver, HtmlTable innerTable) : base(driver, innerTable.InternalTableElement)
        {
            Initialize(driver, innerTable);
        }

        /// <summary>
        /// Extends the standard initializations by performing additional checks.
        /// </summary>
        /// <param name="driver">Webdriver</param>
        /// <param name="table">Table wrapper instance</param>
        /// <exception cref="HtmlElementIsNoInputElementException">Thrown if it's not an input control.</exception>
        public void Initialize(IWebDriver driver, HtmlTable table)
        {
            if (driver == null) throw new ArgumentNullException("driver");
            if (table == null) throw new ArgumentNullException("innerTable");

            base.Initialize(driver, table.InternalTableElement);
            if (this.InputType != HtmlInputType.Table)
                throw new InvalidHtmlInputTypeException("The element is not a table.");

            InnerTable = table;
        }

        /// <summary>
        /// Table instance
        /// </summary>
        private HtmlTable InnerTable { get; set; }

        /// <summary>
        /// Title of the table
        /// </summary>
        public string Title
        {
            get { return InnerTable.Caption; }
        }

        /// <summary>
        /// True if the table contains a row with &lt;th&gt; elements
        /// </summary>
        public bool HasHeaderRow
        {
            get { return InnerTable.HasHeaderRow; }
        }
    }
}
