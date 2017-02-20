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
    public partial class RegisterAccountSteps : BaseSeleniumSteps
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state">State is passed in using Constructor Injection</param>
        public RegisterAccountSteps(SeleniumBrowserInfo state) : base(state) { }


        #region Arrange - Given

        [Given("I go to the RegisterAccount on url '(.*)'")]
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
            var screen = GetScreen<RegisterAccount>();
            screen.HomeLink.Click();
        }

        [When(@"I click the AboutLink")]
        public void When_I_Click_The_AboutLink()
        {
            var screen = GetScreen<RegisterAccount>();
            screen.AboutLink.Click();
        }

        [When(@"I click the ContactLink")]
        public void When_I_Click_The_ContactLink()
        {
            var screen = GetScreen<RegisterAccount>();
            screen.ContactLink.Click();
        }

        [When(@"I click the RegisterLink")]
        public void When_I_Click_The_RegisterLink()
        {
            var screen = GetScreen<RegisterAccount>();
            screen.RegisterLink.Click();
        }

        [When(@"I click the LogInLink")]
        public void When_I_Click_The_LogInLink()
        {
            var screen = GetScreen<RegisterAccount>();
            screen.LogInLink.Click();
        }

        [When(@"I click the ToggleNavigationButton")]
        public void When_I_Click_The_ToggleNavigationButton()
        {
            var screen = GetScreen<RegisterAccount>();
            screen.ToggleNavigationButton.Click();
        }

        [When(@"I type ""(.*)"" in text PasswordTextbox")]
        public void When_I_Type_In_Text_PasswordTextbox(string text)
        {
            var screen = GetScreen<RegisterAccount>();
            screen.PasswordTextbox.Text = text;
        }

        [When(@"I type ""(.*)"" in text ConfirmPasswordTextbox")]
        public void When_I_Type_In_Text_ConfirmPasswordTextbox(string text)
        {
            var screen = GetScreen<RegisterAccount>();
            screen.ConfirmPasswordTextbox.Text = text;
        }

        [When(@"I type ""(.*)"" in text EmailTextbox")]
        public void When_I_Type_In_Text_EmailTextbox(string text)
        {
            var screen = GetScreen<RegisterAccount>();
            screen.EmailTextbox.Text = text;
        }

        #endregion

        #region Assert - Then

        [Then(@"link HomeLink is ([not]?) visible")]
        public void Then_Link_HomeLink_Check_Visibility(string not)
        {
            var screen = GetScreen<RegisterAccount>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.HomeLink.IsDisplayed, visible);
        }

        [Then(@"link HomeLink is ([not]?) enabled")]
        public void Then_Link_HomeLink_Check_Enabled(string not)
        {
            var screen = GetScreen<RegisterAccount>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.HomeLink.IsEnabled, enabled);
        }

        [Then(@"link AboutLink is ([not]?) visible")]
        public void Then_Link_AboutLink_Check_Visibility(string not)
        {
            var screen = GetScreen<RegisterAccount>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AboutLink.IsDisplayed, visible);
        }

        [Then(@"link AboutLink is ([not]?) enabled")]
        public void Then_Link_AboutLink_Check_Enabled(string not)
        {
            var screen = GetScreen<RegisterAccount>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AboutLink.IsEnabled, enabled);
        }

        [Then(@"link ContactLink is ([not]?) visible")]
        public void Then_Link_ContactLink_Check_Visibility(string not)
        {
            var screen = GetScreen<RegisterAccount>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ContactLink.IsDisplayed, visible);
        }

        [Then(@"link ContactLink is ([not]?) enabled")]
        public void Then_Link_ContactLink_Check_Enabled(string not)
        {
            var screen = GetScreen<RegisterAccount>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ContactLink.IsEnabled, enabled);
        }

        [Then(@"link RegisterLink is ([not]?) visible")]
        public void Then_Link_RegisterLink_Check_Visibility(string not)
        {
            var screen = GetScreen<RegisterAccount>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.RegisterLink.IsDisplayed, visible);
        }

        [Then(@"link RegisterLink is ([not]?) enabled")]
        public void Then_Link_RegisterLink_Check_Enabled(string not)
        {
            var screen = GetScreen<RegisterAccount>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.RegisterLink.IsEnabled, enabled);
        }

        [Then(@"link LogInLink is ([not]?) visible")]
        public void Then_Link_LogInLink_Check_Visibility(string not)
        {
            var screen = GetScreen<RegisterAccount>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LogInLink.IsDisplayed, visible);
        }

        [Then(@"link LogInLink is ([not]?) enabled")]
        public void Then_Link_LogInLink_Check_Enabled(string not)
        {
            var screen = GetScreen<RegisterAccount>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LogInLink.IsEnabled, enabled);
        }

        [Then(@"button ToggleNavigationButton is ([not]?) visible")]
        public void Then_Button_ToggleNavigationButton_Check_Visibility(string not)
        {
            var screen = GetScreen<RegisterAccount>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ToggleNavigationButton.IsDisplayed, visible);
        }

        [Then(@"button ToggleNavigationButton is ([not]?) enabled")]
        public void Then_Button_ToggleNavigationButton_Check_Enabled(string not)
        {
            var screen = GetScreen<RegisterAccount>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ToggleNavigationButton.IsEnabled, enabled);
        }

        [Then(@"text PasswordTextbox is ([not]?) visible")]
        public void Then_Text_PasswordTextbox_Check_Visibility(string not)
        {
            var screen = GetScreen<RegisterAccount>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.PasswordTextbox.IsDisplayed, visible);
        }

        [Then(@"text PasswordTextbox is ([not]?) enabled")]
        public void Then_Text_PasswordTextbox_Check_Enabled(string not)
        {
            var screen = GetScreen<RegisterAccount>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.PasswordTextbox.IsEnabled, enabled);
        }

        [Then(@"the text in text PasswordTextbox is ""(.*)""")]
        public void Then_The_Text_in_Text_PasswordTextbox_Is(string text)
        {
            var screen = GetScreen<RegisterAccount>();
            Assert.AreEqual(screen.PasswordTextbox.Text, text);
        }

        [Then(@"text ConfirmPasswordTextbox is ([not]?) visible")]
        public void Then_Text_ConfirmPasswordTextbox_Check_Visibility(string not)
        {
            var screen = GetScreen<RegisterAccount>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ConfirmPasswordTextbox.IsDisplayed, visible);
        }

        [Then(@"text ConfirmPasswordTextbox is ([not]?) enabled")]
        public void Then_Text_ConfirmPasswordTextbox_Check_Enabled(string not)
        {
            var screen = GetScreen<RegisterAccount>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ConfirmPasswordTextbox.IsEnabled, enabled);
        }

        [Then(@"the text in text ConfirmPasswordTextbox is ""(.*)""")]
        public void Then_The_Text_in_Text_ConfirmPasswordTextbox_Is(string text)
        {
            var screen = GetScreen<RegisterAccount>();
            Assert.AreEqual(screen.ConfirmPasswordTextbox.Text, text);
        }

        [Then(@"text EmailTextbox is ([not]?) visible")]
        public void Then_Text_EmailTextbox_Check_Visibility(string not)
        {
            var screen = GetScreen<RegisterAccount>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.EmailTextbox.IsDisplayed, visible);
        }

        [Then(@"text EmailTextbox is ([not]?) enabled")]
        public void Then_Text_EmailTextbox_Check_Enabled(string not)
        {
            var screen = GetScreen<RegisterAccount>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.EmailTextbox.IsEnabled, enabled);
        }

        [Then(@"the text in text EmailTextbox is ""(.*)""")]
        public void Then_The_Text_in_Text_EmailTextbox_Is(string text)
        {
            var screen = GetScreen<RegisterAccount>();
            Assert.AreEqual(screen.EmailTextbox.Text, text);
        }
        #endregion
    }
}