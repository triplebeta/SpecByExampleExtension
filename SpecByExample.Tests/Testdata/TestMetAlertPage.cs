using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using BDO.Selenium.Common;
using BDO.Selenium.Common.Controls;

namespace BDO.Selenium.COProf.Pages.Test
{
    /// <summary>
    /// Some Test page
    /// </summary>
    public class TestMetAlertPage : BaseCOProfMVCPage
    {
        public TestMetAlertPage(IWindsorContainer container, IWebDriver driver)
            : base(container, driver, null, null)
        {
            // Nothing to do here
        }

        #region Elements on this page

// Disable warning for: Field XYZ is never assigned to, and will always have its default value XX
#pragma warning disable 0649

        /// <summary>
        /// Wizard navigatie: Volgende
        /// </summary>
        [FindsBy(How = How.Id, Using = "pop")]
        private IWebElement OpenPopupLinkControl;
        
        /// <summary>
        /// Wizard navigatie: Volgende
        /// </summary>
        [FindsBy(How = How.Id, Using = "btnJS")]
        private IWebElement OpenPopupButtonControl;

#pragma warning restore 0649

        #endregion

        public Link OpenPopupLink
        {
            get
            {
                return OpenPopupLinkControl.As<Link>(CurrentWebDriver);
            }
        }

        public Button OpenPopupButton
        {
            get { return OpenPopupButtonControl.As<Button>(CurrentWebDriver); }
        }


        /// <summary>
        /// Click the link and get the alert
        /// </summary>
        /// <returns></returns>
        public OpenQA.Selenium.IAlert ClickOpenPopupLink()
        {
            // Click the link and return a reference to the Javascript popup
            OpenPopupLink.Click();
            return GetCurrentJavascriptPopup();
        }


        /// <summary>
        /// Click the link and get the alert
        /// </summary>
        /// <returns></returns>
        public OpenQA.Selenium.IAlert ClickOpenPopupButton()
        {
            // Click the link and return a reference to the Javascript popup
            OpenPopupButton.Click();
            return GetCurrentJavascriptPopup();
        }
    }
}
