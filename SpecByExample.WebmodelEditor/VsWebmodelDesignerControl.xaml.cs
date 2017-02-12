using System;
using System.Collections.Generic;
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

namespace SpecByExample.WebmodelEditor
{
    /// <summary>
    /// Interaction logic for VsWebmodelDesignerControl.xaml
    /// </summary>
    public partial class VsWebmodelDesignerControl : UserControl
    {
        public VsWebmodelDesignerControl()
        {
            InitializeComponent();
        }

        public VsWebmodelDesignerControl(IViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
            // wait until we're initialized to handle events
            viewModel.ViewModelChanged += new EventHandler(ViewModelChanged);
        }

        internal void DoIdle()
        {
            // only call the view model DoIdle if this control has focus
            // otherwise, we should skip and this will be called again
            // once focus is regained
            IViewModel viewModel = DataContext as IViewModel;
            if (viewModel != null && this.IsKeyboardFocusWithin)
            {
                viewModel.DoIdle();
            }
        }

        private void ViewModelChanged(object sender, EventArgs e)
        {
            // this gets called when the view model is updated because the Xml Document was updated
            // since we don't get individual PropertyChanged events, just re-set the DataContext
            IViewModel viewModel = DataContext as IViewModel;
            DataContext = null; // first, set to null so that we see the change and rebind
            DataContext = viewModel;
        }
    }
}
