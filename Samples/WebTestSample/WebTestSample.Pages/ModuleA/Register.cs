using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Castle.Windsor;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SpecByExample.Common;
using SpecByExample.Common.Controls;
using WebTestSample.Common.Pages;

namespace WebTestSample.Pages
{
    /// <summary>
    /// Implements the <seealso cref="https://code.google.com/p/selenium/wiki/PageObjects">PageObject</seealso> for RegisterPage for module .
    /// </summary>
	/// <remarks>Generated using the T4 tempate.</remarks>
    public class RegisterPage : BaseWebTestSamplePage
    {
        public RegisterPage(IWindsorContainer container, IWebDriver driver)
            : base(container, driver, "Register - SpecByExample.SampleWebsite", null)
        {
            // Nothing to do here
        }

				/* For the following controls we did not generate code since they could not be uniquely identified
			navbar-brand
			navbar-toggle
			btn btn-default
		*/

        #region Selenium IWebElement items on this page

// Disable warning for: Field XYZ is never assigned to, and will always have its default value XX
#pragma warning disable 0649

        /// <summary>
        /// Html Textbox element: 
		/// </summary>
        [FindsBy(How=How.Id, Using="Password")]
        private IWebElement PasswordTextboxControl;

        /// <summary>
        /// Html Textbox element: 
		/// </summary>
        [FindsBy(How=How.Id, Using="ConfirmPassword")]
        private IWebElement ConfirmPasswordTextboxControl;

        /// <summary>
        /// Html Textbox element: 
		/// </summary>
        [FindsBy(How=How.Id, Using="Email")]
        private IWebElement EmailTextboxControl;

        /// <summary>
        /// Html Textbox element: 
		/// </summary>
        [FindsBy(How = How.LinkText, Using = "Register")]
        private IWebElement RegisterButtonControl;

#pragma warning restore 0649

        #endregion


        #region Controls to wrap the HTML items

        /// <summary>
        /// Textbox: Password
        /// </summary>
        public Textbox PasswordTextbox
        {
            get { return PasswordTextboxControl.As<Textbox>(CurrentWebDriver); }
        }

        /// <summary>
        /// Textbox: ConfirmPassword
        /// </summary>
        public Textbox ConfirmPasswordTextbox
        {
            get { return ConfirmPasswordTextboxControl.As<Textbox>(CurrentWebDriver); }
        }

        /// <summary>
        /// Textbox: Email
        /// </summary>
        public Textbox EmailTextbox
        {
            get { return EmailTextboxControl.As<Textbox>(CurrentWebDriver); }
        }

        /// <summary>
        /// Button: Register
        /// </summary>
        public Button RegisterButton
        {
            get { return RegisterButtonControl.As<Button>(CurrentWebDriver); }
        }

        #endregion

    }
}