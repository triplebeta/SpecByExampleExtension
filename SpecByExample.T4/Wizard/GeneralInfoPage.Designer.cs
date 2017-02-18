namespace SpecByExample.T4.Wizard_pages
{
    partial class GeneralInfoPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPageTitle = new System.Windows.Forms.TextBox();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPageName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkAddSpecFlowFeatureFile = new System.Windows.Forms.CheckBox();
            this.chkAddSpecFlowStepsFile = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Specify the basic settings for the class to wrap your webpage.";
            // 
            // txtPageTitle
            // 
            this.txtPageTitle.Location = new System.Drawing.Point(38, 258);
            this.txtPageTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPageTitle.Name = "txtPageTitle";
            this.txtPageTitle.Size = new System.Drawing.Size(742, 26);
            this.txtPageTitle.TabIndex = 3;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Location = new System.Drawing.Point(33, 234);
            this.lblPageTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(79, 20);
            this.lblPageTitle.TabIndex = 19;
            this.lblPageTitle.Text = "Page title:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 160);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Page name:";
            // 
            // txtPageName
            // 
            this.txtPageName.Location = new System.Drawing.Point(38, 185);
            this.txtPageName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPageName.Name = "txtPageName";
            this.txtPageName.Size = new System.Drawing.Size(338, 26);
            this.txtPageName.TabIndex = 0;
            this.txtPageName.Validating += new System.ComponentModel.CancelEventHandler(this.txtPageName_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Define the class for your page";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // chkAddSpecFlowFeatureFile
            // 
            this.chkAddSpecFlowFeatureFile.AutoSize = true;
            this.chkAddSpecFlowFeatureFile.Location = new System.Drawing.Point(68, 400);
            this.chkAddSpecFlowFeatureFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkAddSpecFlowFeatureFile.Name = "chkAddSpecFlowFeatureFile";
            this.chkAddSpecFlowFeatureFile.Size = new System.Drawing.Size(254, 24);
            this.chkAddSpecFlowFeatureFile.TabIndex = 21;
            this.chkAddSpecFlowFeatureFile.Text = "Create a SpecFlow Feature file";
            this.chkAddSpecFlowFeatureFile.UseVisualStyleBackColor = true;
            // 
            // chkAddSpecFlowStepsFile
            // 
            this.chkAddSpecFlowStepsFile.AutoSize = true;
            this.chkAddSpecFlowStepsFile.Location = new System.Drawing.Point(68, 365);
            this.chkAddSpecFlowStepsFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkAddSpecFlowStepsFile.Name = "chkAddSpecFlowStepsFile";
            this.chkAddSpecFlowStepsFile.Size = new System.Drawing.Size(240, 24);
            this.chkAddSpecFlowStepsFile.TabIndex = 20;
            this.chkAddSpecFlowStepsFile.Text = "Create a SpecFlow Steps file";
            this.chkAddSpecFlowStepsFile.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 324);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Use these options to drive code generation";
            // 
            // GeneralInfoPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.chkAddSpecFlowFeatureFile);
            this.Controls.Add(this.chkAddSpecFlowStepsFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPageTitle);
            this.Controls.Add(this.lblPageTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPageName);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GeneralInfoPage";
            this.Size = new System.Drawing.Size(946, 454);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPageTitle;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPageName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox chkAddSpecFlowFeatureFile;
        private System.Windows.Forms.CheckBox chkAddSpecFlowStepsFile;
        private System.Windows.Forms.Label label2;
    }
}
