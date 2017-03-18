using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Castle.Windsor;
using System.Diagnostics;
using Google.Pages;
using SpecByExample.Common;
using SpecByExample.T4;
using System.IO;
using System.Xml.Serialization;

namespace SeleniumTester
{
    public partial class Tester : Form
    {
        IWebDriver _currentDriver;
        WindsorContainer _container;

        public Tester()
        {
            InitializeComponent();

            // Create an IoC Container to resolve the pages
            _container = new WindsorContainer();
            _container.Install(new CastleWindsorInstaller());
        }


        /// <summary>
        /// Clean up our mess
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseCurrentDriver();
        }


        /// <summary>
        /// Initialize the browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBrowser_SelectedIndexChanged(object sender, EventArgs e)
        {
            string browserType = cmbBrowser.Text;
            try
            {
                switch (browserType)
                {
                    case "Internet Explorer": CurrentDriver = new InternetExplorerDriver(); break;
                    case "Firefox": CurrentDriver = new FirefoxDriver(); break;
                    case "Chrome": CurrentDriver = new ChromeDriver(); break;
                    default: throw new InvalidOperationException(String.Format("Browser {0} not supported", browserType));
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Cannot start a webdriver for {browserType}.\nMake sure to instal one on your system from http://www.seleniumhq.org/download/ \n" +
                                "The server must be found in the path so you need to add its location to your PATH.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Start the browser.
        /// </summary>
        private void btnStartBrowser_Click(object sender, EventArgs e)
        {
            if (CurrentDriver == null)
            {
                MessageBox.Show("You must first choose which browser to use.");
                return;
            }

            if (!String.IsNullOrEmpty(txtUsername.Text) && !String.IsNullOrEmpty(txtPassword.Text))
            {
                // Experimental! Does not work as expected yet.
                var wiaHelper = new WindowsIntegratedAuthenticationHelper(txtUsername.Text, txtPassword.Text);
                wiaHelper.Start();
            }
            else
            {
                // Use /nrc to stop Google from redirecting to your localized Google page as per:
                // http://lifehacker.com/5933248/avoid-getting-redirected-to-country-specific-versions-of-google
                CurrentDriver.Url = "https://www.google.com/ncr";
                CurrentDriver.Navigate();
            }
        }


        /// <summary>
        /// Use Page Object for the Google page
        /// </summary>
        private void btnGaNaarGoogle_Click(object sender, EventArgs e)
        {
            if (CurrentDriver == null)
            {
                MessageBox.Show("You must first choose which browser to use.");
                return;
            }

            CurrentDriver.Url = "http://www.google.com/";
            CurrentDriver.Navigate();
            var target = _container.Resolve<GooglePage>();
            target.NavigateGoogleImagesLink();
            target.SearchFor("Microsoft");
        }


        /// <summary>
        /// Manually close the driver.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseCurrentDriver();
        }


        #region Private helpers

        /// <summary>
        /// Webdriver instance.
        /// </summary>
        private IWebDriver CurrentDriver
        {
            get { return _currentDriver; }
            set
            {
                // Stop the previous driver first
                if (_currentDriver != null)
                    CloseCurrentDriver();

                // Install the new one and register it here
                _currentDriver = value;
                _container.Register(Castle.MicroKernel.Registration.Component.For<IWebDriver>().Instance(_currentDriver).LifeStyle.Singleton);
            }
        }

        /// <summary>
        /// Close the driver
        /// </summary>
        private void CloseCurrentDriver()
        {
            // Dispose the current one
            if (CurrentDriver == null)
                return; // Nothing to do

            // Driver running: close it
            try 
	        {	        
                foreach(var handle in CurrentDriver.WindowHandles)
                {
                    CurrentDriver.Close();
                }
	        }
	        catch
	        {
		        Trace.WriteLine("We will conveniently ignore any exceptions while closing the WebDriver :)");
	        }
            CurrentDriver.Quit();
            _currentDriver = null;
        }


        static public WizardConfiguration LoadWizardConfig(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(WizardConfiguration));
            TextReader textReader = new StreamReader(file);
            WizardConfiguration config = (WizardConfiguration)serializer.Deserialize(textReader);
            textReader.Close();
            return config;
        }

        #endregion

        private void btnShowWizard_Click(object sender, EventArgs e)
        {

        }
    }
}
