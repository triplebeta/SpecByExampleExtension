/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using SpecByExample.T4;
using System.Collections.Generic;

namespace SpecByExample.WebmodelEditor
{
    /// <summary>
    /// Model for the Editor
    /// </summary>
    public interface IEditorViewModel : ICodeGenerationSettings
    {
        Dictionary<HtmlControlTypeEnum, string> ControlTypes { get; }

        // The following fields are probably required just to make the editor work, not for editing the content of the file
        bool DesignerDirty { get; set; }

        event EventHandler ViewModelChanged;

        void DoIdle();

        void OnSelectChanged(object p);
    }
}