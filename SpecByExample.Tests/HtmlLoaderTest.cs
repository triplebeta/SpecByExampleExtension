using SpecByExample.T4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace SpecByExample.Tests
{
    /// <summary>
    ///This is a test class for HtmlLoaderTest and is intended
    ///to contain all HtmlLoaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HtmlLoaderTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        /// <summary>
        ///A test for LoadDocument
        ///</summary>
        [TestMethod, DeploymentItem(@"..\..\Testdata\TestMetTabel.htm")]
        public void LoadDocumentTest()
        {
            string url = @"TestMetTabel.htm";
            HtmlDocument actual;

            var controls = new List<ControlTypeRegistration>();
            var loader = new HtmlLoader(controls);
            actual = loader.LoadDocumentFromUrl(url);
            Assert.IsNotNull( actual);
        }
    }
}
