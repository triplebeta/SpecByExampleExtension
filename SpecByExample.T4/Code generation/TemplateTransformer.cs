using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TextTemplating;
using Microsoft.VisualStudio.TextTemplating.VSHost;
using EnvDTE;
using System.IO;

namespace SpecByExample.T4
{
    /// <summary>
    /// Helperclass to transform a T4 file
    /// </summary>
    public static class TemplateTransformer
    {
        // Implement transforming the T4 template using the given parameters
        // See: http://msdn.microsoft.com/en-us/library/gg586947(v=vs.100).aspx
        public static void TransformTemplateToFile(IServiceProvider serviceProvider)
        {
            // Get a service provider – how you do this depends on the context:
//            IServiceProvider serviceProvider = dte;
//            serviceProvider = sessionHost;

            // Get the text template service:
            ITextTemplating t4 = serviceProvider.GetService(typeof(STextTemplating)) as ITextTemplating;

            // Process a text template:
//            string result = t4.ProcessTemplate(filePath, System.IO.File.ReadAllText(filePath));

            ITextTemplatingSessionHost sessionHost = t4 as ITextTemplatingSessionHost;

            // Create a Session in which to pass parameters:
            sessionHost.Session = sessionHost.CreateSession();
            sessionHost.Session["parameter1"] = "Hello";
            sessionHost.Session["parameter2"] = DateTime.Now;

            // Pass another value in CallContext:
            System.Runtime.Remoting.Messaging.CallContext.LogicalSetData("parameter3", 42);

            // Process a text template:
            string result = t4.ProcessTemplate("",
                // This is the test template:
               "<#@parameter type=\"System.String\" name=\"parameter1\"#>"
             + "<#@parameter type=\"System.DateTime\" name=\"parameter2\"#>"
             + "<#@parameter type=\"System.Int32\" name=\"parameter3\"#>"
             + "Test: <#=parameter1#>    <#=parameter2#>    <#=parameter3#>");

            // This test code yields a result similar to the following line:
            //     Test: Hello    07/06/2010 12:37:45    42
        }


        private static void ProcessMyTemplate(string MyTemplateFile, ITextTemplating t4)
        {
            string templateContent = File.ReadAllText(MyTemplateFile);
            T4Callback cb = new T4Callback();

            // Process a text template:
            string result = t4.ProcessTemplate(MyTemplateFile, templateContent, cb);
            // If there was an output directive in the MyTemplateFile,
            // then cb.SetFileExtension() will have been called.
            // Determine the output file name:
            string resultFileName =
              Path.Combine(Path.GetDirectoryName(MyTemplateFile),
                  Path.GetFileNameWithoutExtension(MyTemplateFile))
                + cb.fileExtension;
            // Write the processed output to file:
            File.WriteAllText(resultFileName, result, cb.outputEncoding);
            // Append any error messages:
            if (cb.errorMessages.Count > 0)
            {
                File.AppendAllLines(resultFileName, cb.errorMessages);
            }
        }

        class T4Callback : ITextTemplatingCallback
        {
            public List<string> errorMessages = new List<string>();
            public string fileExtension = ".txt";
            public Encoding outputEncoding = Encoding.UTF8;

            public void ErrorCallback(bool warning, string message, int line, int column)
            { errorMessages.Add(message); }

            public void SetFileExtension(string extension)
            { fileExtension = extension; }

            public void SetOutputEncoding(Encoding encoding, bool fromOutputDirective)
            { outputEncoding = encoding; }
        }
    }
}
