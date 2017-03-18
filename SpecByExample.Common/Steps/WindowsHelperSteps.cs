using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SpecByExample.Common
{
    /// <summary>
    /// Implementation of extra shared steps.
    /// </summary>
    /// <remarks>
    /// These steps must be declared in the SAME class instead of a new instance of a steps file.
    /// That would create a new instance and Castle Windsor would resolve a new instance of the SeleniumBrowserInfo, with its own info.</remarks>
    [Binding]
    public class WindowsHelperSteps : BaseSeleniumStepsWithoutState
    {
        #region Manage windows

        [When(@"I switch to the main window")]
        [Then(@"I switch to the main window")]
        public void WhenISwitchToTheMainWindow()
        {
            SeleniumWindowHelper.SwitchToWindowByHandle(CurrentWebDriver, MainWindowHandle);
        }


        [When(@"I remember to the current window handle as '(\w+)'")]
        public void WhenIRememberTheCurrentWindowAs(string windowName)
        {
            // Use an extension method to register the current window under a specific name
            if (windowName == null) throw new ArgumentNullException("windowName");
            ScenarioContext.Current.RegisterWindow(windowName, CurrentWebDriver.CurrentWindowHandle);
        }

        [When(@"I go back to window '(\w+)'")]
        [Then(@"I go back to window '(\w+)'")]
        public void WhenIGoToWindowAs(string windowName)
        {
            // Use an extension method to register the current window under a specific name
            if (windowName == null) throw new ArgumentNullException("windowName");
            var handle = ScenarioContext.Current.FindRegisteredWindow(windowName);
            SeleniumWindowHelper.SwitchToWindowByHandle(CurrentWebDriver, handle);
        }


        [When(@"I close all windows except the main window")]
        [Then(@"I close all windows except the main window")]
        public void WhenICloseAllWindowsExceptTheMainWindow()
        {
            SeleniumWindowHelper.CloseAllWindowsExcept(CurrentWebDriver, MainWindowHandle);
        }

        /// <summary>
        /// Close all browser windows for the current driver.
        /// </summary>
        [When(@"I close all windows")]
        [Then(@"I close all windows")]
        public void WhenICloseAllWindows()
        {
            foreach (var handle in CurrentWebDriver.WindowHandles)
            {
                SeleniumWindowHelper.SwitchToWindowByHandle(CurrentWebDriver, handle);
                CurrentWebDriver.Close();
            }
        }

        [When(@"I close the current window")]
        [Then(@"I close the current window")]
        public void WhenICloseTheCurrentWindow()
        {
            bool closingMainWindow = CurrentWebDriver.CurrentWindowHandle == MainWindowHandle;
            CurrentWebDriver.Close();
            if (closingMainWindow==false)
                SeleniumWindowHelper.SwitchToWindowByHandle(CurrentWebDriver, MainWindowHandle);
        }

        [When(@"I close window with code '(.+)'")]
        [Then(@"I close window with code '(.+)'")]
        public void WhenICloseWindowByWindowcode(string windowcode)
        {
            var handle = SeleniumWindowHelper.FindWindowByUrl(CurrentWebDriver, "WeekstaatSelecteren.aspx");
            SeleniumWindowHelper.CloseBrowserWindow(CurrentWebDriver, handle, MainWindowHandle);
        }


        [When(@"I switch the focus to window '(\w*)'")]
        [Then(@"I switch the focus to window '(\w*)'")]
        public void WhenISwitchToTheWindow(string windowcode)
        {
            // Make the given window the standard 
            var handle = SeleniumWindowHelper.FindWindowByTitle(CurrentWebDriver, windowcode);
            var window = SeleniumWindowHelper.SwitchToWindowByHandle(CurrentWebDriver, handle);

            // Get the window with the appropriate title
            var process = Process.GetProcesses().FirstOrDefault(x => x.MainWindowTitle == CurrentWebDriver.Title);
            var windowHandle = process.MainWindowHandle;
        }


        #endregion
    }
}
