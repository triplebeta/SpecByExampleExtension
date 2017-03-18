using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Castle.Windsor;
using System.Diagnostics;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Remote;

namespace SpecByExample.Common
{
    /// <summary>
    /// Statebag for data to be injected into the constructor of Specflow tests.
    /// Use this to pass the browser instance.
    /// </summary>
    /// <remarks>
    /// This class contains the WebDriver instance and will control its lifetime.
    /// The static constructor will make sure it's created just once.
    /// </remarks>
    public class SeleniumBrowserInfo // : IDisposable
    {
        private static IWebDriver _currentWebDriver;
        private static WindsorContainer _container;
        private static string _mainBrowserWindowHandle; // Initial Browser window. Close this one only when exiting the application.

#if !USE_INTERNETEXPLORER && !USE_FIREFOX && !USE_CHROME
#error You must define exactly one of the following compiler directives: USE_INTERNETEXPLORER, USE_FIREFOX or USE_CHROME
#endif

#if (USE_INTERNETEXPLORER && USE_FIREFOX) || (USE_INTERNETEXPLORER && USE_CHROME) || (USE_FIREFOX && USE_CHROME)
#error Cannot define more than one of the following compiler directives at once: USE_INTERNETEXPLORER, USE_FIREFOX or USE_CHROME
#endif


        /// <summary>
        /// Static constructor: will be executed once, before creating the first instance.
        /// </summary>
        static SeleniumBrowserInfo()
        {
            // Use this to create the IoC container for creating the screens.
            // Create an IoC Container to resolve the pages
            _container = new WindsorContainer();
            _container.Install(new CastleWindsorInstaller());

            // Register this container as the resource to be returned when resolving the IWindsorContainer. This must be done explicitly.
            _container.Register(Castle.MicroKernel.Registration.Component.For<IWindsorContainer>().Instance(_container).LifeStyle.Singleton);

            // Create a new WebDriver instance
            // Use a compiler directive to switch between the implementations. This allows for creating different assemblies for each browser using build configurations.
            // A test runner can then start the tests in the appropriate assembly to execute the tests for a specific platform.


#if USE_INTERNETEXPLORER
            SwitchToAnotherWebDriver(SeleniumBrowerType.InternetExplorer, ref _currentWebDriver);
#endif
#if USE_FIREFOX
            SwitchToAnotherWebDriver(SeleniumBrowerType.Firefox, ref _currentWebDriver);
#endif
#if USE_CHROME
            SwitchToAnotherWebDriver(SeleniumBrowerType.Chrome, ref _currentWebDriver);
#endif

        }

        /// <summary>
        /// Constructor
        /// </summary>
        public SeleniumBrowserInfo()
        {
            if (_currentWebDriver == null) throw new InvalidOperationException("Current web driver is null but required when creating the selenium browser info instance.");
            MainWindowHandle = _currentWebDriver.CurrentWindowHandle;
        }


        /// <summary>
        /// Expose the container
        /// </summary>
        public WindsorContainer Container
        {
            get { return _container; }
        }

        /// <summary>
        /// Webdriver to use
        /// </summary>
        public IWebDriver CurrentWebDriver
        {
            get
            {
                // TODO Add locking
                return _currentWebDriver;
            }
        }

        /// <summary>
        /// Selenium Handle for the first window created by the CurrentDriver.
        /// </summary>
        public string MainWindowHandle
        {
            get { return _mainBrowserWindowHandle;  }
            private set { _mainBrowserWindowHandle = value; }
        }

        /// <summary>
        /// Set another WebDriver
        /// </summary>
        public static void SwitchToAnotherWebDriver(SeleniumBrowerType browser, ref IWebDriver webDriver)
        {
            if (webDriver != null)
                CloseCurrentWebDriver();

            switch(browser)
            {
                case SeleniumBrowerType.InternetExplorer:
                    {
                        var options = new InternetExplorerOptions();
                        options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                        options.UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Default;

//                        DesiredCapabilities ieCapabilities = new DesiredCapabilities();
//                        ieCapabilities.SetCapability(InternetExplorerDriver.INTRODUCE_FLAKINESS_BY_IGNORING_SECURITY_DOMAINS, true);
                        webDriver = new InternetExplorerDriver(options);
                    } break;
                case SeleniumBrowerType.Firefox:
                    {
                        var profile = new FirefoxProfile();
                        profile.AcceptUntrustedCertificates = true;
                        webDriver = new FirefoxDriver(profile);
                    } break;
                case SeleniumBrowerType.Chrome:
                    {
                        var options = new ChromeOptions();
                        webDriver = new ChromeDriver(options);
                    } break;
                default: throw new ArgumentOutOfRangeException("Cannot create a WebDriver, unknown type of browser.");
            }

            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Install the new one and register it here
            _container.Register(Castle.MicroKernel.Registration.Component.For<IWebDriver>().Instance(_currentWebDriver).LifeStyle.Singleton);
        }


        /// <summary>
        /// Gently close the WebDriver
        /// </summary>
        /// <remarks>
        /// Make sure to close the driver at the end of the test. Do this just once per assembly instead of just in the Dispose
        /// since that will be executed 
        /// </remarks>
        public static void CloseCurrentWebDriver()
        {
            // Dispose the current driver
            if (_currentWebDriver != null)
            {
                try
                {
                    foreach (var handle in _currentWebDriver.WindowHandles)
                    {
                        _currentWebDriver.Close();
                    }
                }
                catch
                {
                    Trace.WriteLine("We will conveniently ignore the exceptions here :)");
                }
                _currentWebDriver.Quit();
                _currentWebDriver.Dispose();
                _currentWebDriver = null;
            }
        }
    }
}
