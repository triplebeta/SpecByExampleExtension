using Microsoft.VisualStudio.TemplateWizard;
using SpecByExample.T4;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace WizardTester
{
    static class Program
    {
        private static PageObjectWizardForm dialog;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string configFile = Path.Combine(Environment.CurrentDirectory, "ControlAdapterMapping.config");
            var config = WizardConfigLoader.LoadWizardConfiguration(configFile);
            if (config == null) return;
            List<string> configErrors;
            if (config.ValidateConfiguration(out configErrors))
            {
                dialog = new PageObjectWizardForm("Foo", config);
                dialog.WizardController.OnCommit += WizardController_OnCommit;

                try
                {
                    Application.Run(dialog);

                    string newModel = @"c:\temp\model.xml";
                    XmlSerializer serializer = new XmlSerializer(typeof(CodeGenerationSettings));
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
                    settings.Indent = true;
                    settings.OmitXmlDeclaration = false;

                    using (var textWriter = new StreamWriter(newModel))
                    {
                        using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                        {
                            serializer.Serialize(xmlWriter, dialog.WizardController.WizardState);
                        }
                    }                   
                }
                catch(WizardCancelledException)
                {
                    // Ignore this error since the user just cancelled the dialog.
                    Trace.WriteLine("Wizard cancelled by the user");
                }

                // Use the result of the wizard to generate files
                Trace.WriteLine("Wizard done, now testing the code generation");
            }
            else
            {
                string errors = String.Join("\n", configErrors);
                MessageBox.Show(String.Format($"The Wizard configuration is invalid in file\n{configFile}\n\nErrors:\n{errors}"), "Wizard configuration validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void WizardController_OnCommit()
        {
            Trace.WriteLine("Wizard is done, close it.");
            dialog.Close();
        }
    }
}
