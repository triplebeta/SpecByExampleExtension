using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using SpecByExample.Common;
using WebTestSample.Pages;
namespace WebTestSample.Specs
{
    [Binding]
    public partial class HomePageSteps : BaseSeleniumSteps
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state">State is passed in using Constructor Injection</param>
        public HomePageSteps(SeleniumBrowserInfo state) : base(state) { }


        #region Arrange - Given

        [Given("I go to the HomePage on url '(.*)'")]
        public void Given_I_Go_To_Url(string url)
        {
            CurrentWebDriver.Url = url;
            CurrentWebDriver.Navigate();
        }

        #endregion

        #region Act - When


        [When(@"I click the HomeLink")]
        public void When_I_Click_The_HomeLink()
        {
            var screen = GetScreen<HomePage>();
            screen.HomeLink.Click();
        }

        [When(@"I click the AboutLink")]
        public void When_I_Click_The_AboutLink()
        {
            var screen = GetScreen<HomePage>();
            screen.AboutLink.Click();
        }

        [When(@"I click the ContactLink")]
        public void When_I_Click_The_ContactLink()
        {
            var screen = GetScreen<HomePage>();
            screen.ContactLink.Click();
        }

        [When(@"I click the RegisterLink")]
        public void When_I_Click_The_RegisterLink()
        {
            var screen = GetScreen<HomePage>();
            screen.RegisterLink.Click();
        }

        [When(@"I click the LogInLink")]
        public void When_I_Click_The_LogInLink()
        {
            var screen = GetScreen<HomePage>();
            screen.LogInLink.Click();
        }

        [When(@"I click the LearnMoreLink1")]
        public void When_I_Click_The_LearnMoreLink1()
        {
            var screen = GetScreen<HomePage>();
            screen.LearnMoreLink1.Click();
        }

        [When(@"I click the PreviousLink")]
        public void When_I_Click_The_PreviousLink()
        {
            var screen = GetScreen<HomePage>();
            screen.PreviousLink.Click();
        }

        [When(@"I click the NextLink")]
        public void When_I_Click_The_NextLink()
        {
            var screen = GetScreen<HomePage>();
            screen.NextLink.Click();
        }

        [When(@"I click the BowerLink")]
        public void When_I_Click_The_BowerLink()
        {
            var screen = GetScreen<HomePage>();
            screen.BowerLink.Click();
        }

        [When(@"I click the BootstrapLink")]
        public void When_I_Click_The_BootstrapLink()
        {
            var screen = GetScreen<HomePage>();
            screen.BootstrapLink.Click();
        }

        [When(@"I click the AddAControllerAndViewLink")]
        public void When_I_Click_The_AddAControllerAndViewLink()
        {
            var screen = GetScreen<HomePage>();
            screen.AddAControllerAndViewLink.Click();
        }

        [When(@"I click the AddAnAppsettingInConfigAndAccessItInAppLink")]
        public void When_I_Click_The_AddAnAppsettingInConfigAndAccessItInAppLink()
        {
            var screen = GetScreen<HomePage>();
            screen.AddAnAppsettingInConfigAndAccessItInAppLink.Click();
        }

        [When(@"I click the ToggleNavigationButton")]
        public void When_I_Click_The_ToggleNavigationButton()
        {
            var screen = GetScreen<HomePage>();
            screen.ToggleNavigationButton.Click();
        }

        #endregion

        #region Assert - Then

        [Then(@"link HomeLink is ([not]?) visible")]
        public void Then_Link_HomeLink_Check_Visibility(string not)
        {
            var screen = GetScreen<HomePage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.HomeLink.IsDisplayed, visible);
        }

        [Then(@"link HomeLink is ([not]?) enabled")]
        public void Then_Link_HomeLink_Check_Enabled(string not)
        {
            var screen = GetScreen<HomePage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.HomeLink.IsEnabled, enabled);
        }

        [Then(@"link AboutLink is ([not]?) visible")]
        public void Then_Link_AboutLink_Check_Visibility(string not)
        {
            var screen = GetScreen<HomePage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AboutLink.IsDisplayed, visible);
        }

        [Then(@"link AboutLink is ([not]?) enabled")]
        public void Then_Link_AboutLink_Check_Enabled(string not)
        {
            var screen = GetScreen<HomePage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AboutLink.IsEnabled, enabled);
        }

        [Then(@"link ContactLink is ([not]?) visible")]
        public void Then_Link_ContactLink_Check_Visibility(string not)
        {
            var screen = GetScreen<HomePage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ContactLink.IsDisplayed, visible);
        }

        [Then(@"link ContactLink is ([not]?) enabled")]
        public void Then_Link_ContactLink_Check_Enabled(string not)
        {
            var screen = GetScreen<HomePage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ContactLink.IsEnabled, enabled);
        }

        [Then(@"link RegisterLink is ([not]?) visible")]
        public void Then_Link_RegisterLink_Check_Visibility(string not)
        {
            var screen = GetScreen<HomePage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.RegisterLink.IsDisplayed, visible);
        }

        [Then(@"link RegisterLink is ([not]?) enabled")]
        public void Then_Link_RegisterLink_Check_Enabled(string not)
        {
            var screen = GetScreen<HomePage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.RegisterLink.IsEnabled, enabled);
        }

        [Then(@"link LogInLink is ([not]?) visible")]
        public void Then_Link_LogInLink_Check_Visibility(string not)
        {
            var screen = GetScreen<HomePage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LogInLink.IsDisplayed, visible);
        }

        [Then(@"link LogInLink is ([not]?) enabled")]
        public void Then_Link_LogInLink_Check_Enabled(string not)
        {
            var screen = GetScreen<HomePage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LogInLink.IsEnabled, enabled);
        }

        [Then(@"link LearnMoreLink1 is ([not]?) visible")]
        public void Then_Link_LearnMoreLink1_Check_Visibility(string not)
        {
            var screen = GetScreen<HomePage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LearnMoreLink1.IsDisplayed, visible);
        }

        [Then(@"link LearnMoreLink1 is ([not]?) enabled")]
        public void Then_Link_LearnMoreLink1_Check_Enabled(string not)
        {
            var screen = GetScreen<HomePage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LearnMoreLink1.IsEnabled, enabled);
        }

        [Then(@"link PreviousLink is ([not]?) visible")]
        public void Then_Link_PreviousLink_Check_Visibility(string not)
        {
            var screen = GetScreen<HomePage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.PreviousLink.IsDisplayed, visible);
        }

        [Then(@"link PreviousLink is ([not]?) enabled")]
        public void Then_Link_PreviousLink_Check_Enabled(string not)
        {
            var screen = GetScreen<HomePage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.PreviousLink.IsEnabled, enabled);
        }

        [Then(@"link NextLink is ([not]?) visible")]
        public void Then_Link_NextLink_Check_Visibility(string not)
        {
            var screen = GetScreen<HomePage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.NextLink.IsDisplayed, visible);
        }

        [Then(@"link NextLink is ([not]?) enabled")]
        public void Then_Link_NextLink_Check_Enabled(string not)
        {
            var screen = GetScreen<HomePage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.NextLink.IsEnabled, enabled);
        }

        [Then(@"link BowerLink is ([not]?) visible")]
        public void Then_Link_BowerLink_Check_Visibility(string not)
        {
            var screen = GetScreen<HomePage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.BowerLink.IsDisplayed, visible);
        }

        [Then(@"link BowerLink is ([not]?) enabled")]
        public void Then_Link_BowerLink_Check_Enabled(string not)
        {
            var screen = GetScreen<HomePage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.BowerLink.IsEnabled, enabled);
        }

        [Then(@"link BootstrapLink is ([not]?) visible")]
        public void Then_Link_BootstrapLink_Check_Visibility(string not)
        {
            var screen = GetScreen<HomePage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.BootstrapLink.IsDisplayed, visible);
        }

        [Then(@"link BootstrapLink is ([not]?) enabled")]
        public void Then_Link_BootstrapLink_Check_Enabled(string not)
        {
            var screen = GetScreen<HomePage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.BootstrapLink.IsEnabled, enabled);
        }

        [Then(@"link AddAControllerAndViewLink is ([not]?) visible")]
        public void Then_Link_AddAControllerAndViewLink_Check_Visibility(string not)
        {
            var screen = GetScreen<HomePage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AddAControllerAndViewLink.IsDisplayed, visible);
        }

        [Then(@"link AddAControllerAndViewLink is ([not]?) enabled")]
        public void Then_Link_AddAControllerAndViewLink_Check_Enabled(string not)
        {
            var screen = GetScreen<HomePage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AddAControllerAndViewLink.IsEnabled, enabled);
        }

        [Then(@"link AddAnAppsettingInConfigAndAccessItInAppLink is ([not]?) visible")]
        public void Then_Link_AddAnAppsettingInConfigAndAccessItInAppLink_Check_Visibility(string not)
        {
            var screen = GetScreen<HomePage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AddAnAppsettingInConfigAndAccessItInAppLink.IsDisplayed, visible);
        }

        [Then(@"link AddAnAppsettingInConfigAndAccessItInAppLink is ([not]?) enabled")]
        public void Then_Link_AddAnAppsettingInConfigAndAccessItInAppLink_Check_Enabled(string not)
        {
            var screen = GetScreen<HomePage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AddAnAppsettingInConfigAndAccessItInAppLink.IsEnabled, enabled);
        }

        [Then(@"button ToggleNavigationButton is ([not]?) visible")]
        public void Then_Button_ToggleNavigationButton_Check_Visibility(string not)
        {
            var screen = GetScreen<HomePage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ToggleNavigationButton.IsDisplayed, visible);
        }

        [Then(@"button ToggleNavigationButton is ([not]?) enabled")]
        public void Then_Button_ToggleNavigationButton_Check_Enabled(string not)
        {
            var screen = GetScreen<HomePage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ToggleNavigationButton.IsEnabled, enabled);
        }
        #endregion
    }
}