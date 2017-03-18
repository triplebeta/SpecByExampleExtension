using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Security;
using System.IO;

namespace SpecByExample.Common
{
    /// <summary>
    /// Helper to start a Browser instance using Windows Integrated security and different credentials
    /// </summary>
    /// <remarks>
    /// Code comes from: http://blogs.atlassian.com/2009/06/selenium_testing_with_windows/
    /// NOTE: For Firefox you need to modify the default FireFox settings as described in the url above.
    /// Otherwise it will not work due to the Firefox NTLM restrictions.
    /// http://support.mozilla.org/nl/kb/Firefox%20vraagt%20om%20gebruikersnaam%20en%20wachtwoord%20op%20interne%20sites
    /// </remarks>
    public class WindowsIntegratedAuthenticationHelper
    {
        private readonly Process process = new Process();
        private bool started;

        public WindowsIntegratedAuthenticationHelper(string username, string password)
        {
            process.StartInfo.FileName = "java";
            process.StartInfo.Arguments = "-jar lib/selenium-server.jar";
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.StartInfo.UseShellExecute = false;

            // TODO Remove these hardcoded credentials
            string[] domainAndUser = new string[] {"MYDOMAIN", username };
            process.StartInfo.UserName = domainAndUser[1];

            SecureString pw = new SecureString();
            foreach (char c in password)
                pw.AppendChar(c);

            process.StartInfo.Password = pw;
            DirectoryInfo currentDir = new DirectoryInfo(Environment.CurrentDirectory);
            process.StartInfo.WorkingDirectory = currentDir.Parent.Parent.Parent.Parent.FullName;

#if USE_INTERNETEXPLORER
            Trace.WriteLine("No additional configuration required for IE");
#endif

#if USE_FIREFOX
            Trace.WriteLine("Configuring FireFox to use Integrated Authentication");

            // TODO Check the profile to exists
            // Profile required for Firefox
            if (Config.Exists(ConfigProps.SeleniumFirefoxProfile))
            {
                process.StartInfo.Arguments += (" -firefoxProfileTemplate " + Config[ConfigProps.SeleniumFirefoxProfile]);
            }
#endif
        }

        public void Start()
        {
            lock (this)
            {
                if (started)
                    throw new InvalidOperationException("Selenium already started");

                if (!process.Start())
                    throw new Exception("Failed to start Selenium process");
                started = true;
            }

            // Give it half a second to start up
            Thread.Sleep(500);
        } // Start

        /// <summary>
        /// Close the browser
        /// </summary>
        public void Stop()
        {
            lock (this)
            {
                if (!started)
                    throw new InvalidOperationException("Selenium not running");
                try
                {
                    process.CloseMainWindow();
                }
                catch
                {
                    //Ignore
                }

                // Give Selenium 5sec to close before we kill it
                if (!process.WaitForExit(5000))
                    process.Kill();
                started = false;
            } // lock
        } // Stop
    }
}
