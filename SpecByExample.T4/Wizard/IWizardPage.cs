using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecByExample.T4.Wizard
{
    /// <summary>
    /// Defines the capabilities of a UserControl that acts as a Wizard page
    /// </summary>
    internal interface IWizardPage
    {
        /// <summary>
        /// Will be set to the configuration of the wizard.
        /// </summary>
        WizardConfiguration WizardConfig { get; set; }

        /// <summary>
        /// Allows the page to load its state from a statebag. 
        /// </summary>
        /// <param name="container">Container from which to load the values.</param>
        void LoadState(CodeGenerationSettings container);

        /// <summary>
        /// Allows the page to save its state to a statebag. 
        /// </summary>
        /// <param name="container">Container to fill.</param>
        void SaveState(CodeGenerationSettings container);

        /// <summary>
        /// Validate the content of this page
        /// </summary>
        bool ValidateInput();
    }
}
