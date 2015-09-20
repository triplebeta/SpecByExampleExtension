using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpecByExample.T4.Wizard;

namespace SpecByExample.T4.Wizard_pages
{
    public partial class GeneralInfoPage : UserControl, IWizardPage
    {
        public GeneralInfoPage()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Dock = DockStyle.Fill;
        }

        #region Properties for the elements on this wizardpage

        /// <summary>
        /// Name of the page
        /// </summary>
        private string HtmlPageName
        {
            get { return txtPageName.Text; }
            set { txtPageName.Text = value; }
        }

        /// <summary>
        /// Title for this page
        /// </summary>
        private string PageTitle
        {
            get { return txtPageTitle.Text; }
            set { txtPageTitle.Text = value; }
        }

        #endregion


        #region Validation event handlers

        private void txtPageName_Validating(object sender, CancelEventArgs e)
        {
            if (txtPageName.Text.Trim() == String.Empty)
            {
                errorProvider1.SetError(txtPageName, "Page name is required");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtPageName, "");
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
            HtmlPageName = container.PageName;
            PageTitle = container.PageInfo.PageTitle;
        }

        public void SaveState(CodeGenerationSettings container)
        {
            container.PageName = HtmlPageName;
            container.PageInfo.PageTitle = PageTitle;
        }

        public bool ValidateInput()
        {
            var valid = ValidateChildren();
            System.Diagnostics.Trace.WriteLineIf(valid, "Page is valid");
            System.Diagnostics.Trace.WriteLineIf(!valid, "Page is invalid");
            return valid;
        }

        #endregion
    }
}
