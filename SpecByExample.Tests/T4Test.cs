using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecByExample.T4;
using HtmlAgilityPack;
using System.Diagnostics;

namespace SpecByExample.Tests
{
    [TestClass]
    public class T4Test
    {
        ParsingOptions options = new ParsingOptions();

        public T4Test()
        {
            options.PreferredIdentifications = new ControlIdentificationType[] {
            ControlIdentificationType.Id, 
            ControlIdentificationType.Name,
            ControlIdentificationType.LinkText,
            ControlIdentificationType.Cssclass };
        }


        [TestMethod, DeploymentItem(@"..\..\Testdata\PaginaMetDubbeleIDs.htm")]
        public void TestLoadControls()
        {
            string url = @"PaginaMetDubbeleIDs.htm";
            var doc = HtmlLoader.LoadDocumentFromUrl(url);
            var registeredControls = CreateRegisteredControls();
            var controlInfo = HtmlLoader.GetHtmlControls(doc, registeredControls, options);

            Assert.AreEqual(1, controlInfo.Count<HtmlControlInfo>(x => x.HtmlId == "RadiobuttonWithID"));
            Assert.IsTrue(controlInfo.All<HtmlControlInfo>(x=>x.HtmlId!=null));
            Assert.IsTrue(controlInfo.All<HtmlControlInfo>(x => x.HtmlName != null));
            Assert.IsTrue(controlInfo.All<HtmlControlInfo>(x => x.CodeControlName != null));
            Assert.IsTrue(controlInfo.All<HtmlControlInfo>(x => x.CodeControlType != null));
            Assert.IsTrue(controlInfo.All<HtmlControlInfo>(x => x.Description != null));
        }

        /// <summary>
        ///A test for LoadDocument
        ///</summary>
        [TestMethod, DeploymentItem(@"..\..\Testdata\PaginaMetDubbeleIDs.htm")]
        public void LoadDocumentWithDuplicateIDsTest()
        {
            var registeredControls = CreateRegisteredControls();

            string url = @"PaginaMetDubbeleIDs.htm";
            var doc = HtmlLoader.LoadDocumentFromUrl(url);
            var allControlInfo = HtmlLoader.GetHtmlControls(doc, registeredControls, options);

            var noIdentifiers = allControlInfo.Where(x=>x.ReasonNoCodeGeneration == ExclusionCodeGenerationReasons.NoValidIdentifier).ToList();
            Assert.AreEqual(3, noIdentifiers.Count);

            // In this testpage, all identifyable controls meet the following criteria (not necessarily true for any ordinary webpage)
            var identifyableControls = allControlInfo.Except(noIdentifiers);
            Assert.IsTrue(identifyableControls.All<HtmlControlInfo>(x => x.HtmlId != null));
            Assert.IsTrue(identifyableControls.All<HtmlControlInfo>(x => x.HtmlName != null));
            Assert.IsTrue(identifyableControls.All<HtmlControlInfo>(x => x.CodeControlName != null));
            Assert.IsTrue(identifyableControls.All<HtmlControlInfo>(x => x.CodeControlType != null));
            Assert.IsTrue(identifyableControls.All<HtmlControlInfo>(x => x.Description != null));
        }


        /// <summary>
        /// Code generation should be disabled for controls when they have no unique identification
        /// </summary>
        [TestMethod, DeploymentItem(@"..\..\Testdata\PaginaMetDubbeleIDs.htm")]
        public void SetCodeGenerationToFalseWhenControlNotUniquelyIdentifyable()
        {
            var registeredControls = CreateRegisteredControls();

            string url = @"PaginaMetDubbeleIDs.htm";
            var doc = HtmlLoader.LoadDocumentFromUrl(url);
            var allControlInfo = HtmlLoader.GetHtmlControls(doc, registeredControls, options);

            // Validate CodeGeneration is disabled for each of these and only for these (not for others!)
            var noIdentifiers = allControlInfo.Where(x => x.ReasonNoCodeGeneration == ExclusionCodeGenerationReasons.NoValidIdentifier).ToList();
            Assert.IsTrue(noIdentifiers.All(x => x.SupportsCodeGeneration == false));

            var identifyableControls = allControlInfo.Except(noIdentifiers);
            Assert.IsTrue(identifyableControls.All(x => x.SupportsCodeGeneration == true));
        }

        [TestMethod, DeploymentItem(@"..\..\Testdata\GoogleHome.htm")]
        public void LoadGooglePage()
        {
            // Load a snapshot of the standard Google homepage
            string url = @"GoogleHome.htm";
            var doc = HtmlLoader.LoadDocumentFromUrl(url);

            // Define which control to generate for each html element
            var registeredControls = CreateRegisteredControls();
            var allControlInfo = HtmlLoader.GetHtmlControls(doc, registeredControls, options);

            Assert.AreEqual(1, allControlInfo.Count<HtmlControlInfo>(x => x.Description=="Afbeeldingen"));
        }

        /// <summary>
        /// Test that all relevant items were detected as to be identified by their LinkText
        /// </summary>
        [TestMethod, DeploymentItem(@"..\..\Testdata\GoogleHome.htm")]
        public void IdentificationByLinkTextAllFoundTest()
        {
            // Load a snapshot of the standard Google homepage
            string url = @"GoogleHome.htm";
            var doc = HtmlLoader.LoadDocumentFromUrl(url);

            // Define which control to generate for each html element
            var registeredControls = CreateRegisteredControls();
            var allControlInfo = HtmlLoader.GetHtmlControls(doc, registeredControls, options);
            Assert.AreEqual(16, allControlInfo.Count(x=>x.IdentifiedBy==ControlIdentificationType.LinkText));

            // Validate that these are all of type Link
            var linkControls = allControlInfo.Where(x => x.IdentifiedBy == ControlIdentificationType.LinkText);
            Assert.IsTrue(linkControls.All(x => x.HtmlControlType==HtmlControlTypeEnum.Link));
        }

        [TestMethod, DeploymentItem(@"..\..\Testdata\GoogleHome.htm")]
        public void CodeControlNameUnsupportedTokensTest()
        {
            // Load a snapshot of the standard Google homepage
            string url = @"GoogleHome.htm";
            var doc = HtmlLoader.LoadDocumentFromUrl(url);

            // Define which control to generate for each html element
            var registeredControls = CreateRegisteredControls();
            var allControlInfo = HtmlLoader.GetHtmlControls(doc, registeredControls, options);

            foreach (var x in allControlInfo)
            //{
            //    Trace.WriteLine(x.CodeControlName);
            //}

            // Check for invalid characters
            Assert.IsTrue(allControlInfo.All(x=>x.CodeControlName.Contains("(")==false));
            Assert.IsTrue(allControlInfo.All(x => x.CodeControlName.Contains("&") == false));
            Assert.IsTrue(allControlInfo.All(x => x.CodeControlName.Contains(" ") == false));
            Assert.IsTrue(allControlInfo.All(x => x.CodeControlName.Contains("$") == false));
            Assert.IsTrue(allControlInfo.All(x => x.CodeControlName.Length<100));
        }


        [TestMethod, DeploymentItem(@"..\..\Testdata\GoogleHome.htm")]
        public void GenerateValidCodeNameTest()
        {
            // Load a snapshot of the standard Google homepage
            string url = @"GoogleHome.htm";
            var doc = HtmlLoader.LoadDocumentFromUrl(url);

            // Define which control to generate for each html element
            var registeredControls = CreateRegisteredControls();
            var allControlInfo = HtmlLoader.GetHtmlControls(doc, registeredControls, options);

            Assert.AreEqual("AfbeeldingenLink", allControlInfo.Single(x => x.Description == "Afbeeldingen").CodeControlName);
            Assert.AreEqual("VoorwaardenLink", allControlInfo.Single(x => x.Description == "Voorwaarden").CodeControlName);
        }


        #region Private helpers

        private List<ControlTypeRegistration> CreateRegisteredControls()
        {
            var controls = new List<ControlTypeRegistration>();
            controls.Add(new ControlTypeRegistration("Link", "Link", "//a"));
            controls.Add(new ControlTypeRegistration("Button", "Button", "//button"));
            controls.Add(new ControlTypeRegistration("Combobox", "Select", "//select"));
            controls.Add(new ControlTypeRegistration("Listbox", "Listbox", "//select[@size>0]"));
            controls.Add(new ControlTypeRegistration("Textbox", "Text", "//input[@type='text' or not(@type)]"));
            controls.Add(new ControlTypeRegistration("Checkbox", "Checkbox", "//input[@type='checkbox']"));
            controls.Add(new ControlTypeRegistration("Radiobutton", "Radiobutton", "//input[@type='radio']"));
            controls.Add(new ControlTypeRegistration("Textarea", "Textarea", "//input[@type='textarea']"));
            controls.Add(new ControlTypeRegistration("Textarea", "Textarea", "//textarea"));
            controls.Add(new ControlTypeRegistration("WebTable", "Table", "//table"));
            return controls;
        }

        #endregion
    }
}
