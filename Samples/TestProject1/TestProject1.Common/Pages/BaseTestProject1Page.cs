using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecByExample.Common;
using OpenQA.Selenium;
using Castle.Windsor;
using TestProject1.Common;

namespace TestProject1.Common.Pages
{
    /// <summary>
    /// Base class for all page objects.
    /// </summary>
    public abstract class BaseTestProject1Page : BaseSeleniumPage
    {
        public BaseTestProject1Page(IWindsorContainer container, IWebDriver driver, string title, string code)
            : this(container, driver)
        {
            // Nothing to do here
        }

        public BaseTestProject1Page(IWindsorContainer container, IWebDriver driver)
            : base(container, driver, null, null)
        {
            // Nothing to do here either
        }


        /// <summary>
        /// Return all errors currently on the page.
        /// </summary>
        /// <returns>A new dictionary instance containing the errorcodes as keys and the errormessages as values.</returns>
        protected override Dictionary<string, string> GetErrors()
        {
            // When the Error element is not found, no errors on this page.
            var errors = new Dictionary<string, string>();

            // TODO Implement retrieving the error information from the page
            return errors;
        }
    }
}
