namespace SpecByExample.T4.Wizard
{
    partial class CodeGenerationOptionsPage
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
            this.chkAddSpecFlowStepsFile = new System.Windows.Forms.CheckBox();
            this.chkAddSpecFlowFeatureFile = new System.Windows.Forms.CheckBox();
            this.chkAddWellKnownUrl = new System.Windows.Forms.CheckBox();
            this.txtWellKnownUrlName = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Code generation options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Use these options to drive code generation";
            // 
            // chkAddSpecFlowStepsFile
            // 
            this.chkAddSpecFlowStepsFile.AutoSize = true;
            this.chkAddSpecFlowStepsFile.Location = new System.Drawing.Point(43, 93);
            this.chkAddSpecFlowStepsFile.Name = "chkAddSpecFlowStepsFile";
            this.chkAddSpecFlowStepsFile.Size = new System.Drawing.Size(162, 17);
            this.chkAddSpecFlowStepsFile.TabIndex = 0;
            this.chkAddSpecFlowStepsFile.Text = "Create a SpecFlow Steps file";
            this.chkAddSpecFlowStepsFile.UseVisualStyleBackColor = true;
            // 
            // chkAddSpecFlowFeatureFile
            // 
            this.chkAddSpecFlowFeatureFile.AutoSize = true;
            this.chkAddSpecFlowFeatureFile.Location = new System.Drawing.Point(43, 116);
            this.chkAddSpecFlowFeatureFile.Name = "chkAddSpecFlowFeatureFile";
            this.chkAddSpecFlowFeatureFile.Size = new System.Drawing.Size(171, 17);
            this.chkAddSpecFlowFeatureFile.TabIndex = 1;
            this.chkAddSpecFlowFeatureFile.Text = "Create a SpecFlow Feature file";
            this.chkAddSpecFlowFeatureFile.UseVisualStyleBackColor = true;
            // 
            // chkAddWellKnownUrl
            // 
            this.chkAddWellKnownUrl.AutoSize = true;
            this.chkAddWellKnownUrl.Location = new System.Drawing.Point(43, 162);
            this.chkAddWellKnownUrl.Name = "chkAddWellKnownUrl";
            this.chkAddWellKnownUrl.Size = new System.Drawing.Size(208, 17);
            this.chkAddWellKnownUrl.TabIndex = 3;
            this.chkAddWellKnownUrl.Text = "Add url as well-known url by this name:";
            this.chkAddWellKnownUrl.UseVisualStyleBackColor = true;
            this.chkAddWellKnownUrl.Visible = false;
            // 
            // txtWellKnownUrlName
            // 
            this.txtWellKnownUrlName.Location = new System.Drawing.Point(257, 162);
            this.txtWellKnownUrlName.Name = "txtWellKnownUrlName";
            this.txtWellKnownUrlName.Size = new System.Drawing.Size(190, 20);
            this.txtWellKnownUrlName.TabIndex = 4;
            this.txtWellKnownUrlName.Visible = false;
            this.txtWellKnownUrlName.Validating += new System.ComponentModel.CancelEventHandler(this.txtWellKnownUrlName_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // CodeGenerationOptionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.txtWellKnownUrlName);
            this.Controls.Add(this.chkAddWellKnownUrl);
            this.Controls.Add(this.chkAddSpecFlowFeatureFile);
            this.Controls.Add(this.chkAddSpecFlowStepsFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "CodeGenerationOptionsPage";
            this.Size = new System.Drawing.Size(469, 285);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAddSpecFlowStepsFile;
        private System.Windows.Forms.CheckBox chkAddSpecFlowFeatureFile;
        private System.Windows.Forms.CheckBox chkAddWellKnownUrl;
        private System.Windows.Forms.TextBox txtWellKnownUrlName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
