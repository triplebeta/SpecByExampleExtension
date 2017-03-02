using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace SpecByExample.T4.Wizard
{
    /// <summary>
    /// Wizard Tab that lets you specify how to generate code for a table.
    /// The table you select will be wrapped in an adapter and it will try to create an entity for the rows in it so you can easily use them in tests.
    /// </summary>
    public partial class TableInfo : UserControl, IWizardPage
    {
        public TableInfo()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Document to work on.
        /// </summary>
        private HtmlAgilityPack.HtmlDocument HtmlDocumentCache
        {
            get;
            set;
        }

        /// <summary>
        /// Cache of the controls in page PageUrl.
        /// </summary>
        private List<HtmlControlInfo> ControlInfoCache
        {
            get;
            set;
        }


        /// <summary>
        ///  List of all table nodes (value) and their names (key)
        /// </summary>
        private SortedDictionary<string, HtmlNode> TableCache
        {
            get;
            set;
        }


        /// <summary>
        /// Most recently loaded page.
        /// </summary>
        private string PageUrl
        {
            get;
            set;
        }


        #region Implement IWizardPage

        public WizardConfiguration WizardConfig
        {
            get;
            set;
        }

        public void LoadState(PageAdapterWizardViewModel container)
        {
            bool isTablePage = (container.PageInfo.TypeOfPage == PageTemplatesEnum.TablePage);
            PageUrl = container.PageInfo.Url;
            ToggleTableFields(isTablePage);
        }


        public void SaveState(PageAdapterWizardViewModel container)
        {
            if (chkCreateTableWrapper.Checked)
            {
                container.PageInfo.TypeOfPage = PageTemplatesEnum.TablePage;
                container.PageInfo.TableInfo = ComposeTableInfo();
            }
            else
                container.PageInfo.TypeOfPage = PageTemplatesEnum.GenericPage;
        }

        public bool ValidateInput()
        {
            // Ignore disabled controls
            return ValidateChildren();
        }

        #endregion


        #region Handle Events

        /// <summary>
        /// When selecting a table element: load its columns into the grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Fill the grid with the names of the columns of the HTML page.
            // Use the th elements or if not available, the values from the first row.
            webTableColumnsDatasetBindingSource.DataSource = ComposeGridData(ControlInfoCache);
        }

        private void chkCreateTableWrapper_CheckedChanged(object sender, EventArgs e)
        {
            ToggleTableFields(chkCreateTableWrapper.Checked);
        }

        private void txtEntityName_Validating(object sender, CancelEventArgs e)
        {
            if (txtEntityName.Enabled && txtEntityName.Text.Trim() == String.Empty)
            {
                errorProvider1.SetError(txtEntityName, "Entity name is required");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtEntityName, "");
        }


        private void cmbTables_Validating(object sender, CancelEventArgs e)
        {
            if (cmbTables.Enabled && cmbTables.Text.Trim() == String.Empty)
            {
                errorProvider1.SetError(cmbTables, "Table name is required");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(cmbTables, "");
        }

        #endregion


        #region Private support methods

        /// <summary>
        /// Initialize the controls on this page
        /// </summary>
        private void InitializeListOfElements(List<HtmlControlInfo> controlInfo)
        {
            // Fill the list with all tables of this page
            var tables = controlInfo.Where(x => x.HtmlControlType == HtmlControlTypeEnum.Table);

            // Replace the list of tables with a new one
            TableCache = new SortedDictionary<string, HtmlNode>();
            foreach (var t in tables)
            {
                var node = HtmlDocumentCache.DocumentNode.SelectSingleNode(t.HtmlXPath);
                TableCache.Add(t.DisplayName, node);
            }
            cmbTables.DataSource = new BindingSource(TableCache,null);
            cmbTables.DisplayMember = "Key";
            cmbTables.ValueMember = "Value";
        }


        /// <summary>
        /// Compose a datatable to databind to the grid.
        /// </summary>
        /// <returns></returns>
        private DataTable ComposeGridData(List<HtmlControlInfo> controlInfo)
        {
            // Get the selected table
            var tableName = cmbTables.Text;
            if (TableCache.ContainsKey(tableName) == false)
                return null;

            DataTable data = new DataTable();
            data.Columns.Add("ColumnPosition",typeof(int));
            data.Columns.Add("ColumnTitle", typeof(string));
            data.Columns.Add("CodeFieldname", typeof(string));
            data.Columns.Add("CodeDatatype", typeof(string));
            data.Columns.Add("IncludeField", typeof(bool));
            var tableNode = TableCache[tableName];

            // Get the headers from the table
            string[] headerTitles = GetHeaderTitles(tableNode);
            int pos = 1;
            foreach (var header in headerTitles)
            {
                data.Rows.Add(new object[] { pos++, header, header, "String", true });
            }
            return data;
        }


        /// <summary>
        /// Get the text from the TH tags or the first row of data
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private string[] GetHeaderTitles(HtmlNode table)
        {
            // Get the body of the table
            var tbody = table.SelectSingleNode("tbody");
            var rowRoot = tbody ?? table;
            var rows = rowRoot.SelectNodes("tr");

            List<string> columnNames = new List<string>();
            HtmlNode firstRow = null;
            if (rows.Count > 0)
            {
                // Get the first row
                firstRow = rows.First();
                if (firstRow != null)
                {
                    // Assumption: if we find one th in this row, we assume all column headers will be
                    // constructed from TH elements. Otherwise, we assume each TD contains a columnname.
                    var headerCells = firstRow.SelectNodes("th");
                    if (headerCells != null)
                    {
                        foreach (var th in headerCells)
                            columnNames.Add(th.InnerText);
                    }
                    else
                    {
                        headerCells = firstRow.SelectNodes("td");
                        if (headerCells != null)
                        {
                            foreach (var th in headerCells)
                                columnNames.Add(th.InnerText);
                        }

                    }
                }
            }
            return columnNames.ToArray();
        }


        /// <summary>
        /// Collect the data we need to pass back.
        /// </summary>
        /// <returns>Information to use for code generation: which elements must be generated for this table?</returns>
        private SeleniumTableInfo ComposeTableInfo()
        {
            // Create a container for the settings of this table.
            var tableInfo = new SeleniumTableInfo();
            tableInfo.EntityName = txtEntityName.Text;
            tableInfo.TableName = cmbTables.Text;

            // Use the table to fill the entity
            DataTable table = webTableColumnsDatasetBindingSource.DataSource as DataTable;
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    // Skip excluded columns
                    bool isIncluded = (bool)row["IncludeField"];
                    if (isIncluded)
                    {
                        int position = (int)row["ColumnPosition"];
                        string title = (string)row["ColumnTitle"];
                        string fieldname = (string)row["CodeFieldname"];
                        string datatype = (string)row["CodeDatatype"];
                        tableInfo.Columns.Add(new TableColumnDef(position, title, fieldname, datatype));
                    }
                }
            }
            return tableInfo;
        }


        private delegate void CursorUpdateDelegate(Cursor cursor);
        private delegate void ControlUpdateDelegate(List<HtmlControlInfo> controlInfo);

        private void SetCursor(Cursor cursor)
        {
            Cursor = cursor;
        }

        private void LoadTableInfoWithTask(string url)
        {
            var loadPageInfoTask = new Task(() =>
            {
                try
                {
                    Invoke(new CursorUpdateDelegate(SetCursor), Cursors.WaitCursor);
                    if (PageUrl != url || HtmlDocumentCache == null || ControlInfoCache == null)
                    {
                        // Get the HTML and parse its objects
                        var loader = new HtmlLoader(WizardConfig.RegisteredControlTypes);
                        HtmlDocumentCache = loader.LoadDocumentFromUrl(url);
                        ControlInfoCache = loader.GetHtmlControls(HtmlDocumentCache, HtmlLoader.DefaultOptions);
                        PageUrl = url;
                    }

                    Invoke(new ControlUpdateDelegate(InitializeListOfElements), ControlInfoCache);
                }
                finally
                {
                    Invoke(new CursorUpdateDelegate(SetCursor), Cursors.Default);
                }
            });
            loadPageInfoTask.Start();
        }


        /// <summary>
        /// Plain variant without a task.
        /// </summary>
        /// <param name="url"></param>
        private void LoadTableInfo(string url)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (PageUrl != url || HtmlDocumentCache == null || ControlInfoCache == null)
                {
                    // Get the HTML and parse its objects
                    var loader = new HtmlLoader(WizardConfig.RegisteredControlTypes);
                    HtmlDocumentCache = loader.LoadDocumentFromUrl(url);
                    ControlInfoCache = loader.GetHtmlControls(HtmlDocumentCache, HtmlLoader.DefaultOptions);
                    PageUrl = url;
                }

                InitializeListOfElements(ControlInfoCache);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Enable/Disable fields for the table info
        /// </summary>
        private void ToggleTableFields(bool enable)
        {
            pnlTableInfo.Enabled = enable;
            errorProvider1.Clear();

            // Load cache with info of this page
            if (enable)
            {
                LoadTableInfo(PageUrl);
//                LoadTableInfoWithTask(PageUrl);
            }
            else
            {
                // Reset the fields
                cmbTables.DataSource = null;
                txtEntityName.Clear();
                webTableColumnsDatasetBindingSource.DataSource = null;
            }
        }

        #endregion
    }
}
