/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Globalization;
using SpecByExample.T4;

namespace SpecByExample.WebmodelEditor
{
    public interface IViewModel
    {
        string PageName { get; set; }
        string Url { get; set; }
        string ApplicationModule { get; set; }
        string HtmlRootNodeXPath { get; set; }

        bool CreateSpecFlowStepsFile { get; set; }
        bool CreateSpecFlowFeatureFile { get; set; }

        PageInfo PageInfo { get; }

        // The following fields are probably required just to make the editor work, not for editing the content of the file
        bool DesignerDirty { get; set; }

        event EventHandler ViewModelChanged;
        void DoIdle();
        void Close();

        void OnSelectChanged(object p);

#if DEPRECATED
        VSTemplateTemplateData TemplateData { get; }
        VSTemplateTemplateContent TemplateContent { get; }

        string Name { get; set; }
        string Description { get; set; }
        string Icon { get; set; }
        string ProjectType { get; set; }
        string ProjectSubType { get; set; }
        string DefaultName { get; set; }
        string TemplateID { get; set; }
        string GroupID { get; set; }
        string SortOrder { get; set; }
        VSTemplateTemplateDataLocationField LocationField { get; set; }
        string LocationFieldMRUPrefix { get; set; }
        string PreviewImage { get; set; }
        string WizardAssembly { get; set; }
        string WizardClassName { get; set; }
        string WizardData { get; set; }

        bool ProvideDefaultName { get; set; }
        bool CreateNewFolder { get; set; }
        bool PromptForSaveOnCreation { get; set; }
        bool Hidden { get; set; }
        bool SupportsMasterPage { get; set; }
        bool SupportsCodeSeparation { get; set; }
        bool SupportsLanguageDropDown { get; set; }

        bool DesignerDirty { get; set; }
        bool IsNameEnabled { get; }
        bool IsDescriptionEnabled { get; }
        bool IsIconEnabled { get; }
        bool IsLocationFieldSpecified { get; }
        
        event EventHandler ViewModelChanged;
        void DoIdle();
        void Close();

        void OnSelectChanged(object p);
#endif
    }
}