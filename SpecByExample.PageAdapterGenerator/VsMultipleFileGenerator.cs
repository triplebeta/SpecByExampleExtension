using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TextTemplating.VSHost;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using System.Runtime.InteropServices;
using System.IO;
using System.ComponentModel;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio;

namespace SpecByExample.PageAdapterGenerator
{
    /// <summary>
    /// Base class for a custom tool that generates multiple files.
    /// </summary>
    /// <remarks>Source from: https://www.codeproject.com/kb/cs/vsmultiplefilegenerator.aspx </remarks>
    /// <typeparam name="IterativeElementType"></typeparam>
    public abstract class VsMultipleFileGenerator<IterativeElementType> : IVsSingleFileGenerator, IObjectWithSite
    {
        #region Visual Studio Specific Fields
        private object site;
        private ServiceProvider serviceProvider = null;
        #endregion

        #region Our Fields
        private string inputFileContents;
        private string inputFilePath;
        private EnvDTE.Project project;

        private EnvDTE.DTE dte;

        private List<string> newFileNames;
        #endregion

        protected EnvDTE.DTE Dte
        {
            get { return dte; }
        }

        protected EnvDTE.Project Project
        {
            get { return project; }
        }

        protected string InputFileContents
        {
            get { return inputFileContents; }
        }

        protected string InputFilePath
        {
            get { return inputFilePath; }
        }

        #region Abstract methods to override

        protected abstract byte[] GeneratePageAdapterCode();
        protected abstract byte[] GenerateStepsCode();

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public VsMultipleFileGenerator()
        {
            EnvDTE.DTE dte = (EnvDTE.DTE)Package.GetGlobalService(typeof(EnvDTE.DTE));
            Array ary = (Array)dte.ActiveSolutionProjects;
            if (ary.Length > 0)
            {
                project = (EnvDTE.Project)ary.GetValue(0);

            }
            newFileNames = new List<string>();
        }

        /// <summary>
        /// Use the default file for the PageAdapter code.
        /// </summary>
        public int DefaultExtension(out string defaultExtension)
        {
            // The default file 
            defaultExtension = ".PageAdapter.cs";
            return defaultExtension.Length;
        }

        /// <summary>
        /// Starting point for the code generation.
        /// This is implemented in an alternative manner: it does not use its parameters to return the content for 1 file.
        /// Instead it just creates its own files on disk and addes them to the solution.
        /// </summary>
        public int Generate(string inputFilePath, string inputFileContents, string defaultNamespace, IntPtr[] outputFileContents, out uint output, IVsGeneratorProgress generateProgress)
        {
            // Set shared variables so that subclasses can use them as well.
            dte = (EnvDTE.DTE)Package.GetGlobalService(typeof(EnvDTE.DTE));
            this.inputFileContents = inputFileContents;
            this.inputFilePath = inputFilePath;
            this.newFileNames.Clear();

            int found = 0;
            uint itemId = 0;
            output = 0;
            EnvDTE.ProjectItem item;
            Microsoft.VisualStudio.Shell.Interop.VSDOCUMENTPRIORITY[] pdwPriority = new Microsoft.VisualStudio.Shell.Interop.VSDOCUMENTPRIORITY[1];

            // obtain a reference to the current project as an IVsProject type
            Microsoft.VisualStudio.Shell.Interop.IVsProject VsProject = VsHelper.ToVsProject(project);
            // this locates, and returns a handle to our source file, as a ProjectItem
            VsProject.IsDocumentInProject(InputFilePath, out found, pdwPriority, out itemId);

            // if our source file was found in the project (which it should have been)
            if (found != 0 && itemId != 0)
            {
                Microsoft.VisualStudio.OLE.Interop.IServiceProvider oleSp = null;
                VsProject.GetItemContext(itemId, out oleSp);
                if (oleSp != null)
                {
                    ServiceProvider sp = new ServiceProvider(oleSp);
                    // convert our handle to a ProjectItem
                    item = sp.GetService(typeof(EnvDTE.ProjectItem)) as EnvDTE.ProjectItem;
                }
                else
                    throw new ApplicationException("Unable to retrieve Visual Studio ProjectItem");
            }
            else
                throw new ApplicationException("Unable to retrieve Visual Studio ProjectItem");

            // =================================================
            // Create PageAdapter
            // =================================================

            // Write the code tot the file that this Generator is expected to create.
            string baseFilename = Path.GetFileNameWithoutExtension(InputFilePath);
            string fileName = $"{baseFilename}.PageAdapter.cs";
            newFileNames.Add(fileName);
            byte[] pageAdapterCode = GeneratePageAdapterCode();
            outputFileContents[0] = Marshal.AllocCoTaskMem(pageAdapterCode.Length);
            Marshal.Copy(pageAdapterCode, 0, outputFileContents[0], pageAdapterCode.Length);
            output = (uint)pageAdapterCode.Length;

            // =================================================
            // Create the Steps file, using a fully qualify the file on the filesystem
            // =================================================
            fileName = $"{baseFilename}.Steps.cs";
            newFileNames.Add(fileName);
            string outputFilename = Path.Combine(inputFilePath.Substring(0, inputFilePath.LastIndexOf(Path.DirectorySeparatorChar)), fileName);
            FileStream fs = File.Create(outputFilename);
            try
            {
                // generate our target file content and copy it to a byte array.
                byte[] stepsCode = GenerateStepsCode();
                fs.Write(stepsCode, 0, stepsCode.Length);
                fs.Close();

                // add the newly generated file to the solution, as a child of the source file...
                EnvDTE.ProjectItem itm = item.ProjectItems.AddFromFile(outputFilename);
            }
            catch (Exception)
            {
                fs.Close();
                if (File.Exists(outputFilename))
                    File.Delete(outputFilename);
            }

            // Perform some clean-up, making sure we delete any old (stale) target-files.
            // This should leave us with only the newly generated files as children of the input file.
            foreach (EnvDTE.ProjectItem childItem in item.ProjectItems)
            {
                if (newFileNames.Contains(childItem.Name)==false)
                    childItem.Delete();  // then delete it
            }
            return VSConstants.S_OK;
        }

        #region IObjectWithSite Members

        private ServiceProvider SiteServiceProvider
        {
            get
            {
                if (serviceProvider == null)
                {
                    Microsoft.VisualStudio.OLE.Interop.IServiceProvider oleServiceProvider = site as Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
                    serviceProvider = new ServiceProvider(oleServiceProvider);
                }
                return serviceProvider;
            }
        }

        public void GetSite(ref Guid riid, out IntPtr ppvSite)
        {
            if (this.site == null)
            {
                throw new Win32Exception(-2147467259);
            }

            IntPtr objectPointer = Marshal.GetIUnknownForObject(this.site);

            try
            {
                Marshal.QueryInterface(objectPointer, ref riid, out ppvSite);
                if (ppvSite == IntPtr.Zero)
                {
                    throw new Win32Exception(-2147467262);
                }
            }
            finally
            {
                if (objectPointer != IntPtr.Zero)
                {
                    Marshal.Release(objectPointer);
                    objectPointer = IntPtr.Zero;
                }
            }
        }

        public void SetSite(object pUnkSite)
        {
            this.site = pUnkSite;
        }

        #endregion

    }
}

