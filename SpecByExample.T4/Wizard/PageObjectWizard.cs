using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EnvDTE;
using System.IO;
using System.Xml.Serialization;

namespace SpecByExample.T4
{
    public partial class PageObjectWizardForm : Form
    {
        // Used instead of the DialogResult since it does not work well (??)
        public bool IsOke = false;
        private readonly WizardController controller;


        public PageObjectWizardForm()
        {
            InitializeComponent();
        }


        public PageObjectWizardForm(string pageName, WizardConfiguration config)
        {
            InitializeComponent();

            // Load the image at runtime. For some reason the designer crashes when loading it designtime
            pictureBox2.Image = Properties.Resources.seleniumlogo;

            // Create a controller to handle the actions
            controller = new WizardController(wizardControl, btnPrevious, btnNext, config);
            controller.OnCommit += new WizardController.CommitHandler(controller_OnCommit);
            if (pageName != null)
            {
                // Use the name entered by the user as the pagename and make sure it ends with Page
                controller.WizardState.PageName = pageName;
                if (pageName.EndsWith("Page", StringComparison.InvariantCultureIgnoreCase)==false)
                    controller.WizardState.PageName = pageName + "Page";
            }
        }

        /// <summary>
        /// All is well: start the action
        /// </summary>
        void controller_OnCommit()
        {
            // Start the action
            IsOke = true;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }


        /// <summary>
        /// Show the dialog and get its settings.
        /// </summary>
        /// <returns>An entity with the settings, or null if cancelled.</returns>
        public static CodeGenerationSettings ShowAndGetData(string pageName, WizardConfiguration config)
        {
            // Create and show the dialog
            var dialog = new PageObjectWizardForm(pageName, config);
            dialog.ShowDialog();

            // For each control, generate a private field and decorate it with an attribute to access the item by its ID
            // Then, generate a public property to wrap it in a control instance.
            var settings = dialog.controller.WizardState;

            // Stop the transformation if not OK
            dialog.controller.WizardState.IsCancelled = (dialog.IsOke == false);
            return settings;
        }


        private void PageObjectWizardForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Close the screen on Escape.
            if (e.KeyCode == Keys.Escape)
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
