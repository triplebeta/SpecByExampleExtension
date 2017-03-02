using Microsoft.Win32;
using SpecByExample.T4;
using SpecByExample.WebmodelEditor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WebmodelEditorTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private PageInfo InternalModel;

        public IEditorViewModel ViewModel { get; set; }

        private void Window_Initialized(object sender, EventArgs e)
        {
            // If file passed on commandline: load it. If not: load a static default model.
            var args = Environment.GetCommandLineArgs();
            if (args.Length == 2 && File.Exists(args[1]))
                InternalModel = LoadModelFromFile(args[1]);
            else
                InternalModel = LoadInternalModel();

            // then create a viewmodel from it
            ViewModel = new EditorViewModel(InternalModel);
            DataContext = this;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            // Show the resulting XML in the Debug window
            Trace.WriteLine(InternalModel.Url);
        }


        private PageInfo LoadInternalModel()
        {
            // Load the data
            var model = new PageInfo();
            model.PageName = "TestPage";
            model.HtmlRootNodeXPath = "/";
            model.Url = "http://www.mytestpage.org";
            model.Class = "TestClass";
            model.PageTitle = "TestTitle";
            model.HtmlElements = new List<HtmlControlInfo>
            {
                new HtmlControlInfo() { HtmlTitle="Home link", HtmlXPath="/body/a", HtmlId="link1", HtmlControlType=HtmlControlTypeEnum.Link, CodeControlType="Link", IdentifiedBy=ControlIdentificationType.Id },
                new HtmlControlInfo() { HtmlTitle="Start", HtmlXPath="/body/div/div/input", HtmlId="btnStart", HtmlControlType=HtmlControlTypeEnum.Button, CodeControlType= "Button1", IdentifiedBy=ControlIdentificationType.LinkText },
                new HtmlControlInfo() { HtmlCssClass="MyImg2", HtmlXPath="/body/div/div/img", HtmlId="imgStop", HtmlControlType=HtmlControlTypeEnum.Image, CodeControlType="Image2", IdentifiedBy=ControlIdentificationType.Name },
                new HtmlControlInfo() { HtmlTitle="BooSpan", HtmlXPath="/body/div/div/span", HtmlId="spanX", HtmlCssClass="topSpan", HtmlControlType=HtmlControlTypeEnum.Span, CodeControlType="Span", IdentifiedBy=ControlIdentificationType.Cssclass },
                new HtmlControlInfo() { HtmlTitle="Choose", HtmlXPath="/body/div/div/select", HtmlId="listSelect", HtmlControlType=HtmlControlTypeEnum.Select, CodeControlType="Select3" }
            };
            return model;
        }

        private PageInfo LoadModelFromFile(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PageInfo));
            TextReader textReader = new StreamReader(filename);
            var model = (PageInfo)serializer.Deserialize(textReader);
            textReader.Close();
            return model;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Select a webmodel file, deserialize it and bind a new viewmodel to the editor
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "webmodel files (*.webmodel)|*.webmodel|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            var result = openFileDialog1.ShowDialog();
            if (result.HasValue && result.Value)
            {
                InternalModel = LoadModelFromFile(openFileDialog1.FileName);
                // then create a viewmodel from it
                ViewModel = new EditorViewModel(InternalModel);
                DataContext = null;
                DataContext = this;
            }
        }
    }
}
