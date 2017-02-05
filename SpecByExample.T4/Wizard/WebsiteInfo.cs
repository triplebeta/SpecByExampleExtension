using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SpecByExample.T4.Wizard;
using System.IO;

namespace SpecByExample.T4.Wizard_pages
{
    public partial class WebsiteInfo : UserControl, IWizardPage
    {
        private PageInfo pageInfo;

        public WebsiteInfo()
        {
            InitializeComponent();
        }

        #region Implement IWizardPage

        public WizardConfiguration WizardConfig
        {
            get;
            set;
        }

        public void LoadState(CodeGenerationSettings container)
        {
            PageUrl = container.Url;
            ActiveControl = txtUrl;
            ExcludeNonUniqueControls = container.Options.ExcludeNonUniqueControls;
        }

        public void SaveState(CodeGenerationSettings container)
        {
            // Only when the url changes (going back and forth in the wizard) we must update
            // the collection of selected HTML controls.
            if (String.Equals(container.Url, PageUrl,StringComparison.InvariantCultureIgnoreCase) == false)
            {
                container.Url = PageUrl;
                container.PageInfo = pageInfo;

                // By default select all elements
                container.SelectedHtmlElements.Clear();
                container.SelectedHtmlElements.AddRange(pageInfo.HtmlElements);

                container.Options.ExcludeNonUniqueControls = ExcludeNonUniqueControls;
            }
        }

        public bool ValidateInput()
        {
            bool isValid = ValidateChildren();
            if (isValid)
            {
                // Check that the url is valid and load all controls into a list.
                try
                {
                    Cursor = Cursors.WaitCursor;
                    lblWaiting.Visible = true;
                    lblWaiting.Update();

                    var loader = new HtmlLoader(WizardConfig.RegisteredControlTypes);
                    pageInfo = loader.GetPageInfo(PageUrl, WizardConfig, Options);
                }
                catch
                {
                    MessageBox.Show("Cannot load HTML from the specified url.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isValid = false;
                }
                finally
                {
                    lblWaiting.Visible = false;
                    Cursor = Cursors.Default;
                }
            }
            return isValid;
        }

        #endregion

        #region Private properties

        /// <summary>
        /// Url of the page
        /// </summary>
        private string PageUrl
        {
            get
            {
                string url = txtUrl.Text ?? "";
                if ((url.StartsWith("file://", StringComparison.InvariantCultureIgnoreCase) && File.Exists(url)) ||
                    url.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase) ||
                    url.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase))
                    return url;
                else
                    return "http://" + url;
            }
            set { txtUrl.Text = value; }
        }


        /// <summary>
        /// True when duplicates should be ignored
        /// </summary>
        private bool ExcludeNonUniqueControls
        {
            get { return chkExcludeNonUniqueControls.Checked; }
            set { chkExcludeNonUniqueControls.Checked = value; }
        }

        /// <summary>
        /// Options for parsing the page
        /// </summary>
        private ParsingOptions Options
        {
            get
            {
                var options = new ParsingOptions();
                options.ExcludeNonUniqueControls = ExcludeNonUniqueControls;
                options.PreferredIdentifications = HtmlLoader.DefaultOptions.PreferredIdentifications;
                return options;
            }
        }

        #endregion

        #region Validation event handlers

        private void txtUrl_Validating(object sender, CancelEventArgs e)
        {
            if (txtUrl.Text.Trim() == String.Empty)
            {
                errorProvider1.SetError(txtUrl, "Url is required");
                e.Cancel = true;
            }
            else if (Uri.IsWellFormedUriString(txtUrl.Text, UriKind.RelativeOrAbsolute) == false && System.IO.File.Exists(txtUrl.Text) == false)
            {
                errorProvider1.SetError(txtUrl, "Url is not recognized as a valid url format.");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtUrl, "");
        }

        #endregion
    }
}
