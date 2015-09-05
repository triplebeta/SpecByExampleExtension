namespace SeleniumTester
{
    partial class Form1
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
            this.btnStartBrowser = new System.Windows.Forms.Button();
            this.btnGaNaarGoogle = new System.Windows.Forms.Button();
            this.cmbBrowser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.StartDriverService = new System.Windows.Forms.Button();
            this.btnShowWizard = new System.Windows.Forms.Button();
            this.btnLoadWizardConfig = new System.Windows.Forms.Button();
            this.btnSaveWizardConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartBrowser
            // 
            this.btnStartBrowser.Location = new System.Drawing.Point(108, 82);
            this.btnStartBrowser.Name = "btnStartBrowser";
            this.btnStartBrowser.Size = new System.Drawing.Size(140, 23);
            this.btnStartBrowser.TabIndex = 0;
            this.btnStartBrowser.Text = "Start browser";
            this.btnStartBrowser.UseVisualStyleBackColor = true;
            this.btnStartBrowser.Click += new System.EventHandler(this.btnStartBrowser_Click);
            // 
            // btnGaNaarGoogle
            // 
            this.btnGaNaarGoogle.Location = new System.Drawing.Point(108, 111);
            this.btnGaNaarGoogle.Name = "btnGaNaarGoogle";
            this.btnGaNaarGoogle.Size = new System.Drawing.Size(140, 23);
            this.btnGaNaarGoogle.TabIndex = 1;
            this.btnGaNaarGoogle.Text = "Ga naar Google";
            this.btnGaNaarGoogle.UseVisualStyleBackColor = true;
            this.btnGaNaarGoogle.Click += new System.EventHandler(this.btnGaNaarGoogle_Click);
            // 
            // cmbBrowser
            // 
            this.cmbBrowser.FormattingEnabled = true;
            this.cmbBrowser.Items.AddRange(new object[] {
            "Internet Explorer",
            "Firefox",
            "Chrome"});
            this.cmbBrowser.Location = new System.Drawing.Point(48, 33);
            this.cmbBrowser.Name = "cmbBrowser";
            this.cmbBrowser.Size = new System.Drawing.Size(237, 21);
            this.cmbBrowser.TabIndex = 4;
            this.cmbBrowser.SelectedIndexChanged += new System.EventHandler(this.cmbBrowser_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Browser";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(291, 31);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // StartDriverService
            // 
            this.StartDriverService.Location = new System.Drawing.Point(273, 82);
            this.StartDriverService.Name = "StartDriverService";
            this.StartDriverService.Size = new System.Drawing.Size(117, 23);
            this.StartDriverService.TabIndex = 7;
            this.StartDriverService.Text = "Start driver service";
            this.StartDriverService.UseVisualStyleBackColor = true;
            this.StartDriverService.Click += new System.EventHandler(this.StartDriverService_Click);
            // 
            // btnShowWizard
            // 
            this.btnShowWizard.Location = new System.Drawing.Point(273, 111);
            this.btnShowWizard.Name = "btnShowWizard";
            this.btnShowWizard.Size = new System.Drawing.Size(117, 23);
            this.btnShowWizard.TabIndex = 8;
            this.btnShowWizard.Text = "Show wizard";
            this.btnShowWizard.UseVisualStyleBackColor = true;
            this.btnShowWizard.Click += new System.EventHandler(this.btnShowWizard_Click);
            // 
            // btnLoadWizardConfig
            // 
            this.btnLoadWizardConfig.Location = new System.Drawing.Point(108, 152);
            this.btnLoadWizardConfig.Name = "btnLoadWizardConfig";
            this.btnLoadWizardConfig.Size = new System.Drawing.Size(140, 23);
            this.btnLoadWizardConfig.TabIndex = 9;
            this.btnLoadWizardConfig.Text = "Load Wizard Config";
            this.btnLoadWizardConfig.UseVisualStyleBackColor = true;
            this.btnLoadWizardConfig.Click += new System.EventHandler(this.btnLoadWizardConfig_Click);
            // 
            // btnSaveWizardConfig
            // 
            this.btnSaveWizardConfig.Location = new System.Drawing.Point(108, 182);
            this.btnSaveWizardConfig.Name = "btnSaveWizardConfig";
            this.btnSaveWizardConfig.Size = new System.Drawing.Size(140, 23);
            this.btnSaveWizardConfig.TabIndex = 10;
            this.btnSaveWizardConfig.Text = "Save Wizard Config";
            this.btnSaveWizardConfig.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 237);
            this.Controls.Add(this.btnSaveWizardConfig);
            this.Controls.Add(this.btnLoadWizardConfig);
            this.Controls.Add(this.btnShowWizard);
            this.Controls.Add(this.StartDriverService);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBrowser);
            this.Controls.Add(this.btnGaNaarGoogle);
            this.Controls.Add(this.btnStartBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selenium Tester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartBrowser;
        private System.Windows.Forms.Button btnGaNaarGoogle;
        private System.Windows.Forms.ComboBox cmbBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button StartDriverService;
        private System.Windows.Forms.Button btnShowWizard;
        private System.Windows.Forms.Button btnLoadWizardConfig;
        private System.Windows.Forms.Button btnSaveWizardConfig;
    }
}

