using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using VSLangProj;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Xml;

namespace SpecByExample.T4
{
    /// <summary>
    /// Wizard for the Item Template, it shows the Wizard to select the webpage and set the properties for code generation.
    /// Will be invoked when creating a new PageAdapter
    /// </summary>
    public class CreatePageAdapterWizard : IWizard
    {
        // Add items only if the wizard is completed successfully
        private PageInfo settings = null;
        private bool _createSpecFlowFeatureFile = false;
        const string WIZARD_CONFIG_FILENAME = "ControlAdapterMapping.config";

        // Declare a set of variables to remember some values when enterin ProjectItemFinishedGenerating
        private _DTE dte { get; set; }
        private string StepsCode { get; set; }
        private string FeatureCode { get; set; }
        private string PagesProjectName { get; set; }
        private string SpecsProjectName { get; set; }
        private string BasePageName { get; set; }


        #region IWizard implementation

        // This method is called before opening any item that has the OpenInEditor attribute.
        public void BeforeOpeningFile(ProjectItem projectItem) { }
        public void ProjectFinishedGenerating(Project project) { }


        /// <summary>
        /// Main routine of this wizard.
        /// </summary>
        /// <param name="automationObject"></param>
        /// <param name="replacementsDictionary"></param>
        /// <param name="runKind"></param>
        /// <param name="customParams"></param>
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            // Some tasks cannot be done from this routine since we do not yet have all the information.
            // Therefore we need to set some global variables to complete the job in the method ProjectItemFinishedGenerating
            try
            {
                dte = (_DTE)automationObject;
                string rootNamespace = replacementsDictionary[PlaceholdersName.RootNamespace];
                var helper = new ReplacementDictionaryHelper(rootNamespace, replacementsDictionary);
                string vstemplateFile = (string)customParams[0];
                string rootTemplatePath = Path.GetDirectoryName(vstemplateFile);

                // Try to find the Wizard configuration in this project
                string projectFile = dte.GetCurrentProject().FullName;
                string projectDir = Path.GetDirectoryName(projectFile);

                // First check if it's in the Properties directory of the Pages project
                string configFile = Path.Combine(projectDir, "Properties", WIZARD_CONFIG_FILENAME);
                if (!File.Exists(configFile))
                {
                    // If not there: look in the root of the project
                    configFile = Path.Combine(projectDir, WIZARD_CONFIG_FILENAME);
                }

                WizardConfiguration config = null;
                bool localConfigUsed = false;
                if (File.Exists(configFile))
                {
                    config = WizardConfigLoader.LoadWizardConfiguration(configFile);
                    if (config == null)
                    {
                        localConfigUsed = true;
                        string error = String.Format("The wizard could not load the control mapping file in your project:\n{0}\n\nFix it or remove it.", configFile);
                        MessageBox.Show(error, "Error loading wizard configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Try loading the default config.
                if (!localConfigUsed)
                {
                    // Try loading it from the default config file
                    configFile = Path.Combine(rootTemplatePath, WIZARD_CONFIG_FILENAME);
                    config = WizardConfigLoader.LoadWizardConfiguration(configFile);
                    if (config == null)
                    {
                        var error = String.Format("The wizard could not load its default the control mapping file either.\nFix it or reinstall the VSIX package.", configFile);
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
                string safeItemName = replacementsDictionary[PlaceholdersName.SafeItemName];
                var model = PageObjectWizardForm.ShowAndGetData(helper.PageName, safeItemName, config);
                if (model.IsCancelled)
                    throw new WizardCancelledException("Wizard cancelled by the user.");

                // Keep a reference to the page info
                settings = model.PageInfo;
                _createSpecFlowFeatureFile = model.CreateSpecFlowFeatureFile;

                // Make sure all values of the ReplacementDictionary are in the Placeholder property so they will be serialized to file.
                AddReplacementVariablesForTemplates(helper, settings, replacementsDictionary, dte);
                settings.Placeholders.Clear();
                foreach (KeyValuePair<string, string> x in replacementsDictionary)
                {
                    // Only save certain elements as placeholders
                    if (PlaceholdersName.KnownPlaceholders.Contains(x.Key))
                        settings.Placeholders.Add(new Placeholder(x.Key, x.Value));
                }

                replacementsDictionary.Add("$generatedmodel$", settings.SerializeToXml());

                SpecsProjectName = $"{helper.BaseName}.Specs";
                PagesProjectName = $"{helper.BaseName}.Pages";
                BasePageName = helper.PageName;

                if (model.CreateSpecFlowFeatureFile)
                {
                    string t4Template = "SpecFlowFeature.Init.tt";
                    string templateFile = Path.Combine(rootTemplatePath, "T4", t4Template);
                    if (!File.Exists(templateFile))
                        throw new WizardCancelledException($"T4 Template file '{t4Template}' not found in the installer package.\nCheck that the VSIX package is created correctly.");

                    // ==========================================================================
                    // Prepare the FeatureCode variable for use in ProjectItemFinishedGenerating
                    // ==========================================================================
                    string partialFeatureCode = T4Helper.TransformToCode(dte, templateFile, settings);
                    FeatureCode = T4Helper.ReplaceParametersInCode(partialFeatureCode, replacementsDictionary);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Wizard failed with an unexpected error: " + ex.ToString());
                throw new WizardCancelledException("Wizard cancelled due to an exception: " + ex.Message, ex);
            }
        }


        /// <summary>
        /// Post-processing
        /// </summary>
        /// <remarks>Invoked for Item Templates, not for Project Templates.</remarks>
        /// <param name="projectItem"></param>
        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            EnvDTE.Project pagesProject = FindProjectByName(dte.Solution.Projects, PagesProjectName);
            if (pagesProject == null)
                throw new ArgumentOutOfRangeException(String.Format("Project {0} was not found in the solution.", PagesProjectName));

            // Determine the subdirectory within the project
            string fullPagesProjectPath = Path.GetDirectoryName(pagesProject.FullName);
            string fullFilePath = Path.GetDirectoryName(projectItem.Properties.Item("FullPath").Value as string);
            string subdirectory = fullFilePath.Replace(fullPagesProjectPath, "").TrimStart(new char[] { '\\' });

            // Create the Feature file by just adding a new file to the solution.
            if (_createSpecFlowFeatureFile)
            {
                string featureFilename = BasePageName + "Feature.feature";
                var featureFile = CreateNewFileInProject(dte, SpecsProjectName, subdirectory, featureFilename, FeatureCode);

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
        /// This method is called after the project is created.
        /// </summary>
        public void RunFinished()
        {
        }


        /// <summary>
        /// This method is only called for item templates, not for project templates.
        /// </summary>
        /// <param name="filePath">A file that can potentially be added to the solution.</param>
        /// <returns>True to add the file</returns>
        public bool ShouldAddProjectItem(string filePath)
        {
            // Here we exclude files that are part of the Item Template as supportfiles.
            // but not meant to be added to the project. For those files, return false.
            return !(filePath.EndsWith(".tt") || filePath.Equals(WIZARD_CONFIG_FILENAME, StringComparison.InvariantCultureIgnoreCase));
        }

        #endregion


        #region Private helper methods


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
        /// Adds new elements to the replacement dictionary to use in the templates.
        /// </summary>
        /// <param name="settings">Settings to use for the code generation.</param>
        /// <param name="replacementsDictionary">Replacement values</param>
        /// <param name="dte">Reference to the IDE</param>
        public void AddReplacementVariablesForTemplates(ReplacementDictionaryHelper helper, PageInfo settings, Dictionary<string, string> replacementsDictionary, _DTE dte)
        {
            replacementsDictionary[PlaceholdersName.SpecFlowStepsClass] = helper.SpecFlowStepsClassname;
            replacementsDictionary[PlaceholdersName.TargetFilename] = helper.OutputFile;
            replacementsDictionary[PlaceholdersName.RootNamespace] = helper.RootNamespace;
            replacementsDictionary[PlaceholdersName.BasePageclass] = helper.GetPageBaseclass(settings.TypeOfPage);
            replacementsDictionary[PlaceholdersName.Basename] = helper.BaseName;
            if (this.settings.TypeOfPage == PageTemplatesEnum.TablePage)
            {
                replacementsDictionary[PlaceholdersName.EntityName] = settings.TableInfo.EntityName;
                replacementsDictionary[PlaceholdersName.TableControlName] = settings.TableInfo.TableControlName + "Control";
            }
        }

#endregion
    }
}
