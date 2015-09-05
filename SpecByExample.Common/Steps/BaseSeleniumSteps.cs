using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Globalization;


namespace SpecByExample.Common
{
    /// <summary>
    /// Baseclass for defining Specflow Step files requiring access to the Selenium framework.
    /// Use this class as the baseclass for normal Steps classes, it will make sure each will get its state injected.
    /// </summary>
    /// <remarks>
    /// Implements a framework for accessing the browser.
    /// This class has several partial class files implementing shared steps.
    /// Since SpecFlow uses Castle Winsor to instantiate the Steps files, we use Constructor injection to get an instance of the IoC container and the driver.
    /// </remarks>
    public abstract class BaseSeleniumSteps : BaseSeleniumStepsWithoutState
    {
        private List<string> _knownWindows = new List<string>();


        /// <summary>
        /// Use IoC to get access to the webbrowser.
        /// </summary>
        /// <param name="info"></param>
        public BaseSeleniumSteps(SeleniumBrowserInfo state)
        {
            if (state == null) throw new ArgumentNullException("state");

            // Share the state with other steps by adding it to the ScenarioContext
            if (BrowserInfo == null)
            {
                BrowserInfo = state;
            }
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            // Nothing to do here
            DoBeforeScenario();
        }


        [AfterScenario]
        public void AfterScenario()
        {
            DoAfterScenario();
        }


        /// <summary>
        /// Extension point for code to run before each scenario
        /// </summary>
        protected virtual void DoBeforeScenario()
        {
            // Nothing to do here
        }


        /// <summary>
        /// By default: after each scenario: close all windows except for the main window
        /// And point the driver to the MainWindow
        /// </summary>
        protected virtual void DoAfterScenario()
        {
            // Close all windows except the main window an switch to the main Window
            SeleniumWindowHelper.CloseAllWindowsExcept(CurrentWebDriver, MainWindowHandle);
            CurrentWebDriver.SwitchTo().Window(MainWindowHandle);
        }
    }
}
