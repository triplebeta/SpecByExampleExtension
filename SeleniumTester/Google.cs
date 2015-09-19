using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using Castle.Windsor;
using SpecByExample.Common;

namespace Google.Pages
{
    /// <summary>
    /// Page class for the Google search page
    /// </summary>
    public class GooglePage :  BaseSeleniumPage
    {
        public GooglePage(IWindsorContainer container, IWebDriver driver)
            : base(container, driver, "Google", null)
        {
            // Nothing to do here
        }

        /// <summary>
        /// Search for a specific text.
        /// </summary>
        /// <param name="text"></param>
        public void SearchFor(string text)
        {
            // Set the text and click the button
            SearchText.SendKeys(text);
            SearchText.Submit();
        }

        /// <summary>
        /// Return all errors currently on the page.
        /// </summary>
        /// <returns>A new dictionary instance containing the errorcodes as keys and the errormessages as values.</returns>
        protected override Dictionary<string, string> GetErrors()
        {
            return null;
        }


        #region Elements of this page

// Disable warning for: Field XYZ is never assigned to, and will always have its default value XX
#pragma warning disable 0649

        /// <summary>
        /// Searchbox
        /// </summary>
        [FindsBy(How = How.Name, Using = "q")]
        IWebElement SearchText;


        #region Selenium Html Controls

        /// <summary>
        /// Google News link
        /// </summary>
        [FindsBy(How = How.Id, Using = "gb_5")]
        IWebElement GoogleNewsLinkControl;

        /// <summary>
        /// Google Jij link
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "gb_P")]
        IWebElement GoogleImagesLinkControl;
        
        #endregion


        public void NavigateGoogleNewsLink()
        {
            GoogleNewsLinkControl.Click();
        }


        /// <summary>
        /// Google Jij link
        /// </summary>
        [FindsBy(How = How.Id, Using = "gb_1")]
        IWebElement GoogleYou;

        public void NavigateGoogleImagesLink()
        {
            GoogleImagesLinkControl.Click();
        }

#pragma warning restore 0649

        #endregion
    }
}
