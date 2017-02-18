namespace SpecByExample.T4.Wizard
{
    partial class HtmlControlsPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIncludeAllControls = new System.Windows.Forms.CheckBox();
            this.pnlHtmlElements = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSelectedCount = new System.Windows.Forms.Label();
            this.chkTextArea = new System.Windows.Forms.CheckBox();
            this.chkImage = new System.Windows.Forms.CheckBox();
            this.chkRadiobutton = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gridControls = new System.Windows.Forms.DataGridView();
            this.generateCodeForThisItemDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.userDefinedNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.htmlControlTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HtmlId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HtmlName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.htmlXPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.htmlControlInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chkCheckbox = new System.Windows.Forms.CheckBox();
            this.chkHyperlink = new System.Windows.Forms.CheckBox();
            this.chkButton = new System.Windows.Forms.CheckBox();
            this.chkTable = new System.Windows.Forms.CheckBox();
            this.chkListbox = new System.Windows.Forms.CheckBox();
            this.chkCombobox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTextbox = new System.Windows.Forms.CheckBox();
            this.cmbContainers = new System.Windows.Forms.ComboBox();
            this.containerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlHtmlElements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.htmlControlInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(509, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Select for elements you want to include in the page adapter";
            // 
            // chkIncludeAllControls
            // 
            this.chkIncludeAllControls.AutoSize = true;
            this.chkIncludeAllControls.Checked = true;
            this.chkIncludeAllControls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeAllControls.Location = new System.Drawing.Point(32, 66);
            this.chkIncludeAllControls.Margin = new System.Windows.Forms.Padding(4);
            this.chkIncludeAllControls.Name = "chkIncludeAllControls";
            this.chkIncludeAllControls.Size = new System.Drawing.Size(222, 24);
            this.chkIncludeAllControls.TabIndex = 21;
            this.chkIncludeAllControls.Text = "Include all HTML elements";
            this.chkIncludeAllControls.UseVisualStyleBackColor = true;
            this.chkIncludeAllControls.CheckedChanged += new System.EventHandler(this.chkIncludeAllControls_CheckedChanged);
            // 
            // pnlHtmlElements
            // 
            this.pnlHtmlElements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHtmlElements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHtmlElements.Controls.Add(this.label5);
            this.pnlHtmlElements.Controls.Add(this.lblSelectedCount);
            this.pnlHtmlElements.Controls.Add(this.chkTextArea);
            this.pnlHtmlElements.Controls.Add(this.chkImage);
            this.pnlHtmlElements.Controls.Add(this.chkRadiobutton);
            this.pnlHtmlElements.Controls.Add(this.label3);
            this.pnlHtmlElements.Controls.Add(this.gridControls);
            this.pnlHtmlElements.Controls.Add(this.chkCheckbox);
            this.pnlHtmlElements.Controls.Add(this.chkHyperlink);
            this.pnlHtmlElements.Controls.Add(this.chkButton);
            this.pnlHtmlElements.Controls.Add(this.chkTable);
            this.pnlHtmlElements.Controls.Add(this.chkListbox);
            this.pnlHtmlElements.Controls.Add(this.chkCombobox);
            this.pnlHtmlElements.Controls.Add(this.label2);
            this.pnlHtmlElements.Controls.Add(this.chkTextbox);
            this.pnlHtmlElements.Controls.Add(this.cmbContainers);
            this.pnlHtmlElements.Controls.Add(this.label1);
            this.pnlHtmlElements.Enabled = false;
            this.pnlHtmlElements.Location = new System.Drawing.Point(32, 92);
            this.pnlHtmlElements.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHtmlElements.Name = "pnlHtmlElements";
            this.pnlHtmlElements.Size = new System.Drawing.Size(679, 388);
            this.pnlHtmlElements.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(541, 200);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Selected:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSelectedCount
            // 
            this.lblSelectedCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedCount.AutoSize = true;
            this.lblSelectedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedCount.Location = new System.Drawing.Point(636, 200);
            this.lblSelectedCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectedCount.Name = "lblSelectedCount";
            this.lblSelectedCount.Size = new System.Drawing.Size(19, 20);
            this.lblSelectedCount.TabIndex = 16;
            this.lblSelectedCount.Text = "0";
            // 
            // chkTextArea
            // 
            this.chkTextArea.AutoSize = true;
            this.chkTextArea.Checked = true;
            this.chkTextArea.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTextArea.Location = new System.Drawing.Point(52, 122);
            this.chkTextArea.Margin = new System.Windows.Forms.Padding(4);
            this.chkTextArea.Name = "chkTextArea";
            this.chkTextArea.Size = new System.Drawing.Size(97, 24);
            this.chkTextArea.TabIndex = 15;
            this.chkTextArea.Tag = "Textarea";
            this.chkTextArea.Text = "Textarea";
            this.chkTextArea.UseVisualStyleBackColor = true;
            this.chkTextArea.CheckedChanged += new System.EventHandler(this.chkSelectHtmlElementChanged);
            // 
            // chkImage
            // 
            this.chkImage.AutoSize = true;
            this.chkImage.Checked = true;
            this.chkImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImage.Location = new System.Drawing.Point(183, 154);
            this.chkImage.Margin = new System.Windows.Forms.Padding(4);
            this.chkImage.Name = "chkImage";
            this.chkImage.Size = new System.Drawing.Size(80, 24);
            this.chkImage.TabIndex = 14;
            this.chkImage.Tag = "Image";
            this.chkImage.Text = "Image";
            this.chkImage.UseVisualStyleBackColor = true;
            this.chkImage.CheckedChanged += new System.EventHandler(this.chkSelectHtmlElementChanged);
            // 
            // chkRadiobutton
            // 
            this.chkRadiobutton.AutoSize = true;
            this.chkRadiobutton.Checked = true;
            this.chkRadiobutton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRadiobutton.Location = new System.Drawing.Point(333, 154);
            this.chkRadiobutton.Margin = new System.Windows.Forms.Padding(4);
            this.chkRadiobutton.Name = "chkRadiobutton";
            this.chkRadiobutton.Size = new System.Drawing.Size(123, 24);
            this.chkRadiobutton.TabIndex = 13;
            this.chkRadiobutton.Tag = "Radiobutton";
            this.chkRadiobutton.Text = "Radiobutton";
            this.chkRadiobutton.UseVisualStyleBackColor = true;
            this.chkRadiobutton.CheckedChanged += new System.EventHandler(this.chkSelectHtmlElementChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 200);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(343, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Select the elements to add to the page adapter";
            // 
            // gridControls
            // 
            this.gridControls.AllowUserToAddRows = false;
            this.gridControls.AllowUserToDeleteRows = false;
            this.gridControls.AllowUserToResizeRows = false;
            this.gridControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControls.AutoGenerateColumns = false;
            this.gridControls.ColumnHeadersHeight = 32;
            this.gridControls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.generateCodeForThisItemDataGridViewCheckBoxColumn,
            this.userDefinedNameDataGridViewTextBoxColumn,
            this.htmlControlTypeDataGridViewTextBoxColumn,
            this.HtmlId,
            this.HtmlName,
            this.htmlXPathDataGridViewTextBoxColumn});
            this.gridControls.DataSource = this.htmlControlInfoBindingSource;
            this.gridControls.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridControls.Location = new System.Drawing.Point(21, 224);
            this.gridControls.Margin = new System.Windows.Forms.Padding(4);
            this.gridControls.Name = "gridControls";
            this.gridControls.RowHeadersWidth = 40;
            this.gridControls.ShowCellToolTips = false;
            this.gridControls.Size = new System.Drawing.Size(639, 158);
            this.gridControls.TabIndex = 11;
            this.gridControls.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gridControls_CellValidating);
            this.gridControls.CurrentCellDirtyStateChanged += new System.EventHandler(this.gridControls_CurrentCellDirtyStateChanged);
            this.gridControls.Validating += new System.ComponentModel.CancelEventHandler(this.gridControls_Validating);
            // 
            // generateCodeForThisItemDataGridViewCheckBoxColumn
            // 
            this.generateCodeForThisItemDataGridViewCheckBoxColumn.DataPropertyName = "GenerateCodeForThisItem";
            this.generateCodeForThisItemDataGridViewCheckBoxColumn.HeaderText = "Use";
            this.generateCodeForThisItemDataGridViewCheckBoxColumn.Name = "generateCodeForThisItemDataGridViewCheckBoxColumn";
            this.generateCodeForThisItemDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.generateCodeForThisItemDataGridViewCheckBoxColumn.Width = 48;
            // 
            // userDefinedNameDataGridViewTextBoxColumn
            // 
            this.userDefinedNameDataGridViewTextBoxColumn.DataPropertyName = "UserDefinedName";
            this.userDefinedNameDataGridViewTextBoxColumn.HeaderText = "Field name";
            this.userDefinedNameDataGridViewTextBoxColumn.Name = "userDefinedNameDataGridViewTextBoxColumn";
            this.userDefinedNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // htmlControlTypeDataGridViewTextBoxColumn
            // 
            this.htmlControlTypeDataGridViewTextBoxColumn.DataPropertyName = "HtmlControlType";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.htmlControlTypeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.htmlControlTypeDataGridViewTextBoxColumn.HeaderText = "Maps to";
            this.htmlControlTypeDataGridViewTextBoxColumn.Name = "htmlControlTypeDataGridViewTextBoxColumn";
            this.htmlControlTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.htmlControlTypeDataGridViewTextBoxColumn.Width = 90;
            // 
            // HtmlId
            // 
            this.HtmlId.DataPropertyName = "HtmlId";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.HtmlId.DefaultCellStyle = dataGridViewCellStyle2;
            this.HtmlId.HeaderText = "ID";
            this.HtmlId.Name = "HtmlId";
            this.HtmlId.ReadOnly = true;
            this.HtmlId.Width = 60;
            // 
            // HtmlName
            // 
            this.HtmlName.DataPropertyName = "HtmlName";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.HtmlName.DefaultCellStyle = dataGridViewCellStyle3;
            this.HtmlName.HeaderText = "Name";
            this.HtmlName.Name = "HtmlName";
            this.HtmlName.ReadOnly = true;
            // 
            // htmlXPathDataGridViewTextBoxColumn
            // 
            this.htmlXPathDataGridViewTextBoxColumn.DataPropertyName = "HtmlXPath";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.htmlXPathDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.htmlXPathDataGridViewTextBoxColumn.HeaderText = "XPath";
            this.htmlXPathDataGridViewTextBoxColumn.Name = "htmlXPathDataGridViewTextBoxColumn";
            this.htmlXPathDataGridViewTextBoxColumn.ReadOnly = true;
            this.htmlXPathDataGridViewTextBoxColumn.Width = 250;
            // 
            // htmlControlInfoBindingSource
            // 
            this.htmlControlInfoBindingSource.DataSource = typeof(SpecByExample.T4.HtmlControlInfo);
            // 
            // chkCheckbox
            // 
            this.chkCheckbox.AutoSize = true;
            this.chkCheckbox.Checked = true;
            this.chkCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCheckbox.Location = new System.Drawing.Point(183, 122);
            this.chkCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.chkCheckbox.Name = "chkCheckbox";
            this.chkCheckbox.Size = new System.Drawing.Size(105, 24);
            this.chkCheckbox.TabIndex = 10;
            this.chkCheckbox.Tag = "Checkbox";
            this.chkCheckbox.Text = "Checkbox";
            this.chkCheckbox.UseVisualStyleBackColor = true;
            this.chkCheckbox.CheckedChanged += new System.EventHandler(this.chkSelectHtmlElementChanged);
            // 
            // chkHyperlink
            // 
            this.chkHyperlink.AutoSize = true;
            this.chkHyperlink.Checked = true;
            this.chkHyperlink.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHyperlink.Location = new System.Drawing.Point(183, 90);
            this.chkHyperlink.Margin = new System.Windows.Forms.Padding(4);
            this.chkHyperlink.Name = "chkHyperlink";
            this.chkHyperlink.Size = new System.Drawing.Size(64, 24);
            this.chkHyperlink.TabIndex = 9;
            this.chkHyperlink.Tag = "Link";
            this.chkHyperlink.Text = "Link";
            this.chkHyperlink.UseVisualStyleBackColor = true;
            this.chkHyperlink.CheckedChanged += new System.EventHandler(this.chkSelectHtmlElementChanged);
            // 
            // chkButton
            // 
            this.chkButton.AutoSize = true;
            this.chkButton.Checked = true;
            this.chkButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkButton.Location = new System.Drawing.Point(52, 154);
            this.chkButton.Margin = new System.Windows.Forms.Padding(4);
            this.chkButton.Name = "chkButton";
            this.chkButton.Size = new System.Drawing.Size(83, 24);
            this.chkButton.TabIndex = 8;
            this.chkButton.Tag = "Button";
            this.chkButton.Text = "Button";
            this.chkButton.UseVisualStyleBackColor = true;
            this.chkButton.CheckedChanged += new System.EventHandler(this.chkSelectHtmlElementChanged);
            // 
            // chkTable
            // 
            this.chkTable.AutoSize = true;
            this.chkTable.Checked = true;
            this.chkTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTable.Location = new System.Drawing.Point(484, 90);
            this.chkTable.Margin = new System.Windows.Forms.Padding(4);
            this.chkTable.Name = "chkTable";
            this.chkTable.Size = new System.Drawing.Size(74, 24);
            this.chkTable.TabIndex = 6;
            this.chkTable.Tag = "Table";
            this.chkTable.Text = "Table";
            this.chkTable.UseVisualStyleBackColor = true;
            this.chkTable.CheckedChanged += new System.EventHandler(this.chkSelectHtmlElementChanged);
            // 
            // chkListbox
            // 
            this.chkListbox.AutoSize = true;
            this.chkListbox.Checked = true;
            this.chkListbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkListbox.Location = new System.Drawing.Point(333, 90);
            this.chkListbox.Margin = new System.Windows.Forms.Padding(4);
            this.chkListbox.Name = "chkListbox";
            this.chkListbox.Size = new System.Drawing.Size(85, 24);
            this.chkListbox.TabIndex = 5;
            this.chkListbox.Tag = "Listbox";
            this.chkListbox.Text = "Listbox";
            this.chkListbox.UseVisualStyleBackColor = true;
            this.chkListbox.CheckedChanged += new System.EventHandler(this.chkSelectHtmlElementChanged);
            // 
            // chkCombobox
            // 
            this.chkCombobox.AutoSize = true;
            this.chkCombobox.Checked = true;
            this.chkCombobox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCombobox.Location = new System.Drawing.Point(333, 122);
            this.chkCombobox.Margin = new System.Windows.Forms.Padding(4);
            this.chkCombobox.Name = "chkCombobox";
            this.chkCombobox.Size = new System.Drawing.Size(111, 24);
            this.chkCombobox.TabIndex = 4;
            this.chkCombobox.Tag = "Select";
            this.chkCombobox.Text = "Combobox";
            this.chkCombobox.UseVisualStyleBackColor = true;
            this.chkCombobox.CheckedChanged += new System.EventHandler(this.chkSelectHtmlElementChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Include elements with these types:";
            // 
            // chkTextbox
            // 
            this.chkTextbox.AutoSize = true;
            this.chkTextbox.Checked = true;
            this.chkTextbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTextbox.Location = new System.Drawing.Point(52, 90);
            this.chkTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.chkTextbox.Name = "chkTextbox";
            this.chkTextbox.Size = new System.Drawing.Size(90, 24);
            this.chkTextbox.TabIndex = 2;
            this.chkTextbox.Tag = "Text";
            this.chkTextbox.Text = "Textbox";
            this.chkTextbox.UseVisualStyleBackColor = true;
            this.chkTextbox.CheckedChanged += new System.EventHandler(this.chkSelectHtmlElementChanged);
            // 
            // cmbContainers
            // 
            this.cmbContainers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbContainers.DataSource = this.containerBindingSource;
            this.cmbContainers.DisplayMember = "DisplayName";
            this.cmbContainers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContainers.FormattingEnabled = true;
            this.cmbContainers.Location = new System.Drawing.Point(202, 15);
            this.cmbContainers.Margin = new System.Windows.Forms.Padding(4);
            this.cmbContainers.Name = "cmbContainers";
            this.cmbContainers.Size = new System.Drawing.Size(457, 28);
            this.cmbContainers.TabIndex = 1;
            this.cmbContainers.ValueMember = "HtmlXPath";
            this.cmbContainers.SelectedIndexChanged += new System.EventHandler(this.cmbContainers_SelectedIndexChanged);
            // 
            // containerBindingSource
            // 
            this.containerBindingSource.DataSource = typeof(SpecByExample.T4.HtmlControlInfo);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Element must be within:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // HtmlControlsPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pnlHtmlElements);
            this.Controls.Add(this.chkIncludeAllControls);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HtmlControlsPage";
            this.Size = new System.Drawing.Size(727, 494);
            this.pnlHtmlElements.ResumeLayout(false);
            this.pnlHtmlElements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.htmlControlInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIncludeAllControls;
        private System.Windows.Forms.Panel pnlHtmlElements;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkCheckbox;
        private System.Windows.Forms.CheckBox chkHyperlink;
        private System.Windows.Forms.CheckBox chkButton;
        private System.Windows.Forms.CheckBox chkTable;
        private System.Windows.Forms.CheckBox chkListbox;
        private System.Windows.Forms.CheckBox chkCombobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTextbox;
        private System.Windows.Forms.ComboBox cmbContainers;
        private System.Windows.Forms.DataGridView gridControls;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource htmlControlInfoBindingSource;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource containerBindingSource;
        private System.Windows.Forms.CheckBox chkImage;
        private System.Windows.Forms.CheckBox chkRadiobutton;
        private System.Windows.Forms.CheckBox chkTextArea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSelectedCount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn generateCodeForThisItemDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userDefinedNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn htmlControlTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HtmlId;
        private System.Windows.Forms.DataGridViewTextBoxColumn HtmlName;
        private System.Windows.Forms.DataGridViewTextBoxColumn htmlXPathDataGridViewTextBoxColumn;
    }
}
