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
    public partial class Form1 : Form
    {
        IWebDriver _currentDriver;
        WindsorContainer _container;

        public Form1()
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
        /// Webdriver to use
        /// </summary>
        private IWebDriver CurrentDriver
        {
            get { return _currentDriver; }
            set
            {
                if (_currentDriver != null)
                    CloseCurrentDriver();

                // Install the new one and register it here
                _currentDriver = value;
                _container.Register(Castle.MicroKernel.Registration.Component.For<IWebDriver>().Instance(_currentDriver).LifeStyle.Singleton);
            }
        }


        /// <summary>
        /// Initialize the browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBrowser_SelectedIndexChanged(object sender, EventArgs e)
        {
            string browserType = cmbBrowser.Text;
            switch (browserType)
            {
                case "Internet Explorer": CurrentDriver = new InternetExplorerDriver(); break;
                case "Firefox": CurrentDriver = new FirefoxDriver(); break;
                case "Chrome": CurrentDriver = new ChromeDriver(); break;
                default: throw new InvalidOperationException(String.Format("Browser {0} not supported", browserType));
            }
        }


        /// <summary>
        /// Start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartBrowser_Click(object sender, EventArgs e)
        {
            // Driver download from: http://code.google.com/p/selenium/wiki/InternetExplorerDriver
            // NOTE: The server must be found in the path!!!
            // So you need to add its location to your PATH
            CurrentDriver.Url = "http://www.TripleBeta.nl"; 
            CurrentDriver.Navigate();
        }


        /// <summary>
        /// Use Page Object for the Google page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGaNaarGoogle_Click(object sender, EventArgs e)
        {
            CurrentDriver.Url = "http://www.google.com/";
            CurrentDriver.Navigate();
            var target = _container.Resolve<GooglePage>();
            target.NavigateGoogleImagesLink();
//            target.NavigateGoogleNewsLink();
            target.SearchFor("Triple Beta");
        }

/*
        /// <summary>
        /// Use Page Object for the Google page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGaNaarGoogleYou_Click(object sender, EventArgs e)
        {
            CurrentDriver.Url = "http://www.google.com/";
            CurrentDriver.Navigate();
            var target = _container.Resolve<GooglePage>();
            target.NavigateGoogleJijLink();
            target.SearchFor("Triple Beta");
        } */


        /// <summary>
        /// Manually close the driver.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseCurrentDriver();
        }


        /// <summary>
        /// Close the driver
        /// </summary>
        private void CloseCurrentDriver()
        {
            // Dispose the current one
            if (CurrentDriver != null)
            {
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
        }

        private void StartDriverService_Click(object sender, EventArgs e)
        {
            var wiaHelper = new WindowsIntegratedAuthenticationHelper(false);
            wiaHelper.Start();
        }

        private void btnShowWizard_Click(object sender, EventArgs e)
        {
            string configFile = Path.Combine(Environment.CurrentDirectory, "PageObjectControlMappingConfig.xml");
            var config = WizardConfigLoader.LoadWizardConfiguration(configFile);
            if (config == null) return;

            List<string> configErrors;
            if (config.ValidateConfiguration(out configErrors))
            {
                var data = SpecByExample.T4.PageObjectWizardForm.ShowAndGetData("Boo", config);
                CreatePageAdapterWizard wizard = new CreatePageAdapterWizard();
            }
            else
            {
                MessageBox.Show(String.Format("The Wizard configuration is invalid in file\n{0}\n\nErrors:\n{1}", configFile, String.Join("\n",configErrors)),"Wizard configuration validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadWizardConfig_Click(object sender, EventArgs e)
        {
            // Load the configuration of the wizard
            string file = Path.Combine(Environment.CurrentDirectory, "PageObjectControlMappingConfig.xml");
            var config = LoadWizardConfig(file);
        }


        static public WizardConfiguration LoadWizardConfig(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(WizardConfiguration));
            TextReader textReader = new StreamReader(file);
            WizardConfiguration config = (WizardConfiguration)serializer.Deserialize(textReader);
            textReader.Close();
            return config;
        }
    }
}
