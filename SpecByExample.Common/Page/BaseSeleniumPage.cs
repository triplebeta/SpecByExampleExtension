using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using Castle.Windsor;
using System.Threading;
using System.Globalization;
using OpenQA.Selenium.Support.UI;

namespace SpecByExample.Common
{
    /// <summary>
    /// Baseclass for the Selenium Page Objects
    /// </summary>
    public abstract class BaseSeleniumPage
    {
        private IWindsorContainer _container;
        private string _pageCode;
        private string _pageTitle;

        /// <summary>
        /// Baseclass for the webpage
        /// </summary>
        /// <param name="container">IoC container</param>
        /// <param name="driver">WebDriver for Selenium</param>
        /// <param name="pageTitle">Expected beginning of the title for this page (can be a partial title but must match from the beginning)</param>
        public BaseSeleniumPage(IWindsorContainer container, IWebDriver driver, string pageTitle, string pageCode)
        {
            _container = container;
            _pageTitle = pageTitle;
            _pageCode = pageCode;
            CurrentWebDriver = driver;
            PageFactory.InitElements(driver, this);
        }


        /// <summary>
        /// Culture for parsing numbers and dates
        /// </summary>
        virtual protected IFormatProvider Culture
        {
            get
            {
                // TODO Read the value configured in the SpecFlow configuration instead of using the hardcoded value
                return CultureInfo.CreateSpecificCulture(GlobalSpecFlowSettings.CULTURE_FOR_PARSING);
            }
        }


        #region Helpers

        /// <summary>
        /// Helper to convert some string to a floatingpoint value
        /// </summary>
        /// <remarks>
        /// Returns 0.0F on failure
        /// </remarks>
        /// <param name="text">Text to be converted</param>
        /// <returns>The floatingpoint value</returns>
        protected float ConvertToFloat(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
                return 0.0F;

            float value;
            if (float.TryParse(text, NumberStyles.Float, Culture, out value) == false)
                return 0.0F;
            else
                return value;
        }


        /// <summary>
        /// Provides access to some utility methods
        /// </summary>
        protected IJavaScriptExecutor ScriptExecutor
        {
            get { return ((IJavaScriptExecutor)CurrentWebDriver); }
        }


        /// <summary>
        /// Get a reference to the currently active Javascript popup
        /// or throw an exception if it does not appear before the timeout.
        /// </summary>
        /// <param name="timeout">Milliseconds to wait for the popup, default: 3000</param>
        /// <returns>A reference to the alert.</returns>
        protected IAlert GetCurrentJavascriptPopup(int timeout=10000)
        {
            IAlert alert = null;
            SeleniumWindowHelper.SafelyWaitFor(() =>
            {
                try
                {
                    alert = CurrentWebDriver.SwitchTo().Alert();
                }
                catch (Exception)
                {
                }
                return alert != null;
            }, timeout);
            return alert;
        }

        #endregion



        /// <summary>
        /// Default implementation to check if the current page matches this type of Page Object.
        /// </summary>
        /// <returns>True if so.</returns>
        public virtual bool IsCurrentPage()
        {
            bool bothNamesNull = (String.IsNullOrEmpty(_pageTitle) && String.IsNullOrEmpty(CurrentPageTitle));
            bool titlesMatch = ((_pageTitle ?? "").Equals((CurrentPageTitle ?? ""),StringComparison.InvariantCultureIgnoreCase));
            bool titleStartsWith = (CurrentPageTitle ?? "").StartsWith((_pageTitle ?? ""),StringComparison.InvariantCultureIgnoreCase);
            return bothNamesNull || titlesMatch || titleStartsWith;
        }


        /// <summary>
        /// Throw an exception on error.
        /// </summary>
        /// <param name="exceptionOnError">True to throw an exception if not on this page, false to just get the result back as a boolean. Default=true</param>
        /// <exception cref="InvalidPageException">Thrown if the current page does not match this type.</exception>
        public bool EnsureOnPage(bool exceptionOnError=true)
        {
            // Check that the beginning of the page title matches
            if (SeleniumWindowHelper.SafelyWaitFor(()=>IsCurrentPage(), 3000)==false)
            {
                if (exceptionOnError)
                    throw new InvalidPageException(String.Format("The current page was not recognized as an instance of '{0}' since its title does not match the title '{1}'", this.GetType().Name, _pageTitle ?? "null"));
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// All error messages. Override GetErrors() to implement this.
        /// </summary>
        public Dictionary<string,string> Errors
        {
            get
            {
                // Use an abstract template method to get the errors from the page
                return GetErrors();
            }
        }

        /// <summary>
        /// True if the Errors property is properly implemented by the subclass.
        /// </summary>
        public bool PageSupportsErrors
        {
            get { return Errors != null; }
        }


        /// <summary>
        /// Return true if any errors are currently displaying on the page.
        /// </summary>
        /// <remarks>Uses the Error property.</remarks>
        public bool HasErrors
        {
            get
            {
                var errors = Errors;
                if (errors == null) throw new InvalidOperationException("This page adapter does not support retrieving errors and therefore thou shalt not use this property in thy check :)");
                else return Errors.Count() > 0;
            }
        }


        /// <summary>
        /// Page title
        /// </summary>
        /// <remarks>
        /// Override this property in the child classes if we need to get this from another place.
        /// </remarks>
        public virtual string CurrentPageTitle
        {
            get { return CurrentWebDriver.Title; }
        }


        /// <summary>
        /// Unique code for this screen
        /// </summary>
        public virtual string PageCode
        {
            get { return _pageCode;  }
        }


        #region Protected helpers

        /// <summary>
        /// Driver for accessing the webpage
        /// </summary>
        protected IWebDriver CurrentWebDriver
        {
            get;
            private set;
        }

        /// <summary>
        /// Return all errors currently on the page.
        /// </summary>
        /// <returns>
        /// A new dictionary instance containing the errorcodes as keys and the errormessages as values.
        /// Return null to indicate returning Errors is not supported by this page adapter.
        /// </returns>
        protected abstract Dictionary<string, string> GetErrors();


        /// <summary>
        /// Get a new instance of the screen.
        /// </summary>
        /// <typeparam name="T">Type of a screen</typeparam>
        /// <returns></returns>
        protected T GetScreen<T>() where T : BaseSeleniumPage
        {
            var page = _container.Resolve<T>();
            SeleniumWindowHelper.SafelyWaitFor(() => page.EnsureOnPage(), 3000);
            return page;
        }


        /// <summary>
        /// Iterate over all windows and find the one which contains the given code in its title.
        /// </summary>
        /// <param name="title">(part of the) title of the page to match</param>
        /// <returns>On success: an instance of Page Object T for that window. On failure: an exception and the window will not be switched.</returns>
        protected T GetPopupByTitle<T>(string title) where T : BaseSeleniumPage
        {
            string handle = SeleniumWindowHelper.FindWindowByTitle(CurrentWebDriver, title);
            SeleniumWindowHelper.SwitchToWindowByHandle(CurrentWebDriver, handle);
            return GetScreen<T>();
        }


        /// <summary>
        /// Iterate over all windows and find the one which contains the given code in its title.
        /// </summary>
        /// <param name="url">(part of the) Url of the page to match</param>
        /// <returns>On success: an instance of Page Object T for that window. On failure: an exception and the window will not be switched.</returns>
        protected T GetPopupByUrl<T>(string url) where T : BaseSeleniumPage
        {
            string handle = SeleniumWindowHelper.FindWindowByUrl(CurrentWebDriver, url);
            SeleniumWindowHelper.SwitchToWindowByHandle(CurrentWebDriver, handle);
            return GetScreen<T>();
        } 
        #endregion
    }
}
