using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;

namespace SpecByExample.Common
{
    /// <summary>
    /// Helper class for utils
    /// </summary>
    public static class SeleniumWindowHelper
    {        
        /// <summary>
        /// Iterate over all windows and find the one which Window its Title matches the given pattern.
        /// </summary>
        /// <param name="driver">WebDriver</param>
        /// <param name="titlePattern">Regular expression string to match the title</param>
        /// <param name="matchPartial">True to match even if the Title partially matches the given string (default=true)</param>
        /// <returns>On success: the handle for the window. On failure: an exception and the window will not be switched.</returns>
        public static string FindWindowByTitleRegex(IWebDriver driver, string titlePattern)
        {
            if (driver == null) throw new ArgumentNullException("driver");
            if (titlePattern == null) throw new ArgumentNullException("titlePattern");

            Func<IWebDriver, bool> matchFunc = new Func<IWebDriver, bool>((d) => {
                Regex re = new Regex(titlePattern);
                return re.IsMatch(d.Title);
            });

            return FindWindowBy(driver, matchFunc);
        }


        /// <summary>
        /// Iterate over all windows and find the one which Window its Title matches the given text.
        /// </summary>
        /// <param name="driver">WebDriver</param>
        /// <param name="title">Window title to match</param>
        /// <param name="matchPartial">True to match even if the Title partially matches the given string (default=true)</param>
        /// <returns>On success: the handle for the window. On failure: an exception and the window will not be switched.</returns>
        public static string FindWindowByTitle(IWebDriver driver, string title, bool matchPartial = true)
        {
            if (driver == null) throw new ArgumentNullException("driver");
            if (title == null) throw new ArgumentNullException("title");

            Func<IWebDriver, bool> matchFunc;
            if (matchPartial)
                matchFunc = new Func<IWebDriver, bool>((d) => d.Title.Contains(title));
            else
                matchFunc = new Func<IWebDriver, bool>((d) => d.Title.Equals(title, StringComparison.InvariantCultureIgnoreCase));

            return FindWindowBy(driver, matchFunc);
        }


        /// <summary>
        /// Iterate over all windows and find the one which Window its url matches the given pattern.
        /// </summary>
        /// <param name="driver">WebDriver</param>
        /// <param name="urlPattern">Regular expression string to match the title</param>
        /// <param name="matchPartial">True to match even if the Title partially matches the given string (default=true)</param>
        /// <returns>On success: the handle for the window. On failure: an exception and the window will not be switched.</returns>
        public static string FindWindowByUrlRegex(IWebDriver driver, string urlPattern)
        {
            if (driver == null) throw new ArgumentNullException("driver");
            if (urlPattern == null) throw new ArgumentNullException("urlPattern");

            Func<IWebDriver, bool> matchFunc = new Func<IWebDriver, bool>((d) =>
            {
                Regex re = new Regex(urlPattern);
                return re.IsMatch(d.Url);
            });

            return FindWindowBy(driver, matchFunc);
        }


        /// <summary>
        /// Iterate over all windows and find the one which Window its URL matches the given text.
        /// </summary>
        /// <param name="driver">WebDriver</param>
        /// <param name="url">URL to be matched</param>
        /// <param name="matchPartial">True to match even if the url partially matches the given string (default=true)</param>
        /// <returns>On success: the handle for the window. On failure: an exception and the window will not be switched.</returns>
        public static string FindWindowByUrl(IWebDriver driver, string url, bool matchPartial = true)
        {
            if (driver == null) throw new ArgumentNullException("driver");
            if (url == null) throw new ArgumentNullException("url");

            Func<IWebDriver, bool> matchFunc;
            if (matchPartial)
                matchFunc = new Func<IWebDriver, bool>((d) => d.Url.Contains(url));
            else
                matchFunc = new Func<IWebDriver, bool>((d) => d.Url.Equals(url,StringComparison.InvariantCultureIgnoreCase));

            return FindWindowBy(driver, matchFunc);
        }

        /// <summary>
        /// Close all windows except the given window
        /// </summary>
        /// <param name="MainWindowHandle"></param>
        public static void CloseAllWindowsExcept(IWebDriver driver, string windowToKeepHandle)
        {
            if (windowToKeepHandle == null) throw new ArgumentNullException("windowToKeepHandle");

            try
            {
                var handles = driver.WindowHandles;
                foreach (var handle in handles)
                {
                    if (handle != windowToKeepHandle)
                    {
                        driver.SwitchTo().Window(handle);
                        driver.Close();
                    }
                }
            }
            catch (WebDriverException)
            {
                // Ignore this
                Trace.WriteLine("Ignoring the WebDriverException in CloseAllWindowsExcept()");
            }
        }


        /// <summary>
        /// Close a specific window by its title but keep the focus on the current window.
        /// </summary>
        /// <param name="driver">WebDriver</param>
        /// <param name="windowToCloseHandle">Selenium window handle for the window to be closed</param>
        /// <param name="windowToGoToHandle">Window to go to after closing the given window. Null if no explicit action is required.</param>
        public static void CloseBrowserWindow(IWebDriver driver, string windowToCloseHandle, string windowToGoToHandle=null)
        {
            if (driver == null) throw new ArgumentNullException("driver");
            if (driver == null) throw new ArgumentNullException("windowHandle");

            Trace.WriteLine(String.Format("Closing browserwindow with handle {0}", windowToCloseHandle));
            SwitchToWindowByHandle(driver, windowToCloseHandle);
            driver.Close();

            // Switch to another Window
            if (windowToGoToHandle != null && driver.WindowHandles.Count>0)
                SwitchToWindowByHandle(driver, windowToGoToHandle);
        }


        /// <summary>
        /// Switch to a specific window by its handle.
        /// </summary>
        /// <param name="windowHandle">Handle of the window to switch to</param>
        /// <exception cref="InvalidOperationException">Thrown if window not found</exception>
        public static IWindow SwitchToWindowByHandle(IWebDriver driver, string windowHandle)
        {
            var handles = driver.WindowHandles;
            foreach (var handle in handles)
            {
                driver.SwitchTo().Window(handle);
                if (handle == windowHandle)
                    return driver.Manage().Window;
            }
            throw new InvalidOperationException(String.Format("Cannot find window with handle {0}.", windowHandle));
        }


        /// <summary>
        /// Wait for an action to complete and guarantee to return after the given time.
        /// </summary>
        /// <param name="condition">Condition to test for.</param>
        /// <param name="timeout">Time in milliseconds to wait for the action to be completed.</param>
        /// <returns>True if found within time</returns>
        public static bool SafelyWaitFor(Func<bool> condition, int timeout, bool throwExceptionOnError = true)
        {
            int count = 0;
            const int sleeptime = 100;

            // Ensure the condition is not executed again after being successful
            bool completed = false;
            while ((completed = condition()) == false && count++ < (timeout / sleeptime))
            {
                Thread.Sleep(sleeptime);
            }

            if (completed)
                return true;
            else
            {
                if (throwExceptionOnError)
                    throw new TimeoutException("Condition not satisfied before the timeout.");
                else
                    return false;
            }
        }


        #region Private Helper methods

        /// <summary>
        /// Iterate over all windows and find the one which contains the given code in its title.
        /// NOTE: This will NOT change the focus to that window, you should call SwitchToWindowByHandle for that.
        /// </summary>
        /// <param name="matchFunc">Function to perform the match</param>
        /// <returns>On success: the handle for the window. On failure: an exception and the window will not be switched.</returns>
        private static string FindWindowBy(IWebDriver driver, Func<IWebDriver, bool> matchFunc)
        {
            if (driver == null) throw new ArgumentNullException("driver");

            // Switch to the newly opened screen
            bool windowFound = false;
            string handleFound = null;
            var currentHandle = driver.CurrentWindowHandle;
            try
            {
                // Loop the windows until we find a match
                var handles = driver.WindowHandles;
                foreach (string handle in handles)
                {
                    var popup = driver.SwitchTo().Window(handle);
                    if (matchFunc(driver))
                    {
                        windowFound = true;
                        handleFound = handle;
                        break;
                    }
                }

                if (windowFound)
                    return handleFound;
                else
                    throw new InvalidPageException("The expected page was not found");
            }
            catch (Exception ex)
            {
                SwitchToWindowByHandle(driver, currentHandle);
                throw ex;
            }
            finally
            {
                // Go back to the original window
                driver.SwitchTo().Window(currentHandle);
            }
        }

        #endregion
    }
}
