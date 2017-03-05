using SpecByExample.T4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpecByExample.WebmodelEditor
{
    /// <summary>
    /// ViewModel for the editor. Wraps the CodeGenerationSettings entity.
    /// </summary>
    public class EditorViewModel : IEditorViewModel, INotifyPropertyChanged
    {
        private readonly PageInfo _settings;
        private bool _createSpecFlowFeatureFile = true;

        /// <summary>
        /// Define a static object to use in case no data is supplied - intended for the designer view only
        /// </summary>
        private static PageInfo staticModel = new PageInfo()
        {
            HtmlRootNodeXPath = "/",
            PageName = "BooPage",
            Url = "http://www.test.com",
            ClassName = "BooClass",
            PageTitle = "BooTitle",
            HtmlElements = new List<HtmlControlInfo>() {
                new HtmlControlInfo() { CodeControlName="MyLink", HtmlId="myLink", HtmlXPath="/html/body/a", HtmlControlType=HtmlControlTypeEnum.Link, HtmlCssClass="toplink red", HtmlTitle="Click me", InnerText="Click me", IdentifiedBy=ControlIdentificationType.Id },
                new HtmlControlInfo() { CodeControlName="SecondLink", HtmlId="secondLink", HtmlXPath="/html/body/a", IdentifiedBy=ControlIdentificationType.LinkText, GenerateCode=true }
            }
        };

        public EditorViewModel() : this(staticModel) { }

        public EditorViewModel(PageInfo settings)
        {
            _settings = settings;

            DesignerDirty = false;
            HtmlControls = HtmlControlViewModel.Load(settings.HtmlElements);
        }

        #region IEditorViewModel


        /// <summary>
        /// List of available control types.
        /// </summary>
        public Dictionary<HtmlControlTypeEnum, string> ControlTypes
        {
            get
            {
                return new Dictionary<HtmlControlTypeEnum, string>()
                {
                    { HtmlControlTypeEnum.Button, "Button" },
                    { HtmlControlTypeEnum.Checkbox, "Checkbox" },
                    { HtmlControlTypeEnum.Div, "Div" },
                    { HtmlControlTypeEnum.Image, "Image" },
                    { HtmlControlTypeEnum.Listbox, "Listbox" },
                    { HtmlControlTypeEnum.Link, "Link" },
                    { HtmlControlTypeEnum.None, "None" },
                    { HtmlControlTypeEnum.Object, "Object" },
                    { HtmlControlTypeEnum.Paragraph, "Paragraph" },
                    { HtmlControlTypeEnum.Radiobutton, "Radio button" },
                    { HtmlControlTypeEnum.Select, "Select" },
                    { HtmlControlTypeEnum.Span, "Span" },
                    { HtmlControlTypeEnum.Table, "Table" },
                    { HtmlControlTypeEnum.Text, "Textbox" },
                    { HtmlControlTypeEnum.Textarea, "Text area" },
                };
            }
        }

        public bool CreateSpecFlowFeatureFile
        {
            get { return _createSpecFlowFeatureFile; }
            set
            {
                if (_createSpecFlowFeatureFile != value)
                {
                    _createSpecFlowFeatureFile = value;
                    DesignerDirty = true;
                }
            }
        }

        public bool CreateSpecFlowStepsFile
        {

            get { return _settings.CreateSpecFlowStepsFile; }
            set
            {
                if (_settings.CreateSpecFlowStepsFile != value)
                {
                    _settings.CreateSpecFlowStepsFile = value;
                    DesignerDirty = true;
                }
            }
        }

        public string HtmlRootNodeXPath
        {

            get { return _settings.HtmlRootNodeXPath; }
            set
            {
                if (_settings.HtmlRootNodeXPath != value)
                {
                    _settings.HtmlRootNodeXPath = value;
                    DesignerDirty = true;
                }
            }
        }

        public string PageName
        {
            get { return _settings.PageName; }
            set
            {
                if (_settings.PageName != value)
                {
                    _settings.PageName = value;
                    DesignerDirty = true;
                }
            }
        }

        public string PageTitle
        {
            get { return _settings.PageName; }
            set
            {
                if (_settings.PageTitle != value)
                {
                    _settings.PageTitle = value;
                    DesignerDirty = true;
                }
            }
        }

        public string ClassName
        {
            get { return _settings.ClassName; }
            set
            {
                if (_settings.ClassName != value)
                {
                    _settings.ClassName = value;
                    DesignerDirty = true;
                }
            }
        }

        public string Url
        {
            get { return _settings.Url; }
            set
            {
                if (_settings.Url != value)
                {
                    _settings.Url = value;
                    DesignerDirty = true;
                }
            }
        }

        /// <summary>
        /// ViewModels for the Html controls.
        /// </summary>
        public IEnumerable<HtmlControlViewModel> HtmlControls
        {
            get;
            private set;
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        /// <summary>
        /// True if changes were made to the model.
        /// </summary>
        public bool DesignerDirty
        {
            get;
            set;
        }

        public event EventHandler ViewModelChanged;

        public void DoIdle() 
        {
            Trace.WriteLine("DoIdle invoked");
        }

        public void OnSelectChanged(object p)
        {
            Trace.WriteLine("OnSelectChanged invoked");
        }
    }
}
