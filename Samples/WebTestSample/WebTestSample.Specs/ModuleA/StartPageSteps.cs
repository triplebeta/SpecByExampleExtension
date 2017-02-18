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
    public class StartPageSteps : BaseSeleniumSteps
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state">State is passed in using Constructor Injection</param>
        public StartPageSteps(SeleniumBrowserInfo state) : base(state) { }


        #region Arrange - Given

        [Given("I go to the StartPage on url '(.*)'")]
        public void Given_I_Go_To_Url(string url)
        {
            CurrentWebDriver.Url = url;
            CurrentWebDriver.Navigate();
        }

        #endregion

        #region Act - When


        [When(@"I click the SpecByExampleSampleWebsiteLink link")]
        public void When_I_Click_The_SpecByExampleSampleWebsiteLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.SpecByExampleSampleWebsiteLink.Click();
        }

        [When(@"I click the HomeLink link")]
        public void When_I_Click_The_HomeLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.HomeLink.Click();
        }

        [When(@"I click the AboutLink link")]
        public void When_I_Click_The_AboutLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.AboutLink.Click();
        }

        [When(@"I click the ContactLink link")]
        public void When_I_Click_The_ContactLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.ContactLink.Click();
        }

        [When(@"I click the RegisterLink link")]
        public void When_I_Click_The_RegisterLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.RegisterLink.Click();
        }

        [When(@"I click the LogInLink link")]
        public void When_I_Click_The_LogInLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.LogInLink.Click();
        }

        [When(@"I click the LearnMoreLink1 link")]
        public void When_I_Click_The_LearnMoreLink1_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.LearnMoreLink1.Click();
        }

        [When(@"I click the LearnMoreLink21 link")]
        public void When_I_Click_The_LearnMoreLink21_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.LearnMoreLink21.Click();
        }

        [When(@"I click the LearnMoreLink31 link")]
        public void When_I_Click_The_LearnMoreLink31_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.LearnMoreLink31.Click();
        }

        [When(@"I click the LearnMoreLink41 link")]
        public void When_I_Click_The_LearnMoreLink41_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.LearnMoreLink41.Click();
        }

        [When(@"I click the PreviousLink link")]
        public void When_I_Click_The_PreviousLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.PreviousLink.Click();
        }

        [When(@"I click the NextLink link")]
        public void When_I_Click_The_NextLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.NextLink.Click();
        }

        [When(@"I click the BowerLink link")]
        public void When_I_Click_The_BowerLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.BowerLink.Click();
        }

        [When(@"I click the BootstrapLink link")]
        public void When_I_Click_The_BootstrapLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.BootstrapLink.Click();
        }

        [When(@"I click the AddAControllerAndViewLink link")]
        public void When_I_Click_The_AddAControllerAndViewLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.AddAControllerAndViewLink.Click();
        }

        [When(@"I click the AddAnAppsettingInConfigAndAccessItInAppLink link")]
        public void When_I_Click_The_AddAnAppsettingInConfigAndAccessItInAppLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.AddAnAppsettingInConfigAndAccessItInAppLink.Click();
        }

        [When(@"I click the ManageUserSecretsUsingSecretManagerLink link")]
        public void When_I_Click_The_ManageUserSecretsUsingSecretManagerLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.ManageUserSecretsUsingSecretManagerLink.Click();
        }

        [When(@"I click the UseLoggingToLogAMessageLink link")]
        public void When_I_Click_The_UseLoggingToLogAMessageLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.UseLoggingToLogAMessageLink.Click();
        }

        [When(@"I click the AddPackagesUsingNuGetLink link")]
        public void When_I_Click_The_AddPackagesUsingNuGetLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.AddPackagesUsingNuGetLink.Click();
        }

        [When(@"I click the AddClientPackagesUsingBowerLink link")]
        public void When_I_Click_The_AddClientPackagesUsingBowerLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.AddClientPackagesUsingBowerLink.Click();
        }

        [When(@"I click the TargetDevelopmentStagingOrProductionEnvironmentLink link")]
        public void When_I_Click_The_TargetDevelopmentStagingOrProductionEnvironmentLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.TargetDevelopmentStagingOrProductionEnvironmentLink.Click();
        }

        [When(@"I click the ConceptualOverviewOfWhatIsASPNETCoreLink link")]
        public void When_I_Click_The_ConceptualOverviewOfWhatIsASPNETCoreLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.ConceptualOverviewOfWhatIsASPNETCoreLink.Click();
        }

        [When(@"I click the FundamentalsOfASPNETCoreSuchAsStartupAndMiddlewareLink link")]
        public void When_I_Click_The_FundamentalsOfASPNETCoreSuchAsStartupAndMiddlewareLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.FundamentalsOfASPNETCoreSuchAsStartupAndMiddlewareLink.Click();
        }

        [When(@"I click the WorkingWithDataLink link")]
        public void When_I_Click_The_WorkingWithDataLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.WorkingWithDataLink.Click();
        }

        [When(@"I click the SecurityLink link")]
        public void When_I_Click_The_SecurityLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.SecurityLink.Click();
        }

        [When(@"I click the ClientSideDevelopmentLink link")]
        public void When_I_Click_The_ClientSideDevelopmentLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.ClientSideDevelopmentLink.Click();
        }

        [When(@"I click the DevelopOnDifferentPlatformsLink link")]
        public void When_I_Click_The_DevelopOnDifferentPlatformsLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.DevelopOnDifferentPlatformsLink.Click();
        }

        [When(@"I click the ReadMoreOnTheDocumentationSiteLink link")]
        public void When_I_Click_The_ReadMoreOnTheDocumentationSiteLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.ReadMoreOnTheDocumentationSiteLink.Click();
        }

        [When(@"I click the RunYourAppLink link")]
        public void When_I_Click_The_RunYourAppLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.RunYourAppLink.Click();
        }

        [When(@"I click the RunToolsSuchAsEFMigrationsAndMoreLink link")]
        public void When_I_Click_The_RunToolsSuchAsEFMigrationsAndMoreLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.RunToolsSuchAsEFMigrationsAndMoreLink.Click();
        }

        [When(@"I click the PublishToMicrosoftAzureWebAppsLink link")]
        public void When_I_Click_The_PublishToMicrosoftAzureWebAppsLink_Link()
        {
            var screen = GetScreen<StartPage>();
            screen.PublishToMicrosoftAzureWebAppsLink.Click();
        }

        [When(@"I click the ToggleNavigationButton button")]
        public void When_I_Click_The_ToggleNavigationButton_Button()
        {
            var screen = GetScreen<StartPage>();
            screen.ToggleNavigationButton.Click();
        }

        #endregion

        #region Assert - Then

        [Then(@"link SpecByExampleSampleWebsiteLink is ([not]?) visible")]
        public void Then_Link_SpecByExampleSampleWebsiteLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.SpecByExampleSampleWebsiteLink.IsDisplayed, visible);
        }

        [Then(@"link SpecByExampleSampleWebsiteLink is ([not]?) enabled")]
        public void Then_Link_SpecByExampleSampleWebsiteLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.SpecByExampleSampleWebsiteLink.IsEnabled, enabled);
        }

        [Then(@"link HomeLink is ([not]?) visible")]
        public void Then_Link_HomeLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.HomeLink.IsDisplayed, visible);
        }

        [Then(@"link HomeLink is ([not]?) enabled")]
        public void Then_Link_HomeLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.HomeLink.IsEnabled, enabled);
        }

        [Then(@"link AboutLink is ([not]?) visible")]
        public void Then_Link_AboutLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AboutLink.IsDisplayed, visible);
        }

        [Then(@"link AboutLink is ([not]?) enabled")]
        public void Then_Link_AboutLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AboutLink.IsEnabled, enabled);
        }

        [Then(@"link ContactLink is ([not]?) visible")]
        public void Then_Link_ContactLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ContactLink.IsDisplayed, visible);
        }

        [Then(@"link ContactLink is ([not]?) enabled")]
        public void Then_Link_ContactLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ContactLink.IsEnabled, enabled);
        }

        [Then(@"link RegisterLink is ([not]?) visible")]
        public void Then_Link_RegisterLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.RegisterLink.IsDisplayed, visible);
        }

        [Then(@"link RegisterLink is ([not]?) enabled")]
        public void Then_Link_RegisterLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.RegisterLink.IsEnabled, enabled);
        }

        [Then(@"link LogInLink is ([not]?) visible")]
        public void Then_Link_LogInLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LogInLink.IsDisplayed, visible);
        }

        [Then(@"link LogInLink is ([not]?) enabled")]
        public void Then_Link_LogInLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LogInLink.IsEnabled, enabled);
        }

        [Then(@"link LearnMoreLink1 is ([not]?) visible")]
        public void Then_Link_LearnMoreLink1_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LearnMoreLink1.IsDisplayed, visible);
        }

        [Then(@"link LearnMoreLink1 is ([not]?) enabled")]
        public void Then_Link_LearnMoreLink1_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LearnMoreLink1.IsEnabled, enabled);
        }

        [Then(@"link LearnMoreLink21 is ([not]?) visible")]
        public void Then_Link_LearnMoreLink21_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LearnMoreLink21.IsDisplayed, visible);
        }

        [Then(@"link LearnMoreLink21 is ([not]?) enabled")]
        public void Then_Link_LearnMoreLink21_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LearnMoreLink21.IsEnabled, enabled);
        }

        [Then(@"link LearnMoreLink31 is ([not]?) visible")]
        public void Then_Link_LearnMoreLink31_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LearnMoreLink31.IsDisplayed, visible);
        }

        [Then(@"link LearnMoreLink31 is ([not]?) enabled")]
        public void Then_Link_LearnMoreLink31_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LearnMoreLink31.IsEnabled, enabled);
        }

        [Then(@"link LearnMoreLink41 is ([not]?) visible")]
        public void Then_Link_LearnMoreLink41_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LearnMoreLink41.IsDisplayed, visible);
        }

        [Then(@"link LearnMoreLink41 is ([not]?) enabled")]
        public void Then_Link_LearnMoreLink41_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LearnMoreLink41.IsEnabled, enabled);
        }

        [Then(@"link PreviousLink is ([not]?) visible")]
        public void Then_Link_PreviousLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.PreviousLink.IsDisplayed, visible);
        }

        [Then(@"link PreviousLink is ([not]?) enabled")]
        public void Then_Link_PreviousLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.PreviousLink.IsEnabled, enabled);
        }

        [Then(@"link NextLink is ([not]?) visible")]
        public void Then_Link_NextLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.NextLink.IsDisplayed, visible);
        }

        [Then(@"link NextLink is ([not]?) enabled")]
        public void Then_Link_NextLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.NextLink.IsEnabled, enabled);
        }

        [Then(@"link BowerLink is ([not]?) visible")]
        public void Then_Link_BowerLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.BowerLink.IsDisplayed, visible);
        }

        [Then(@"link BowerLink is ([not]?) enabled")]
        public void Then_Link_BowerLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.BowerLink.IsEnabled, enabled);
        }

        [Then(@"link BootstrapLink is ([not]?) visible")]
        public void Then_Link_BootstrapLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.BootstrapLink.IsDisplayed, visible);
        }

        [Then(@"link BootstrapLink is ([not]?) enabled")]
        public void Then_Link_BootstrapLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.BootstrapLink.IsEnabled, enabled);
        }

        [Then(@"link AddAControllerAndViewLink is ([not]?) visible")]
        public void Then_Link_AddAControllerAndViewLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AddAControllerAndViewLink.IsDisplayed, visible);
        }

        [Then(@"link AddAControllerAndViewLink is ([not]?) enabled")]
        public void Then_Link_AddAControllerAndViewLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AddAControllerAndViewLink.IsEnabled, enabled);
        }

        [Then(@"link AddAnAppsettingInConfigAndAccessItInAppLink is ([not]?) visible")]
        public void Then_Link_AddAnAppsettingInConfigAndAccessItInAppLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AddAnAppsettingInConfigAndAccessItInAppLink.IsDisplayed, visible);
        }

        [Then(@"link AddAnAppsettingInConfigAndAccessItInAppLink is ([not]?) enabled")]
        public void Then_Link_AddAnAppsettingInConfigAndAccessItInAppLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AddAnAppsettingInConfigAndAccessItInAppLink.IsEnabled, enabled);
        }

        [Then(@"link ManageUserSecretsUsingSecretManagerLink is ([not]?) visible")]
        public void Then_Link_ManageUserSecretsUsingSecretManagerLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ManageUserSecretsUsingSecretManagerLink.IsDisplayed, visible);
        }

        [Then(@"link ManageUserSecretsUsingSecretManagerLink is ([not]?) enabled")]
        public void Then_Link_ManageUserSecretsUsingSecretManagerLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ManageUserSecretsUsingSecretManagerLink.IsEnabled, enabled);
        }

        [Then(@"link UseLoggingToLogAMessageLink is ([not]?) visible")]
        public void Then_Link_UseLoggingToLogAMessageLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.UseLoggingToLogAMessageLink.IsDisplayed, visible);
        }

        [Then(@"link UseLoggingToLogAMessageLink is ([not]?) enabled")]
        public void Then_Link_UseLoggingToLogAMessageLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.UseLoggingToLogAMessageLink.IsEnabled, enabled);
        }

        [Then(@"link AddPackagesUsingNuGetLink is ([not]?) visible")]
        public void Then_Link_AddPackagesUsingNuGetLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AddPackagesUsingNuGetLink.IsDisplayed, visible);
        }

        [Then(@"link AddPackagesUsingNuGetLink is ([not]?) enabled")]
        public void Then_Link_AddPackagesUsingNuGetLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AddPackagesUsingNuGetLink.IsEnabled, enabled);
        }

        [Then(@"link AddClientPackagesUsingBowerLink is ([not]?) visible")]
        public void Then_Link_AddClientPackagesUsingBowerLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AddClientPackagesUsingBowerLink.IsDisplayed, visible);
        }

        [Then(@"link AddClientPackagesUsingBowerLink is ([not]?) enabled")]
        public void Then_Link_AddClientPackagesUsingBowerLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AddClientPackagesUsingBowerLink.IsEnabled, enabled);
        }

        [Then(@"link TargetDevelopmentStagingOrProductionEnvironmentLink is ([not]?) visible")]
        public void Then_Link_TargetDevelopmentStagingOrProductionEnvironmentLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.TargetDevelopmentStagingOrProductionEnvironmentLink.IsDisplayed, visible);
        }

        [Then(@"link TargetDevelopmentStagingOrProductionEnvironmentLink is ([not]?) enabled")]
        public void Then_Link_TargetDevelopmentStagingOrProductionEnvironmentLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.TargetDevelopmentStagingOrProductionEnvironmentLink.IsEnabled, enabled);
        }

        [Then(@"link ConceptualOverviewOfWhatIsASPNETCoreLink is ([not]?) visible")]
        public void Then_Link_ConceptualOverviewOfWhatIsASPNETCoreLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ConceptualOverviewOfWhatIsASPNETCoreLink.IsDisplayed, visible);
        }

        [Then(@"link ConceptualOverviewOfWhatIsASPNETCoreLink is ([not]?) enabled")]
        public void Then_Link_ConceptualOverviewOfWhatIsASPNETCoreLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ConceptualOverviewOfWhatIsASPNETCoreLink.IsEnabled, enabled);
        }

        [Then(@"link FundamentalsOfASPNETCoreSuchAsStartupAndMiddlewareLink is ([not]?) visible")]
        public void Then_Link_FundamentalsOfASPNETCoreSuchAsStartupAndMiddlewareLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.FundamentalsOfASPNETCoreSuchAsStartupAndMiddlewareLink.IsDisplayed, visible);
        }

        [Then(@"link FundamentalsOfASPNETCoreSuchAsStartupAndMiddlewareLink is ([not]?) enabled")]
        public void Then_Link_FundamentalsOfASPNETCoreSuchAsStartupAndMiddlewareLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.FundamentalsOfASPNETCoreSuchAsStartupAndMiddlewareLink.IsEnabled, enabled);
        }

        [Then(@"link WorkingWithDataLink is ([not]?) visible")]
        public void Then_Link_WorkingWithDataLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.WorkingWithDataLink.IsDisplayed, visible);
        }

        [Then(@"link WorkingWithDataLink is ([not]?) enabled")]
        public void Then_Link_WorkingWithDataLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.WorkingWithDataLink.IsEnabled, enabled);
        }

        [Then(@"link SecurityLink is ([not]?) visible")]
        public void Then_Link_SecurityLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.SecurityLink.IsDisplayed, visible);
        }

        [Then(@"link SecurityLink is ([not]?) enabled")]
        public void Then_Link_SecurityLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.SecurityLink.IsEnabled, enabled);
        }

        [Then(@"link ClientSideDevelopmentLink is ([not]?) visible")]
        public void Then_Link_ClientSideDevelopmentLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ClientSideDevelopmentLink.IsDisplayed, visible);
        }

        [Then(@"link ClientSideDevelopmentLink is ([not]?) enabled")]
        public void Then_Link_ClientSideDevelopmentLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ClientSideDevelopmentLink.IsEnabled, enabled);
        }

        [Then(@"link DevelopOnDifferentPlatformsLink is ([not]?) visible")]
        public void Then_Link_DevelopOnDifferentPlatformsLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.DevelopOnDifferentPlatformsLink.IsDisplayed, visible);
        }

        [Then(@"link DevelopOnDifferentPlatformsLink is ([not]?) enabled")]
        public void Then_Link_DevelopOnDifferentPlatformsLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.DevelopOnDifferentPlatformsLink.IsEnabled, enabled);
        }

        [Then(@"link ReadMoreOnTheDocumentationSiteLink is ([not]?) visible")]
        public void Then_Link_ReadMoreOnTheDocumentationSiteLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ReadMoreOnTheDocumentationSiteLink.IsDisplayed, visible);
        }

        [Then(@"link ReadMoreOnTheDocumentationSiteLink is ([not]?) enabled")]
        public void Then_Link_ReadMoreOnTheDocumentationSiteLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ReadMoreOnTheDocumentationSiteLink.IsEnabled, enabled);
        }

        [Then(@"link RunYourAppLink is ([not]?) visible")]
        public void Then_Link_RunYourAppLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.RunYourAppLink.IsDisplayed, visible);
        }

        [Then(@"link RunYourAppLink is ([not]?) enabled")]
        public void Then_Link_RunYourAppLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.RunYourAppLink.IsEnabled, enabled);
        }

        [Then(@"link RunToolsSuchAsEFMigrationsAndMoreLink is ([not]?) visible")]
        public void Then_Link_RunToolsSuchAsEFMigrationsAndMoreLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.RunToolsSuchAsEFMigrationsAndMoreLink.IsDisplayed, visible);
        }

        [Then(@"link RunToolsSuchAsEFMigrationsAndMoreLink is ([not]?) enabled")]
        public void Then_Link_RunToolsSuchAsEFMigrationsAndMoreLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.RunToolsSuchAsEFMigrationsAndMoreLink.IsEnabled, enabled);
        }

        [Then(@"link PublishToMicrosoftAzureWebAppsLink is ([not]?) visible")]
        public void Then_Link_PublishToMicrosoftAzureWebAppsLink_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.PublishToMicrosoftAzureWebAppsLink.IsDisplayed, visible);
        }

        [Then(@"link PublishToMicrosoftAzureWebAppsLink is ([not]?) enabled")]
        public void Then_Link_PublishToMicrosoftAzureWebAppsLink_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.PublishToMicrosoftAzureWebAppsLink.IsEnabled, enabled);
        }

        [Then(@"button ToggleNavigationButton is ([not]?) visible")]
        public void Then_Button_ToggleNavigationButton_Check_Visibility(string not)
        {
            var screen = GetScreen<StartPage>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ToggleNavigationButton.IsDisplayed, visible);
        }

        [Then(@"button ToggleNavigationButton is ([not]?) enabled")]
        public void Then_Button_ToggleNavigationButton_Check_Enabled(string not)
        {
            var screen = GetScreen<StartPage>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ToggleNavigationButton.IsEnabled, enabled);
        }
        #endregion
    }
}


