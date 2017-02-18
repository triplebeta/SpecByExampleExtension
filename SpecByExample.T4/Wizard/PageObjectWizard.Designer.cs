namespace SpecByExample.T4
{
    partial class PageObjectWizardForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.wizardControl = new System.Windows.Forms.WizardTabControl();
            this.tabWebsitePage = new System.Windows.Forms.TabPage();
            this.websiteInfoControl = new SpecByExample.T4.Wizard_pages.WebsiteInfo();
            this.tabCommonPage = new System.Windows.Forms.TabPage();
            this.generalInfo = new SpecByExample.T4.Wizard_pages.GeneralInfoPage();
            this.tabHtmlControls = new System.Windows.Forms.TabPage();
            this.htmlControlsPage1 = new SpecByExample.T4.Wizard.HtmlControlsPage();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.wizardControl.SuspendLayout();
            this.tabWebsitePage.SuspendLayout();
            this.tabCommonPage.SuspendLayout();
            this.tabHtmlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(1300, 742);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(156, 37);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "&Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.CausesValidation = false;
            this.btnPrevious.Location = new System.Drawing.Point(1134, 742);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(156, 37);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "< &Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Create Page Adaptor";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(68, 18);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 111);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(8, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(233, 715);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // wizardControl
            // 
            this.wizardControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardControl.CausesValidation = false;
            this.wizardControl.Controls.Add(this.tabWebsitePage);
            this.wizardControl.Controls.Add(this.tabCommonPage);
            this.wizardControl.Controls.Add(this.tabHtmlControls);
            this.wizardControl.Location = new System.Drawing.Point(250, 6);
            this.wizardControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wizardControl.Name = "wizardControl";
            this.wizardControl.SelectedIndex = 0;
            this.wizardControl.Size = new System.Drawing.Size(1205, 726);
            this.wizardControl.TabIndex = 0;
            // 
            // tabWebsitePage
            // 
            this.tabWebsitePage.Controls.Add(this.websiteInfoControl);
            this.tabWebsitePage.Location = new System.Drawing.Point(4, 29);
            this.tabWebsitePage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabWebsitePage.Name = "tabWebsitePage";
            this.tabWebsitePage.Size = new System.Drawing.Size(1197, 693);
            this.tabWebsitePage.TabIndex = 0;
            this.tabWebsitePage.Text = "Website";
            this.tabWebsitePage.UseVisualStyleBackColor = true;
            // 
            // websiteInfoControl
            // 
            this.websiteInfoControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.websiteInfoControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.websiteInfoControl.Location = new System.Drawing.Point(0, 0);
            this.websiteInfoControl.Margin = new System.Windows.Forms.Padding(6);
            this.websiteInfoControl.Name = "websiteInfoControl";
            this.websiteInfoControl.Size = new System.Drawing.Size(1197, 693);
            this.websiteInfoControl.TabIndex = 0;
            this.websiteInfoControl.WizardConfig = null;
            // 
            // tabCommonPage
            // 
            this.tabCommonPage.Controls.Add(this.generalInfo);
            this.tabCommonPage.Location = new System.Drawing.Point(4, 29);
            this.tabCommonPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabCommonPage.Name = "tabCommonPage";
            this.tabCommonPage.Size = new System.Drawing.Size(1197, 693);
            this.tabCommonPage.TabIndex = 1;
            this.tabCommonPage.Text = "Common";
            this.tabCommonPage.UseVisualStyleBackColor = true;
            // 
            // generalInfo
            // 
            this.generalInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.generalInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalInfo.Location = new System.Drawing.Point(0, 0);
            this.generalInfo.Margin = new System.Windows.Forms.Padding(6);
            this.generalInfo.Name = "generalInfo";
            this.generalInfo.Size = new System.Drawing.Size(1197, 693);
            this.generalInfo.TabIndex = 1;
            this.generalInfo.WizardConfig = null;
            // 
            // tabHtmlControls
            // 
            this.tabHtmlControls.Controls.Add(this.htmlControlsPage1);
            this.tabHtmlControls.Location = new System.Drawing.Point(4, 29);
            this.tabHtmlControls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabHtmlControls.Name = "tabHtmlControls";
            this.tabHtmlControls.Size = new System.Drawing.Size(1197, 693);
            this.tabHtmlControls.TabIndex = 4;
            this.tabHtmlControls.Text = "Html Controls";
            this.tabHtmlControls.UseVisualStyleBackColor = true;
            // 
            // htmlControlsPage1
            // 
            this.htmlControlsPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.htmlControlsPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlControlsPage1.Location = new System.Drawing.Point(0, 0);
            this.htmlControlsPage1.Margin = new System.Windows.Forms.Padding(6);
            this.htmlControlsPage1.Name = "htmlControlsPage1";
            this.htmlControlsPage1.Size = new System.Drawing.Size(1197, 693);
            this.htmlControlsPage1.TabIndex = 0;
            this.htmlControlsPage1.WizardConfig = null;
            // 
            // PageObjectWizardForm
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 797);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.wizardControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PageObjectWizardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Page Adapter Wizard";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PageObjectWizardForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.wizardControl.ResumeLayout(false);
            this.tabWebsitePage.ResumeLayout(false);
            this.tabCommonPage.ResumeLayout(false);
            this.tabHtmlControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WizardTabControl wizardControl;
        private System.Windows.Forms.TabPage tabCommonPage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.TabPage tabWebsitePage;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabHtmlControls;
        private Wizard.HtmlControlsPage htmlControlsPage1;
        private Wizard_pages.WebsiteInfo websiteInfoControl;
        private Wizard_pages.GeneralInfoPage generalInfo;
    }
}