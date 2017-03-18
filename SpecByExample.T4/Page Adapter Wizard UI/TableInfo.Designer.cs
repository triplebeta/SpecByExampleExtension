namespace SpecByExample.T4.Wizard
{
    partial class TableInfo
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
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.lblTables = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblGrid = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.IncludeField = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeFieldname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datatype = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.webTableColumnsDatasetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblEntityName = new System.Windows.Forms.Label();
            this.txtEntityName = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlTableInfo = new System.Windows.Forms.Panel();
            this.chkCreateTableWrapper = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webTableColumnsDatasetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlTableInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTables
            // 
            this.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(15, 32);
            this.cmbTables.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTables.MaxDropDownItems = 12;
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(545, 24);
            this.cmbTables.TabIndex = 0;
            this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
            this.cmbTables.Validating += new System.ComponentModel.CancelEventHandler(this.cmbTables_Validating);
            // 
            // lblTables
            // 
            this.lblTables.AutoSize = true;
            this.lblTables.Location = new System.Drawing.Point(15, 9);
            this.lblTables.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTables.Name = "lblTables";
            this.lblTables.Size = new System.Drawing.Size(282, 17);
            this.lblTables.TabIndex = 10;
            this.lblTables.Text = "Select the main table element of your page:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Configure a typed data table";
            // 
            // lblGrid
            // 
            this.lblGrid.AutoSize = true;
            this.lblGrid.Location = new System.Drawing.Point(15, 135);
            this.lblGrid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrid.Name = "lblGrid";
            this.lblGrid.Size = new System.Drawing.Size(342, 17);
            this.lblGrid.TabIndex = 16;
            this.lblGrid.Text = "Specify a name and datatype for each of its columns:";
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoGenerateColumns = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IncludeField,
            this.ColumnIndex,
            this.ColumnTitle,
            this.CodeFieldname,
            this.Datatype});
            this.grid.DataSource = this.webTableColumnsDatasetBindingSource;
            this.grid.Location = new System.Drawing.Point(15, 155);
            this.grid.Margin = new System.Windows.Forms.Padding(4);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(696, 155);
            this.grid.TabIndex = 2;
            // 
            // IncludeField
            // 
            this.IncludeField.DataPropertyName = "IncludeField";
            this.IncludeField.HeaderText = "Use";
            this.IncludeField.Name = "IncludeField";
            this.IncludeField.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IncludeField.Width = 35;
            // 
            // ColumnIndex
            // 
            this.ColumnIndex.DataPropertyName = "ColumnPosition";
            this.ColumnIndex.HeaderText = "Position";
            this.ColumnIndex.Name = "ColumnIndex";
            this.ColumnIndex.ReadOnly = true;
            this.ColumnIndex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnIndex.Width = 60;
            // 
            // ColumnTitle
            // 
            this.ColumnTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTitle.DataPropertyName = "ColumnTitle";
            this.ColumnTitle.HeaderText = "Title";
            this.ColumnTitle.Name = "ColumnTitle";
            this.ColumnTitle.ReadOnly = true;
            // 
            // CodeFieldname
            // 
            this.CodeFieldname.DataPropertyName = "CodeFieldname";
            this.CodeFieldname.HeaderText = "Fieldname";
            this.CodeFieldname.Name = "CodeFieldname";
            // 
            // Datatype
            // 
            this.Datatype.DataPropertyName = "CodeDatatype";
            this.Datatype.HeaderText = "Datatype";
            this.Datatype.Items.AddRange(new object[] {
            "String",
            "Integer",
            "Float",
            "Double",
            "DateTime",
            "Boolean",
            "Url"});
            this.Datatype.Name = "Datatype";
            // 
            // lblEntityName
            // 
            this.lblEntityName.AutoSize = true;
            this.lblEntityName.Location = new System.Drawing.Point(15, 71);
            this.lblEntityName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEntityName.Name = "lblEntityName";
            this.lblEntityName.Size = new System.Drawing.Size(354, 17);
            this.lblEntityName.TabIndex = 18;
            this.lblEntityName.Text = "What does a row in this table represent:   (entity name)";
            // 
            // txtEntityName
            // 
            this.txtEntityName.Location = new System.Drawing.Point(15, 91);
            this.txtEntityName.Margin = new System.Windows.Forms.Padding(4);
            this.txtEntityName.Name = "txtEntityName";
            this.txtEntityName.Size = new System.Drawing.Size(545, 22);
            this.txtEntityName.TabIndex = 1;
            this.txtEntityName.Validating += new System.ComponentModel.CancelEventHandler(this.txtEntityName_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pnlTableInfo
            // 
            this.pnlTableInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTableInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTableInfo.Controls.Add(this.txtEntityName);
            this.pnlTableInfo.Controls.Add(this.grid);
            this.pnlTableInfo.Controls.Add(this.lblEntityName);
            this.pnlTableInfo.Controls.Add(this.lblGrid);
            this.pnlTableInfo.Controls.Add(this.lblTables);
            this.pnlTableInfo.Controls.Add(this.cmbTables);
            this.pnlTableInfo.Enabled = false;
            this.pnlTableInfo.Location = new System.Drawing.Point(32, 95);
            this.pnlTableInfo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTableInfo.Name = "pnlTableInfo";
            this.pnlTableInfo.Size = new System.Drawing.Size(717, 316);
            this.pnlTableInfo.TabIndex = 1;
            // 
            // chkCreateTableWrapper
            // 
            this.chkCreateTableWrapper.AutoSize = true;
            this.chkCreateTableWrapper.Location = new System.Drawing.Point(32, 66);
            this.chkCreateTableWrapper.Margin = new System.Windows.Forms.Padding(4);
            this.chkCreateTableWrapper.Name = "chkCreateTableWrapper";
            this.chkCreateTableWrapper.Size = new System.Drawing.Size(371, 21);
            this.chkCreateTableWrapper.TabIndex = 0;
            this.chkCreateTableWrapper.Text = "Create a strongly typed wrapper for the data in a table";
            this.chkCreateTableWrapper.UseVisualStyleBackColor = true;
            this.chkCreateTableWrapper.CheckedChanged += new System.EventHandler(this.chkCreateTableWrapper_CheckedChanged);
            // 
            // TableInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.chkCreateTableWrapper);
            this.Controls.Add(this.pnlTableInfo);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TableInfo";
            this.Size = new System.Drawing.Size(764, 425);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webTableColumnsDatasetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlTableInfo.ResumeLayout(false);
            this.pnlTableInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Label lblTables;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblGrid;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label lblEntityName;
        private System.Windows.Forms.TextBox txtEntityName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource webTableColumnsDatasetBindingSource;
        private System.Windows.Forms.CheckBox chkCreateTableWrapper;
        private System.Windows.Forms.Panel pnlTableInfo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IncludeField;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeFieldname;
        private System.Windows.Forms.DataGridViewComboBoxColumn Datatype;
    }
}
