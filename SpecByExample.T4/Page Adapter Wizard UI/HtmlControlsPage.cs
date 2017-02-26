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
    /// <summary>
    /// Tab to select the HTML controls to include in the Page Adapter.
    /// </summary>
    public partial class HtmlControlsPage : UserControl, IWizardPage
    {
        private string pageUrl;
        private ParsingOptions options;
        private List<HtmlControlInfo> allHtmlContainers;
        private HtmlControlInfo documentNode;
        private List<HtmlControlInfo> allSelectableControls;
        private List<HtmlControlInfo> currentlySelectedControls;
        private bool IsSaved = false; // flag to note when not to respond to events


        public HtmlControlsPage()
        {
            InitializeComponent();
            currentlySelectedControls = new List<HtmlControlInfo>();

            // Add an item for the rootNode
            documentNode = new HtmlControlInfo();
            documentNode.HtmlXPath = @"/";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Dock = DockStyle.Fill;
        }

        private string HtmlRootNodeXPath
        {
            get
            {
                if (cmbContainers.SelectedItem == null || Disposing)
                    return null;
                else
                    return (cmbContainers.SelectedItem as HtmlControlInfo).HtmlXPath;
            }
        }

        
        #region Handle events

        /// <summary>
        /// When selecting a specific container in the page, show only the elements in that container
        /// </summary>
        private void cmbContainers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Disposing && !IsSaved)
                LoadAndSelectHtmlControls(currentlySelectedControls, HtmlRootNodeXPath);
        }


        /// <summary>
        /// Toggle the panel with the elements to select.
        /// </summary>
        private void chkIncludeAllControls_CheckedChanged(object sender, EventArgs e)
        {
            pnlHtmlElements.Enabled = !chkIncludeAllControls.Checked;
            if (chkIncludeAllControls.Checked)
            {
                // Restore the selection to all items
                LoadAndSelectHtmlControls(currentlySelectedControls, null);
                cmbContainers.SelectedItem = cmbContainers.Items[0];
            }
        }

        /// <summary>
        /// Initializes the checkboxes that allow you to include/exclude controls from code generation.
        /// Gray out all checkboxes for control types that are not present in the list.
        /// </summary>
        private void InitializeFilterCheckboxes()
        {
            // Check all checkboxes
            var checkboxes = new CheckBox[] {
                chkButton, chkCheckbox, chkCombobox,
                chkHyperlink, chkImage, chkListbox, chkRadiobutton,
                chkTable, chkTextArea, chkTextbox
            };

            foreach (var chk in checkboxes)
            {
                // Check the box
                chk.Checked = true;

                // Disable the checkboxes for which the selectedControls does not contain any controls
                string htmlControlType = (chk.Tag as string);
                HtmlControlTypeEnum controlType;
                if (Enum.TryParse<HtmlControlTypeEnum>(htmlControlType, out controlType))
                {
                    if (currentlySelectedControls.Count(x => x.HtmlControlType == controlType)==0)
                    {
                        chk.Enabled = false;
                    }
                    else
                        chk.Enabled = true;
                }
            }
        }

        /// <summary>
        /// When clicking one of the HTML Control type checkboxes, toggle the GenerateCodeForThisControl value for all elements of that type.
        /// </summary>
        private void chkSelectHtmlElementChanged(object sender, EventArgs e)
        {
            // Find the type of control
            var thisCheckbox = (CheckBox)sender;
            string htmlControlType = (thisCheckbox.Tag as string);
            HtmlControlTypeEnum controlType;
            if (Enum.TryParse<HtmlControlTypeEnum>(htmlControlType, out controlType))
            {
                // Image, Object, Paragraph, Radiobutton, Select, Span, Textarea
                bool enabled = thisCheckbox.Checked;
                foreach (HtmlControlInfo ctrl in currentlySelectedControls)
                    if (ctrl.HtmlControlType == controlType)
                        ctrl.GenerateCodeForThisItem = enabled;
                gridControls.Refresh();
            }
            else
                throw new NotSupportedException($"This checkbox is linked to an unsupported type of control: {htmlControlType}.\nFix the wizard :)");
            UpdateSelectedControlCounter();
        }

        /// <summary>
        /// Update counter when updating a control.
        /// </summary>
        private void gridControls_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            UpdateSelectedControlCounter();
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
            IsSaved = false;

            // Remember the rootnode for the scope
            pageUrl = container.Url;
            options = container.Options;

            // Fill the list of containers
            allHtmlContainers = container.PageInfo.HtmlContainers;
            allHtmlContainers.Insert(0, documentNode);  // Add it at the beginning of the list
            containerBindingSource.DataSource = allHtmlContainers;
            cmbContainers.SelectedIndex = 0;

            // Get the selected controls for which we might generate code.
            allSelectableControls = new List<HtmlControlInfo>();
            allSelectableControls.AddRange(container.PageInfo.HtmlElements.Where(x=>x.HtmlControlType!=HtmlControlTypeEnum.Div));
            currentlySelectedControls = new List<HtmlControlInfo>();
            currentlySelectedControls.AddRange(allSelectableControls.Where(x => x.GenerateCodeForThisItem));

            LoadAndSelectHtmlControls(currentlySelectedControls,container.HtmlRootNodeXPath);
        }


        public void SaveState(CodeGenerationSettings container)
        {
            container.HtmlRootNodeXPath = HtmlRootNodeXPath;
            IsSaved = true;
        }

        public bool ValidateInput()
        {
            return ValidateChildren();
        }

        #endregion

        #region Validation

        private void gridControls_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                bool isUsed = (bool)this.gridControls.Rows[e.RowIndex].Cells[0].Value;
                if (isUsed && String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    this.gridControls.Rows[e.RowIndex].ErrorText = "Controlname is required";
                }
                else
                    this.gridControls.Rows[e.RowIndex].ErrorText = "";
            }
        }

        private void gridControls_Validating(object sender, CancelEventArgs e)
        {
            // Check that at least one item is selected
            if (currentlySelectedControls.Count(x => x.GenerateCodeForThisItem) == 0)
            {
                errorProvider1.SetError(gridControls, "At least one HTML control must be selected.");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(gridControls, "");


            // Check that each control has a valid custom name.
            if (currentlySelectedControls.Count(x => x.GenerateCodeForThisItem && String.IsNullOrWhiteSpace(x.UserDefinedName)) > 0)
            {
                errorProvider1.SetError(gridControls, "Each selected control must have a unique custom name.");
                e.Cancel = true;
            }

            var onlySelectedItems = from c in currentlySelectedControls
                                    where c.GenerateCodeForThisItem
                                    select c;

            var duplicates = onlySelectedItems
                .GroupBy(i => i.CodeControlName)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            if (duplicates.Count() > 0)
            {
                errorProvider1.SetError(gridControls, "Duplicate user-defined names detected.");
                e.Cancel = true;
            }
        }

        #endregion

        #region Private Helper code

        private void LoadAndSelectHtmlControls(List<HtmlControlInfo> controlsToLoad, string htmlRootNodeXPath)
        {
            // Now reload the list of SelectedHtmlControls
            currentlySelectedControls = allSelectableControls.OrderByDescending(x => x.GenerateCodeForThisItem).ToList();

            // Ensure only the visible controls are selected
            allSelectableControls.ForEach(x => x.GenerateCodeForThisItem = false);
            currentlySelectedControls.ForEach(x => x.GenerateCodeForThisItem = x.SupportsCodeGeneration);

            // Then show the new selection and update the applicable filter checkboxes.
            htmlControlInfoBindingSource.DataSource = currentlySelectedControls;
            UpdateSelectedControlCounter();
            InitializeFilterCheckboxes();
        }

        private void UpdateSelectedControlCounter()
        {
            if (currentlySelectedControls != null)
                lblSelectedCount.Text = currentlySelectedControls.Count(x => x.GenerateCodeForThisItem).ToString();
        }

        #endregion
    }
}
