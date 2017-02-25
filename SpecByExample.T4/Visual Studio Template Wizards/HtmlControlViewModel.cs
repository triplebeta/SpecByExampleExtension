using SpecByExample.T4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpecByExample.T4
{
    /// <summary>
    /// ViewModel to display one HTML control in the list of controls
    /// </summary>
    public class HtmlControlViewModel : INotifyPropertyChanged
    {
        public readonly HtmlControlInfo ControlInfo;

        public HtmlControlViewModel(HtmlControlInfo control)
        {
            ControlInfo = control;
        }

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
        /// Wrap each control in a ViewModel.
        /// </summary>
        public static IEnumerable<HtmlControlViewModel> Load(IEnumerable<HtmlControlInfo> controls)
        {
            var list = new List<HtmlControlViewModel>();
            foreach (var c in controls)
                list.Add(new T4.HtmlControlViewModel(c));
            return list;
        }

        #region Helpers to display data on the screen

        /// <summary>
        /// Name of the control - a user friendly name that helps to identify which control it is
        /// </summary>
        public string DisplayName
        {
            get
            {
                // Prefer a more user friendly one over a technical value
                if (!String.IsNullOrWhiteSpace(ControlInfo.InnerText)) return ControlInfo.InnerText;
                if (!String.IsNullOrWhiteSpace(ControlInfo.HtmlTitle)) return ControlInfo.HtmlTitle;
                if (!String.IsNullOrWhiteSpace(ControlInfo.HtmlName)) return ControlInfo.HtmlName;
                return ControlInfo.HtmlId;
            }
        }

        /// <summary>
        /// Used to display the identification enum.
        /// </summary>
        public string IdentifiedByDescription
        {
            get
            {
                switch (ControlInfo.IdentifiedBy)
                {
                    case ControlIdentificationType.Id: return $"id = {ControlInfo.HtmlId}";
                    case ControlIdentificationType.Cssclass: return $"style = {ControlInfo.HtmlCssClass}";
                    case ControlIdentificationType.LinkText:
                        if (!String.IsNullOrWhiteSpace(ControlInfo.InnerText)) return $"link text = {ControlInfo.InnerText}";
                        return $"link text = {ControlInfo.HtmlTitle}";
                    case ControlIdentificationType.Name: return $"name = {ControlInfo.HtmlName}";
                    default: return $"XPath expression: {ControlInfo.HtmlXPath}";
                }
            }
        }

        /// <summary>
        /// Used to display the control type enum.
        /// </summary>
        public string ControlTypeDescription
        {
            get { return ControlInfo.HtmlControlType.ToString(); }
        }


        /// <summary>
        /// A FontAwesome icon representing the type of control
        /// </summary>
        public char ControlTypeImage
        {
            get
            {
                switch (ControlInfo.HtmlControlType)
                {
                    case HtmlControlTypeEnum.Link: return '\uf0c1'; // fa-link
                    case HtmlControlTypeEnum.Button: return '\uf152'; // caret-square-o-right
                    case HtmlControlTypeEnum.Checkbox: return '\uf046'; // check-square-o
                    case HtmlControlTypeEnum.Div: return '\uf046';  // square-o
                    case HtmlControlTypeEnum.Image: return '\uf1c5'; // file-picture-o'
                    case HtmlControlTypeEnum.Listbox: return '\uf0ca'; //list-ul
                    case HtmlControlTypeEnum.Object: return '\uf247'; // object-group
                    case HtmlControlTypeEnum.Paragraph: return '\uf1dd'; // paragraph
                    case HtmlControlTypeEnum.Radiobutton: return '\uf192'; //  dot-circle-o
                    case HtmlControlTypeEnum.Select: return '\uf044'; // edit
                    case HtmlControlTypeEnum.Span: return '\uf121'; //code
                    case HtmlControlTypeEnum.Table: return '\uf0ce'; // table
                    case HtmlControlTypeEnum.Text: return '\uf031'; //font
                    case HtmlControlTypeEnum.Textarea: return '\uf039'; //  align-justify
                    default: return '\uf15b'; // file
                }
            }
        }

        #endregion

        /// <summary>
        /// Name of the property.
        /// </summary>
        public string ControlName
        {
            get { return ControlInfo.CodeControlName; }
            set {
                ControlInfo.CodeControlName = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Type of Control to wrap this HTML element into.
        /// </summary>
        public HtmlControlTypeEnum ControlType
        {
            get { return ControlInfo.HtmlControlType; }
            set
            {
                ControlInfo.HtmlControlType = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("ControlTypeDescription");
            }
        }

        public bool GenerateCodeForThisItem
        {
            get { return ControlInfo.GenerateCodeForThisItem; }
            set { ControlInfo.GenerateCodeForThisItem = value; }
        }

        /// <summary>
        /// XPath expression to find the control.
        /// </summary>
        public string XPath
        {
            get { return ControlInfo.HtmlXPath; }
            set { ControlInfo.HtmlXPath = value; }
        }

        #region Attributes found for the HTML item wrapped by this control.

        /// <summary>
        /// Text of the control.
        /// </summary>
        public string InnerHtml
        {
            get { return ControlInfo.InnerText; }
            set { ControlInfo.InnerText = value; }
        }

        /// <summary>
        /// Id 
        /// </summary>
        public string HtmlId
        {
            get { return ControlInfo.HtmlId; }
            set { ControlInfo.HtmlId = value; }
        }

        /// <summary>
        /// Name 
        /// </summary>
        public string HtmlName
        {
            get { return ControlInfo.HtmlName; }
            set { ControlInfo.HtmlName = value; }
        }

        /// <summary>
        /// CSS class 
        /// </summary>
        public string HtmlCssClass
        {
            get { return ControlInfo.HtmlCssClass; }
            set { ControlInfo.HtmlCssClass = value; }
        }

        /// <summary>
        /// Title 
        /// </summary>
        public string HtmlTitle
        {
            get { return ControlInfo.HtmlTitle; }
            set { ControlInfo.HtmlTitle = value; }
        }

        #endregion
    }
}
