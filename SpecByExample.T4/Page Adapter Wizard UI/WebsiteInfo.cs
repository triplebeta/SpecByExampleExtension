using System;
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
            pageInfo = container.PageInfo;  // Take a reference to this property so we can work with it.
            ExcludeNonUniqueControls = container.Options.ExcludeNonUniqueControls;
        }

        public void SaveState(CodeGenerationSettings container)
        {
            // Only when the url changes (going back and forth in the wizard) we must update
            // the collection of selected HTML controls.
            if (String.Equals(container.Url, PageUrl,StringComparison.InvariantCultureIgnoreCase) == false)
            {
                container.Url = PageUrl;
                container.Options.ExcludeNonUniqueControls = ExcludeNonUniqueControls;
            }
        }

        public bool ValidateInput()
        {
            bool isValid = true;

            if (txtUrl.Text.Trim() == String.Empty)
            {
                errorProvider1.SetError(txtUrl, "Webpage address is required");
                isValid = false;
            }
            else if (Uri.IsWellFormedUriString(txtUrl.Text, UriKind.RelativeOrAbsolute) == false && System.IO.File.Exists(txtUrl.Text) == false)
            {
                errorProvider1.SetError(txtUrl, "Url is not recognized as a valid url format.");
                isValid = false;
            }
            else
                errorProvider1.SetError(txtUrl, "");

            if (isValid)
            {
                // Check that the url is valid and load all controls into a list.
                try
                {
                    Cursor = Cursors.WaitCursor;
                    lblWaiting.Visible = true;
                    lblWaiting.Update();

                    var loader = new HtmlLoader(WizardConfig.RegisteredControlTypes);
                    loader.GetPageInfo(pageInfo, PageUrl, WizardConfig, Options);
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
    }
}
