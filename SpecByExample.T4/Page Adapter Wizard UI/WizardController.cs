using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpecByExample.T4.Wizard;
using System.ComponentModel;

namespace SpecByExample.T4
{
    /// <summary>
    /// Helps to implement the logic of the wizard such as navigation between the pages.
    /// </summary>
    public class WizardController
    {
        private readonly Button previous, next;
        private readonly WizardTabControl wizard;

        public delegate void CommitHandler();

        /// <summary>
        /// Statebag for Wizard properties. Use it to store the values the user entered on the pages.
        /// </summary>
        public PageAdapterWizardViewModel WizardState;


        /// <summary>
        /// Initial configuration of the wizard.
        /// </summary>
        internal WizardConfiguration WizardConfig
        {
            get;
            set;
        }


        internal WizardController(WizardTabControl wizardControl, Button previousButton, Button nextButton, WizardConfiguration config)
        {
            previous = previousButton;
            next = nextButton;
            wizard = wizardControl;
            WizardConfig = config;
            WizardState = new PageAdapterWizardViewModel();

            bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            if (designMode == false)
            {
                // Only at runtime: Check that each tabcontrol implements the IWizardPage interface
                for (int i = 0; i < wizard.TabCount; i++)
                {
                    if (wizard.TabPages[i].Controls.Count == 0)
                        throw new InvalidOperationException("Wizard tab must contain at least one control.");
                    var page = wizard.TabPages[i].Controls[0];
                    if ((page is IWizardPage) == false)
                        throw new InvalidOperationException("Each page of the wizard must implement");

                    // Provide the config to the pages
                    (page as IWizardPage).WizardConfig = WizardConfig;
                }
            }

            // Connect our event handlers
            previousButton.CausesValidation = false;
            nextButton.CausesValidation = true;
            previousButton.Click += new EventHandler(previousButton_Click);
            nextButton.Click += new EventHandler(nextButton_Click);
            wizard.SelectedIndexChanged += new EventHandler(wizard_SelectedIndexChanged);

            // Initialize the wizard
            wizard.SelectedIndex = 0;
            CurrentWizardPage.LoadState(WizardState);

            previousButton.Enabled = false;
            nextButton.Enabled = !IsLastWizardPage;
        }


        /// <summary>
        /// Event fired when the wizard is completed.
        /// </summary>
        public event CommitHandler OnCommit;

        /// <summary>
        /// True for the last page of this wizard
        /// </summary>
        bool IsLastWizardPage
        {
            get { return (wizard.SelectedIndex == wizard.TabPages.Count - 1); }
        }

        /// <summary>
        /// Handle going to the next page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void nextButton_Click(object sender, EventArgs e)
        {
            if (CurrentWizardPage.ValidateInput() == false)
                return;

            if (IsLastWizardPage)
            {
                CurrentWizardPage.SaveState(WizardState);
                if (OnCommit != null)
                    OnCommit();
            }
            else
            {
                // Save state and go to the next page
                CurrentWizardPage.SaveState(WizardState);
                wizard.SelectedIndex += 1;
                previous.Enabled = true;
                if (IsLastWizardPage)
                    next.Text = "&Finish";
            }
        }


        /// <summary>
        /// Handle going back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void previousButton_Click(object sender, EventArgs e)
        {
            if (wizard.SelectedIndex > 0)
            {
                // Save state of the page before moving to the new page
                CurrentWizardPage.SaveState(WizardState);

                wizard.SelectedIndex -= 1;
                previous.Enabled = (wizard.SelectedIndex != 0);
                next.Enabled = !IsLastWizardPage;

                if (!IsLastWizardPage)
                    next.Text = "&Next >";
            }
        }


        /// <summary>
        /// When showing a wizardpage: allow it to load its data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wizard_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Allow the control to load its data
            CurrentWizardPage.LoadState(WizardState);
        }

        #region Private support methods

        /// <summary>
        /// Current Wizard page
        /// </summary>
        private IWizardPage CurrentWizardPage
        {
            // The constructor already ensured all controls to be a IWizardPage implementations
            get { return wizard.TabPages[wizard.SelectedIndex].Controls[0] as IWizardPage; }
        }

        #endregion
    }
}
