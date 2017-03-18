using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecByExample.Common
{
    /// <summary>
    /// Extension methods for the ScenarioContext
    /// </summary>
    public static class ScenarioContextExtensions
    {
        /// <summary>
        /// Register a window by its name
        /// </summary>
        public static void RegisterWindow(this ScenarioContext context, string windowName, string windowHandle)
        {
            if (windowName == null) throw new ArgumentNullException("windowName");

            // Check if the key is already in use
            if (context.ContainsKey(windowName))
                throw new ArgumentException(String.Format("A window by the name {0} is already registered in the context of this test, use another name.", windowName));
            ScenarioContext.Current.Add(CreateWindowHandleContextName(windowName), windowHandle);

        }


        /// <summary>
        /// Get the window with the specified name from the context
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="windowName">Name assigned to the window handle using the RegisterWindow extension method.</param>
        /// <returns>Window handle for the name registered under the given name.</returns>
        public static string FindRegisteredWindow(this ScenarioContext context, string windowName)
        {
            if (windowName == null) throw new ArgumentNullException("windowName");

            // Check if the key is already in use
            if (ScenarioContext.Current.ContainsKey(windowName))
                throw new ArgumentException(String.Format("No window registered by the name {0} in the context of this test. Prior to this step you must add a step to remember a window by a specific name.", windowName));

            string handle = (string)ScenarioContext.Current[CreateWindowHandleContextName(windowName)];
            return handle;
        }


        /// <summary>
        /// Create a name to use for storing a Selenium Window handle in the context.
        /// </summary>
        private static string CreateWindowHandleContextName(string windowName)
        {
            return "WINDOW_" + windowName;
        }
    }
}
