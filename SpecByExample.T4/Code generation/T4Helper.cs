using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TextTemplating;
using Microsoft.VisualStudio.TextTemplating.VSHost;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecByExample.T4
{
    public static class T4Helper
    {
        /// <summary>
        /// Replace the parameters in the code and returns the completed code.
        /// </summary>
        /// <param name="code">Original code with parameters</param>
        /// <param name="replacementsDictionary">Values to be replaced</param>
        /// <returns>Code with parameters replaced by their values.</returns>
        public static string ReplaceParametersInCode(string code, Dictionary<string, string> replacementsDictionary)
        {
            string newCode = code;
            foreach (var p in replacementsDictionary)
            {
                newCode = newCode.Replace(p.Key, p.Value);
            }
            return newCode;
        }


        /// <summary>
        /// Transform a T4 template to output, using a set of parameters.
        /// </summary>
        /// <param name="templateFile"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string TransformToCode(_DTE dte, string templateFile, CodeGenerationSettings settings)
        {
            // TODO Add errorhandling
            Dictionary<string, object> parameters = ConvertSettingsToT4Parameters(settings);

            //********************************************************
            // Define the T4 host, set session parameters
            //********************************************************
            // Get a service provider – how you do this depends on the context:
            // Get a service provider
            IServiceProvider serviceProvider = new ServiceProvider(dte as Microsoft.VisualStudio.OLE.Interop.IServiceProvider);

            // Get the text template service:
            ITextTemplating t4 = serviceProvider.GetService(typeof(STextTemplating)) as ITextTemplating;
            ITextTemplatingSessionHost sessionHost = t4 as ITextTemplatingSessionHost;
            ITextTemplatingEngineHost engine = t4 as ITextTemplatingEngineHost;

            sessionHost.Session = sessionHost.CreateSession();
            foreach (var p in parameters)
            {
                sessionHost.Session[p.Key] = p.Value;
            }

            // Read in the template file and use the T4 engine to process the template
            String input = File.ReadAllText(templateFile);
            String output = t4.ProcessTemplate(templateFile, input);
            return output;
        }


        /// <summary>
        /// Create a dictionary of the parameters to be passed to a T4 Template
        /// </summary>
        /// <param name="settings">Settings as entered in the Wizard</param>
        /// <returns>A dictionary containing all the settings</returns>
        private static Dictionary<string, object> ConvertSettingsToT4Parameters(CodeGenerationSettings settings)
        {
            var parameters = new Dictionary<string, object>();

            // Add the settings as one instance
            // NOTE: The types must be Serializable in order to support this!
            parameters.Add("WizardSettings", settings);

            return parameters;
        }
    }
}
