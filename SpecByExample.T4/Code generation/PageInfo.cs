using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SpecByExample.T4
{
    /// <summary>
    /// Details of the page for which we will be creating some code.
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(Encoding))]
    [XmlRoot(Namespace = WebmodelXmlNamespace)]
    public class PageInfo
    {
        [XmlNamespaceDeclarations]
        public static XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
        public const string WebmodelXmlNamespace = "http://specbyexample.triplebeta.nl/webmodel/2005";

        private string pageTitle, className;

        /// <summary>
        /// Ensure XML Namespaces are initialized appropriately before use of this class.
        /// </summary>
        static PageInfo()
        {
            xmlns.Add("", WebmodelXmlNamespace);
        }

        // Required for serialization
        public PageInfo()
        {
            TypeOfPage = PageTemplatesEnum.GenericPage;
            Placeholders = new List<Placeholder>();

            // Configure the default options
            CreateSpecFlowStepsFile = true;
        }

        #region Serialize/deserialize an instance

        /// <summary>
        /// Serialize this instance to a string.
        /// </summary>
        /// <returns>XML representing this instance.</returns>
        public string SerializeToXml()
        {
            XmlWriterSettings serializerSettings = new XmlWriterSettings();
            XmlSerializer serializer = new XmlSerializer(typeof(PageInfo));
            serializerSettings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
            serializerSettings.Indent = true;
            serializerSettings.OmitXmlDeclaration = false;

            using (var textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, serializerSettings))
                {
                    serializer.Serialize(xmlWriter, this);
                    return textWriter.ToString();
                }
            }
        }

        /// <summary>
        /// Load a new instance from a model file
        /// </summary>
        /// <param name="modelFile">Webmodel file.</param>
        /// <returns>Instance of the given model.</returns>
        public static PageInfo LoadModelFromFile(string modelFile)
        {
            // Load the model
            string xml = File.ReadAllText(modelFile);
            return LoadModelFromXml(xml);
        }

        /// <summary>
        /// Load a new instance from a model file
        /// </summary>
        /// <returns>Instance of the given model.</returns>
        public static PageInfo LoadModelFromXml(XDocument document)
        {
            // Load the model
            XmlSerializer deserializer = new XmlSerializer(typeof(PageInfo));
            XmlReader textReader = document.CreateReader();
            var model = (PageInfo)deserializer.Deserialize(textReader);
            textReader.Close();
            return model;
        }

        /// <summary>
        /// Load a new instance from a model file
        /// </summary>
        /// <returns>Instance of the given model.</returns>
        public static PageInfo LoadModelFromXml(string xml)
        {
            // Load the model
            XmlSerializer deserializer = new XmlSerializer(typeof(PageInfo));
            TextReader textReader = new StringReader(xml);
            var model = (PageInfo)deserializer.Deserialize(textReader);
            textReader.Close();
            return model;
        }

        #endregion

        /// <summary>
        /// Given name for this page.
        /// </summary>
        [XmlAttribute]
        public string PageName { get; set; }

        /// <summary>
        /// Title of the page. Captured for readability of the documentation of the generated classes.
        /// </summary>
        [XmlAttribute]
        public string PageTitle
        {
            get { return pageTitle ?? ""; }
            set { pageTitle = value; }
        }

        /// <summary>
        /// Url of the page captured by this model. Used to reload this page.
        /// </summary>
        [XmlElement]
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Name of the class to create for this page.
        /// </summary>
        [XmlAttribute]
        public string ClassName
        {
            get { return className ?? ""; }
            set { className = value; }
        }

        /// <summary>
        /// True to create a new SpecFlow Steps file.
        /// </summary>
        [XmlAttribute]
        public bool CreateSpecFlowStepsFile { get; set; }

        /// <summary>
        /// Defines the scope for finding controls within the webpage.
        /// By default, it will search the complete document but you can change this
        /// by assinging an HtmlAgilityPack XPath expression to a DIV to this field.
        /// In that case, the list of SelectedHtmlElements will only contain the elements
        /// WITHIN that DIV. Use this when all your pages use the same masterpage with a
        /// menu structure. You can then just use the Div with the page-specific content.
        /// </summary>
        [XmlAttribute]
        public string HtmlRootNodeXPath { get; set; }

        /// <summary>
        /// Defines what type of page adapter to create from this model. Can be a TablePage or a standard page.
        /// The Table page adapter extends the normal page by providing a way to access data in a table as entities.
        /// </summary>
        [XmlAttribute]
        public PageTemplatesEnum TypeOfPage { get; set; }

        /// <summary>
        /// Placeholder values to inject specific values that are available in the context of the T4 engine.
        /// </summary>
        [XmlArray("Placeholders"), XmlArrayItem(typeof(Placeholder), ElementName = "Placeholder")]
        public List<Placeholder> Placeholders { get; set; }

        /// <summary>
        /// Container for information about the table
        /// </summary>
        [XmlElement]
        public SeleniumTableInfo TableInfo { get; set; }

        /// <summary>
        /// The set of all HTML input elements on the page, the SelectedHtmlElements is a subset of this collection.
        /// This set will contain the elements you might want to use in testing.
        /// DIV's will not be included since we assume they will be used for scope only.
        /// </summary>
        public List<HtmlControlInfo> HtmlElements
        {
            get;
            set;
        }

        /// <summary>
        /// The set of all containers, like DIVs
        /// </summary>
        public List<HtmlControlInfo> HtmlContainers
        {
            get;
            set;
        }
    }
}
