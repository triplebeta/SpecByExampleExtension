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
            this.wizardControl = new System.Windows.Forms.WizardTabControl();
            this.tabWebsitePage = new System.Windows.Forms.TabPage();
            this.websiteInfoControl = new SpecByExample.T4.Wizard_pages.WebsiteInfo();
            this.tabCommonPage = new System.Windows.Forms.TabPage();
            this.generalInfo = new SpecByExample.T4.Wizard_pages.GeneralInfoPage();
            this.tabHtmlControls = new System.Windows.Forms.TabPage();
            this.htmlControlsPage1 = new SpecByExample.T4.Wizard.HtmlControlsPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.wizardControl.SuspendLayout();
            this.tabWebsitePage.SuspendLayout();
            this.tabCommonPage.SuspendLayout();
            this.tabHtmlControls.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(668, 425);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(104, 24);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "&Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.CausesValidation = false;
            this.btnPrevious.Location = new System.Drawing.Point(558, 425);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(104, 24);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "< &Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
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
            this.wizardControl.Location = new System.Drawing.Point(133, 7);
            this.wizardControl.Name = "wizardControl";
            this.wizardControl.SelectedIndex = 0;
            this.wizardControl.Size = new System.Drawing.Size(647, 412);
            this.wizardControl.TabIndex = 0;
            // 
            // tabWebsitePage
            // 
            this.tabWebsitePage.Controls.Add(this.websiteInfoControl);
            this.tabWebsitePage.Location = new System.Drawing.Point(4, 22);
            this.tabWebsitePage.Name = "tabWebsitePage";
            this.tabWebsitePage.Size = new System.Drawing.Size(639, 386);
            this.tabWebsitePage.TabIndex = 0;
            this.tabWebsitePage.Text = "Website";
            this.tabWebsitePage.UseVisualStyleBackColor = true;
            // 
            // websiteInfoControl
            // 
            this.websiteInfoControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.websiteInfoControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.websiteInfoControl.Location = new System.Drawing.Point(0, 0);
            this.websiteInfoControl.Margin = new System.Windows.Forms.Padding(4);
            this.websiteInfoControl.Name = "websiteInfoControl";
            this.websiteInfoControl.Size = new System.Drawing.Size(639, 386);
            this.websiteInfoControl.TabIndex = 0;
            this.websiteInfoControl.WizardConfig = null;
            // 
            // tabCommonPage
            // 
            this.tabCommonPage.Controls.Add(this.generalInfo);
            this.tabCommonPage.Location = new System.Drawing.Point(4, 22);
            this.tabCommonPage.Name = "tabCommonPage";
            this.tabCommonPage.Size = new System.Drawing.Size(866, 436);
            this.tabCommonPage.TabIndex = 1;
            this.tabCommonPage.Text = "Common";
            this.tabCommonPage.UseVisualStyleBackColor = true;
            // 
            // generalInfo
            // 
            this.generalInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.generalInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalInfo.Location = new System.Drawing.Point(0, 0);
            this.generalInfo.Margin = new System.Windows.Forms.Padding(4);
            this.generalInfo.Name = "generalInfo";
            this.generalInfo.Size = new System.Drawing.Size(866, 436);
            this.generalInfo.TabIndex = 1;
            this.generalInfo.WizardConfig = null;
            // 
            // tabHtmlControls
            // 
            this.tabHtmlControls.Controls.Add(this.htmlControlsPage1);
            this.tabHtmlControls.Location = new System.Drawing.Point(4, 22);
            this.tabHtmlControls.Name = "tabHtmlControls";
            this.tabHtmlControls.Size = new System.Drawing.Size(866, 436);
            this.tabHtmlControls.TabIndex = 4;
            this.tabHtmlControls.Text = "Html Controls";
            this.tabHtmlControls.UseVisualStyleBackColor = true;
            // 
            // htmlControlsPage1
            // 
            this.htmlControlsPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.htmlControlsPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlControlsPage1.Location = new System.Drawing.Point(0, 0);
            this.htmlControlsPage1.Margin = new System.Windows.Forms.Padding(4);
            this.htmlControlsPage1.Name = "htmlControlsPage1";
            this.htmlControlsPage1.Size = new System.Drawing.Size(866, 436);
            this.htmlControlsPage1.TabIndex = 0;
            this.htmlControlsPage1.WizardConfig = null;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(4, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(123, 449);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SpecByExample.T4.Properties.Resources.seleniumlogo;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(26, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(68, 72);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // PageObjectWizardForm
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.wizardControl);
            this.KeyPreview = true;
            this.Name = "PageObjectWizardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Page Adapter Wizard";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PageObjectWizardForm_KeyDown);
            this.wizardControl.ResumeLayout(false);
            this.tabWebsitePage.ResumeLayout(false);
            this.tabCommonPage.ResumeLayout(false);
            this.tabHtmlControls.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WizardTabControl wizardControl;
        private System.Windows.Forms.TabPage tabCommonPage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        internal System.Windows.Forms.TabPage tabWebsitePage;
        private System.Windows.Forms.TabPage tabHtmlControls;
        private Wizard.HtmlControlsPage htmlControlsPage1;
        private Wizard_pages.WebsiteInfo websiteInfoControl;
        private Wizard_pages.GeneralInfoPage generalInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}