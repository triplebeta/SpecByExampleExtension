/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.XmlEditor;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
using System.Diagnostics;
using VSLangProj;
using System.Text.RegularExpressions;
using System.Text;
using SpecByExample.WebmodelEditor;
using SpecByExample.T4;

namespace Microsoft.VsTemplateDesigner
{
    public class ResourceInfo
    {
        public static string ErrorMessageBoxTitle = "VsTemplateDesigner";
        public static string FieldNameDescription = "Description";
        public static string FieldNameId = "ID";
        public static string InvalidWebmodel = "The webmodel file you are attempting to load is missing the PageInfo";
        public static string SynchronizeBuffer = "Synchronize XML file with view";
        public static string ReformatBuffer = "Reformat";
        public static string ValidationFieldMaxLength = "{0} must be {1} characters or less.";
        public static string ValidationRequiredField = "{0} is a required value.";
    }

    /// <summary>
    /// ViewModel is where the interesting portion of the VsTemplate Designer lives. The View binds to an instance of this class.
    /// 
    /// The View binds the various designer controls to the methods derived from IViewModel that get and set values in the XmlModel.
    /// The ViewModel and an underlying XmlModel manage how an IVsTextBuffer is shared between the designer and the XML editor (if opened).
    /// </summary>
    public class ViewModel : IViewModel, IDataErrorInfo, INotifyPropertyChanged
    {
        const int MaxIdLength = 100;
        const int MaxProductNameLength = 60;
        const int MaxDescriptionLength = 1024;

        XmlModel _xmlModel;
        XmlStore _xmlStore;
        CodeGenerationSettings _webModel;

        IServiceProvider _serviceProvider;
        IVsTextLines _buffer;

        bool _synchronizing;
        long _dirtyTime;
        EventHandler<XmlEditingScopeEventArgs> _editingScopeCompletedHandler;
        EventHandler<XmlEditingScopeEventArgs> _undoRedoCompletedHandler;
        EventHandler _bufferReloadedHandler;

        LanguageService _xmlLanguageService;

        public ViewModel(XmlStore xmlStore, XmlModel xmlModel, IServiceProvider provider, IVsTextLines buffer)
        {
            if (xmlModel == null)
                throw new ArgumentNullException("xmlModel");
            if (xmlStore == null)
                throw new ArgumentNullException("xmlStore");
            if (provider == null)
                throw new ArgumentNullException("provider");
            if (buffer == null)
                throw new ArgumentNullException("buffer");

            BufferDirty = false;
            DesignerDirty = false;

            _serviceProvider = provider;
            _buffer = buffer;

            _xmlStore = xmlStore;
            // OnUnderlyingEditCompleted
            _editingScopeCompletedHandler = new EventHandler<XmlEditingScopeEventArgs>(OnUnderlyingEditCompleted);
            _xmlStore.EditingScopeCompleted += _editingScopeCompletedHandler;
            // OnUndoRedoCompleted
            _undoRedoCompletedHandler = new EventHandler<XmlEditingScopeEventArgs>(OnUndoRedoCompleted);
            _xmlStore.UndoRedoCompleted += _undoRedoCompletedHandler;

            _xmlModel = xmlModel;
            // BufferReloaded
            _bufferReloadedHandler += new EventHandler(BufferReloaded);
            _xmlModel.BufferReloaded += _bufferReloadedHandler;

            LoadModelFromXmlModel();
        }

        public void Close()
        {
            //Unhook the events from the underlying XmlStore/XmlModel
            if (_xmlStore != null)
            {
                _xmlStore.EditingScopeCompleted -= _editingScopeCompletedHandler;
                _xmlStore.UndoRedoCompleted -= _undoRedoCompletedHandler;
            }
            if (_xmlModel != null)
            {
                _xmlModel.BufferReloaded -= _bufferReloadedHandler;
            }
        }

        /// <summary>
        /// Property indicating if there is a pending change in the underlying text buffer
        /// that needs to be reflected in the ViewModel.
        /// 
        /// Used by DoIdle to determine if we need to sync.
        /// </summary>
        bool BufferDirty
        {
            get;
            set;
        }

        /// <summary>
        /// Property indicating if there is a pending change in the ViewModel that needs to 
        /// be committed to the underlying text buffer.
        /// 
        /// Used by DoIdle to determine if we need to sync.
        /// </summary>
        public bool DesignerDirty
        {
            get;
            set;
        }

        /// <summary>
        /// We must not try and update the XDocument while the XML Editor is parsing as this may cause
        /// a deadlock in the XML Editor!
        /// </summary>
        /// <returns></returns>
        bool IsXmlEditorParsing
        {
            get
            {
                LanguageService langsvc = GetXmlLanguageService();
                return langsvc != null ? langsvc.IsParsing : false;
            }
        }

        /// <summary>
        /// Called on idle time. This is when we check if the designer is out of sync with the underlying text buffer.
        /// </summary>
        public void DoIdle()
        {
            if (BufferDirty || DesignerDirty)
            {
                int delay = 100;

                if ((Environment.TickCount - _dirtyTime) > delay)
                {
                    // Must not try and sync while XML editor is parsing otherwise we just confuse matters.
                    if (IsXmlEditorParsing)
                    {
                        _dirtyTime = Environment.TickCount;
                        return;
                    }

                    //If there is contention, give the preference to the designer.
                    if (DesignerDirty)
                    {
                        SaveModelToXmlModel(ResourceInfo.SynchronizeBuffer);
                        //We don't do any merging, so just overwrite whatever was in the buffer.
                        BufferDirty = false;
                    }
                    else if (BufferDirty)
                    {
                        LoadModelFromXmlModel();
                    }
                }
            }
        }

        /// <summary>
        /// Load the model from the underlying text buffer.
        /// </summary>
        private void LoadModelFromXmlModel()
        {
            try
            {
                // Load the model
                XmlSerializer deserializer = new XmlSerializer(typeof(CodeGenerationSettings));
                XmlReader textReader = GetParseTree().CreateReader();
                _webModel = (CodeGenerationSettings)deserializer.Deserialize(textReader);
                textReader.Close();
            }
            catch (Exception e)
            {
                //Display error message
                ErrorHandler.ThrowOnFailure(VsShellUtilities.ShowMessageBox(_serviceProvider,
                    ResourceInfo.InvalidWebmodel + e.Message,
                    ResourceInfo.ErrorMessageBoxTitle,
                    OLEMSGICON.OLEMSGICON_CRITICAL,
                    OLEMSGBUTTON.OLEMSGBUTTON_OK,
                    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST));
            }

            BufferDirty = false;

            if (ViewModelChanged != null)
            {
                // Update the Designer View
                ViewModelChanged(this, new EventArgs());
            }
        }


        /// <summary>
        /// Get an up to date XML parse tree from the XML Editor.
        /// </summary>
        XDocument GetParseTree()
        {
            LanguageService langsvc = GetXmlLanguageService();

            // don't crash if the language service is not available
            if (langsvc != null)
            {
                Source src = langsvc.GetSource(_buffer);

                // We need to access this method to get the most up to date parse tree.
                // public virtual XmlDocument GetParseTree(Source source, IVsTextView view, int line, int col, ParseReason reason) {
                MethodInfo mi = langsvc.GetType().GetMethod("GetParseTree");
                int line = 0, col = 0;
                mi.Invoke(langsvc, new object[] { src, null, line, col, ParseReason.Check });
            }

            // Now the XmlDocument should be up to date also.
            return _xmlModel.Document;
        }

        /// <summary>
        /// Get the XML Editor language service
        /// </summary>
        /// <returns></returns>
        LanguageService GetXmlLanguageService()
        {
            if (_xmlLanguageService == null)
            {
                IOleServiceProvider vssp = _serviceProvider.GetService(typeof(IOleServiceProvider)) as IOleServiceProvider;
                Guid xmlEditorGuid = new Guid("f6819a78-a205-47b5-be1c-675b3c7f0b8e");
                Guid iunknown = new Guid("00000000-0000-0000-C000-000000000046");
                IntPtr ptr;
                if (ErrorHandler.Succeeded(vssp.QueryService(ref xmlEditorGuid, ref iunknown, out ptr)))
                {
                    try
                    {
                        _xmlLanguageService = Marshal.GetObjectForIUnknown(ptr) as LanguageService;
                    }
                    finally
                    {
                        Marshal.Release(ptr);
                    }
                }
            }
            return _xmlLanguageService;
        }

        /// <summary>
        /// Reformat the text buffer
        /// </summary>
        void FormatBuffer(Source src)
        {
            using (EditArray edits = new EditArray(src, null, false, ResourceInfo.ReformatBuffer))
            {
                TextSpan span = src.GetDocumentSpan();
                src.ReformatSpan(edits, span);
            }
        }

        /// <summary>
        /// Get the XML Editor Source object for this document.
        /// </summary>
        /// <returns></returns>
        Source GetSource()
        {
            LanguageService langsvc = GetXmlLanguageService();
            if (langsvc == null)
            {
                return null;
            }
            Source src = langsvc.GetSource(_buffer);
            return src;
        }

        /// <summary>
        /// This method is called when it is time to save the designer values to the
        /// underlying buffer.
        /// </summary>
        /// <param name="undoEntry"></param>
        void SaveModelToXmlModel(string undoEntry)
        {
            LanguageService langsvc = GetXmlLanguageService();

            try
            {
                //We can't edit this file (perhaps the user cancelled a SCC prompt, etc...)
                if (!CanEditFile())
                {
                    DesignerDirty = false;
                    BufferDirty = true;
                    throw new Exception();
                }

                //PopulateModelFromReferencesBindingList();
                //PopulateModelFromContentBindingList();

                XmlSerializer serializer = new XmlSerializer(typeof(CodeGenerationSettings));
                XDocument documentFromDesignerState = new XDocument();
                using (XmlWriter w = documentFromDesignerState.CreateWriter())
                {
                    serializer.Serialize(w, _webModel);
                }

                _synchronizing = true;
                XDocument document = GetParseTree();
                Source src = GetSource();
                if (src == null || langsvc == null)
                {
                    return;
                }

                langsvc.IsParsing = true; // lock out the background parse thread.

                // Wrap the buffer sync and the formatting in one undo unit.
                using (CompoundAction ca = new CompoundAction(src, ResourceInfo.SynchronizeBuffer))
                {
                    using (XmlEditingScope scope = _xmlStore.BeginEditingScope(ResourceInfo.SynchronizeBuffer, this))
                    {
                        //Replace the existing XDocument with the new one we just generated.
                        document.Root.ReplaceWith(documentFromDesignerState.Root);
                        scope.Complete();
                    }
                    ca.FlushEditActions();
                    FormatBuffer(src);
                }
                DesignerDirty = false;
            }
            catch (Exception)
            {
                // if the synchronization fails then we'll just try again in a second.
                _dirtyTime = Environment.TickCount;
            }
            finally
            {
                langsvc.IsParsing = false;
                _synchronizing = false;
            }
        }

        /// <summary>
        /// Fired when all controls should be re-bound.
        /// </summary>
        public event EventHandler ViewModelChanged;

        private void BufferReloaded(object sender, EventArgs e)
        {
            if (!_synchronizing)
            {
                BufferDirty = true;
                _dirtyTime = Environment.TickCount;
            }
        }

        /// <summary>
        /// Handle undo/redo completion event.  This happens when the user invokes Undo/Redo on a buffer edit operation.
        /// We need to resync when this happens.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnUndoRedoCompleted(object sender, XmlEditingScopeEventArgs e)
        {
            if (!_synchronizing)
            {
                BufferDirty = true;
                _dirtyTime = Environment.TickCount;
            }
        }

        /// <summary>
        /// Handle edit scope completion event.  This happens when the XML editor buffer decides to update
        /// it's XDocument parse tree.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnUnderlyingEditCompleted(object sender, XmlEditingScopeEventArgs e)
        {
            if (e.EditingScope.UserState != this && !_synchronizing)
            {
                BufferDirty = true;
                _dirtyTime = Environment.TickCount;
            }
        }

        #region Source Control

        bool? _canEditFile;
        bool _gettingCheckoutStatus;

        /// <summary>
        /// This function asks the QueryEditQuerySave service if it is possible to edit the file.
        /// This can result in an automatic checkout of the file and may even prompt the user for
        /// permission to checkout the file.  If the user says no or the file cannot be edited 
        /// this returns false.
        /// </summary>
        private bool CanEditFile()
        {
            // Cache the value so we don't keep asking the user over and over.
            if (_canEditFile.HasValue)
            {
                return (bool)_canEditFile;
            }

            // Check the status of the recursion guard
            if (_gettingCheckoutStatus)
                return false;

            _canEditFile = false; // assume the worst
            try
            {
                // Set the recursion guard
                _gettingCheckoutStatus = true;

                // Get the QueryEditQuerySave service
                IVsQueryEditQuerySave2 queryEditQuerySave = _serviceProvider.GetService(typeof(SVsQueryEditQuerySave)) as IVsQueryEditQuerySave2;

                string filename = _xmlModel.Name;

                // Now call the QueryEdit method to find the edit status of this file
                string[] documents = { filename };
                uint result;
                uint outFlags;

                // Note that this function can popup a dialog to ask the user to checkout the file.
                // When this dialog is visible, it is possible to receive other request to change
                // the file and this is the reason for the recursion guard
                int hr = queryEditQuerySave.QueryEditFiles(
                    0,              // Flags
                    1,              // Number of elements in the array
                    documents,      // Files to edit
                    null,           // Input flags
                    null,           // Input array of VSQEQS_FILE_ATTRIBUTE_DATA
                    out result,     // result of the checkout
                    out outFlags    // Additional flags
                );
                if (ErrorHandler.Succeeded(hr) && (result == (uint)tagVSQueryEditResult.QER_EditOK))
                {
                    // In this case (and only in this case) we can return true from this function
                    _canEditFile = true;
                }
            }
            finally
            {
                _gettingCheckoutStatus = false;
            }
            return (bool)_canEditFile;
        }

        #endregion
#if DEPRECATED
        #region IViewModel methods

        public VSTemplateTemplateData TemplateData
        {
            get
            {
                return _webModel.TemplateData;
            }
        }

        public VSTemplateTemplateContent TemplateContent
        {
            get
            {
                return _webModel.TemplateContent;
            }
        }

        public string TemplateID
        {
            get
            {
                return _webModel.TemplateData.TemplateID;
            }
            set
            {
                if (_webModel.TemplateData.TemplateID != value)
                {
                    _webModel.TemplateData.TemplateID = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("TemplateID");
                }
            }
        }

        public string Name
        {
            get
            {
                if (!IsNameEnabled)
                {
                    return _webModel.TemplateData.Name.Package + " " + _webModel.TemplateData.Name.ID;
                }
                return _webModel.TemplateData.Name.Value;
            }
            set
            {
                if (_webModel.TemplateData.Name.Value != value)
                {
                    _webModel.TemplateData.Name.Value = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public bool IsNameEnabled
        {
            get
            {
                // only enable if not associated with a package (guid)
                return string.IsNullOrEmpty(_webModel.TemplateData.Name.Package);
            }
        }

        public string Description
        {
            get
            {
                if (!IsDescriptionEnabled)
                {
                    return _webModel.TemplateData.Description.Package + " " + _webModel.TemplateData.Description.ID;
                }
                return _webModel.TemplateData.Description.Value;
            }
            set
            {
                if (_webModel.TemplateData.Description.Value != value)
                {
                    _webModel.TemplateData.Description.Value = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        public bool IsDescriptionEnabled
        {
            get
            {
                // only enable if not associated with a package (guid)
                return string.IsNullOrEmpty(_webModel.TemplateData.Description.Package);
            }
        }

        public string Icon
        {
            get
            {
                if (!IsIconEnabled)
                {
                    return _webModel.TemplateData.Icon.Package + " " + _webModel.TemplateData.Icon.ID;
                }
                return _webModel.TemplateData.Icon.Value;
            }
            set
            {
                if (_webModel.TemplateData.Icon.Value != value)
                {
                    _webModel.TemplateData.Icon.Value = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("Icon");
                }
            }
        }

        public bool IsIconEnabled
        {
            get
            {
                // only enable if not associated with a package (guid)
                return string.IsNullOrEmpty(_webModel.TemplateData.Icon.Package);
            }
        }


        public string PreviewImage
        {
            get
            {
                return _webModel.TemplateData.PreviewImage;
            }
            set
            {
                if (_webModel.TemplateData.PreviewImage != value)
                {
                    _webModel.TemplateData.PreviewImage = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("PreviewImage");
                }
            }
        }

        public string ProjectType
        {
            get
            {
                return _webModel.TemplateData.ProjectType;
            }
            set
            {
                if (_webModel.TemplateData.ProjectType != value)
                {
                    _webModel.TemplateData.ProjectType = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("ProjectType");
                }
            }
        }

        public string ProjectSubType
        {
            get
            {
                return _webModel.TemplateData.ProjectSubType;
            }
            set
            {
                if (_webModel.TemplateData.ProjectSubType != value)
                {
                    _webModel.TemplateData.ProjectSubType = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("ProjectSubType");
                }
            }
        }

        public string DefaultName
        {
            get
            {
                return _webModel.TemplateData.DefaultName;
            }
            set
            {
                if (_webModel.TemplateData.DefaultName != value)
                {
                    _webModel.TemplateData.DefaultName = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("DefaultName");
                }
            }
        }

        public string GroupID
        {
            get
            {
                return _webModel.TemplateData.TemplateGroupID;
            }
            set
            {
                if (_webModel.TemplateData.TemplateGroupID != value)
                {
                    _webModel.TemplateData.TemplateGroupID = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("TemplateGroupID");
                }
            }
        }

        public string SortOrder
        {
            get
            {
                return _webModel.TemplateData.SortOrder;
            }
            set
            {
                if (_webModel.TemplateData.SortOrder != value)
                {
                    _webModel.TemplateData.SortOrder = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("SortOrder");
                }
            }
        }

        public string LocationFieldMRUPrefix
        {
            get
            {
                return _webModel.TemplateData.LocationFieldMRUPrefix;
            }
            set
            {
                if (_webModel.TemplateData.LocationFieldMRUPrefix != value)
                {
                    _webModel.TemplateData.LocationFieldMRUPrefix = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("LocationFieldMRUPrefix");
                }
            }
        }

        public bool ProvideDefaultName
        {
            get
            {
                return _webModel.TemplateData.ProvideDefaultName;
            }
            set
            {
                if (_webModel.TemplateData.ProvideDefaultName != value)
                {
                    // if we don't make sure the XML model knows this value is specified,
                    // it won't save it (and it will get reset the next time we read the model)
                    _webModel.TemplateData.ProvideDefaultNameSpecified = true;
                    _webModel.TemplateData.ProvideDefaultName = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("ProvideDefaultName");
                }
            }
        }

        public bool CreateNewFolder
        {
            get
            {
                return _webModel.TemplateData.CreateNewFolder;
            }
            set
            {
                if (_webModel.TemplateData.CreateNewFolder != value)
                {
                    // if we don't make sure the XML model knows this value is specified,
                    // it won't save it (and it will get reset the next time we read the model)
                    _webModel.TemplateData.CreateNewFolderSpecified = true;
                    _webModel.TemplateData.CreateNewFolder = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("CreateNewFolder");
                }
            }
        }

        public bool PromptForSaveOnCreation
        {
            get
            {
                return _webModel.TemplateData.PromptForSaveOnCreation;
            }
            set
            {
                if (_webModel.TemplateData.PromptForSaveOnCreation != value)
                {
                    // if we don't make sure the XML model knows this value is specified,
                    // it won't save it (and it will get reset the next time we read the model)
                    _webModel.TemplateData.PromptForSaveOnCreationSpecified = true;
                    _webModel.TemplateData.PromptForSaveOnCreation = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("PromptForSaveOnCreation");
                }
            }
        }

        public bool Hidden
        {
            get
            {
                return _webModel.TemplateData.Hidden;
            }
            set
            {
                if (_webModel.TemplateData.Hidden != value)
                {
                    // if we don't make sure the XML model knows this value is specified,
                    // it won't save it (and it will get reset the next time we read the model)
                    _webModel.TemplateData.HiddenSpecified = true;
                    _webModel.TemplateData.Hidden = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("Hidden");
                }
            }
        }

        public bool SupportsMasterPage
        {
            get
            {
                return _webModel.TemplateData.SupportsMasterPage;
            }
            set
            {
                if (_webModel.TemplateData.SupportsMasterPage != value)
                {
                    // if we don't make sure the XML model knows this value is specified,
                    // it won't save it (and it will get reset the next time we read the model)
                    _webModel.TemplateData.SupportsMasterPageSpecified = true;
                    _webModel.TemplateData.SupportsMasterPage = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("SupportsMasterPage");
                }
            }
        }

        public bool SupportsCodeSeparation
        {
            get
            {
                return _webModel.TemplateData.SupportsCodeSeparation;
            }
            set
            {
                if (_webModel.TemplateData.SupportsCodeSeparation != value)
                {
                    // if we don't make sure the XML model knows this value is specified,
                    // it won't save it (and it will get reset the next time we read the model)
                    _webModel.TemplateData.SupportsCodeSeparationSpecified = true;
                    _webModel.TemplateData.SupportsCodeSeparation = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("SupportsCodeSeparation");
                }
            }
        }

        public bool SupportsLanguageDropDown
        {
            get
            {
                return _webModel.TemplateData.SupportsLanguageDropDown;
            }
            set
            {
                if (_webModel.TemplateData.SupportsLanguageDropDown != value)
                {
                    // if we don't make sure the XML model knows this value is specified,
                    // it won't save it (and it will get reset the next time we read the model)
                    _webModel.TemplateData.SupportsLanguageDropDownSpecified = true;
                    _webModel.TemplateData.SupportsLanguageDropDown = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("SupportsLanguageDropDown");
                }
            }
        }

        public bool IsLocationFieldSpecified
        {
            get
            {
                return _webModel.TemplateData.LocationFieldSpecified;
            }
        }

        public VSTemplateTemplateDataLocationField LocationField
        {
            get
            {
                return _webModel.TemplateData.LocationField;
            }
            set
            {
                if (_webModel.TemplateData.LocationField != value)
                {
                    // if we don't make sure the XML model knows this value is specified,
                    // it won't save it (and it will get reset the next time we read the model)
                    _webModel.TemplateData.LocationFieldSpecified = true;
                    _webModel.TemplateData.LocationField = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("LocationField");
                }
            }
        }

        public string WizardAssembly
        {
            get
            {
                if ((_webModel.WizardExtension != null) && (_webModel.WizardExtension.Count() == 1) && (_webModel.WizardExtension[0].Assembly.Count() == 1))
                {
                    return _webModel.WizardExtension[0].Assembly[0] as string;
                }
                return null;
            }
            set
            {
                // intentionally not implemented until the correct behavior is determined
            }
        }

        public string WizardClassName
        {
            get
            {
                if ((_webModel.WizardExtension != null) && (_webModel.WizardExtension.Count() == 1) && (_webModel.WizardExtension[0].FullClassName.Count() == 1))
                {
                    return _webModel.WizardExtension[0].FullClassName[0] as string;
                }
                return null;
            }
            set
            {
                // intentionally not implemented until the correct behavior is determined
            }
        }

        public string WizardData
        {
            get
            {
                string result = "";
                if (_webModel.WizardData == null)
                {
                    return result;
                }
                foreach (var wizData in _webModel.WizardData)
                {
                    foreach (var xmlItem in wizData.Any)
                    {
                        result += xmlItem;
                    }
                }
                return result;
            }
            set
            {
                // intentionally not implemented until the correct behavior is determined
            }
        }

        #endregion
#endif

        #region IViewModel methods

        public string PageName
        {
            get { return _webModel.PageName; }
            set
            {
                if (_webModel.PageName != value)
                {
                    _webModel.PageName = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("PageName");
                }
            }
        }

        public string Url
        {
            get { return _webModel.Url; }
            set
            {
                if (_webModel.Url != value)
                {
                    _webModel.Url = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("Url");
                }
            }
        }

        public string HtmlRootNodeXPath
        {
            get { return _webModel.HtmlRootNodeXPath; }
            set
            {
                if (_webModel.HtmlRootNodeXPath != value)
                {
                    _webModel.HtmlRootNodeXPath = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("HtmlRootNodeXPath");
                }
            }
        }


        public bool CreateSpecFlowStepsFile
        {
            get { return _webModel.CreateSpecFlowStepsFile; }
            set
            {
                if (_webModel.CreateSpecFlowStepsFile != value)
                {
                    _webModel.CreateSpecFlowStepsFile = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("CreateSpecFlowStepsFile");
                }
            }
        }

        public bool CreateSpecFlowFeatureFile
        {
            get { return _webModel.CreateSpecFlowFeatureFile; }
            set
            {
                if (_webModel.CreateSpecFlowFeatureFile != value)
                {
                    _webModel.CreateSpecFlowFeatureFile = value;
                    DesignerDirty = true;
                    NotifyPropertyChanged("CreateSpecFlowFeatureFile");
                }
            }
        }

        public PageInfo PageInfo
        {
            get { return _webModel.PageInfo; }
        }
        #endregion

        #region IDataErrorInfo
        public string Error
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public string this[string columnName]
            {
                get
                {
                    string error = null;
                    switch (columnName)
                    {
                        case "ID":
                            error = ValidateId();
                            break;
                        case "Description":
                            error = ValidateDescription();
                            break;
                    }
                    return error;
                }
            }

            private string ValidateId()
            {
                // TODO Implement validation
                //if (string.IsNullOrEmpty(TemplateID))
                //{
                //    return string.Format(ResourceInfo.ValidationRequiredField, ResourceInfo.FieldNameId);
                //}
                //if (TemplateID.Length > MaxIdLength)
                //{
                //    return string.Format(ResourceInfo.ValidationFieldMaxLength, ResourceInfo.FieldNameId, MaxIdLength);
                //}
                return null;
            }

            private string ValidateDescription()
            {
            // TODO Implement validation
                //if (string.IsNullOrEmpty(Description))
                //{
                //    return string.Format(ResourceInfo.ValidationRequiredField, ResourceInfo.FieldNameDescription);
                //}
                //if (Description.Length > MaxDescriptionLength)
                //{
                //    return string.Format(ResourceInfo.ValidationFieldMaxLength, ResourceInfo.FieldNameDescription, MaxDescriptionLength);
                //}
                return null;
            }


    #endregion

        #region INotifyPropertyChanged

                public event PropertyChangedEventHandler PropertyChanged;

                protected void NotifyPropertyChanged(string propertyName)
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    }
                }

        #endregion

        #region TreeView SelectionChanged

                private ITrackSelection trackSel;
                private ITrackSelection TrackSelection
                {
                    get
                    {
                        if (trackSel == null)
                            trackSel = _serviceProvider.GetService(typeof(STrackSelection)) as ITrackSelection;
                        return trackSel;
                    }
                }

                private Microsoft.VisualStudio.Shell.SelectionContainer selContainer;
                public void OnSelectChanged(object p)
                {
                    selContainer = new VisualStudio.Shell.SelectionContainer(true, false);
                    ArrayList items = new ArrayList();
                    items.Add(p);
                    selContainer.SelectableObjects = items;
                    selContainer.SelectedObjects = items;

                    ITrackSelection track = TrackSelection;
                    if (track != null)
                        track.OnSelectChange(selContainer);
                }

        #endregion
    }    
}
