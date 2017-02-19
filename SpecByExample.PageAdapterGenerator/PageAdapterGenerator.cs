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
using System.Collections.Generic;

namespace SpecByExample.PageAdapterGenerator
{
    [ComVisible(true)]
    [Guid("c07152bb-23eb-4ea5-902c-51090d04dc3d")]
    [CodeGeneratorRegistration(typeof(PageAdapterGenerator), "Generates the page adapter code from a webmodel file.", VSConstants.UICONTEXT.CSharpProject_string, GeneratesDesignTimeSource = true)]
    [ProvideObject(typeof(PageAdapterGenerator))]
    public class PageAdapterGenerator : VsMultipleFileGenerator<string>
    {
        protected override byte[] GeneratePageAdapterCode()
        {
            if (Model == null) Model = LoadModel(InputFileContents);
            string generatedCode = GenerateCodeFromFile(Model, "PageObject.Init.tt");
            byte[] data = Encoding.UTF8.GetBytes(generatedCode);
            return data;
        }

        protected override byte[] GenerateStepsCode()
        {
            if (Model == null) Model = LoadModel(InputFileContents);
            string generatedCode = GenerateCodeFromFile(Model, "SpecFlowSteps.Init.tt");
            byte[] data = Encoding.UTF8.GetBytes(generatedCode);
            return data;
        }

        #region Private members

        private CodeGenerationSettings Model
        {
            get;
            set;
        }

        /// <summary>
        /// Load a model from file.
        /// </summary>
        /// <returns></returns>
        private CodeGenerationSettings LoadModel(string modelFile)
        {
            // Load the model
            XmlSerializer deserializer = new XmlSerializer(typeof(CodeGenerationSettings));
            TextReader textReader = new StringReader(modelFile);
            var model = (CodeGenerationSettings)deserializer.Deserialize(textReader);
            textReader.Close();
            return model;
        }

        /// <summary>
        /// Get the location of the T4 templates.
        /// </summary>
        /// <param name="solution">Root element of the solution.</param>
        /// <param name="fileToTransform">Full filename of the file to be transformed.</param>
        /// <param name="t4Filename">Name of the transformation file to search for.</param>
        /// <returns>Path of the T4 templates to use.</returns>
        private string GetFullTemplatePath(Solution solution, string  fileToTransform, string t4Filename)
        {
            // First check if the project has its own set of templates.
            // If they are not found: use the templates of the custom tool itself.
            var templateProjectItem = solution.FindProjectItem(t4Filename);
            string templateFile = string.Empty;

            // 1. Search for T4 directory in the root of the current project
            var projectPath = Path.GetDirectoryName(Project.FullName);
            templateFile = Path.Combine(projectPath, "T4", t4Filename);
            if (File.Exists(templateFile))
                return templateFile;

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
        /// Generate code from a T4 template.
        /// </summary>
        /// <param name="model">Model as input for the template.</param>
        /// <param name="templateFile">Name of T4 file without path.</param>
        /// <returns>Byte array representing the generated code.</returns>
        private string GenerateCodeFromFile(CodeGenerationSettings model, string templateFile)
        {
            string generatedCode = String.Empty;
            try
            {
                var fullTemplateFile = GetFullTemplatePath(Dte.Solution, InputFilePath, templateFile);

                // Create the code and replace the parameters and use that code.
                // Put all generated code back into one replacement parameter to inject it.
                string pageObjectCode = T4Helper.TransformToCode(Dte, fullTemplateFile, model);
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

            return generatedCode;
        }

        #endregion
    }
}
