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
    /// Implements the <seealso cref="https://code.google.com/p/selenium/wiki/PageObjects">PageObject</seealso> for StartPage for module .
    /// </summary>
	/// <remarks>Generated using the T4 tempate.</remarks>
    public class StartPage : BaseWebTestSamplePage
    {
        public StartPage(IWindsorContainer container, IWebDriver driver)
            : base(container, driver, "Home Page - SpecByExample.SampleWebsite", null)
        {
            // Nothing to do here
        }

		
        #region Selenium IWebElement items on this page

// Disable warning for: Field XYZ is never assigned to, and will always have its default value XX
#pragma warning disable 0649

        /// <summary>
        /// Html Link element: SpecByExample.SampleWebsite
		/// </summary>
        [FindsBy(How=How.LinkText, Using="SpecByExample.SampleWebsite")]
        private IWebElement SpecByExampleSampleWebsiteLinkControl;

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
        /// Html Link element: Learn More
		/// </summary>
        private IWebElement LearnMoreLink21Control;

        /// <summary>
        /// Html Link element: Learn More
		/// </summary>
        private IWebElement LearnMoreLink31Control;

        /// <summary>
        /// Html Link element: Learn More
		/// </summary>
        private IWebElement LearnMoreLink41Control;

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
        /// Html Link element: Manage User Secrets using Secret Manager.
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Manage User Secrets using Secret Manager.")]
        private IWebElement ManageUserSecretsUsingSecretManagerLinkControl;

        /// <summary>
        /// Html Link element: Use logging to log a message.
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Use logging to log a message.")]
        private IWebElement UseLoggingToLogAMessageLinkControl;

        /// <summary>
        /// Html Link element: Add packages using NuGet.
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Add packages using NuGet.")]
        private IWebElement AddPackagesUsingNuGetLinkControl;

        /// <summary>
        /// Html Link element: Add client packages using Bower.
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Add client packages using Bower.")]
        private IWebElement AddClientPackagesUsingBowerLinkControl;

        /// <summary>
        /// Html Link element: Target development, staging or production environment.
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Target development, staging or production environment.")]
        private IWebElement TargetDevelopmentStagingOrProductionEnvironmentLinkControl;

        /// <summary>
        /// Html Link element: Conceptual overview of what is ASP.NET Core
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Conceptual overview of what is ASP.NET Core")]
        private IWebElement ConceptualOverviewOfWhatIsASPNETCoreLinkControl;

        /// <summary>
        /// Html Link element: Fundamentals of ASP.NET Core such as Startup and middleware.
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Fundamentals of ASP.NET Core such as Startup and middleware.")]
        private IWebElement FundamentalsOfASPNETCoreSuchAsStartupAndMiddlewareLinkControl;

        /// <summary>
        /// Html Link element: Working with Data
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Working with Data")]
        private IWebElement WorkingWithDataLinkControl;

        /// <summary>
        /// Html Link element: Security
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Security")]
        private IWebElement SecurityLinkControl;

        /// <summary>
        /// Html Link element: Client side development
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Client side development")]
        private IWebElement ClientSideDevelopmentLinkControl;

        /// <summary>
        /// Html Link element: Develop on different platforms
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Develop on different platforms")]
        private IWebElement DevelopOnDifferentPlatformsLinkControl;

        /// <summary>
        /// Html Link element: Read more on the documentation site
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Read more on the documentation site")]
        private IWebElement ReadMoreOnTheDocumentationSiteLinkControl;

        /// <summary>
        /// Html Link element: Run your app
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Run your app")]
        private IWebElement RunYourAppLinkControl;

        /// <summary>
        /// Html Link element: Run tools such as EF migrations and more
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Run tools such as EF migrations and more")]
        private IWebElement RunToolsSuchAsEFMigrationsAndMoreLinkControl;

        /// <summary>
        /// Html Link element: Publish to Microsoft Azure Web Apps
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Publish to Microsoft Azure Web Apps")]
        private IWebElement PublishToMicrosoftAzureWebAppsLinkControl;

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
        public Link SpecByExampleSampleWebsiteLink
        {
            get { return SpecByExampleSampleWebsiteLinkControl.As<Link>(CurrentWebDriver); }
        }

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
        public Link LearnMoreLink21
        {
            get { return LearnMoreLink21Control.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link LearnMoreLink31
        {
            get { return LearnMoreLink31Control.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link LearnMoreLink41
        {
            get { return LearnMoreLink41Control.As<Link>(CurrentWebDriver); }
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
        /// Link: 
        /// </summary>
        public Link ManageUserSecretsUsingSecretManagerLink
        {
            get { return ManageUserSecretsUsingSecretManagerLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link UseLoggingToLogAMessageLink
        {
            get { return UseLoggingToLogAMessageLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link AddPackagesUsingNuGetLink
        {
            get { return AddPackagesUsingNuGetLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link AddClientPackagesUsingBowerLink
        {
            get { return AddClientPackagesUsingBowerLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link TargetDevelopmentStagingOrProductionEnvironmentLink
        {
            get { return TargetDevelopmentStagingOrProductionEnvironmentLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link ConceptualOverviewOfWhatIsASPNETCoreLink
        {
            get { return ConceptualOverviewOfWhatIsASPNETCoreLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link FundamentalsOfASPNETCoreSuchAsStartupAndMiddlewareLink
        {
            get { return FundamentalsOfASPNETCoreSuchAsStartupAndMiddlewareLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link WorkingWithDataLink
        {
            get { return WorkingWithDataLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link SecurityLink
        {
            get { return SecurityLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link ClientSideDevelopmentLink
        {
            get { return ClientSideDevelopmentLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link DevelopOnDifferentPlatformsLink
        {
            get { return DevelopOnDifferentPlatformsLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link ReadMoreOnTheDocumentationSiteLink
        {
            get { return ReadMoreOnTheDocumentationSiteLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link RunYourAppLink
        {
            get { return RunYourAppLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link RunToolsSuchAsEFMigrationsAndMoreLink
        {
            get { return RunToolsSuchAsEFMigrationsAndMoreLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link PublishToMicrosoftAzureWebAppsLink
        {
            get { return PublishToMicrosoftAzureWebAppsLinkControl.As<Link>(CurrentWebDriver); }
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