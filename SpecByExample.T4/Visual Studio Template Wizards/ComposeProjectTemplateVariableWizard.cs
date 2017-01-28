using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TemplateWizard;
using EnvDTE;

namespace SpecByExample.T4
{
    /// <summary>
    /// This wizard has no UI and is used as a helper to create the Project Templates.
    /// It adds some custom-defined variables to the context of the Project Template so we can use those to compose filenames.
    /// </summary>
    public class ComposeProjectTemplateVariableWizard : IWizard
    {
        // This method is called before opening any item that 
        // has the OpenInEditor attribute.
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
        }

        // This method is called after the project is created.
        public void RunFinished()
        {
        }


        /// <summary>
        ///  Create extra variables to use in the templates
        /// </summary>
        /// <param name="automationObject"></param>
        /// <param name="replacementsDictionary"></param>
        /// <param name="runKind"></param>
        /// <param name="customParams"></param>
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            // Get the full name
            var safeProjectName = replacementsDictionary["$safeprojectname$"];

            // Remove the last part of the name
            string rootname = null;
            if (safeProjectName.Contains("."))
            {
                var pos = safeProjectName.LastIndexOf('.');
                if (pos > 0)
                    rootname = safeProjectName.Substring(0, pos);
            }

            var helper = new ReplacementDictionaryHelper((_DTE)automationObject, replacementsDictionary);
            replacementsDictionary["$rootname$"] = rootname ?? safeProjectName;
            replacementsDictionary["$basename$"] = helper.BaseName;
        }


        // This method is only called for item templates, not for project templates.
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

    }
}
