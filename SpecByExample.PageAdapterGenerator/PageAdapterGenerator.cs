using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using SpecByExample.T4;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace SpecByExample.PageAdapterGenerator
{
    [ComVisible(true)]
    [Guid("c07152bb-23eb-4ea5-902c-51090d04dc3d")]
    [CodeGeneratorRegistration(typeof(PageAdapterGenerator), "Generates the page adapter code from a webmodel file.", VSConstants.UICONTEXT.CSharpProject_string, GeneratesDesignTimeSource = true)]
    [ProvideObject(typeof(PageAdapterGenerator))]
    public class PageAdapterGenerator : IVsSingleFileGenerator
    {
        #region IVsSingleFileGenerator Members

        public int DefaultExtension(out string defaultExtension)
        {
            defaultExtension = ".cs";
            return defaultExtension.Length;
        }

        /// <summary>
        /// Get the location of the T4 templates.
        /// </summary>
        /// <param name="solution">Root element of the solution.</param>
        /// <param name="fileToTransform">Full filename of the file to be transformed.</param>
        /// <param name="t4Filename">Name of the transformation file to search for.</param>
        /// <returns>Path of the T4 templates to use.</returns>
        private string GetTemplatePath(Solution solution, string  fileToTransform, string t4Filename)
        {
            // First check if the project has its own set of templates.
            // If they are not found: use the templates of the custom tool itself.
            var templateProjectItem = solution.FindProjectItem(t4Filename);
            string templateFile = string.Empty;

#if DISABLED
            // TODO Find out how to get the full path of all project files, then re-enable this code

            // 1. Search for T4 directory in the current project
            string longestPath = string.Empty;
            string modelPath = Path.GetDirectoryName(fileToTransform);
            var projects = solution.Projects.GetEnumerator();
            while (projects.MoveNext())
            {
                var project = (Project)projects.Current;
                var projectPath = project.Properties.Item("FullName").Value;
//                var projectPath = Path.GetDirectoryName(project.FullName);

                // Find the longest matching path. That's the project the file is in.
                if (modelPath.StartsWith(projectPath) && projectPath.Length >= longestPath.Length)
                    longestPath = projectPath;
            }
            if (longestPath!=string.Empty)
            {
                // Project found, look for a T4 folder in the root of it
                templateFile = Path.Combine(longestPath, "T4", t4Filename);
                if (File.Exists(templateFile))
                    return templateFile;
            }
#endif

            // 2. Search for a directory named T4 next to the solution file
            string solutionPath = Path.GetDirectoryName(solution.FullName);
            templateFile = Path.Combine(solutionPath, "T4", t4Filename);
            if (File.Exists(templateFile))
                return templateFile;

            // 3. As a last option: use the T4 template files distributed with the custom tool itself
            string toolPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            templateFile = Path.Combine(toolPath, "T4", t4Filename);
            if (File.Exists(templateFile))
                return templateFile;

            throw new FileNotFoundException($"T4 Template file not found in the installer package.\nCheck that the VSIX package is created correctly.", t4Filename);
        }

        /// <summary>
        /// Main routine for generating the PageObject for a .webmodel file.
        /// </summary>
        /// <returns>C# code</returns>
        public int Generate(string inputFilePath, string inputFileContents, string defaultNamespace, IntPtr[] outputFileContents, out uint output, IVsGeneratorProgress generateProgress)
        {
            // Example from https://www.codeproject.com/articles/688939/visual-studio-custom-tools-do-it-smarter
            EnvDTE.DTE dte = (DTE)Package.GetGlobalService(typeof(DTE));
            string generatedCode = string.Empty;
            int returnCode = VSConstants.S_OK;

            try
            {
                string t4Template = "PageObject.Init.tt";
                var templateFile = GetTemplatePath(dte.Solution, inputFilePath, t4Template);

                // Load the model
                XmlSerializer deserializer = new XmlSerializer(typeof(CodeGenerationSettings));
                TextReader textReader = new StringReader(inputFileContents);
                var model = (CodeGenerationSettings)deserializer.Deserialize(textReader);
                textReader.Close();

                // Create the code and replace the parameters and use that code.
                // Put all generated code back into one replacement parameter to inject it.
                string pageObjectCode = T4Helper.TransformToCode(dte, templateFile, model);
                pageObjectCode = pageObjectCode.Trim();
                generatedCode = T4Helper.ReplaceParametersInCode(pageObjectCode, model.CodePlaceholders.ReplacementDictionary);
            }
            catch (FileNotFoundException ex)
            {
                var sb = new StringBuilder();
                sb.AppendLine("/*");
                sb.AppendLine($"Cannot find template file {ex.FileName}\n");
                sb.AppendLine($"{ex.ToString()}");
                sb.AppendLine("*/");
                generatedCode = sb.ToString();
            }
            catch (Exception ex)
            {
                var sb = new StringBuilder();
                sb.AppendLine("/*");
                sb.AppendLine($"A problem occured while transforming the template:\n");
                sb.AppendLine($"{ex.ToString()}");
                sb.AppendLine("*/");
                generatedCode = sb.ToString();
            }
            finally
            {
                byte[] bytes = Encoding.UTF8.GetBytes(generatedCode);
                int length = bytes.Length;
                outputFileContents[0] = Marshal.AllocCoTaskMem(length);
                Marshal.Copy(bytes, 0, outputFileContents[0], length);
                output = (uint)length;
                returnCode = VSConstants.S_FALSE;
            }
            return returnCode;
        }

#endregion
    }
}
