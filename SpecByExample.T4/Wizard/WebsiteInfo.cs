using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpecByExample.T4.Wizard;
using System.IO;
using System.Diagnostics;

namespace SpecByExample.T4.Wizard_pages
{
    public partial class WebsiteInfo : UserControl, IWizardPage
    {
        private List<HtmlControlInfo> allHtmlElements, allHtmlContainers;
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
            PageUrl = container.PageUrl;
            ActiveControl = txtUrl;
            ExcludeNonUniqueControls = container.Options.ExcludeNonUniqueControls;
        }

        public void SaveState(CodeGenerationSettings container)
        {
            // Only when the url changes (going back and forth in the wizard) we must update
            // the collection of selected HTML controls.
            if (String.Equals(container.PageUrl, PageUrl,StringComparison.InvariantCultureIgnoreCase) == false)
            {
                container.PageUrl = PageUrl;
                container.PageInfo = pageInfo;
                container.AllHtmlElements.Clear();
                container.AllHtmlElements.AddRange(allHtmlElements);

                container.AllHtmlContainers.Clear();
                container.AllHtmlContainers.AddRange(allHtmlContainers);

                container.SelectedHtmlElements.Clear();
                container.SelectedHtmlElements.AddRange(container.AllHtmlElements);

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

                    // Load the HTML
                    var doc = HtmlLoader.LoadDocumentFromUrl(PageUrl);

                    // Get all registered controls except DIVs
                    // Assume we want to generate a property for each item that supports this.
                    var allExceptDiv = from x in WizardConfig.RegisteredControlTypes where x.TypeName != "Div" select x;
                    allHtmlElements = HtmlLoader.GetHtmlControls(doc, allExceptDiv, Options);
                    allHtmlElements.ForEach(x => x.GenerateCodeForThisItem = x.SupportsCodeGeneration);

                    // Get all DIVs by filtering the list of registered controls
                    var divOnly = from x in WizardConfig.RegisteredControlTypes where x.TypeName == "Div" select x;
                    allHtmlContainers = HtmlLoader.GetHtmlControls(doc, divOnly, Options);

                    pageInfo = HtmlLoader.GetPageInfo(doc);
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
                if (!url.StartsWith("file://", StringComparison.InvariantCultureIgnoreCase) &&
                    !File.Exists(url) &&
                    !url.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase))
                    return "http://" + url;
                else
                    return url;
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
