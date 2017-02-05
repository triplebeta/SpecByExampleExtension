using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using System.IO;
using SpecByExample.T4;
using System.Xml;

namespace SpecByExample.Selenium.Tests.Serialization
{
    /// <summary>
    /// Test saving and deserializing the models
    /// </summary>
    [TestClass]
    public class LoadSaveWebmodel
    {
        public LoadSaveWebmodel()
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
        public void SaveModel()
        {
            string newModel = @"c:\temp\model.xml";
            var state = new CodeGenerationSettings();

            XmlSerializer serializer = new XmlSerializer(typeof(CodeGenerationSettings));
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
            settings.Indent = true;
            settings.OmitXmlDeclaration = false;

            using (var textWriter = new StreamWriter(newModel))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, state);
                }
            }
        }

        [TestMethod]
        public void LoadModelTest()
        {
            // Read model it back into an object...
            string file = @"c:\temp\model.xml";
            XmlSerializer deserializer = new XmlSerializer(typeof(CodeGenerationSettings));
            TextReader textReader = new StreamReader(file);
            var state = (CodeGenerationSettings)deserializer.Deserialize(textReader);
            textReader.Close();
        }
    }
}
