using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace SpecByExample.T4
{
    /// <summary>
    /// Implements the algoritm to load the configuration for the wizard.
    /// </summary>
    public class WizardConfigLoader
    {
        /// <summary>
        /// Loads the configuration
        /// </summary>
        /// <returns>An instance of the configuration</returns>
        public static WizardConfiguration LoadWizardConfiguration(string configFile)
        {
            WizardConfiguration config = null;
            try
            {
                // Load the configuration
                System.Diagnostics.Trace.WriteLine("Loading configuration for the wizard from file: " + configFile);
                config = LoadWizardConfigFromFile(configFile);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Failed to load configuration data: "  + ex.ToString());
            }
            return config;
        }


        #region Private helpers

        /// <summary>
        /// Load the configuration of the wizard from a file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private static WizardConfiguration LoadWizardConfigFromFile(string file)
        {
            if (File.Exists(file) == false) throw new FileNotFoundException(String.Format("Cannot load the configuration of the wizard since configurationfile '{0}' is missing", file));

            // Get a list of all controls in order to generate template implementations for them.
            // Create controls:
            //	Input	List		--> Combobox
            //	Input	Textarea	--> Memo
            //  Button				--> Button + click method
            //  Link				--> Link + a click method
            //  Table				--> WebTable 
            XmlSerializer serializer = new XmlSerializer(typeof(WizardConfiguration));
            TextReader textReader = new StreamReader(file);
            WizardConfiguration config = (WizardConfiguration)serializer.Deserialize(textReader);
            textReader.Close();
            return config;
        }

        #endregion
    }
}
