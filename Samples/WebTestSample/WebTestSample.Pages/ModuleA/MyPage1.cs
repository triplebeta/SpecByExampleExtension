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
    /// Implements the <seealso cref="https://code.google.com/p/selenium/wiki/PageObjects">PageObject</seealso> for MyPage1Page for module .
    /// </summary>
	/// <remarks>Generated using the T4 tempate.</remarks>
    public partial class MyPage1Page : BaseWebTestSamplePage
    {
        public MyPage1Page(IWindsorContainer container, IWebDriver driver)
            : base(container, driver, "Home - Gemeente Geertruidenberg", null)
        {
            // Nothing to do here
        }

				/* For the following controls we did not generate code since they could not be uniquely identified
		*/

        #region Selenium IWebElement items on this page

// Disable warning for: Field XYZ is never assigned to, and will always have its default value XX
#pragma warning disable 0649

        /// <summary>
        /// Html Link element: Ga direct naar zoeken
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Ga direct naar zoeken")]
        private IWebElement GaDirectNaarZoekenLinkControl;

        /// <summary>
        /// Html Link element: Ga direct naar het tekstgedeelte
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Ga direct naar het tekstgedeelte")]
        private IWebElement GaDirectNaarHetTekstgedeelteLinkControl;

        /// <summary>
        /// Html Link element: Ga direct naar de navigatie
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Ga direct naar de navigatie")]
        private IWebElement GaDirectNaarDeNavigatieLinkControl;

        /// <summary>
        /// Html Link element: Inwoners
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Inwoners")]
        private IWebElement InwonersLinkControl;

        /// <summary>
        /// Html Link element: Paspoort, ID-kaart, rijbewijs en uittreksel
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Paspoort, ID-kaart, rijbewijs en uittreksel")]
        private IWebElement PaspoortID_kaartRijbewijsEnUittrekselLinkControl;

        /// <summary>
        /// Html Link element: Afval
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Afval")]
        private IWebElement AfvalLinkControl;

        /// <summary>
        /// Html Link element: Meldingen
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Meldingen")]
        private IWebElement MeldingenLink1Control;

        /// <summary>
        /// Html Link element: Werk en inkomen
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Werk en inkomen")]
        private IWebElement WerkEnInkomenLinkControl;

        /// <summary>
        /// Html Link element: Zorg
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Zorg")]
        private IWebElement ZorgLink1Control;

        /// <summary>
        /// Html Link element: Wonen en (ver)bouwen
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Wonen en (ver)bouwen")]
        private IWebElement WonenEnVerbouwenLinkControl;

        /// <summary>
        /// Html Link element: Geboorte, trouwen en overlijden
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Geboorte, trouwen en overlijden")]
        private IWebElement GeboorteTrouwenEnOverlijdenLinkControl;

        /// <summary>
        /// Html Link element: Jeugd en onderwijs
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Jeugd en onderwijs")]
        private IWebElement JeugdEnOnderwijsLinkControl;

        /// <summary>
        /// Html Link element: Verkeer
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Verkeer")]
        private IWebElement VerkeerLinkControl;

        /// <summary>
        /// Html Link element: Cultuur en vrije tijd
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Cultuur en vrije tijd")]
        private IWebElement CultuurEnVrijeTijdLinkControl;

        /// <summary>
        /// Html Link element: Praat en doe mee
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Praat en doe mee")]
        private IWebElement PraatEnDoeMeeLinkControl;

        /// <summary>
        /// Html Link element: Belastingen en WOZ
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Belastingen en WOZ")]
        private IWebElement BelastingenEnWOZLinkControl;

        /// <summary>
        /// Html Link element: Actueel
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Actueel")]
        private IWebElement ActueelLinkControl;

        /// <summary>
        /// Html Link element: Ondernemers
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Ondernemers")]
        private IWebElement OndernemersLinkControl;

        /// <summary>
        /// Html Link element: Starten
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Starten")]
        private IWebElement StartenLinkControl;

        /// <summary>
        /// Html Link element: Vestigen
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Vestigen")]
        private IWebElement VestigenLinkControl;

        /// <summary>
        /// Html Link element: Uitbreiden of verbouwen
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Uitbreiden of verbouwen")]
        private IWebElement UitbreidenOfVerbouwenLinkControl;

        /// <summary>
        /// Html Link element: Horeca
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Horeca")]
        private IWebElement HorecaLinkControl;

        /// <summary>
        /// Html Link element: Belastingen
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Belastingen")]
        private IWebElement BelastingenLinkControl;

        /// <summary>
        /// Html Link element: Ondersteuning voor ondernemers
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Ondersteuning voor ondernemers")]
        private IWebElement OndersteuningVoorOndernemersLinkControl;

        /// <summary>
        /// Html Link element: Nieuws en projecten
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Nieuws en projecten")]
        private IWebElement NieuwsEnProjectenLinkControl;

        /// <summary>
        /// Html Link element: Inkoop en aanbesteding
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Inkoop en aanbesteding")]
        private IWebElement InkoopEnAanbestedingLinkControl;

        /// <summary>
        /// Html Link element: Bestuur
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Bestuur")]
        private IWebElement BestuurLinkControl;

        /// <summary>
        /// Html Link element: Gemeenteraad
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Gemeenteraad")]
        private IWebElement GemeenteraadLinkControl;

        /// <summary>
        /// Html Link element: College van B&amp;W
		/// </summary>
        [FindsBy(How=How.LinkText, Using="College van B&amp;W")]
        private IWebElement CollegeVanBWLinkControl;

        /// <summary>
        /// Html Link element: Vergaderkalender
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Vergaderkalender")]
        private IWebElement VergaderkalenderLinkControl;

        /// <summary>
        /// Html Link element: Bekijk de raadsvergadering
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Bekijk de raadsvergadering")]
        private IWebElement BekijkDeRaadsvergaderingLinkControl;

        /// <summary>
        /// Html Link element: Beleid
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Beleid")]
        private IWebElement BeleidLinkControl;

        /// <summary>
        /// Html Link element: Werken bij de gemeente
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Werken bij de gemeente")]
        private IWebElement WerkenBijDeGemeenteLinkControl;

        /// <summary>
        /// Html Link element: Financiën
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Financiën")]
        private IWebElement FinanciënLinkControl;

        /// <summary>
        /// Html Link element: Ga naar boven
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Ga naar boven")]
        private IWebElement GaNaarBovenLink1Control;

        /// <summary>
        /// Html Link element: Openingstijden / contact
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Openingstijden / contact")]
        private IWebElement OpeningstijdenContactLinkControl;

        /// <summary>
        /// Html Link element: Afvalkalender
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Afvalkalender")]
        private IWebElement AfvalkalenderLinkControl;

        /// <summary>
        /// Html Link element: Paspoort, ID-kaart, Rijbewijs
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Paspoort, ID-kaart, Rijbewijs")]
        private IWebElement PaspoortID_kaartRijbewijsLinkControl;

        /// <summary>
        /// Html Link element: Werk &amp; Inkomen
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Werk &amp; Inkomen")]
        private IWebElement WerkInkomenLinkControl;

        /// <summary>
        /// Html Link element: Verhuizen
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Verhuizen")]
        private IWebElement VerhuizenLinkControl;

        /// <summary>
        /// Html Link element: Hondenbelasting
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Hondenbelasting")]
        private IWebElement HondenbelastingLinkControl;

        /// <summary>
        /// Html Link element: Ga naar beneden
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Ga naar beneden")]
        private IWebElement GaNaarBenedenLink1Control;

        /// <summary>
        /// Html Link element: GroterAA
		/// </summary>
        [FindsBy(How=How.LinkText, Using="GroterAA")]
        private IWebElement GroterAALinkControl;

        /// <summary>
        /// Html Link element: Lees voor
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Lees voor")]
        private IWebElement LeesVoorLinkControl;

        /// <summary>
        /// Html Link element: Contrast
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Contrast")]
        private IWebElement ContrastLinkControl;

        /// <summary>
        /// Html Link element: Oorkonde voor reddingsactie op Bergse Maas voor&hellip;
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Oorkonde voor reddingsactie op Bergse Maas voor&hellip;")]
        private IWebElement OorkondeVoorReddingsactieOpBergseMaasVoorLinkControl;

        /// <summary>
        /// Html Link element: Afrondende werkzaamheden Markt en Brandestraat &hellip;
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Afrondende werkzaamheden Markt en Brandestraat &hellip;")]
        private IWebElement AfrondendeWerkzaamhedenMarktEnBrandestraatLinkControl;

        /// <summary>
        /// Html Link element: maakte de gemeente bekend
		/// </summary>
        [FindsBy(How=How.LinkText, Using="maakte de gemeente bekend")]
        private IWebElement MaakteDeGemeenteBekendLinkControl;

        /// <summary>
        /// Html Link element: Ondertekening participatieverklaring
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Ondertekening participatieverklaring")]
        private IWebElement OndertekeningParticipatieverklaringLinkControl;

        /// <summary>
        /// Html Link element: VerkiezingenOp 15 maart 2017 mogen Nederlanders die 18 jaar en ouder zijn, kiezen wie hen vertegenwoordigen in de Tweede Kamer.
		/// </summary>
        [FindsBy(How=How.LinkText, Using="VerkiezingenOp 15 maart 2017 mogen Nederlanders die 18 jaar en ouder zijn, kiezen wie hen vertegenwoordigen in de Tweede Kamer.")]
        private IWebElement VerkiezingenOp15Maart2017MogenNederlandersDie18JaarEnOuderZijnKiezenWieHenVertegenwoordigenInDeTweedeKamerLinkControl;

        /// <summary>
        /// Html Link element: Geertruidenberg zoekt historische schepen De gemeente Geertruidenberg is op zoek naar enkele historische woonschepen die willen aanmeren aan de Timmerstee&hellip;
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Geertruidenberg zoekt historische schepen De gemeente Geertruidenberg is op zoek naar enkele historische woonschepen die willen aanmeren aan de Timmerstee&hellip;")]
        private IWebElement GeertruidenbergZoektHistorischeSchepenDeGemeenteGeertruidenbergIsOpZoekNaarEnkeleHistorischeWoonschepenDieWillenAanmerenAanDeTimmersteeLinkControl;

        /// <summary>
        /// Html Link element: Project Donge-oeversOm de recreatieve aantrekkingskracht van Geertruidenberg te vergroten ontwikkelen wij&nbsp;de komende jaren verschill&hellip;
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Project Donge-oeversOm de recreatieve aantrekkingskracht van Geertruidenberg te vergroten ontwikkelen wij&nbsp;de komende jaren verschill&hellip;")]
        private IWebElement ProjectDonge_oeversOmDeRecreatieveAantrekkingskrachtVanGeertruidenbergTeVergrotenOntwikkelenWijdeKomendeJarenVerschillLinkControl;

        /// <summary>
        /// Html Link element: Afspraak maken
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Afspraak maken")]
        private IWebElement AfspraakMakenLinkControl;

        /// <summary>
        /// Html Link element: info@geertruidenberg.nl
		/// </summary>
        [FindsBy(How=How.LinkText, Using="info@geertruidenberg.nl")]
        private IWebElement InfogeertruidenbergnlLinkControl;

        /// <summary>
        /// Html Link element: Twitter
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Twitter")]
        private IWebElement TwitterLinkControl;

        /// <summary>
        /// Html Link element: Facebook
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Facebook")]
        private IWebElement FacebookLinkControl;

        /// <summary>
        /// Html Link element: RSS
		/// </summary>
        [FindsBy(How=How.LinkText, Using="RSS")]
        private IWebElement RSSLinkControl;

        /// <summary>
        /// Html Link element: Proclaimer
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Proclaimer")]
        private IWebElement ProclaimerLinkControl;

        /// <summary>
        /// Html Link element: Sitemap
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Sitemap")]
        private IWebElement SitemapLinkControl;

        /// <summary>
        /// Html Link element: Laat het ons weten
		/// </summary>
        [FindsBy(How=How.LinkText, Using="Laat het ons weten")]
        private IWebElement LaatHetOnsWetenLinkControl;

        /// <summary>
        /// Html Textbox element: 
		/// </summary>
        [FindsBy(How=How.Id, Using="search_trefwoord")]
        private IWebElement Search_trefwoordTextboxControl;

#pragma warning restore 0649

        #endregion


		#region Controls to wrap the HTML items

        /// <summary>
        /// Link: 
        /// </summary>
        public Link GaDirectNaarZoekenLink
        {
            get { return GaDirectNaarZoekenLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link GaDirectNaarHetTekstgedeelteLink
        {
            get { return GaDirectNaarHetTekstgedeelteLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link GaDirectNaarDeNavigatieLink
        {
            get { return GaDirectNaarDeNavigatieLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link InwonersLink
        {
            get { return InwonersLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link PaspoortID_kaartRijbewijsEnUittrekselLink
        {
            get { return PaspoortID_kaartRijbewijsEnUittrekselLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link AfvalLink
        {
            get { return AfvalLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link MeldingenLink1
        {
            get { return MeldingenLink1Control.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link WerkEnInkomenLink
        {
            get { return WerkEnInkomenLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link ZorgLink1
        {
            get { return ZorgLink1Control.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link WonenEnVerbouwenLink
        {
            get { return WonenEnVerbouwenLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link GeboorteTrouwenEnOverlijdenLink
        {
            get { return GeboorteTrouwenEnOverlijdenLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link JeugdEnOnderwijsLink
        {
            get { return JeugdEnOnderwijsLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link VerkeerLink
        {
            get { return VerkeerLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link CultuurEnVrijeTijdLink
        {
            get { return CultuurEnVrijeTijdLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link PraatEnDoeMeeLink
        {
            get { return PraatEnDoeMeeLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link BelastingenEnWOZLink
        {
            get { return BelastingenEnWOZLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link ActueelLink
        {
            get { return ActueelLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link OndernemersLink
        {
            get { return OndernemersLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link StartenLink
        {
            get { return StartenLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link VestigenLink
        {
            get { return VestigenLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link UitbreidenOfVerbouwenLink
        {
            get { return UitbreidenOfVerbouwenLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link HorecaLink
        {
            get { return HorecaLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link BelastingenLink
        {
            get { return BelastingenLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link OndersteuningVoorOndernemersLink
        {
            get { return OndersteuningVoorOndernemersLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link NieuwsEnProjectenLink
        {
            get { return NieuwsEnProjectenLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link InkoopEnAanbestedingLink
        {
            get { return InkoopEnAanbestedingLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link BestuurLink
        {
            get { return BestuurLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link GemeenteraadLink
        {
            get { return GemeenteraadLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link CollegeVanBWLink
        {
            get { return CollegeVanBWLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link VergaderkalenderLink
        {
            get { return VergaderkalenderLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link BekijkDeRaadsvergaderingLink
        {
            get { return BekijkDeRaadsvergaderingLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link BeleidLink
        {
            get { return BeleidLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link WerkenBijDeGemeenteLink
        {
            get { return WerkenBijDeGemeenteLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link FinanciënLink
        {
            get { return FinanciënLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link GaNaarBovenLink1
        {
            get { return GaNaarBovenLink1Control.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link OpeningstijdenContactLink
        {
            get { return OpeningstijdenContactLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link AfvalkalenderLink
        {
            get { return AfvalkalenderLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link PaspoortID_kaartRijbewijsLink
        {
            get { return PaspoortID_kaartRijbewijsLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link WerkInkomenLink
        {
            get { return WerkInkomenLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link VerhuizenLink
        {
            get { return VerhuizenLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link HondenbelastingLink
        {
            get { return HondenbelastingLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link GaNaarBenedenLink1
        {
            get { return GaNaarBenedenLink1Control.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link GroterAALink
        {
            get { return GroterAALinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link LeesVoorLink
        {
            get { return LeesVoorLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link ContrastLink
        {
            get { return ContrastLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link OorkondeVoorReddingsactieOpBergseMaasVoorLink
        {
            get { return OorkondeVoorReddingsactieOpBergseMaasVoorLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link AfrondendeWerkzaamhedenMarktEnBrandestraatLink
        {
            get { return AfrondendeWerkzaamhedenMarktEnBrandestraatLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link MaakteDeGemeenteBekendLink
        {
            get { return MaakteDeGemeenteBekendLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link OndertekeningParticipatieverklaringLink
        {
            get { return OndertekeningParticipatieverklaringLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link VerkiezingenOp15Maart2017MogenNederlandersDie18JaarEnOuderZijnKiezenWieHenVertegenwoordigenInDeTweedeKamerLink
        {
            get { return VerkiezingenOp15Maart2017MogenNederlandersDie18JaarEnOuderZijnKiezenWieHenVertegenwoordigenInDeTweedeKamerLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link GeertruidenbergZoektHistorischeSchepenDeGemeenteGeertruidenbergIsOpZoekNaarEnkeleHistorischeWoonschepenDieWillenAanmerenAanDeTimmersteeLink
        {
            get { return GeertruidenbergZoektHistorischeSchepenDeGemeenteGeertruidenbergIsOpZoekNaarEnkeleHistorischeWoonschepenDieWillenAanmerenAanDeTimmersteeLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link ProjectDonge_oeversOmDeRecreatieveAantrekkingskrachtVanGeertruidenbergTeVergrotenOntwikkelenWijdeKomendeJarenVerschillLink
        {
            get { return ProjectDonge_oeversOmDeRecreatieveAantrekkingskrachtVanGeertruidenbergTeVergrotenOntwikkelenWijdeKomendeJarenVerschillLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link AfspraakMakenLink
        {
            get { return AfspraakMakenLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link InfogeertruidenbergnlLink
        {
            get { return InfogeertruidenbergnlLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link TwitterLink
        {
            get { return TwitterLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link FacebookLink
        {
            get { return FacebookLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link RSSLink
        {
            get { return RSSLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link ProclaimerLink
        {
            get { return ProclaimerLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link SitemapLink
        {
            get { return SitemapLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Link: 
        /// </summary>
        public Link LaatHetOnsWetenLink
        {
            get { return LaatHetOnsWetenLinkControl.As<Link>(CurrentWebDriver); }
        }

        /// <summary>
        /// Textbox: trefwoord
        /// </summary>
        public Textbox Search_trefwoordTextbox
        {
            get { return Search_trefwoordTextboxControl.As<Textbox>(CurrentWebDriver); }
        }

		#endregion

	}
}