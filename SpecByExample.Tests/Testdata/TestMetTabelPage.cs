using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using BDO.Selenium.Common;
using BDO.Selenium.Common.Controls;
using System.Data;

namespace BDO.Selenium.COProf.Pages
{
    /// <summary>
    /// Some Test page containing a table
    /// </summary>
    public class TestMetTabelPage : BaseCOProfListPage<MedewerkerColumns>
    {
        public TestMetTabelPage(IWindsorContainer container, IWebDriver driver)
            : base(container, driver)
        {
            // Nothing to do here
        }


        #region Implement abstract methods

        protected override ITableMappingDefinition<MedewerkerColumns> CreateTableMapping()
        {
            return new COProfTableMappingDefinition();
        }

        protected override List<MedewerkerColumns> CreateListOfColumns()
        {
            return new List<MedewerkerColumns>() { MedewerkerColumns.EmployeeNumber, MedewerkerColumns.FirstName };
        }

        protected override HtmlTable CreateHtmlTable()
        {
            return EmployeesTableControl.As<HtmlTable>(CurrentWebDriver);
        }

        #endregion


        #region Elements on this page

// Disable warning for: Field XYZ is never assigned to, and will always have its default value XX
#pragma warning disable 0649

        /// <summary>
        /// COProf Table
        /// </summary>
        [FindsBy(How = How.Id, Using = "MyEmployeeTable")]
        private IWebElement EmployeesTableControl;


#pragma warning restore 0169

        #endregion


        /// <summary>
        /// Data for the employees
        /// </summary>
        private MedewerkerContainer employees = null;
        public MedewerkerContainer Employees
        {
            get
            {
                // Lazy initialization
                if (employees == null)
                {
                    employees = new MedewerkerContainer();
                    var keyColumns = new MedewerkerColumns[] { MedewerkerColumns.EmployeeNumber };
                    GetTableData<MedewerkerContainer, MedewerkerRow, MedewerkerColumns>(HtmlTableControl, "Medewerkers", Employees, Columns, keyColumns);
                }
                return employees;
            }
        }

        /// <summary>
        /// Provides access to the HTML elements of the table.
        /// Use the Employees property to access its data
        /// </summary>
        public WebTable EmployeeTable
        {
            get
            {
                return new WebTable(CurrentWebDriver, HtmlTableControl);
            }
        }
    }
}
