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
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Specify the basic settings for the class to wrap your webpage.";
            // 
            // txtPageTitle
            // 
            this.txtPageTitle.Location = new System.Drawing.Point(25, 168);
            this.txtPageTitle.Name = "txtPageTitle";
            this.txtPageTitle.Size = new System.Drawing.Size(496, 20);
            this.txtPageTitle.TabIndex = 3;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Location = new System.Drawing.Point(22, 152);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(54, 13);
            this.lblPageTitle.TabIndex = 19;
            this.lblPageTitle.Text = "Page title:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Page name:";
            // 
            // txtPageName
            // 
            this.txtPageName.Location = new System.Drawing.Point(25, 120);
            this.txtPageName.Name = "txtPageName";
            this.txtPageName.Size = new System.Drawing.Size(227, 20);
            this.txtPageName.TabIndex = 0;
            this.txtPageName.Validating += new System.ComponentModel.CancelEventHandler(this.txtPageName_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Define the class for your page";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // GeneralInfoPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.txtPageTitle);
            this.Controls.Add(this.lblPageTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPageName);
            this.Name = "GeneralInfoPage";
            this.Size = new System.Drawing.Size(631, 295);
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
    }
}
