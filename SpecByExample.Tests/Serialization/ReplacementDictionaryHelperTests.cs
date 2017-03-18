using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using System.IO;
using SpecByExample.T4;
using System.Xml;
using System.Text.RegularExpressions;

namespace SpecByExample.Selenium.Tests.Serialization
{
    /// <summary>
    /// Test ReplacementDictionary
    /// </summary>
    [TestClass]
    public class ReplacementDictionaryHelperTests
    {
        public ReplacementDictionaryHelperTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void PageNameTest()
        {
            string regex = "Page[0-9]*$";

            Assert.IsTrue(Regex.IsMatch("BooPage", regex, RegexOptions.IgnoreCase));
            Assert.IsTrue(Regex.IsMatch("Page", regex, RegexOptions.IgnoreCase));
            Assert.IsTrue(Regex.IsMatch("Page1", regex, RegexOptions.IgnoreCase));
            Assert.IsTrue(Regex.IsMatch("pAgE1", regex, RegexOptions.IgnoreCase));
            Assert.IsTrue(Regex.IsMatch("PAGE1", regex, RegexOptions.IgnoreCase));
            Assert.IsTrue(Regex.IsMatch("Page13425234532", regex, RegexOptions.IgnoreCase));

            Assert.IsFalse(Regex.IsMatch("PageBooooo1234Foo", regex, RegexOptions.IgnoreCase));
            Assert.IsFalse(Regex.IsMatch("PageBooooo1", regex, RegexOptions.IgnoreCase));
            Assert.IsFalse(Regex.IsMatch("BooPag", regex, RegexOptions.IgnoreCase));
            Assert.IsFalse(Regex.IsMatch("PageBoo", regex, RegexOptions.IgnoreCase));
        }
    }
}
