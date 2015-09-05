using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using Microsoft.VisualStudio.TextTemplating.VSHost;
using Microsoft.VisualStudio.TextTemplating;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio;
using System.Runtime.InteropServices;
using VSLangProj;
using System.Diagnostics;

namespace SpecByExample.T4
{
    /// <summary>
    /// VSIX Wizard - invoked when creating a new List page
    /// </summary>
    public class CreatePageAdapterWizard : IWizard
    {
        // Add items only if the wizard is completed successfully
        private CodeGenerationSettings settings = null;
        const string WIZARD_CONFIG_FILENAME = "PageAdapterWizardConfig.xml";

        // Declare a set of variables to remember some values when enterin ProjectItemFinishedGenerating
        private _DTE Dte { get; set; }
        private string StepsCode { get; set; }
        private string FeatureCode { get; set; }
        private string PagesProjectName { get; set; }
        private string SpecsProjectName { get; set; }
        private string BasePageName { get; set; }


        #region IWizard implementation

        // This method is called before opening any item that has the OpenInEditor attribute.
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        // This method is only called for item templates,
        // not for project templates.
        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            EnvDTE.Project pagesProject = FindProjectByName(Dte.Solution.Projects, PagesProjectName);
            if (pagesProject == null)
                throw new ArgumentOutOfRangeException(String.Format("Project {0} was not found in the solution.", PagesProjectName));

            // Determine the subdirectory within the project
            string fullPagesProjectPath = Path.GetDirectoryName(pagesProject.FullName);
            string fullFilePath = Path.GetDirectoryName(projectItem.Properties.Item("FullPath").Value as string);
            string subdirectory = fullFilePath.Replace(fullPagesProjectPath, "").TrimStart(new char[] { '\\' });

            if (settings.CreateSpecFlowStepsFile)
            {
                string specsStepsFilename = BasePageName + "Steps.cs";
                CreateNewFileInProject(Dte, SpecsProjectName, subdirectory, specsStepsFilename, StepsCode);
            }
            if (settings.CreateSpecFlowFeatureFile)
            {
                string featureFilename = BasePageName + "Feature.feature";
                var featureFile = CreateNewFileInProject(Dte, SpecsProjectName, subdirectory, featureFilename, FeatureCode);

                // Set properties for code generation
                featureFile.Properties.Item("BuildAction").let_Value(0);    // Build Action = None  instead of Compile
                featureFile.Properties.Item("CustomTool").let_Value("SpecFlowSingleFileGenerator");

                VSProjectItem vsProjectItem = featureFile.Object as VSProjectItem;
                if (vsProjectItem != null)
                {
                    try
                    {
                        vsProjectItem.RunCustomTool();
                    }
                    catch (Exception)
                    {
                        Trace.WriteLine("Failed to run the custom tool for SpecFlow, perhaps SpecFlow is not properly loaded or you are running the wizard outsize of Visual Studio.");
                    }
                }
            }

        }


        /// <summary>
        /// Main routine of this wizard.
        /// </summary>
        /// <param name="automationObject"></param>
        /// <param name="replacementsDictionary"></param>
        /// <param name="runKind"></param>
        /// <param name="customParams"></param>
        public void RunStarted(object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind, object[] customParams)
        {
            // Some tasks cannot be done from this routine since we do not yet have all the information.
            // Therefore we need to set some global variables to complete the job in the method ProjectItemFinishedGenerating
            try
            {
                Dte = (_DTE)automationObject;
                var helper = new ReplacementDictionaryHelper(Dte, replacementsDictionary);
                string vstemplateFile = (string)customParams[0];
                string rootTemplatePath = Path.GetDirectoryName(vstemplateFile);

                // TODO Try to find the Wizard configuration in this project
                string projectFile = helper.GetCurrentProject().FullName;
                string projectDir = Path.GetDirectoryName(projectFile);
                string configFile = Path.Combine(projectDir, "Properties", WIZARD_CONFIG_FILENAME);
                var config = WizardConfigLoader.LoadWizardConfiguration(configFile);
                if (config == null)
                {
                    // Try loading it from the default config file
                    configFile = Path.Combine(rootTemplatePath, WIZARD_CONFIG_FILENAME);
                    config = WizardConfigLoader.LoadWizardConfiguration(configFile);
                    if (config == null)
                    {
                        string error = String.Format("The wizard could not load its configuration from file: \n{0}\n\nFix it or remove it.", configFile);
                        MessageBox.Show(error, "Error loading wizard configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Stop if configuration is not loaded properly
                    }
                }

                // If a configuration was loaded: validate it
                List<string> configErrors;
                if (config.ValidateConfiguration(out configErrors) == false)
                {
                    MessageBox.Show(String.Format("The Wizard configuration is invalid in file\n{0}\n\nErrors:\n{1}", configFile, String.Join("\n", configErrors)), "Wizard configuration validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new WizardCancelledException("Invalid wizard configuration error.");
                }

                // When configuration was properly loaded: Show the wizard
                settings = PageObjectWizardForm.ShowAndGetData(helper.PageName, config);
                if (settings == null || settings.IsCancelled)
                    throw new WizardCancelledException("Wizard cancelled by the user.");

                // Create the code
                AddReplacementVariablesForTemplates(settings, replacementsDictionary, Dte);

                // Create the code and replace the parameters and use that code.
                string pageObjectCode = TransformToCode(Dte, rootTemplatePath, "PageObject.Init.tt", settings);
                replacementsDictionary["$generatedpagecode$"] = ReplaceParametersInCode(pageObjectCode, replacementsDictionary);

                SpecsProjectName = helper.BaseName + ".Specs";
                PagesProjectName = helper.BaseName + ".Pages";
                BasePageName = helper.PageName; ;
                if (settings.CreateSpecFlowStepsFile)
                {
                    string partialStepsCode = TransformToCode(Dte, rootTemplatePath, "SpecFlowSteps.Init.tt", settings);
                    StepsCode = ReplaceParametersInCode(partialStepsCode, replacementsDictionary);
                }
                if (settings.CreateSpecFlowFeatureFile)
                {
                    string partialFeatureCode = TransformToCode(Dte, rootTemplatePath, "SpecFlowFeature.Init.tt", settings);
                    FeatureCode = ReplaceParametersInCode(partialFeatureCode, replacementsDictionary);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Wizard failed with an unexpected error: " + ex.ToString());
                throw new WizardCancelledException("Wizard cancelled due to an exception: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// This method is called after the project is created.
        /// </summary>
        public void RunFinished()
        {
        }


        /// <summary>
        /// This method is only called for item templates, not for project templates.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool ShouldAddProjectItem(string filePath)
        {
            // Here we exclude files that are part of the Item Template as supportfiles
            // but not meant to be added to the project. For those files, return false.
            return !(filePath.EndsWith(".tt") || filePath.Equals(WIZARD_CONFIG_FILENAME, StringComparison.InvariantCultureIgnoreCase));
        }
        
        #endregion


        #region Private helper methods

        /// <summary>
        /// Replace the parameters in the code and returns the completed code.
        /// </summary>
        /// <param name="code">Original code with parameters</param>
        /// <param name="replacementsDictionary">Values to be replaced</param>
        /// <returns>Code with parameters replaced by their values.</returns>
        private string ReplaceParametersInCode(string code, Dictionary<string, string> replacementsDictionary)
        {
            string newCode = code;
            foreach (var p in replacementsDictionary)
            {
                newCode = newCode.Replace(p.Key, p.Value);
            }
            return newCode;
        }


        /// <summary>
        /// Transform a T4 template to output, using a set of parameters
        /// </summary>
        /// <param name="templateFile"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private string TransformToCode(_DTE dte, string rootTemplatePath, string t4Template, CodeGenerationSettings settings)
        {
            string templateFile = Path.Combine(rootTemplatePath, "T4", t4Template);
            if (!File.Exists(templateFile))
                throw new WizardCancelledException(String.Format("T4 Template file '{0}' not found in the installer package.\nCheck that the VSIX package is created correctly.", t4Template));

            // TODO Add errorhandling
            Dictionary<string, object> parameters = ConvertSettingsToT4Parameters(settings);

            //********************************************************
            // A: define the T4 host, set session parameters
            //********************************************************
            // Get a service provider – how you do this depends on the context:
            // Get a service provider
            IServiceProvider serviceProvider = new ServiceProvider(dte as Microsoft.VisualStudio.OLE.Interop.IServiceProvider);

            // Get the text template service:
            ITextTemplating t4 = serviceProvider.GetService(typeof(STextTemplating)) as ITextTemplating;
            ITextTemplatingSessionHost sessionHost = t4 as ITextTemplatingSessionHost;

            sessionHost.Session = sessionHost.CreateSession();
            foreach (var p in parameters)
            {
                sessionHost.Session[p.Key] = p.Value;
            }

            ////********************************************************
            //// B: read in the template file
            ////********************************************************
            String input = File.ReadAllText(templateFile);

            //********************************************************
            // C: use the T4 engine to process the template
            //********************************************************
            String output = t4.ProcessTemplate(templateFile, input);

            //********************************************************
            // D: display generated code on console
            //********************************************************
            Console.WriteLine("[T4TestCustom|output] ==>");
            Console.WriteLine(output);
            Console.WriteLine("[T4TestCustom|output] <==");

            // Output of the template
            return output;
        }


        /// <summary>
        /// Create a dictionary of the parameters to be passed to a T4 Template
        /// </summary>
        /// <param name="settings">Settings as entered in the Wizard</param>
        /// <returns>A dictionary containing all the settings</returns>
        private Dictionary<string, object> ConvertSettingsToT4Parameters(CodeGenerationSettings settings)
        {
            var parameters = new Dictionary<string, object>();

            // Add the settings as one instance
            // NOTE: The types must be Serializable in order to support this!
            parameters.Add("WizardSettings", settings);

            return parameters;
        }

        /// <summary>
        /// Adds new file to the current Solution/Project and inserts the contents
        /// </summary>
        /// <param name="projectName">Project in which to create the file</param>
        /// <param name="subdir">Subdirectory within the project. Will be created if it does not exist yet.</param>
        /// <param name="fileType">File type, eg. General\XML File</param>
        /// <param name="title">File title</param>
        /// <param name="fileContents">File contents</param>
        /// <returns>The newly created item.</returns>
        internal ProjectItem CreateNewFileInProject(_DTE dte, string projectName, string subdir, string title, string fileContents)
        {
            const string Folder = "{6BB5F8EF-4483-11D3-8BCF-00C04F8EC28C}";

            EnvDTE.Project project = FindProjectByName(dte.Solution.Projects, projectName);
            if (project == null)
                throw new ArgumentOutOfRangeException(String.Format("Project {0} was not found in the solution, file {1} will not be created.", projectName, title));

            string projectPath = Path.GetDirectoryName(project.FullName);
            string fileName = Path.Combine(projectPath, subdir, title);
            Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            File.WriteAllText(fileName, fileContents);

            ProjectItem folderForSpecsFile = null;
            foreach (ProjectItem item in project.ProjectItems)
            {
                if (item.Kind == Folder && item.Name.Equals(subdir, StringComparison.InvariantCultureIgnoreCase))
                    folderForSpecsFile = item;
            }

            // If not found: add it to the root of the project 
            if (folderForSpecsFile==null)
            {
                // Add a new folder
                folderForSpecsFile = project.ProjectItems.AddFolder(subdir);
            }

            // Finally, add the file to this folder in the project
            ProjectItem newFile = project.ProjectItems.AddFromFile(fileName);
            return newFile;
        }


        /// <summary>
        /// Recursively search within the solution for the project.
        /// </summary>
        /// <param name="dte">Automation object to access the Visual Studio instance.</param>
        /// <param name="projectName">Name of the project</param>
        /// <returns></returns>
        private EnvDTE.Project FindProjectByName(EnvDTE.Projects projects, string projectName)
        {
            // See also: http://msdn.microsoft.com/en-us/library/hb23x61k(v=vs.80).aspx
            const string SolutionFolderKind = "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}";
            const string CSharpProjectKind = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}";

            // This list will loop the items in the solution, which can be solution folders, projects or items
            foreach (EnvDTE.Project item in projects)
            {
                System.Diagnostics.Trace.WriteLine("Finding project in " + item.Name);
                System.Diagnostics.Trace.Indent();
                try
                {
                    if (item.Kind == SolutionFolderKind)
                    {
                        // If it's a Solution folder: Recursively loop children
                        var myProject = FindProjectByName(item.ProjectItems, projectName);
                        return myProject;
                    }
                    else if (item.Kind == CSharpProjectKind && item.Name.Equals(projectName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return item;
                    }
                }
                finally
                {
                    System.Diagnostics.Trace.Unindent();
                }
            }
            return null;
        }


        /// <summary>
        /// Recursively search within the solution for the project.
        /// </summary>
        /// <param name="dte">Automation object to access the Visual Studio instance.</param>
        /// <param name="projectName">Name of the project</param>
        /// <returns></returns>
        private EnvDTE.Project FindProjectByName(EnvDTE.ProjectItems projectItems, string projectName)
        {
            // See also: http://msdn.microsoft.com/en-us/library/hb23x61k(v=vs.80).aspx
            const string SolutionFolderKind = "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}";
            //const string CSharpProjectKind = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}";

            // This list will loop the items in the solution, which can be solution folders, projects or items
            foreach (EnvDTE.ProjectItem item in projectItems)
            {
                System.Diagnostics.Trace.WriteLine("Finding project in " + item.Name);
                System.Diagnostics.Trace.Indent();
                try
                {
                    if (item.Kind == SolutionFolderKind)
                    {
                        // If it's a Solution folder: Recursively loop children
                        return FindProjectByName(item.ProjectItems, projectName);
                    }
                    else if (item.Name.Equals(projectName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return (item.SubProject as EnvDTE.Project);
                    }
                }
                finally
                {
                    System.Diagnostics.Trace.Unindent();
                }
            }
            return null;
        }

        #endregion

        
        #region Helpers to create the code

        /// <summary>
        /// Adds new elements to the replacement dictionary to use in the templates
        /// </summary>
        /// <param name="settings">Settings to use for the code generation.</param>
        /// <param name="replacementsDictionary">Replacement values</param>
        /// <param name="dte">Reference to the IDE</param>
        public void AddReplacementVariablesForTemplates(CodeGenerationSettings settings, Dictionary<string, string> replacementsDictionary, _DTE dte)
        {
            var helper = new ReplacementDictionaryHelper(dte, replacementsDictionary);

            // Inject the generated code into the PageClassPlaceholder.txt file and rename it
            replacementsDictionary["$specflowstepsclass$"] = helper.SpecFlowStepsClassname;
            replacementsDictionary["$pageclass$"] = helper.PageClassname;
            replacementsDictionary["$targetfilename$"] = helper.OutputFile;
            replacementsDictionary["$rootnamespace$"] = helper.RootNamespace;
            replacementsDictionary["$basename$"] = helper.BaseName;
            replacementsDictionary["$basepageclass$"] = helper.GetPageBaseclass(settings.TypeOfPage);
            if (this.settings.TypeOfPage == PageTemplatesEnum.TablePage)
            {
                replacementsDictionary["$entityname$"] = settings.TableInfo.EntityName;
                replacementsDictionary["$tablecontrolname$"] = settings.TableInfo.TableControlName + "Control";
            }

            if (this.settings.CreateSpecFlowStepsFile)
            {
//                replacementsDictionary["$entityname$"] = settings.TableInfo.EntityName;
            }

            if (this.settings.CreateSpecFlowFeatureFile)
            {
//                replacementsDictionary["$entityname$"] = settings.TableInfo.EntityName;
            }
        }


        public string CreateSpecFlowStepsCode(CodeGenerationSettings data, Dictionary<string, string> replacementsDictionary, _DTE dte)
        {
            string code = null;
            return code;
        }


        public string CreateSpecFlowFeatureCode(CodeGenerationSettings data, Dictionary<string, string> replacementsDictionary, _DTE dte)
        {
            string code = null;
            return code;
        }

        #endregion
    }
}
