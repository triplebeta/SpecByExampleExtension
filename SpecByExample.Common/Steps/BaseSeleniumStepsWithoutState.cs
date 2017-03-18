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
    /// Baseclass for Steps files that, in their constructor, explicitly do NOT require IoC to create a new state instance.
    /// </summary>
    /// <remarks>
    /// When creating a Steps file, you need information such as the WebDriver.
    /// To ensure it's available, we use Constructor-injection and the IoC container will therefore create a new instance of the state
    /// However, some Steps files are meant to be shared and need to access the current state instead of getting their own new instance.
    /// For those Steps classes, use this class as their base class.
    /// 
    /// NOTE: We cannot implement these shared steps in the baseclass for the steps, for the following reason:
    /// - the methods for those steps would need a [Given], [When] or [Then] attribute and the class would need a [Binding] attribute
    /// - subclasses would all contain those methods
    /// - therefore, same method would appear in each of those subclasses, decorated with the same attribute
    /// - SpecFlow will then have an ambiguous method 
    /// This behaviour of SpecFlow is by design: the class is just a container and SpecFlow does not consider it in its scope when scanning the assembly for steps.
    /// </remarks>
    public abstract class BaseSeleniumStepsWithoutState
    {
        /// <summary>
        /// Provides access to the state
        /// </summary>
        /// <remarks>
        /// Subclasses should have no need to access the BrowserInfo directly since it's meant just for the framework.
        /// </remarks>
        internal protected SeleniumBrowserInfo BrowserInfo
        {
            get
            {
                if (ScenarioContext.Current.ContainsKey(ScenarioContextKeys.SELENIUM_CONTEXT_BROWSERINFO_KEY))
                    return ScenarioContext.Current[ScenarioContextKeys.SELENIUM_CONTEXT_BROWSERINFO_KEY] as SeleniumBrowserInfo;
                else
                    return null;
            }
            set { ScenarioContext.Current[ScenarioContextKeys.SELENIUM_CONTEXT_BROWSERINFO_KEY] = value; }
        }


        /// <summary>
        /// Culture for parsing numbers and dates
        /// </summary>
        virtual protected IFormatProvider Culture
        {
            get
            {
                // TODO Read the value configured in the SpecFlow configuration instead of using the hardcoded value
                return CultureInfo.CreateSpecificCulture(GlobalSpecFlowSettings.CULTURE_FOR_PARSING);
            }
        }


        /// <summary>
        /// Provide access to the driver
        /// </summary>
        protected IWebDriver CurrentWebDriver
        {
            get
            {
                return BrowserInfo.CurrentWebDriver;
//                var driver = ScenarioContext.Current["CurrentWebDriver"] as IWebDriver;
//                if (driver == null) throw new InvalidOperationException("The ScenarioContext does not contain an instance of the CurrentWebDriver. This is required for the steps in the SeleniumwindowSteps class. When you inherit from the BaseSeleniumSteps class, this whould be fixed.");

//                return driver;
            }
        }

        /// <summary>
        /// Provide access to the MainWindowHandle
        /// </summary>
        protected string MainWindowHandle
        {
            get
            {
                return BrowserInfo.MainWindowHandle;
            }
        }

        /// <summary>
        /// The current Selenium WebDriver instance to use for the tests.
        /// </summary>
        private T ResolveNewScreen<T>() where T : BaseSeleniumPage
        {
            // Get the page and check that its title matches the expected title.
            var page = BrowserInfo.Container.Resolve<T>();
            SeleniumWindowHelper.SafelyWaitFor(() => page.EnsureOnPage(), 3000);
            return page;
        }


        /// <summary>
        /// Returns an instance of the given screen.
        /// If it's already in the context: return the current instance.
        /// Otherwise, create a new typed wrapper for the current page.
        /// </summary>
        /// <typeparam name="TScreen"></typeparam>
        /// <returns></returns>
        protected TScreen GetScreen<TScreen>() where TScreen : BaseSeleniumPage
        {
            if (ScenarioContext.Current == null) throw new InvalidOperationException("Cannot retrieve and store a screen in the scenario context since no scenario context is available.");

            string key = typeof(TScreen).ToString();    // "FactuurWeekstaatregelsSelecterenScherm";
            if (ScenarioContext.Current.ContainsKey(key) == false)
                ScenarioContext.Current.Add(key, ResolveNewScreen<TScreen>());
            return ScenarioContext.Current[key] as TScreen;
        }
    }
}
