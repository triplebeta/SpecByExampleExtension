using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Xml.Serialization;
using SpecByExample.T4;
using System.IO;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using System.Diagnostics;
using Microsoft.VisualStudio.TextTemplating;
using Microsoft.VisualStudio.TextTemplating.VSHost;

namespace SpecByExample.Selenium.Tests.CustomTool
{
    [TestClass, DeploymentItem(@"..\..\Testdata\MyFirst.webmodel")]
    public class CustomToolCodeGenerationTests
    {
        [TestMethod]
        public void ExternalHostWithSimpleTemplateWithParameterTest()
        {
            // Just bluntly use the Visual Studio instance running this test to get an instance of the T4 host
            EnvDTE.DTE dte = (EnvDTE.DTE)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE");
            var replacementsDictionary = new Dictionary<string, string>();

            // Get a service provider – how you do this depends on the context:
            // Get a service provider
            IServiceProvider serviceProvider = new ServiceProvider(dte as Microsoft.VisualStudio.OLE.Interop.IServiceProvider);
            var engine = new Microsoft.VisualStudio.TextTemplating.Engine();

            // Get the text template service:
            ITextTemplating t4 = serviceProvider.GetService(typeof(STextTemplating)) as ITextTemplating;
            ITextTemplatingSessionHost sessionHost = t4 as ITextTemplatingSessionHost;

//            sessionHost.Session = sessionHost.CreateSession();
            //sessionHost.Session["MyStringFromSession"] = "Boo";

            // Pass another value in CallContext:  
            System.Runtime.Remoting.Messaging.CallContext.LogicalSetData("MyString", "Foo");

            // Read in the template file and use the T4 engine to process the template
            string templateFile = @"C:\Users\jeroe\Source\Repos\WebUITestAutomationExtension\SpecByExample.Tests\CustomTool\GenerateFromUnitCase.tt";
            String input = File.ReadAllText(templateFile);

            // The real work:
            var host = new TextTemplatingEngineHost();
//            String output = engine.ProcessTemplate(input, host);
            String output = t4.ProcessTemplate(templateFile, input);
            Assert.AreEqual("Boo\n", output);
        }


        [TestMethod]
        public void SimpleTemplateWithParameterTest()
        {
            // Just bluntly use the Visual Studio instance running this test to get an instance of the T4 host
            EnvDTE.DTE dte = (EnvDTE.DTE)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE");
            var replacementsDictionary = new Dictionary<string, string>();

            // Get a service provider – how you do this depends on the context:
            // Get a service provider
            IServiceProvider serviceProvider = new ServiceProvider(dte as Microsoft.VisualStudio.OLE.Interop.IServiceProvider);

            // Get the text template service:
            ITextTemplating t4 = serviceProvider.GetService(typeof(STextTemplating)) as ITextTemplating;
            ITextTemplatingSessionHost sessionHost = t4 as ITextTemplatingSessionHost;

            sessionHost.Session = sessionHost.CreateSession();
            //sessionHost.Session["MyStringFromSession"] = "Boo";

            // Pass another value in CallContext:  
            System.Runtime.Remoting.Messaging.CallContext.LogicalSetData("MyString", "Foo");

            // Read in the template file and use the T4 engine to process the template
            string templateFile = @"C:\Users\jeroe\Source\Repos\WebUITestAutomationExtension\SpecByExample.Tests\CustomTool\GenerateFromUnitCase.tt";
            String input = File.ReadAllText(templateFile);

            // The real work:
            String output = t4.ProcessTemplate(templateFile, input);
            Assert.AreEqual("Boo\n",output);
        }

        [TestMethod]
        public void TransformTemplateUsingDeserializedWebmodelTest()
        {
            // Just bluntly use the Visual Studio instance running this test to get an instance of the T4 host
            EnvDTE.DTE dte = (DTE)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE");
            var replacementsDictionary = new Dictionary<string, string>();

            // TODO Make location for loading T4 templates dynamic
            string templateFile = @"C:\Users\jeroe\Source\Repos\WebUITestAutomationExtension\SpecByExample.T4\Templates\PageObject.Init.tt";
            string modelFile = @"C:\Users\jeroe\Source\Repos\WebUITestAutomationExtension\SpecByExample.Tests\Testdata\" + "MyFirst.webmodel";
            string expectedOutput = @"C:\Users\jeroe\Source\Repos\WebUITestAutomationExtension\SpecByExample.Tests\Testdata\ExpectedTransformedCode.txt";

            // Load the model
            XmlSerializer deserializer = new XmlSerializer(typeof(PageAdapterWizardViewModel));
            TextReader textReader = new StreamReader(modelFile);
            var model = (PageAdapterWizardViewModel)deserializer.Deserialize(textReader);
            textReader.Close();

            // Create the code and replace the parameters and use that code.
            // Put all generated code back into one replacement parameter to inject it.

            // Get the text template service:
            IServiceProvider serviceProvider = new ServiceProvider(dte as Microsoft.VisualStudio.OLE.Interop.IServiceProvider);
            ITextTemplating t4 = serviceProvider.GetService(typeof(STextTemplating)) as ITextTemplating;
            ITextTemplatingSessionHost sessionHost = t4 as ITextTemplatingSessionHost;
            sessionHost.Session = sessionHost.CreateSession();

            System.Runtime.Remoting.Messaging.CallContext.LogicalSetData("WizardSettings", model);

            // Read in the template file and use the T4 engine to process the template
            String input = File.ReadAllText(templateFile);
            String output = t4.ProcessTemplate(templateFile, input);

            var expected = File.ReadAllText(expectedOutput);
            Assert.AreEqual(expected, output);
        }
    }
}
