﻿using SpecByExample.T4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HtmlAgilityPack;

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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for LoadDocument
        ///</summary>
        [TestMethod()]
        public void LoadDocumentTest()
        {
            string url = @"E:\POCs\POC_Selenium\SpecByExample.Tests\Testdata\TestMetTabel.htm";
            HtmlDocument actual;
            actual = HtmlLoader.LoadDocumentFromUrl(url);
            Assert.IsNotNull( actual);
        }
    }
}
