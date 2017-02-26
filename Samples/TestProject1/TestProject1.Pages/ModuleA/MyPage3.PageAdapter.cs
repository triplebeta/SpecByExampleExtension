using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Castle.Windsor;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SpecByExample.Common;
using SpecByExample.Common.Controls;
using TestProject1.Common.Pages;

namespace TestProject1.Pages.ModuleA
{
    /// <summary>
    /// Implements the <seealso cref="https://code.google.com/p/selenium/wiki/PageObjects">PageObject</seealso> for MyPage3.
    /// </summary>
	/// <remarks>Generated using the T4 tempate.</remarks>
    public partial class MyPage3 : BaseTestProject1Page
    {
        public MyPage3(IWindsorContainer container, IWebDriver driver)
            : base(container, driver, "Home Page - SpecByExample.SampleWebsite", null)
        {
            // Nothing to do here
        }

				/* For the following controls we did not generate code since they could not be uniquely identified
			btn btn-default
			btn btn-default
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
        /// Html Link element: Learn More
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Learn More")]
        private IWebElement LearnMoreLink1Control;

        /// <summary>
        /// Html Link element: Previous
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Previous")]
        private IWebElement PreviousLinkControl;

        /// <summary>
        /// Html Link element: Next
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Next")]
        private IWebElement NextLinkControl;

        /// <summary>
        /// Html Link element: Bower
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Bower")]
        private IWebElement BowerLinkControl;

        /// <summary>
        /// Html Link element: Bootstrap
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Bootstrap")]
        private IWebElement BootstrapLinkControl;

        /// <summary>
        /// Html Link element: Add a Controller and View
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Add a Controller and View")]
        private IWebElement AddAControllerAndViewLinkControl;

        /// <summary>
        /// Html Link element: Add an appsetting in config and access it in app.
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Add an appsetting in config and access it in app.")]
        private IWebElement AddAnAppsettingInConfigAndAccessItInAppLinkControl;

        /// <summary>
        /// Html Button element: Toggle navigation
		/// </summary>
        [FindsBy(How=How.ClassName, Using="navbar-toggle")]
        private IWebElement ToggleNavigationButtonControl;

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
        /// Link: 
        /// </summary>
        public Link LearnMoreLink1
        {
            get { return LearnMoreLink1Control.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link PreviousLink
        {
            get { return PreviousLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link NextLink
        {
            get { return NextLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link BowerLink
        {
            get { return BowerLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link BootstrapLink
        {
            get { return BootstrapLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link AddAControllerAndViewLink
        {
            get { return AddAControllerAndViewLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link AddAnAppsettingInConfigAndAccessItInAppLink
        {
            get { return AddAnAppsettingInConfigAndAccessItInAppLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Button: 
        /// </summary>
        public Button ToggleNavigationButton
        {
            get { return ToggleNavigationButtonControl.As<Button>(CurrentWebDriver); }
        }

		#endregion
	}
}