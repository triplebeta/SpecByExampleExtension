using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpecByExample.T4.Wizard
{
    public partial class CodeGenerationOptionsPage : UserControl, IWizardPage
    {
        public CodeGenerationOptionsPage()
        {
            InitializeComponent();
        }

        #region Validation event handlers

        private void txtWellKnownUrlName_Validating(object sender, CancelEventArgs e)
        {

            if (chkAddWellKnownUrl.Checked && String.IsNullOrWhiteSpace(txtWellKnownUrlName.Text))
            {
                errorProvider1.SetError(txtWellKnownUrlName, "Well-known url name is required");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtWellKnownUrlName, "");
        }

        #endregion

        #region Implement IWizardPage

        public WizardConfiguration WizardConfig
        {
            get;
            set;
        }

        public void LoadState(CodeGenerationSettings container)
        {
            chkAddSpecFlowStepsFile.Checked = container.CreateSpecFlowStepsFile;
            chkAddSpecFlowFeatureFile.Checked = container.CreateSpecFlowFeatureFile;
        }

        public void SaveState(CodeGenerationSettings container)
        {
            container.CreateSpecFlowStepsFile = chkAddSpecFlowStepsFile.Checked;
            container.CreateSpecFlowFeatureFile = chkAddSpecFlowFeatureFile.Checked;
        }

        public bool ValidateInput()
        {
            return ValidateChildren();
        }

        #endregion

    }
}
