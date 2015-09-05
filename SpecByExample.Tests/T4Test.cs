using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecByExample.T4;
using HtmlAgilityPack;

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
            ControlIdentificationType.Cssclass };
        }


        [TestMethod]
        public void TestLoadControls()
        {
            var doc = HtmlLoader.LoadDocumentFromUrl("http://www.google.nl");
            var registeredControls = CreateRegisteredControls();
            var controlInfo = HtmlLoader.GetHtmlControls(doc, registeredControls, false, options);

            Assert.AreEqual(1, controlInfo.Count<HtmlControlInfo>(x => x.HtmlId == "ctl00_PlaceHolderSiteName_onetidProjectPropertyTitle"));
            Assert.IsTrue(controlInfo.All<HtmlControlInfo>(x=>x.HtmlId!=null));
            Assert.IsTrue(controlInfo.All<HtmlControlInfo>(x => x.HtmlName != null));
            Assert.IsTrue(controlInfo.All<HtmlControlInfo>(x => x.CodeControlName != null));
            Assert.IsTrue(controlInfo.All<HtmlControlInfo>(x => x.CodeControlType != null));
            Assert.IsTrue(controlInfo.All<HtmlControlInfo>(x => x.Description != null));
        }

        /// <summary>
        ///A test for LoadDocument
        ///</summary>
        [TestMethod()]
        public void LoadDocumentWithDuplicateIDsTest()
        {
            var registeredControls = CreateRegisteredControls();

            string url = @"E:\POCs\POC_Selenium\SpecByExample.Tests\Testdata\PaginaMetDubbeleIDs.htm";
            var doc = HtmlLoader.LoadDocumentFromUrl(url);
            var controlInfo = HtmlLoader.GetHtmlControls(doc, registeredControls, false, options);

            var duplicateIdentifiers = controlInfo.Where(x => x.GenerateCodeForThisItem == false && x.ReasonForExclusion == ExclusionReasonType.DuplicateIdentifier).ToList();
            Assert.AreEqual(2, duplicateIdentifiers.Count);

            var noIdentifiers = controlInfo.Where(x => x.GenerateCodeForThisItem == false && x.ReasonForExclusion == ExclusionReasonType.NoValidIdentifier).ToList();
            Assert.AreEqual(3, noIdentifiers.Count);

            Assert.IsTrue(controlInfo.All<HtmlControlInfo>(x => x.HtmlId != null));
            Assert.IsTrue(controlInfo.All<HtmlControlInfo>(x => x.HtmlName != null));
            Assert.IsTrue(controlInfo.All<HtmlControlInfo>(x => x.CodeControlName != null));
            Assert.IsTrue(controlInfo.All<HtmlControlInfo>(x => x.CodeControlType != null));
            Assert.IsTrue(controlInfo.All<HtmlControlInfo>(x => x.Description != null));
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
