/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using SpecByExample.T4;

namespace SpecByExample.WebmodelEditor
{
    public interface IViewModel
    {
        string PageName { get; set; }
        string Url { get; set; }
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
    }
}