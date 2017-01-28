using Microsoft.VisualStudio.TemplateWizard;
using SpecByExample.T4;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizardTester
{
    static class Program
    {
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
                var wizard = new PageObjectWizardForm("Foo", config);

                try
                {
                    Application.Run(wizard);
                }
                catch(WizardCancelledException)
                {
                    // Ignore this error since the user just cancelled the dialog.
                    Trace.WriteLine("Wizard cancelled by the user");
                }

                // Todo get the info from the screen and serialize it to an XML file with the .webmodel extension
//                wizard.WizardController.WizardState
                // Use the result of the wizard to generate files
                Trace.WriteLine("Wizard done, now testing the code generation");
            }
            else
            {
                string errors = String.Join("\n", configErrors);
                MessageBox.Show(String.Format($"The Wizard configuration is invalid in file\n{configFile}\n\nErrors:\n{errors}"), "Wizard configuration validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
