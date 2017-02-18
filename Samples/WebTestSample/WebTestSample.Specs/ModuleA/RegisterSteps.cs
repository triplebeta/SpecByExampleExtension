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
    public class RegisterSteps : BaseSeleniumSteps
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state">State is passed in using Constructor Injection</param>
        public RegisterSteps(SeleniumBrowserInfo state) : base(state) { }


        #region Arrange - Given

        [Given("I go to the RegisterPage on url '(.*)'")]
        public void Given_I_Go_To_Url(string url)
        {
            CurrentWebDriver.Url = url;
            CurrentWebDriver.Navigate();
        }

        #endregion

        #region Act - When


        [When(@"I type ""(.*)"" in text PasswordTextbox")]
        public void When_I_Type_In_Text_PasswordTextbox(string text)
        {
            var screen = GetScreen<RegisterPage>();
            screen.PasswordTextbox.Text = text;
        }

        [When(@"I type ""(.*)"" in text ConfirmPasswordTextbox")]
        public void When_I_Type_In_Text_ConfirmPasswordTextbox(string text)
        {
            var screen = GetScreen<RegisterPage>();
            screen.ConfirmPasswordTextbox.Text = text;
        }

        [When(@"I type ""(.*)"" in text EmailTextbox")]
        public void When_I_Type_In_Text_EmailTextbox(string text)
        {
            var screen = GetScreen<RegisterPage>();
            screen.EmailTextbox.Text = text;
        }

        [When(@"I click the RegisterButton")]
        public void I_Click_The_RegisterButton()
        {
            var screen = GetScreen<RegisterPage>();
            screen.RegisterButton.Click();
        }

        #endregion

        #region Assert - Then

        [Then(@"text PasswordTextbox is ([not]?) visible")]
        public void Then_Text_PasswordTextbox_Check_Visibility(string not)
        {
            var screen = GetScreen<RegisterPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.PasswordTextbox.IsDisplayed, visible);
        }

        [Then(@"text PasswordTextbox is ([not]?) enabled")]
        public void Then_Text_PasswordTextbox_Check_Enabled(string not)
        {
            var screen = GetScreen<RegisterPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.PasswordTextbox.IsEnabled, enabled);
        }

        [Then(@"The text in text PasswordTextbox is ""(.*)""")]
        public void Then_The_Text_in_Text_PasswordTextbox_Is(string text)
        {
            var screen = GetScreen<RegisterPage>();
            Assert.AreEqual(screen.PasswordTextbox.Text, text);
        }

        [Then(@"text ConfirmPasswordTextbox is ([not]?) visible")]
        public void Then_Text_ConfirmPasswordTextbox_Check_Visibility(string not)
        {
            var screen = GetScreen<RegisterPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ConfirmPasswordTextbox.IsDisplayed, visible);
        }

        [Then(@"text ConfirmPasswordTextbox is ([not]?) enabled")]
        public void Then_Text_ConfirmPasswordTextbox_Check_Enabled(string not)
        {
            var screen = GetScreen<RegisterPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ConfirmPasswordTextbox.IsEnabled, enabled);
        }

        [Then(@"The text in text ConfirmPasswordTextbox is ""(.*)""")]
        public void Then_The_Text_in_Text_ConfirmPasswordTextbox_Is(string text)
        {
            var screen = GetScreen<RegisterPage>();
            Assert.AreEqual(screen.ConfirmPasswordTextbox.Text, text);
        }

        [Then(@"text EmailTextbox is ([not]?) visible")]
        public void Then_Text_EmailTextbox_Check_Visibility(string not)
        {
            var screen = GetScreen<RegisterPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.EmailTextbox.IsDisplayed, visible);
        }

        [Then(@"text EmailTextbox is ([not]?) enabled")]
        public void Then_Text_EmailTextbox_Check_Enabled(string not)
        {
            var screen = GetScreen<RegisterPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.EmailTextbox.IsEnabled, enabled);
        }

        [Then(@"The text in text EmailTextbox is ""(.*)""")]
        public void Then_The_Text_in_Text_EmailTextbox_Is(string text)
        {
            var screen = GetScreen<RegisterPage>();
            Assert.AreEqual(screen.EmailTextbox.Text, text);
        }
        #endregion
    }
}


