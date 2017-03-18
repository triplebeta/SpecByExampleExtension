using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecByExample.Common;
using System.Net;
using System.Diagnostics;

namespace $safeprojectname$
{
    /// <summary>
    /// Helper class for the tests, just to implement cleanup when unloading the assembly
    /// </summary>
    [TestClass]
    public static class SharedTests
    {
        [AssemblyCleanup]
        public static void CleanupSelenium()
        {
            SeleniumBrowserInfo.CloseCurrentWebDriver();
        }

        [AssemblyInitialize]
        public static void WarmupTheWebsite(TestContext context)

        {
            // Warmup the website by invoking it
            // Give it 90 seconds before timing out.
            int timeout = 90;
            string url = WellKnownUrls.MAIN_PAGE_URL;
            try
            {
                WebRequest warmupRequest = WebRequest.Create(url);
                warmupRequest.UseDefaultCredentials = true;
                warmupRequest.Timeout = timeout * 1000;
                var response = warmupRequest.GetResponse();
            }
            catch (Exception)
            {
                Trace.WriteLine(String.Format("Warmup van de website is mislukt: request to '{0}' is getimeout na {1} seconds",url, timeout));
                throw;
            }
        }
    }
}
