using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecByExample.Common;
using $basename$.Common.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace $safeprojectname$
{
    /// <summary>
    /// Common steps for navigation
    /// </summary>
    [Binding]
    public class CommonNavigationSteps : BaseSeleniumStepsWithoutState
    {

        [Given("I start on the Mainpage")]
        public void Given_I_Am_On_The_Mainpage()
        {
            // Goto the start page
            SeleniumWindowHelper.CloseAllWindowsExcept(CurrentWebDriver, MainWindowHandle);
            CurrentWebDriver.Url = WellKnownUrls.MAIN_PAGE_URL;
            CurrentWebDriver.Navigate();
        }



        #region Act - When

        /// <summary>
        /// Store the current url in the context.
        /// Use this in another step like: When_I_Am_No_Longer_On_The_Original_Url
        /// </summary>
        [When(@"I remember the current url")]
        [Given(@"I remember the current url")]
        public void GivenWhen_I_Remember_The_Current_Url()
        {
            ScenarioContext.Current.Add("CurrentUrl", CurrentWebDriver.Url);
        }


        [When(@"I close the Mainpage")]
        public void WhenICloseTheHoofdscherm()
        {
            CurrentWebDriver.Close();
        }
        
        #endregion


        #region Assert - Then

        
        [Then(@"An alert must be visible with message '(.*)'")]
        public void Then_An_Alert_Must_Be_Visible_With_Message(string message)
        {
            IAlert alert = ScenarioContext.Current["alert"] as IAlert;
            Assert.AreEqual(alert.Text, message);
        }

        [Then(@"I am on screen with code '(.*)'")]
        public void WhenIGoToScreenWithCode(string screencode)
        {
            var genericScreen = GetScreen<Base$rootname$Page>();
            Assert.AreEqual(screencode,genericScreen.PageCode);
        }

        
        /// <summary>
        /// Check the last url added to the context using the
        /// </summary>
        [Then(@"I am no longer on the original url")]
        public void When_I_Am_No_Longer_On_The_Original_Url()
        {
            Assert.AreNotEqual(ScenarioContext.Current["CurrentUrl"], CurrentWebDriver.Url);
        }
 
	    #endregion
    }
}
