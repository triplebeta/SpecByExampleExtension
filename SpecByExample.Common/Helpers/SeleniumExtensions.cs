using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using SpecByExample.Common.Controls;
using HtmlAgilityPack;

namespace SpecByExample.Common
{
    /// <summary>
    /// Extension methods on the IWebElement and IWebDriver
    /// </summary>
    public static class SeleniumExtensions
    {
        /// <summary>
        /// Returns an instance of the given Control, by wrapping the IWebElement.
        /// </summary>
        /// <typeparam name="TControl">An instance to get back</typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public static TControl As<TControl>(this IWebElement element, IWebDriver driver) where TControl : BaseSeleniumControl, new()
        {
            var control = new TControl();
            control.Initialize(driver, element);
            return control;
        }


        /// <summary>
        /// Returns a special helper that will work directly on a DOM object.
        /// </summary>
        public static HtmlDocument GetHtmlDocument(this IWebDriver driver)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(driver.PageSource);
            return htmlDoc;
        }
    }
}
