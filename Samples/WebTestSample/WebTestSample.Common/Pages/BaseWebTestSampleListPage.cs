using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SpecByExample.Common;
using System.Diagnostics;
using OpenQA.Selenium;
using Castle.Windsor;
using WebTestSample.Common;

namespace WebTestSample.Common.Pages
{
    /// <summary>
    /// Baseclass for WebTestSample pages that show a list of items
    /// </summary>
    public abstract class BaseWebTestSampleListPage<TTableEnum> : BaseWebTestSamplePage
    {
        private const int COLUMN_NOT_FOUND = -1;

        public BaseWebTestSampleListPage(IWindsorContainer container, IWebDriver driver, string title, string code)
            : this(container, driver)
        {
            // Nothing to do here
        }

        public BaseWebTestSampleListPage(IWindsorContainer container, IWebDriver driver)
            : base(container, driver)
        {
            // Create an instance of the standard COProf table mapping definition
            COProfDefinition = CreateTableMapping();
            Columns = CreateListOfColumns();
        }


        /// <summary>
        /// Factory method for creating an instance of the table definition to be used
        /// </summary>
        /// <returns></returns>
        protected abstract ITableMappingDefinition<TTableEnum> CreateTableMapping();

        /// <summary>
        /// Factory method to create a list of enumerator-items for all the columns relevant to this page.
        /// </summary>
        /// <returns></returns>
        protected abstract List<TTableEnum> CreateListOfColumns();

        /// <summary>
        /// Factory method to create an instance of the HtmlTable to wrap the main table for this page.
        /// </summary>
        /// <returns></returns>
        protected abstract HtmlTable CreateHtmlTable();


        /// <summary>
        /// The main table on this page.
        /// </summary>
        /// <remarks>
        /// This is an instance of a wrapper for the HTML table-element that provides an object model to act on that table.
        /// </remarks>
        private HtmlTable htmlTableControl = null;
        protected HtmlTable HtmlTableControl
        {
            get
            {
                if (htmlTableControl == null)
                    htmlTableControl = CreateHtmlTable();
                return htmlTableControl;
            }
        }


        /// <summary>
        /// List of all the column elements relevant to this page
        /// </summary>
        protected List<TTableEnum> Columns
        {
            get;
            private set;
        }


        /// <summary>
        /// Collection of definitions for the table mappings.
        /// </summary>
        protected ITableMappingDefinition<TTableEnum> COProfDefinition
        {
            get;
            set;
        }


        #region Protected non-overridable methods

        /// <summary>
        /// Read all data from a webtable and add it as rows to the given container.
        /// </summary>
        /// <param name="table">Selenium table element to read from.</param>
        /// <param name="dataTable">The container to be filled.</param>
        /// <param name="requestedColumns">Columns to be read from the table</param>
        /// <param name="maxCount">Optional maximum number of records to be read.</param>
        protected void GetTableData<TContainer, TRowType, TEnum>(HtmlTable table, string dbTableName, TContainer dataTable, List<TEnum> requestedColumns, TEnum[] keys = null, int? maxCount = null)
            where TContainer : DataTable
            where TRowType : IBaseDataRow
        {
            // Check preconditions
            if (table == null) throw new ArgumentNullException("dbTableName");
            if (dataTable == null) throw new ArgumentNullException("dataTable");
            if (requestedColumns == null) throw new ArgumentNullException("requestedColumns");
            if (requestedColumns.Count == 0) throw new ArgumentOutOfRangeException("requestedColumns must contain at least one item.");
            if (maxCount.HasValue && maxCount.Value == 0) throw new ArgumentOutOfRangeException("maxCount cannot be 0. If you want to retrieve all rows, pass null for it.");
            if (maxCount < 0) throw new ArgumentOutOfRangeException("maxCount cannot be a negative number.");
            if (keys != null && requestedColumns.Intersect(keys).Count() != keys.Count()) throw new ArgumentOutOfRangeException("The key-columns need to be part of the requested columns.");

            Debug.WriteLine("Parsing items into a table");

            // Read all data into the table
            int itemCount = table.TotalDataRows;
            int maxRows = itemCount;

            // Report what we are doing here
            Debug.WriteLine(String.Format("Table contains {0} columns and {1} rows.", table.Columnnames.Count, itemCount));

            // Obey maximum
            if (maxCount.HasValue && maxRows > maxCount.Value)
                maxRows = maxCount.Value;

            // 1.	Bepaal de namen van de kolommen die op de pagina staan  (dus de 4 kolommen uit de 1e tabel: A, Mijn B, De D, Fje)
            List<string> columnNamesInTable = new List<string>();
            columnNamesInTable.AddRange(table.Columnnames);

            // 2.	Vertaal die beschikbare kolomnamen naar de enumerator values via de vertaaltabel (dat geeft dus A, B, D en F)
            //      Each table column might appear more than once in the availableColumns list, if we read more than one value from it.
            var htmlColumnNames = DoGetHtmlColumnMapping<TEnum>(dbTableName);
            List<KeyValuePair<TEnum, string>> availableColumns = LookupEnumByHtmlName<TEnum>(columnNamesInTable, htmlColumnNames);

            // Define a list of key columns
            var keyColumns = new List<DataColumn>();

            // 3.	Bepaal of de tabel de kolommen bevat die we opvragen (Check: zitten A en F in de verzameling A,B,D, F)
            // 4.	Bepaal de index van de kolommen die we moeten opvragen (Kolom A staat op index 0, kolom F op index 3, gebruik info uit stap 2)
            // If not found: throw an exception
            var requiredColumnIndexes = new List<int>();
            foreach (var item in requestedColumns)
            {
                if (availableColumns.ContainsKey<TEnum>(item) == false)
                {
                    // throw new IndexOutOfRangeException(String.Format("Kolom '{0}' komt niet voor in de HTML tabel.", item));
                    Debug.WriteLine(String.Format("Skipped column '{0}' since it is not available in the HTML table.", item));
                    requiredColumnIndexes.Add(COLUMN_NOT_FOUND);
                }
                else
                {
                    // Get the HTML name of the column
                    int index = 0;
                    foreach (var x in availableColumns)
                    {
                        if (x.Key.ToString() == item.ToString())
                            break;
                        else
                            index++;
                    }

                    if (index == availableColumns.Count)
                    {
                        //Item wasn't found: raise an error
                        string error = "No HTML column name {0} was not found in the list of available columns. Check the BLIDefinition.";
                        Debug.WriteLine(String.Format("ERROR" + error, item));
                        requiredColumnIndexes.Add(COLUMN_NOT_FOUND);
                    }
                    else
                    {
                        // Now we know the index of the enumerator, and we can get the column name it belongs to.
                        string columnName = availableColumns.ElementAt(index).Value;

                        // Finally, get the position of that column within the table
                        int columnPosition = columnNamesInTable.IndexOf(columnName);
                        if (keys != null && keys.Contains(item))
                            keyColumns.Add(dataTable.Columns[columnPosition]);

                        // Add the position to the list so we can use it to retieve the value
                        requiredColumnIndexes.Add(columnPosition);
                    }
                }
            }

            Debug.Assert(requiredColumnIndexes.Count == requestedColumns.Count, "Requested column count and required column count should be equal to prevent index out of range errors.");

            // Start reading all the rows
            var container = dataTable as IBaseDatacontainer<TRowType>;
            for (int i = 0; i < maxRows; i++)
            {
                // Show progress
                Debug.WriteLine(" Reading row " + (i + 1).ToString());

                // Create a new row
                var tableRow = container.NewRowEntity();

                // Read the values of the selected columns
                int j = 0;
                foreach (var enumItem in requestedColumns)
                {
                    int colIndex = requiredColumnIndexes[j];

                    if (colIndex != COLUMN_NOT_FOUND)
                    {
                        // Find out the expected type of the field
                        Type fieldType = tableRow.GetFieldType<TEnum>(enumItem);

                        object value;
                        if (fieldType == typeof(string))
                            value = table.ReadCellValueAsString(i, colIndex);
                        else if (fieldType == typeof(int))
                            value = table.ReadCellValueAsInt(i, colIndex);
                        else if (fieldType == typeof(Uri))
                            value = table.ReadCellValueAsUrl(i, colIndex);
                        else if (fieldType == typeof(DateTime))
                            value = table.ReadCellValueAsDateTime(i, colIndex);
                        else
                            throw new NotImplementedException("Reading fields of type " + fieldType.ToString() + " is not yet implemented.");

                        // Set the fields using the double mapping attributes
                        string enumName = Enum.GetName(typeof(TEnum), enumItem);
                        tableRow.SetValue<TEnum>(enumItem, value);
                    }

                    // Count the columns
                    j++;
                } // for
                container.AddRowEntity(tableRow);
            } // for


            // Create a primary key for it
            if (keyColumns.Count > 0)
                dataTable.PrimaryKey = keyColumns.ToArray();

            Debug.WriteLine("All rows read");
        }


        /// <summary>
        /// Returns the list of HTML names for all enumerator-items that have their flag set.
        /// </summary>
        /// <typeparam name="TColumnEnum">Type of the enumerator used in the dictionary.</typeparam>
        /// <param name="columns">The columns to lookup.</param>
        /// <param name="dictionary">Table to convert enumerator values to html names.</param>
        /// <returns>A list with as many items as flags in the enumerators. If no name was found for an item, null will be added for it instead.</returns>
        internal static List<string> LookupHtmlNameByEnum<TColumnEnum>(List<TColumnEnum> columns, Dictionary<TColumnEnum, string> dictionary)
        {
            var htmlNames = new List<string>();
            foreach (var item in columns)
            {
                // Always add an item. If name not found: add null
                TColumnEnum key = (TColumnEnum)Enum.Parse(typeof(TColumnEnum), item.ToString());
                if ((columns.Contains(item)) && dictionary.ContainsKey(key))
                    htmlNames.Add(dictionary[key]);
                else
                    htmlNames.Add(null);
            }
            return htmlNames;
        }


        /// <summary>
        /// Returns the list of enumerators for all given columnnames.
        /// </summary>
        /// <remarks>
        /// NOTE: This can return MORE items than the number of columns. This will happen if you read more than one value from the same column.
        /// </remarks>
        /// <typeparam name="TEnum">Type of the enumerator used in the dictionary.</typeparam>
        /// <param name="columnNames">The names of the columns for which to lookup their enumerator.</param>
        /// <param name="dictionary">Table to convert enumerator values to html names.</param>
        /// <returns>A list with as many items as contained in columnnames. If no name was found, it will throw an exception.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if no enumerator item could be found.</exception>
        internal static List<KeyValuePair<TEnum, string>> LookupEnumByHtmlName<TEnum>(List<string> columnNames, Dictionary<TEnum, string> dictionary)
        {
            var enums = new List<KeyValuePair<TEnum, string>>();
            Debug.WriteLine("Looking up enumerators for HTML names");
            Debug.Indent();

            // Used for case-insensitive comparison
            var values = dictionary.Values.ToList<string>();
            foreach (var name in columnNames)
            {
                // Clean the name
                string itemName = name.Trim();

                // Compare case insensitively
                if ((String.IsNullOrEmpty(itemName) || (dictionary.ContainsValue(itemName) == false)))
                {
                    // Find the None item and set it
                    try
                    {
                        TEnum noneItem = (TEnum)Enum.Parse(typeof(TEnum), "None");
                        enums.AddItem<TEnum>(noneItem, name);    // Add the None item
                        Debug.WriteLine("No enum item found for '" + itemName + "': Adding None for it");
                    }
                    catch (ArgumentException ex)
                    {
                        throw new NotSupportedException("LookupEnumByHtmlName kan geen None item vinden in de enumerator " + typeof(TEnum).Name + " en die is wel nodig omdat er een kolom zonder naam is gevonden in de tabel.", ex);
                    }
                }
                else
                {
                    // Always add an item. If name not found: add null
                    var keys = from k in dictionary
                               where string.Compare(k.Value, itemName, true) == 0
                               select k.Key;

                    if (keys.Count() == 0)
                        Debug.Fail("This should never happen since we already checked that the name exists in the dictionary");
                    else if (keys.Count() == 1)
                    {
                        Debug.WriteLine("Adding enumerator item for '" + itemName + "'");
                        enums.AddItem(keys.Single(), name);
                    }
                    else
                    {
                        // More than one item found for this column
                        // This is possible if a column contains multiple information elements,
                        // like a clickable Referentienummer field. In that case, the field
                        // contains the number as well as a hyperlink.
                        foreach (var key in keys)
                            enums.AddItem(key, name);

                        // No more exception required.
                        //                        throw new IndexOutOfRangeException(String.Format("De vertaaltabel bevat meerdere items met dezelfde value. Daardoor kan er geen enumerator gevonden worden voor kolom " + itemName));
                    }
                }
                //else
                //    throw new IndexOutOfRangeException(String.Format("Voor item '{0}' is geen overeenkomstig HTML element gevonden in de dictionary.", itemName));
            }
            Debug.Unindent();
            Debug.WriteLine("All enums processed");
            return enums;
        }

        #endregion


        #region Private support methods

        /// <summary>
        /// Helper to get the mapping between an HTML table and the enumerator item.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>A mapping table.</returns>
        private Dictionary<TEnum, string> DoGetHtmlColumnMapping<TEnum>(string tableName)
        {
            if (tableName == null)
                tableName = "";

            // Use the definition for the mapping.
            var output = COProfDefinition.GetHtmlColumnMapping<TEnum>(tableName);

            // TODO Check if all items were mapped appropriately:
            //   loop all enumerator items and check that each of them appears in the mapping at least once

            return output;
        }

        #endregion

    }
}
