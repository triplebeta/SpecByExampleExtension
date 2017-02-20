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
    /// Implements the <seealso cref="https://code.google.com/p/selenium/wiki/PageObjects">PageObject</seealso> for RegisterAccountPage.
    /// </summary>
	/// <remarks>Generated using the T4 tempate.</remarks>
    public partial class RegisterAccount : BaseWebTestSamplePage
    {
        public RegisterAccount(IWindsorContainer container, IWebDriver driver)
            : base(container, driver, "Register - SpecByExample.SampleWebsite", null)
        {
            // Nothing to do here
        }

				/* For the following controls we did not generate code since they could not be uniquely identified
			btn btn-default
		*/

        #region Selenium IWebElement items on this page

// Disable warning for: Field XYZ is never assigned to, and will always have its default value XX
#pragma warning disable 0649

        /// <summary>
        /// Html Link element: Home
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Home")]
        private IWebElement HomeLinkControl;

        /// <summary>
        /// Html Link element: About
		/// </summary>
        [FindsBy(How=How.LinkText, Using="About")]
        private IWebElement AboutLinkControl;

        /// <summary>
        /// Html Link element: Contact
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Contact")]
        private IWebElement ContactLinkControl;

        /// <summary>
        /// Html Link element: Register
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Register")]
        private IWebElement RegisterLinkControl;

        /// <summary>
        /// Html Link element: Log in
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Log in")]
        private IWebElement LogInLinkControl;

        /// <summary>
        /// Html Button element: Toggle navigation
		/// </summary>
        [FindsBy(How=How.ClassName, Using="navbar-toggle")]
        private IWebElement ToggleNavigationButtonControl;

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

#pragma warning restore 0649

        #endregion


		#region Controls to wrap the HTML items

        /// <summary>
        /// Link: 
        /// </summary>
        public Link HomeLink
        {
            get { return HomeLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link AboutLink
        {
            get { return AboutLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link ContactLink
        {
            get { return ContactLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link RegisterLink
        {
            get { return RegisterLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link LogInLink
        {
            get { return LogInLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Button: 
        /// </summary>
        public Button ToggleNavigationButton
        {
            get { return ToggleNavigationButtonControl.As<Button>(CurrentWebDriver); }
        }

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

		#endregion

	}
}