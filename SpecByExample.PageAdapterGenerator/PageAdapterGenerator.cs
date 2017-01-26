using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SpecByExample.PageAdapterGenerator
{
    [ComVisible(true)]
    [Guid("c07152bb-23eb-4ea5-902c-51090d04dc3d")]
    [CodeGeneratorRegistration(typeof(PageAdapterGenerator), "Creates the page adapter code from the model.", VSConstants.UICONTEXT.CSharpProject_string, GeneratesDesignTimeSource = true)]
    [ProvideObject(typeof(PageAdapterGenerator))]
    public class PageAdapterGenerator : IVsSingleFileGenerator
    {
        #region IVsSingleFileGenerator Members

        public int DefaultExtension(out string pbstrDefaultExtension)
        {
            pbstrDefaultExtension = ".txt";
            return pbstrDefaultExtension.Length;
        }

        public int Generate(string wszInputFilePath, string bstrInputFileContents,
          string wszDefaultNamespace, IntPtr[] rgbOutputFileContents,
          out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
        {
            try
            {
                int lineCount = bstrInputFileContents.Split('\n').Length;
                byte[] bytes = Encoding.UTF8.GetBytes(lineCount.ToString() + " LOC");
                int length = bytes.Length;
                rgbOutputFileContents[0] = Marshal.AllocCoTaskMem(length);
                Marshal.Copy(bytes, 0, rgbOutputFileContents[0], length);
                pcbOutput = (uint)length;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                pcbOutput = 0;
            }
            return 1; // TODO Get this working with: return Constants.S_OK;
        }

        #endregion
    }
}
