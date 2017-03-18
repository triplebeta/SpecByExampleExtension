using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.T4
{
    /// <summary>
    /// Info about the table to use as the main table for the TablePageObject
    /// </summary>
    [Serializable]
    public class SeleniumTableInfo
    {
        public SeleniumTableInfo()
        {
            Columns = new List<TableColumnDef>();
        }

        public string EntityName { get; set; }

        /// <summary>
        /// Name of the Selenium IWebElement property generated on the Page class to access the HTML table.
        /// Use that control to access the table.
        /// </summary>
        public string TableName { get; set; }


        /// <summary>
        /// Name of the control (has a suffix of the control type)
        /// </summary>
        public string TableControlName
        {
            get { return TableName + "Table"; }
        }

        /// <summary>
        /// Defines the columns of this table
        /// </summary>
        public List<TableColumnDef> Columns { get; private set; }
    }
}
