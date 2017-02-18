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
    public partial class MyPage1Steps : BaseSeleniumSteps
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state">State is passed in using Constructor Injection</param>
        public MyPage1Steps(SeleniumBrowserInfo state) : base(state) { }


        #region Arrange - Given

        [Given("I go to the MyPage1Page on url '(.*)'")]
        public void Given_I_Go_To_Url(string url)
        {
            CurrentWebDriver.Url = url;
            CurrentWebDriver.Navigate();
        }

        #endregion

        #region Act - When


        [When(@"I click the GaDirectNaarZoekenLink link")]
        public void When_I_Click_The_GaDirectNaarZoekenLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.GaDirectNaarZoekenLink.Click();
        }

        [When(@"I click the GaDirectNaarHetTekstgedeelteLink link")]
        public void When_I_Click_The_GaDirectNaarHetTekstgedeelteLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.GaDirectNaarHetTekstgedeelteLink.Click();
        }

        [When(@"I click the GaDirectNaarDeNavigatieLink link")]
        public void When_I_Click_The_GaDirectNaarDeNavigatieLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.GaDirectNaarDeNavigatieLink.Click();
        }

        [When(@"I click the InwonersLink link")]
        public void When_I_Click_The_InwonersLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.InwonersLink.Click();
        }

        [When(@"I click the PaspoortID_kaartRijbewijsEnUittrekselLink link")]
        public void When_I_Click_The_PaspoortID_kaartRijbewijsEnUittrekselLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.PaspoortID_kaartRijbewijsEnUittrekselLink.Click();
        }

        [When(@"I click the AfvalLink link")]
        public void When_I_Click_The_AfvalLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.AfvalLink.Click();
        }

        [When(@"I click the MeldingenLink1 link")]
        public void When_I_Click_The_MeldingenLink1_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.MeldingenLink1.Click();
        }

        [When(@"I click the WerkEnInkomenLink link")]
        public void When_I_Click_The_WerkEnInkomenLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.WerkEnInkomenLink.Click();
        }

        [When(@"I click the ZorgLink1 link")]
        public void When_I_Click_The_ZorgLink1_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.ZorgLink1.Click();
        }

        [When(@"I click the WonenEnVerbouwenLink link")]
        public void When_I_Click_The_WonenEnVerbouwenLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.WonenEnVerbouwenLink.Click();
        }

        [When(@"I click the GeboorteTrouwenEnOverlijdenLink link")]
        public void When_I_Click_The_GeboorteTrouwenEnOverlijdenLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.GeboorteTrouwenEnOverlijdenLink.Click();
        }

        [When(@"I click the JeugdEnOnderwijsLink link")]
        public void When_I_Click_The_JeugdEnOnderwijsLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.JeugdEnOnderwijsLink.Click();
        }

        [When(@"I click the VerkeerLink link")]
        public void When_I_Click_The_VerkeerLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.VerkeerLink.Click();
        }

        [When(@"I click the CultuurEnVrijeTijdLink link")]
        public void When_I_Click_The_CultuurEnVrijeTijdLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.CultuurEnVrijeTijdLink.Click();
        }

        [When(@"I click the PraatEnDoeMeeLink link")]
        public void When_I_Click_The_PraatEnDoeMeeLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.PraatEnDoeMeeLink.Click();
        }

        [When(@"I click the BelastingenEnWOZLink link")]
        public void When_I_Click_The_BelastingenEnWOZLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.BelastingenEnWOZLink.Click();
        }

        [When(@"I click the ActueelLink link")]
        public void When_I_Click_The_ActueelLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.ActueelLink.Click();
        }

        [When(@"I click the OndernemersLink link")]
        public void When_I_Click_The_OndernemersLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.OndernemersLink.Click();
        }

        [When(@"I click the StartenLink link")]
        public void When_I_Click_The_StartenLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.StartenLink.Click();
        }

        [When(@"I click the VestigenLink link")]
        public void When_I_Click_The_VestigenLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.VestigenLink.Click();
        }

        [When(@"I click the UitbreidenOfVerbouwenLink link")]
        public void When_I_Click_The_UitbreidenOfVerbouwenLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.UitbreidenOfVerbouwenLink.Click();
        }

        [When(@"I click the HorecaLink link")]
        public void When_I_Click_The_HorecaLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.HorecaLink.Click();
        }

        [When(@"I click the BelastingenLink link")]
        public void When_I_Click_The_BelastingenLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.BelastingenLink.Click();
        }

        [When(@"I click the OndersteuningVoorOndernemersLink link")]
        public void When_I_Click_The_OndersteuningVoorOndernemersLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.OndersteuningVoorOndernemersLink.Click();
        }

        [When(@"I click the NieuwsEnProjectenLink link")]
        public void When_I_Click_The_NieuwsEnProjectenLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.NieuwsEnProjectenLink.Click();
        }

        [When(@"I click the InkoopEnAanbestedingLink link")]
        public void When_I_Click_The_InkoopEnAanbestedingLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.InkoopEnAanbestedingLink.Click();
        }

        [When(@"I click the BestuurLink link")]
        public void When_I_Click_The_BestuurLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.BestuurLink.Click();
        }

        [When(@"I click the GemeenteraadLink link")]
        public void When_I_Click_The_GemeenteraadLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.GemeenteraadLink.Click();
        }

        [When(@"I click the CollegeVanBWLink link")]
        public void When_I_Click_The_CollegeVanBWLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.CollegeVanBWLink.Click();
        }

        [When(@"I click the VergaderkalenderLink link")]
        public void When_I_Click_The_VergaderkalenderLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.VergaderkalenderLink.Click();
        }

        [When(@"I click the BekijkDeRaadsvergaderingLink link")]
        public void When_I_Click_The_BekijkDeRaadsvergaderingLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.BekijkDeRaadsvergaderingLink.Click();
        }

        [When(@"I click the BeleidLink link")]
        public void When_I_Click_The_BeleidLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.BeleidLink.Click();
        }

        [When(@"I click the WerkenBijDeGemeenteLink link")]
        public void When_I_Click_The_WerkenBijDeGemeenteLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.WerkenBijDeGemeenteLink.Click();
        }

        [When(@"I click the FinanciënLink link")]
        public void When_I_Click_The_FinanciënLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.FinanciënLink.Click();
        }

        [When(@"I click the GaNaarBovenLink1 link")]
        public void When_I_Click_The_GaNaarBovenLink1_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.GaNaarBovenLink1.Click();
        }

        [When(@"I click the OpeningstijdenContactLink link")]
        public void When_I_Click_The_OpeningstijdenContactLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.OpeningstijdenContactLink.Click();
        }

        [When(@"I click the AfvalkalenderLink link")]
        public void When_I_Click_The_AfvalkalenderLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.AfvalkalenderLink.Click();
        }

        [When(@"I click the PaspoortID_kaartRijbewijsLink link")]
        public void When_I_Click_The_PaspoortID_kaartRijbewijsLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.PaspoortID_kaartRijbewijsLink.Click();
        }

        [When(@"I click the WerkInkomenLink link")]
        public void When_I_Click_The_WerkInkomenLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.WerkInkomenLink.Click();
        }

        [When(@"I click the VerhuizenLink link")]
        public void When_I_Click_The_VerhuizenLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.VerhuizenLink.Click();
        }

        [When(@"I click the HondenbelastingLink link")]
        public void When_I_Click_The_HondenbelastingLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.HondenbelastingLink.Click();
        }

        [When(@"I click the GaNaarBenedenLink1 link")]
        public void When_I_Click_The_GaNaarBenedenLink1_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.GaNaarBenedenLink1.Click();
        }

        [When(@"I click the GroterAALink link")]
        public void When_I_Click_The_GroterAALink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.GroterAALink.Click();
        }

        [When(@"I click the LeesVoorLink link")]
        public void When_I_Click_The_LeesVoorLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.LeesVoorLink.Click();
        }

        [When(@"I click the ContrastLink link")]
        public void When_I_Click_The_ContrastLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.ContrastLink.Click();
        }

        [When(@"I click the OorkondeVoorReddingsactieOpBergseMaasVoorLink link")]
        public void When_I_Click_The_OorkondeVoorReddingsactieOpBergseMaasVoorLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.OorkondeVoorReddingsactieOpBergseMaasVoorLink.Click();
        }

        [When(@"I click the AfrondendeWerkzaamhedenMarktEnBrandestraatLink link")]
        public void When_I_Click_The_AfrondendeWerkzaamhedenMarktEnBrandestraatLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.AfrondendeWerkzaamhedenMarktEnBrandestraatLink.Click();
        }

        [When(@"I click the MaakteDeGemeenteBekendLink link")]
        public void When_I_Click_The_MaakteDeGemeenteBekendLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.MaakteDeGemeenteBekendLink.Click();
        }

        [When(@"I click the OndertekeningParticipatieverklaringLink link")]
        public void When_I_Click_The_OndertekeningParticipatieverklaringLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.OndertekeningParticipatieverklaringLink.Click();
        }

        [When(@"I click the VerkiezingenOp15Maart2017MogenNederlandersDie18JaarEnOuderZijnKiezenWieHenVertegenwoordigenInDeTweedeKamerLink link")]
        public void When_I_Click_The_VerkiezingenOp15Maart2017MogenNederlandersDie18JaarEnOuderZijnKiezenWieHenVertegenwoordigenInDeTweedeKamerLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.VerkiezingenOp15Maart2017MogenNederlandersDie18JaarEnOuderZijnKiezenWieHenVertegenwoordigenInDeTweedeKamerLink.Click();
        }

        [When(@"I click the GeertruidenbergZoektHistorischeSchepenDeGemeenteGeertruidenbergIsOpZoekNaarEnkeleHistorischeWoonschepenDieWillenAanmerenAanDeTimmersteeLink link")]
        public void When_I_Click_The_GeertruidenbergZoektHistorischeSchepenDeGemeenteGeertruidenbergIsOpZoekNaarEnkeleHistorischeWoonschepenDieWillenAanmerenAanDeTimmersteeLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.GeertruidenbergZoektHistorischeSchepenDeGemeenteGeertruidenbergIsOpZoekNaarEnkeleHistorischeWoonschepenDieWillenAanmerenAanDeTimmersteeLink.Click();
        }

        [When(@"I click the ProjectDonge_oeversOmDeRecreatieveAantrekkingskrachtVanGeertruidenbergTeVergrotenOntwikkelenWijdeKomendeJarenVerschillLink link")]
        public void When_I_Click_The_ProjectDonge_oeversOmDeRecreatieveAantrekkingskrachtVanGeertruidenbergTeVergrotenOntwikkelenWijdeKomendeJarenVerschillLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.ProjectDonge_oeversOmDeRecreatieveAantrekkingskrachtVanGeertruidenbergTeVergrotenOntwikkelenWijdeKomendeJarenVerschillLink.Click();
        }

        [When(@"I click the AfspraakMakenLink link")]
        public void When_I_Click_The_AfspraakMakenLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.AfspraakMakenLink.Click();
        }

        [When(@"I click the InfogeertruidenbergnlLink link")]
        public void When_I_Click_The_InfogeertruidenbergnlLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.InfogeertruidenbergnlLink.Click();
        }

        [When(@"I click the TwitterLink link")]
        public void When_I_Click_The_TwitterLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.TwitterLink.Click();
        }

        [When(@"I click the FacebookLink link")]
        public void When_I_Click_The_FacebookLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.FacebookLink.Click();
        }

        [When(@"I click the RSSLink link")]
        public void When_I_Click_The_RSSLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.RSSLink.Click();
        }

        [When(@"I click the ProclaimerLink link")]
        public void When_I_Click_The_ProclaimerLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.ProclaimerLink.Click();
        }

        [When(@"I click the SitemapLink link")]
        public void When_I_Click_The_SitemapLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.SitemapLink.Click();
        }

        [When(@"I click the LaatHetOnsWetenLink link")]
        public void When_I_Click_The_LaatHetOnsWetenLink_Link()
        {
            var screen = GetScreen<MyPage1Page>();
            screen.LaatHetOnsWetenLink.Click();
        }

        [When(@"I type ""(.*)"" in text Search_trefwoordTextbox")]
        public void When_I_Type_In_Text_Search_trefwoordTextbox(string text)
        {
            var screen = GetScreen<MyPage1Page>();
            screen.Search_trefwoordTextbox.Text = text;
        }

        #endregion

        #region Assert - Then

        [Then(@"link GaDirectNaarZoekenLink is ([not]?) visible")]
        public void Then_Link_GaDirectNaarZoekenLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.GaDirectNaarZoekenLink.IsDisplayed, visible);
        }

        [Then(@"link GaDirectNaarZoekenLink is ([not]?) enabled")]
        public void Then_Link_GaDirectNaarZoekenLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.GaDirectNaarZoekenLink.IsEnabled, enabled);
        }

        [Then(@"link GaDirectNaarHetTekstgedeelteLink is ([not]?) visible")]
        public void Then_Link_GaDirectNaarHetTekstgedeelteLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.GaDirectNaarHetTekstgedeelteLink.IsDisplayed, visible);
        }

        [Then(@"link GaDirectNaarHetTekstgedeelteLink is ([not]?) enabled")]
        public void Then_Link_GaDirectNaarHetTekstgedeelteLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.GaDirectNaarHetTekstgedeelteLink.IsEnabled, enabled);
        }

        [Then(@"link GaDirectNaarDeNavigatieLink is ([not]?) visible")]
        public void Then_Link_GaDirectNaarDeNavigatieLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.GaDirectNaarDeNavigatieLink.IsDisplayed, visible);
        }

        [Then(@"link GaDirectNaarDeNavigatieLink is ([not]?) enabled")]
        public void Then_Link_GaDirectNaarDeNavigatieLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.GaDirectNaarDeNavigatieLink.IsEnabled, enabled);
        }

        [Then(@"link InwonersLink is ([not]?) visible")]
        public void Then_Link_InwonersLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.InwonersLink.IsDisplayed, visible);
        }

        [Then(@"link InwonersLink is ([not]?) enabled")]
        public void Then_Link_InwonersLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.InwonersLink.IsEnabled, enabled);
        }

        [Then(@"link PaspoortID_kaartRijbewijsEnUittrekselLink is ([not]?) visible")]
        public void Then_Link_PaspoortID_kaartRijbewijsEnUittrekselLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.PaspoortID_kaartRijbewijsEnUittrekselLink.IsDisplayed, visible);
        }

        [Then(@"link PaspoortID_kaartRijbewijsEnUittrekselLink is ([not]?) enabled")]
        public void Then_Link_PaspoortID_kaartRijbewijsEnUittrekselLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.PaspoortID_kaartRijbewijsEnUittrekselLink.IsEnabled, enabled);
        }

        [Then(@"link AfvalLink is ([not]?) visible")]
        public void Then_Link_AfvalLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AfvalLink.IsDisplayed, visible);
        }

        [Then(@"link AfvalLink is ([not]?) enabled")]
        public void Then_Link_AfvalLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AfvalLink.IsEnabled, enabled);
        }

        [Then(@"link MeldingenLink1 is ([not]?) visible")]
        public void Then_Link_MeldingenLink1_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.MeldingenLink1.IsDisplayed, visible);
        }

        [Then(@"link MeldingenLink1 is ([not]?) enabled")]
        public void Then_Link_MeldingenLink1_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.MeldingenLink1.IsEnabled, enabled);
        }

        [Then(@"link WerkEnInkomenLink is ([not]?) visible")]
        public void Then_Link_WerkEnInkomenLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.WerkEnInkomenLink.IsDisplayed, visible);
        }

        [Then(@"link WerkEnInkomenLink is ([not]?) enabled")]
        public void Then_Link_WerkEnInkomenLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.WerkEnInkomenLink.IsEnabled, enabled);
        }

        [Then(@"link ZorgLink1 is ([not]?) visible")]
        public void Then_Link_ZorgLink1_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ZorgLink1.IsDisplayed, visible);
        }

        [Then(@"link ZorgLink1 is ([not]?) enabled")]
        public void Then_Link_ZorgLink1_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ZorgLink1.IsEnabled, enabled);
        }

        [Then(@"link WonenEnVerbouwenLink is ([not]?) visible")]
        public void Then_Link_WonenEnVerbouwenLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.WonenEnVerbouwenLink.IsDisplayed, visible);
        }

        [Then(@"link WonenEnVerbouwenLink is ([not]?) enabled")]
        public void Then_Link_WonenEnVerbouwenLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.WonenEnVerbouwenLink.IsEnabled, enabled);
        }

        [Then(@"link GeboorteTrouwenEnOverlijdenLink is ([not]?) visible")]
        public void Then_Link_GeboorteTrouwenEnOverlijdenLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.GeboorteTrouwenEnOverlijdenLink.IsDisplayed, visible);
        }

        [Then(@"link GeboorteTrouwenEnOverlijdenLink is ([not]?) enabled")]
        public void Then_Link_GeboorteTrouwenEnOverlijdenLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.GeboorteTrouwenEnOverlijdenLink.IsEnabled, enabled);
        }

        [Then(@"link JeugdEnOnderwijsLink is ([not]?) visible")]
        public void Then_Link_JeugdEnOnderwijsLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.JeugdEnOnderwijsLink.IsDisplayed, visible);
        }

        [Then(@"link JeugdEnOnderwijsLink is ([not]?) enabled")]
        public void Then_Link_JeugdEnOnderwijsLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.JeugdEnOnderwijsLink.IsEnabled, enabled);
        }

        [Then(@"link VerkeerLink is ([not]?) visible")]
        public void Then_Link_VerkeerLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.VerkeerLink.IsDisplayed, visible);
        }

        [Then(@"link VerkeerLink is ([not]?) enabled")]
        public void Then_Link_VerkeerLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.VerkeerLink.IsEnabled, enabled);
        }

        [Then(@"link CultuurEnVrijeTijdLink is ([not]?) visible")]
        public void Then_Link_CultuurEnVrijeTijdLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.CultuurEnVrijeTijdLink.IsDisplayed, visible);
        }

        [Then(@"link CultuurEnVrijeTijdLink is ([not]?) enabled")]
        public void Then_Link_CultuurEnVrijeTijdLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.CultuurEnVrijeTijdLink.IsEnabled, enabled);
        }

        [Then(@"link PraatEnDoeMeeLink is ([not]?) visible")]
        public void Then_Link_PraatEnDoeMeeLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.PraatEnDoeMeeLink.IsDisplayed, visible);
        }

        [Then(@"link PraatEnDoeMeeLink is ([not]?) enabled")]
        public void Then_Link_PraatEnDoeMeeLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.PraatEnDoeMeeLink.IsEnabled, enabled);
        }

        [Then(@"link BelastingenEnWOZLink is ([not]?) visible")]
        public void Then_Link_BelastingenEnWOZLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.BelastingenEnWOZLink.IsDisplayed, visible);
        }

        [Then(@"link BelastingenEnWOZLink is ([not]?) enabled")]
        public void Then_Link_BelastingenEnWOZLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.BelastingenEnWOZLink.IsEnabled, enabled);
        }

        [Then(@"link ActueelLink is ([not]?) visible")]
        public void Then_Link_ActueelLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ActueelLink.IsDisplayed, visible);
        }

        [Then(@"link ActueelLink is ([not]?) enabled")]
        public void Then_Link_ActueelLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ActueelLink.IsEnabled, enabled);
        }

        [Then(@"link OndernemersLink is ([not]?) visible")]
        public void Then_Link_OndernemersLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.OndernemersLink.IsDisplayed, visible);
        }

        [Then(@"link OndernemersLink is ([not]?) enabled")]
        public void Then_Link_OndernemersLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.OndernemersLink.IsEnabled, enabled);
        }

        [Then(@"link StartenLink is ([not]?) visible")]
        public void Then_Link_StartenLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.StartenLink.IsDisplayed, visible);
        }

        [Then(@"link StartenLink is ([not]?) enabled")]
        public void Then_Link_StartenLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.StartenLink.IsEnabled, enabled);
        }

        [Then(@"link VestigenLink is ([not]?) visible")]
        public void Then_Link_VestigenLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.VestigenLink.IsDisplayed, visible);
        }

        [Then(@"link VestigenLink is ([not]?) enabled")]
        public void Then_Link_VestigenLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.VestigenLink.IsEnabled, enabled);
        }

        [Then(@"link UitbreidenOfVerbouwenLink is ([not]?) visible")]
        public void Then_Link_UitbreidenOfVerbouwenLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.UitbreidenOfVerbouwenLink.IsDisplayed, visible);
        }

        [Then(@"link UitbreidenOfVerbouwenLink is ([not]?) enabled")]
        public void Then_Link_UitbreidenOfVerbouwenLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.UitbreidenOfVerbouwenLink.IsEnabled, enabled);
        }

        [Then(@"link HorecaLink is ([not]?) visible")]
        public void Then_Link_HorecaLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.HorecaLink.IsDisplayed, visible);
        }

        [Then(@"link HorecaLink is ([not]?) enabled")]
        public void Then_Link_HorecaLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.HorecaLink.IsEnabled, enabled);
        }

        [Then(@"link BelastingenLink is ([not]?) visible")]
        public void Then_Link_BelastingenLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.BelastingenLink.IsDisplayed, visible);
        }

        [Then(@"link BelastingenLink is ([not]?) enabled")]
        public void Then_Link_BelastingenLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.BelastingenLink.IsEnabled, enabled);
        }

        [Then(@"link OndersteuningVoorOndernemersLink is ([not]?) visible")]
        public void Then_Link_OndersteuningVoorOndernemersLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.OndersteuningVoorOndernemersLink.IsDisplayed, visible);
        }

        [Then(@"link OndersteuningVoorOndernemersLink is ([not]?) enabled")]
        public void Then_Link_OndersteuningVoorOndernemersLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.OndersteuningVoorOndernemersLink.IsEnabled, enabled);
        }

        [Then(@"link NieuwsEnProjectenLink is ([not]?) visible")]
        public void Then_Link_NieuwsEnProjectenLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.NieuwsEnProjectenLink.IsDisplayed, visible);
        }

        [Then(@"link NieuwsEnProjectenLink is ([not]?) enabled")]
        public void Then_Link_NieuwsEnProjectenLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.NieuwsEnProjectenLink.IsEnabled, enabled);
        }

        [Then(@"link InkoopEnAanbestedingLink is ([not]?) visible")]
        public void Then_Link_InkoopEnAanbestedingLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.InkoopEnAanbestedingLink.IsDisplayed, visible);
        }

        [Then(@"link InkoopEnAanbestedingLink is ([not]?) enabled")]
        public void Then_Link_InkoopEnAanbestedingLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.InkoopEnAanbestedingLink.IsEnabled, enabled);
        }

        [Then(@"link BestuurLink is ([not]?) visible")]
        public void Then_Link_BestuurLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.BestuurLink.IsDisplayed, visible);
        }

        [Then(@"link BestuurLink is ([not]?) enabled")]
        public void Then_Link_BestuurLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.BestuurLink.IsEnabled, enabled);
        }

        [Then(@"link GemeenteraadLink is ([not]?) visible")]
        public void Then_Link_GemeenteraadLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.GemeenteraadLink.IsDisplayed, visible);
        }

        [Then(@"link GemeenteraadLink is ([not]?) enabled")]
        public void Then_Link_GemeenteraadLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.GemeenteraadLink.IsEnabled, enabled);
        }

        [Then(@"link CollegeVanBWLink is ([not]?) visible")]
        public void Then_Link_CollegeVanBWLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.CollegeVanBWLink.IsDisplayed, visible);
        }

        [Then(@"link CollegeVanBWLink is ([not]?) enabled")]
        public void Then_Link_CollegeVanBWLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.CollegeVanBWLink.IsEnabled, enabled);
        }

        [Then(@"link VergaderkalenderLink is ([not]?) visible")]
        public void Then_Link_VergaderkalenderLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.VergaderkalenderLink.IsDisplayed, visible);
        }

        [Then(@"link VergaderkalenderLink is ([not]?) enabled")]
        public void Then_Link_VergaderkalenderLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.VergaderkalenderLink.IsEnabled, enabled);
        }

        [Then(@"link BekijkDeRaadsvergaderingLink is ([not]?) visible")]
        public void Then_Link_BekijkDeRaadsvergaderingLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.BekijkDeRaadsvergaderingLink.IsDisplayed, visible);
        }

        [Then(@"link BekijkDeRaadsvergaderingLink is ([not]?) enabled")]
        public void Then_Link_BekijkDeRaadsvergaderingLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.BekijkDeRaadsvergaderingLink.IsEnabled, enabled);
        }

        [Then(@"link BeleidLink is ([not]?) visible")]
        public void Then_Link_BeleidLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.BeleidLink.IsDisplayed, visible);
        }

        [Then(@"link BeleidLink is ([not]?) enabled")]
        public void Then_Link_BeleidLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.BeleidLink.IsEnabled, enabled);
        }

        [Then(@"link WerkenBijDeGemeenteLink is ([not]?) visible")]
        public void Then_Link_WerkenBijDeGemeenteLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.WerkenBijDeGemeenteLink.IsDisplayed, visible);
        }

        [Then(@"link WerkenBijDeGemeenteLink is ([not]?) enabled")]
        public void Then_Link_WerkenBijDeGemeenteLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.WerkenBijDeGemeenteLink.IsEnabled, enabled);
        }

        [Then(@"link FinanciënLink is ([not]?) visible")]
        public void Then_Link_FinanciënLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.FinanciënLink.IsDisplayed, visible);
        }

        [Then(@"link FinanciënLink is ([not]?) enabled")]
        public void Then_Link_FinanciënLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.FinanciënLink.IsEnabled, enabled);
        }

        [Then(@"link GaNaarBovenLink1 is ([not]?) visible")]
        public void Then_Link_GaNaarBovenLink1_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.GaNaarBovenLink1.IsDisplayed, visible);
        }

        [Then(@"link GaNaarBovenLink1 is ([not]?) enabled")]
        public void Then_Link_GaNaarBovenLink1_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.GaNaarBovenLink1.IsEnabled, enabled);
        }

        [Then(@"link OpeningstijdenContactLink is ([not]?) visible")]
        public void Then_Link_OpeningstijdenContactLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.OpeningstijdenContactLink.IsDisplayed, visible);
        }

        [Then(@"link OpeningstijdenContactLink is ([not]?) enabled")]
        public void Then_Link_OpeningstijdenContactLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.OpeningstijdenContactLink.IsEnabled, enabled);
        }

        [Then(@"link AfvalkalenderLink is ([not]?) visible")]
        public void Then_Link_AfvalkalenderLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AfvalkalenderLink.IsDisplayed, visible);
        }

        [Then(@"link AfvalkalenderLink is ([not]?) enabled")]
        public void Then_Link_AfvalkalenderLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AfvalkalenderLink.IsEnabled, enabled);
        }

        [Then(@"link PaspoortID_kaartRijbewijsLink is ([not]?) visible")]
        public void Then_Link_PaspoortID_kaartRijbewijsLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.PaspoortID_kaartRijbewijsLink.IsDisplayed, visible);
        }

        [Then(@"link PaspoortID_kaartRijbewijsLink is ([not]?) enabled")]
        public void Then_Link_PaspoortID_kaartRijbewijsLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.PaspoortID_kaartRijbewijsLink.IsEnabled, enabled);
        }

        [Then(@"link WerkInkomenLink is ([not]?) visible")]
        public void Then_Link_WerkInkomenLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.WerkInkomenLink.IsDisplayed, visible);
        }

        [Then(@"link WerkInkomenLink is ([not]?) enabled")]
        public void Then_Link_WerkInkomenLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.WerkInkomenLink.IsEnabled, enabled);
        }

        [Then(@"link VerhuizenLink is ([not]?) visible")]
        public void Then_Link_VerhuizenLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.VerhuizenLink.IsDisplayed, visible);
        }

        [Then(@"link VerhuizenLink is ([not]?) enabled")]
        public void Then_Link_VerhuizenLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.VerhuizenLink.IsEnabled, enabled);
        }

        [Then(@"link HondenbelastingLink is ([not]?) visible")]
        public void Then_Link_HondenbelastingLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.HondenbelastingLink.IsDisplayed, visible);
        }

        [Then(@"link HondenbelastingLink is ([not]?) enabled")]
        public void Then_Link_HondenbelastingLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.HondenbelastingLink.IsEnabled, enabled);
        }

        [Then(@"link GaNaarBenedenLink1 is ([not]?) visible")]
        public void Then_Link_GaNaarBenedenLink1_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.GaNaarBenedenLink1.IsDisplayed, visible);
        }

        [Then(@"link GaNaarBenedenLink1 is ([not]?) enabled")]
        public void Then_Link_GaNaarBenedenLink1_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.GaNaarBenedenLink1.IsEnabled, enabled);
        }

        [Then(@"link GroterAALink is ([not]?) visible")]
        public void Then_Link_GroterAALink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.GroterAALink.IsDisplayed, visible);
        }

        [Then(@"link GroterAALink is ([not]?) enabled")]
        public void Then_Link_GroterAALink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.GroterAALink.IsEnabled, enabled);
        }

        [Then(@"link LeesVoorLink is ([not]?) visible")]
        public void Then_Link_LeesVoorLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LeesVoorLink.IsDisplayed, visible);
        }

        [Then(@"link LeesVoorLink is ([not]?) enabled")]
        public void Then_Link_LeesVoorLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LeesVoorLink.IsEnabled, enabled);
        }

        [Then(@"link ContrastLink is ([not]?) visible")]
        public void Then_Link_ContrastLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ContrastLink.IsDisplayed, visible);
        }

        [Then(@"link ContrastLink is ([not]?) enabled")]
        public void Then_Link_ContrastLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ContrastLink.IsEnabled, enabled);
        }

        [Then(@"link OorkondeVoorReddingsactieOpBergseMaasVoorLink is ([not]?) visible")]
        public void Then_Link_OorkondeVoorReddingsactieOpBergseMaasVoorLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.OorkondeVoorReddingsactieOpBergseMaasVoorLink.IsDisplayed, visible);
        }

        [Then(@"link OorkondeVoorReddingsactieOpBergseMaasVoorLink is ([not]?) enabled")]
        public void Then_Link_OorkondeVoorReddingsactieOpBergseMaasVoorLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.OorkondeVoorReddingsactieOpBergseMaasVoorLink.IsEnabled, enabled);
        }

        [Then(@"link AfrondendeWerkzaamhedenMarktEnBrandestraatLink is ([not]?) visible")]
        public void Then_Link_AfrondendeWerkzaamhedenMarktEnBrandestraatLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AfrondendeWerkzaamhedenMarktEnBrandestraatLink.IsDisplayed, visible);
        }

        [Then(@"link AfrondendeWerkzaamhedenMarktEnBrandestraatLink is ([not]?) enabled")]
        public void Then_Link_AfrondendeWerkzaamhedenMarktEnBrandestraatLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AfrondendeWerkzaamhedenMarktEnBrandestraatLink.IsEnabled, enabled);
        }

        [Then(@"link MaakteDeGemeenteBekendLink is ([not]?) visible")]
        public void Then_Link_MaakteDeGemeenteBekendLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.MaakteDeGemeenteBekendLink.IsDisplayed, visible);
        }

        [Then(@"link MaakteDeGemeenteBekendLink is ([not]?) enabled")]
        public void Then_Link_MaakteDeGemeenteBekendLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.MaakteDeGemeenteBekendLink.IsEnabled, enabled);
        }

        [Then(@"link OndertekeningParticipatieverklaringLink is ([not]?) visible")]
        public void Then_Link_OndertekeningParticipatieverklaringLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.OndertekeningParticipatieverklaringLink.IsDisplayed, visible);
        }

        [Then(@"link OndertekeningParticipatieverklaringLink is ([not]?) enabled")]
        public void Then_Link_OndertekeningParticipatieverklaringLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.OndertekeningParticipatieverklaringLink.IsEnabled, enabled);
        }

        [Then(@"link VerkiezingenOp15Maart2017MogenNederlandersDie18JaarEnOuderZijnKiezenWieHenVertegenwoordigenInDeTweedeKamerLink is ([not]?) visible")]
        public void Then_Link_VerkiezingenOp15Maart2017MogenNederlandersDie18JaarEnOuderZijnKiezenWieHenVertegenwoordigenInDeTweedeKamerLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.VerkiezingenOp15Maart2017MogenNederlandersDie18JaarEnOuderZijnKiezenWieHenVertegenwoordigenInDeTweedeKamerLink.IsDisplayed, visible);
        }

        [Then(@"link VerkiezingenOp15Maart2017MogenNederlandersDie18JaarEnOuderZijnKiezenWieHenVertegenwoordigenInDeTweedeKamerLink is ([not]?) enabled")]
        public void Then_Link_VerkiezingenOp15Maart2017MogenNederlandersDie18JaarEnOuderZijnKiezenWieHenVertegenwoordigenInDeTweedeKamerLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.VerkiezingenOp15Maart2017MogenNederlandersDie18JaarEnOuderZijnKiezenWieHenVertegenwoordigenInDeTweedeKamerLink.IsEnabled, enabled);
        }

        [Then(@"link GeertruidenbergZoektHistorischeSchepenDeGemeenteGeertruidenbergIsOpZoekNaarEnkeleHistorischeWoonschepenDieWillenAanmerenAanDeTimmersteeLink is ([not]?) visible")]
        public void Then_Link_GeertruidenbergZoektHistorischeSchepenDeGemeenteGeertruidenbergIsOpZoekNaarEnkeleHistorischeWoonschepenDieWillenAanmerenAanDeTimmersteeLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.GeertruidenbergZoektHistorischeSchepenDeGemeenteGeertruidenbergIsOpZoekNaarEnkeleHistorischeWoonschepenDieWillenAanmerenAanDeTimmersteeLink.IsDisplayed, visible);
        }

        [Then(@"link GeertruidenbergZoektHistorischeSchepenDeGemeenteGeertruidenbergIsOpZoekNaarEnkeleHistorischeWoonschepenDieWillenAanmerenAanDeTimmersteeLink is ([not]?) enabled")]
        public void Then_Link_GeertruidenbergZoektHistorischeSchepenDeGemeenteGeertruidenbergIsOpZoekNaarEnkeleHistorischeWoonschepenDieWillenAanmerenAanDeTimmersteeLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.GeertruidenbergZoektHistorischeSchepenDeGemeenteGeertruidenbergIsOpZoekNaarEnkeleHistorischeWoonschepenDieWillenAanmerenAanDeTimmersteeLink.IsEnabled, enabled);
        }

        [Then(@"link ProjectDonge_oeversOmDeRecreatieveAantrekkingskrachtVanGeertruidenbergTeVergrotenOntwikkelenWijdeKomendeJarenVerschillLink is ([not]?) visible")]
        public void Then_Link_ProjectDonge_oeversOmDeRecreatieveAantrekkingskrachtVanGeertruidenbergTeVergrotenOntwikkelenWijdeKomendeJarenVerschillLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ProjectDonge_oeversOmDeRecreatieveAantrekkingskrachtVanGeertruidenbergTeVergrotenOntwikkelenWijdeKomendeJarenVerschillLink.IsDisplayed, visible);
        }

        [Then(@"link ProjectDonge_oeversOmDeRecreatieveAantrekkingskrachtVanGeertruidenbergTeVergrotenOntwikkelenWijdeKomendeJarenVerschillLink is ([not]?) enabled")]
        public void Then_Link_ProjectDonge_oeversOmDeRecreatieveAantrekkingskrachtVanGeertruidenbergTeVergrotenOntwikkelenWijdeKomendeJarenVerschillLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ProjectDonge_oeversOmDeRecreatieveAantrekkingskrachtVanGeertruidenbergTeVergrotenOntwikkelenWijdeKomendeJarenVerschillLink.IsEnabled, enabled);
        }

        [Then(@"link AfspraakMakenLink is ([not]?) visible")]
        public void Then_Link_AfspraakMakenLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AfspraakMakenLink.IsDisplayed, visible);
        }

        [Then(@"link AfspraakMakenLink is ([not]?) enabled")]
        public void Then_Link_AfspraakMakenLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.AfspraakMakenLink.IsEnabled, enabled);
        }

        [Then(@"link InfogeertruidenbergnlLink is ([not]?) visible")]
        public void Then_Link_InfogeertruidenbergnlLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.InfogeertruidenbergnlLink.IsDisplayed, visible);
        }

        [Then(@"link InfogeertruidenbergnlLink is ([not]?) enabled")]
        public void Then_Link_InfogeertruidenbergnlLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.InfogeertruidenbergnlLink.IsEnabled, enabled);
        }

        [Then(@"link TwitterLink is ([not]?) visible")]
        public void Then_Link_TwitterLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.TwitterLink.IsDisplayed, visible);
        }

        [Then(@"link TwitterLink is ([not]?) enabled")]
        public void Then_Link_TwitterLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.TwitterLink.IsEnabled, enabled);
        }

        [Then(@"link FacebookLink is ([not]?) visible")]
        public void Then_Link_FacebookLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.FacebookLink.IsDisplayed, visible);
        }

        [Then(@"link FacebookLink is ([not]?) enabled")]
        public void Then_Link_FacebookLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.FacebookLink.IsEnabled, enabled);
        }

        [Then(@"link RSSLink is ([not]?) visible")]
        public void Then_Link_RSSLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.RSSLink.IsDisplayed, visible);
        }

        [Then(@"link RSSLink is ([not]?) enabled")]
        public void Then_Link_RSSLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.RSSLink.IsEnabled, enabled);
        }

        [Then(@"link ProclaimerLink is ([not]?) visible")]
        public void Then_Link_ProclaimerLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ProclaimerLink.IsDisplayed, visible);
        }

        [Then(@"link ProclaimerLink is ([not]?) enabled")]
        public void Then_Link_ProclaimerLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.ProclaimerLink.IsEnabled, enabled);
        }

        [Then(@"link SitemapLink is ([not]?) visible")]
        public void Then_Link_SitemapLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.SitemapLink.IsDisplayed, visible);
        }

        [Then(@"link SitemapLink is ([not]?) enabled")]
        public void Then_Link_SitemapLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.SitemapLink.IsEnabled, enabled);
        }

        [Then(@"link LaatHetOnsWetenLink is ([not]?) visible")]
        public void Then_Link_LaatHetOnsWetenLink_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LaatHetOnsWetenLink.IsDisplayed, visible);
        }

        [Then(@"link LaatHetOnsWetenLink is ([not]?) enabled")]
        public void Then_Link_LaatHetOnsWetenLink_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.LaatHetOnsWetenLink.IsEnabled, enabled);
        }

        [Then(@"text Search_trefwoordTextbox is ([not]?) visible")]
        public void Then_Text_Search_trefwoordTextbox_Check_Visibility(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool visible = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.Search_trefwoordTextbox.IsDisplayed, visible);
        }

        [Then(@"text Search_trefwoordTextbox is ([not]?) enabled")]
        public void Then_Text_Search_trefwoordTextbox_Check_Enabled(string not)
        {
            var screen = GetScreen<MyPage1Page>();
			bool enabled = String.IsNullOrEmpty(not);
			Assert.AreEqual(screen.Search_trefwoordTextbox.IsEnabled, enabled);
        }

        [Then(@"the text in text Search_trefwoordTextbox is ""(.*)""")]
        public void Then_The_Text_in_Text_Search_trefwoordTextbox_Is(string text)
        {
            var screen = GetScreen<MyPage1Page>();
            Assert.AreEqual(screen.Search_trefwoordTextbox.Text, text);
        }
        #endregion
    }
}


