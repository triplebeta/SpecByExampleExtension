namespace SpecByExample.T4.Wizard_pages
{
    partial class WebsiteInfo
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
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblWaiting = new System.Windows.Forms.Label();
            this.chkExcludeNonUniqueControls = new System.Windows.Forms.CheckBox();
            this.webbrowser = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(284, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Create an adapter for a webpage";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(606, 20);
            this.label1.TabIndex = 60;
            this.label1.Text = "Enter the address of the webpage for which you want to create a Page Adapter clas" +
    "s";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(36, 185);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(704, 26);
            this.txtUrl.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 160);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Web address:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblWaiting
            // 
            this.lblWaiting.AutoSize = true;
            this.lblWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaiting.Location = new System.Drawing.Point(33, 285);
            this.lblWaiting.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWaiting.Name = "lblWaiting";
            this.lblWaiting.Size = new System.Drawing.Size(222, 20);
            this.lblWaiting.TabIndex = 61;
            this.lblWaiting.Text = "Validating the web address...";
            this.lblWaiting.Visible = false;
            // 
            // chkExcludeNonUniqueControls
            // 
            this.chkExcludeNonUniqueControls.AutoSize = true;
            this.chkExcludeNonUniqueControls.Checked = true;
            this.chkExcludeNonUniqueControls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeNonUniqueControls.Location = new System.Drawing.Point(62, 225);
            this.chkExcludeNonUniqueControls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkExcludeNonUniqueControls.Name = "chkExcludeNonUniqueControls";
            this.chkExcludeNonUniqueControls.Size = new System.Drawing.Size(378, 24);
            this.chkExcludeNonUniqueControls.TabIndex = 62;
            this.chkExcludeNonUniqueControls.Text = "Ignore controls that cannot be identified uniquely";
            this.chkExcludeNonUniqueControls.UseVisualStyleBackColor = true;
            this.chkExcludeNonUniqueControls.Visible = false;
            // 
            // webbrowser
            // 
            this.webbrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webbrowser.Location = new System.Drawing.Point(38, 328);
            this.webbrowser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.webbrowser.MinimumSize = new System.Drawing.Size(30, 31);
            this.webbrowser.Name = "webbrowser";
            this.webbrowser.Size = new System.Drawing.Size(806, 162);
            this.webbrowser.TabIndex = 63;
            this.webbrowser.Visible = false;
            // 
            // WebsiteInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.webbrowser);
            this.Controls.Add(this.chkExcludeNonUniqueControls);
            this.Controls.Add(this.lblWaiting);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUrl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "WebsiteInfo";
            this.Size = new System.Drawing.Size(939, 526);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblWaiting;
        protected internal System.Windows.Forms.CheckBox chkExcludeNonUniqueControls;
        private System.Windows.Forms.WebBrowser webbrowser;
    }
}
