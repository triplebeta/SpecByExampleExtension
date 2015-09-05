using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using HtmlAgilityPack;

namespace SpecByExample.Common
{
    /// <summary>
    /// Helper to simplify the extractioon of data and properties of a Watin Table object.
    /// </summary>
    /// <remarks>
    /// Original code comes from: http://stackoverflow.com/questions/6609447/in-watin-how-to-verify-a-tables-column-headers-and-rows
    /// </remarks>
    public class SeleniumTableHelper : IDisposable
    {
        // For now: always assume each table has 1 row of headers. Can be implemented more sophisticated lateron.
        private static int NUMBER_OF_HEADERROWS = 1;

        private readonly bool _ignoreInvalidColumnnames;
        private readonly IWebDriver _driver;
        HtmlDocument htmlDocument;

        /// <summary>
        /// Create the helper instance.
        /// </summary>
        /// <param name="driver">WebDriver</param>
        /// <param name="xPath">XPath expression to get the table to work on</param>
        /// <param name="ignoreInvalidColumnnames">True to ignore columns with no name on them.</param>
        /// <exception cref="ArgumentNullException">Thrown when table is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when duplicate columnnames are detected.</exception>
        /// <exception cref="FormatException">Thrown if columnnames are missing.</exception>
        public SeleniumTableHelper(IWebDriver driver, string xPath, bool ignoreInvalidColumnnames = false)
        {
            // Check preconditions
            if (driver == null) throw new ArgumentNullException("driver");
            if (xPath == null) throw new ArgumentNullException("xPath");

            // If all is well: continue
            _driver = driver;
            _ignoreInvalidColumnnames = ignoreInvalidColumnnames;
            Columnnames = new List<string>();

            // Create an instance of the parser
            // TODO: Find a way to have it update its content when it's changes dynamically, e.g. when we add a row to the table
            htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(driver.PageSource);

            var table = htmlDocument.DocumentNode.SelectSingleNode(xPath);
            if (table == null) throw new ArgumentNullException("table");
            CurrentTable = table;

            // Get the body of the table
            var tbody = table.SelectSingleNode("tbody");
            var rowRoot = tbody ?? table;
            var rows = rowRoot.SelectNodes("tr");

            HtmlNode firstRow = null;
            if (rows.Count > 0)
            {
                // Get the first row
                firstRow = rows.First();
            }

            if (firstRow != null)
            {
                // Assumption: if we find one th in this row, we assume all column headers will be
                // constructed from TH elements. Otherwise, we assume each TD contains a columnname.
                HasColumnHeaders = firstRow.SelectNodes("th") != null;
                Columnnames.AddRange(GetAllColumnDataFromRow(firstRow, HasColumnHeaders));

                // Check sanity of the columnnames
                if (ignoreInvalidColumnnames == false)
                    ValidateColumnnames(Columnnames);
            }

            // Initialize the totals (to speed things up)
            // Correct it for the number of table header rows
            var count = rows.Count - NUMBER_OF_HEADERROWS;
            TotalDataRows = count >= 0 ? count : 0;
            TotalColumns = Columnnames.Count;
        }


        #region Implement caching support

        private bool _useRowCaching = false;

        /// <summary>
        /// Set this to true to enable caching.
        /// The act of setting it to true will fill the cache.
        /// </summary>
        public bool UseRowCaching
        {
            get { return _useRowCaching; }
            set
            {
                // :oad cache only once
                if (_useRowCaching == false && value)
                    LoadRowCache();
                else
                    ClearRowCache();
                _useRowCaching = value;
            }
        }

        /// <summary>
        /// Array of all cells. Contains one item for each row.
        /// </summary>
        private ReadOnlyCollection<ReadOnlyCollection<HtmlNode>> CachedCells
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes the cache with an instance of each row.
        /// </summary>
        /// <remarks>
        /// Call this method if you want to achieve extra speed by trading memory usage.
        /// It will cache all rows and tell all methods that the cache is usable.
        /// </remarks>
        private void LoadRowCache()
        {
            // Get the body of the table
            var tbody = CurrentTable.SelectSingleNode("tbody");
            var rowRoot = tbody ?? CurrentTable;
            var allRows = rowRoot.SelectNodes("tr");

            var rowsList = new List<ReadOnlyCollection<HtmlNode>>();
            for (int rowIndex = NUMBER_OF_HEADERROWS; rowIndex < allRows.Count(); rowIndex++)
            {
                var row = allRows[rowIndex];
                HtmlTableRow tableRow = new HtmlTableRow(row);
                rowsList.Add(tableRow.TableCells);
            }
            CachedCells = new ReadOnlyCollection<ReadOnlyCollection<HtmlNode>>(rowsList);
        }


        /// <summary>
        /// Free the cache
        /// </summary>
        private void ClearRowCache()
        {
            CachedCells = null;
        }
        
        #endregion


        #region Read typed values from a cell

        /// <summary>
        /// Indexer property to access the data in the rows of this table.
        /// All values will be returned as strings.
        /// </summary>
        /// <param name="row">Index of the datarow. First datarow has index 0.</param>
        /// <param name="columname">Name of the column to read from the row.</param>
        /// <returns>String of the content of this cell.</returns>
        public string this[int row, string columname]
        {
            get
            {
                if (row < 0) throw new ArgumentOutOfRangeException("row", "Datarow cannot be less than 0.");
                if (String.IsNullOrEmpty(columname)) throw new ArgumentNullException("columname");
                if (Columnnames.Contains(columname) == false) throw new InvalidOperationException("De kolom '" + columname + "' is niet gevonden in de tabel.");

                // Fixup the row-index for column-header rows and get the index of the column.
                int colIndex = Columnnames.IndexOf(columname);

                // Use the other indexer to get the data
                return GetCellText(row, colIndex);
            }
        }


        /// <summary>
        /// Gets the value of a cell as an URI. This will try to find an &lt;A href=...&gt; in the cell
        /// an will then return its HREF value.
        /// </summary>
        /// <param name="row">Row to read from.</param>
        /// <param name="column">Column to read</param>
        public string ReadStringValue(int row, int column)
        {
            return GetCellText(row, column);
        }


        /// <summary>
        /// Gets the value of a cell as an integer. It will expect that the Text property of the cell contains a valid int value.
        /// If it's empty, it will return null.
        /// </summary>
        /// <param name="row">Row to read from.</param>
        /// <param name="column">Column to read</param>
        public int? ReadIntValue(int row, int column)
        {
            string value = GetCellText(row, column);
            int number;
            if (int.TryParse(value, out number))
                return number;
            else
                return null;
        }


        /// <summary>
        /// Gets the value of a cell as a DateTime.
        /// </summary>
        /// <param name="row">Row to read from.</param>
        /// <param name="column">Column to read</param>
        public DateTime? ReadDateValue(int row, int column)
        {
            string value = GetCellText(row, column);
            DateTime date;
            if (DateTime.TryParse(value, out date))
                return date;
            else
                return null;
        }


        /// <summary>
        /// Gets the value of a cell as an URI. This will try to find an &lt;A href=...&gt; in the cell
        /// an will then return its HREF value.
        /// </summary>
        /// <param name="row">Row to read from.</param>
        /// <param name="column">Column to read</param>
        public Uri ReadUrlValue(int row, int column)
        {
            // TODO Implement loading URLs: use another way to read the cell since we need to get another element of the cell.
            string html = GetCellOuterHtml(row, column);

            // Use a regular expression to extract the URL
            string RegexPattern = @"<a.*?href=[""'](?<url>.*?)[""'].*?>(?<name>.*?)</a>";

            // match.Groups["name"].Value - URL Name . 
            // match.Groups["url"].Value - URI . 
            // Find matches.
            MatchCollection matches = Regex.Matches(html, RegexPattern, RegexOptions.IgnoreCase);
            if (matches.Count > 0)
            {
                // Get the first url
                string url = matches[0].Groups["url"].Value;
                return new Uri(url);
            }
            else
                return null;
        }
        
        #endregion


        #region (Meta)data for the table

        /// <summary>
        /// Reference to the table being wrapped.
        /// </summary>
        public HtmlNode CurrentTable
        {
            private set;
            get;
        }


        /// <summary>
        /// Names of the columns in the table.
        /// </summary>
        public List<string> Columnnames
        {
            private set;
            get;
        }

        /// <summary>
        /// True if a colum header row was found for this table
        /// </summary>
        public bool HasColumnHeaders
        {
            private set;
            get;
        }


        /// <summary>
        /// Number of columns in the first row.
        /// </summary>
        public int TotalColumns
        {
            get;
            private set;
        }

        /// <summary>
        /// Number of rows of data, this does not include the header rows.
        /// </summary>
        public int TotalDataRows
        {
            get;
            private set;
        }

        #endregion


        #region Private support code


        /// <summary>
        /// Gets the outer HTML of a cell of this table as a string.
        /// </summary>
        /// <param name="row">Index of the datarow. First datarow has index 0.</param>
        /// <param name="column">Index of the column to read from the row.</param>
        /// <returns>String of the content of this cell.</returns>
        private string GetCellOuterHtml(int row, int column)
        {
            var cellNode = GetCell(row, column);
            return cellNode.OuterHtml;
        }


        /// <summary>
        /// Gets the data in the rows of this table as a string.
        /// </summary>
        /// <param name="row">Index of the datarow. First datarow has index 0.</param>
        /// <param name="column">Index of the column to read from the row.</param>
        /// <returns>String of the content of this cell.</returns>
        private string GetCellText(int row, int column)
        {
            var cellNode = GetCell(row, column);
            return cellNode.InnerText;
        }


        /// <summary>
        /// Get the HTML Node for the cell
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private HtmlNode GetCell(int row, int column)
        {
            if (row < 0) throw new ArgumentOutOfRangeException("row", "Datarow cannot be less than 0.");
            if (row >= TotalDataRows) throw new IndexOutOfRangeException("Het opgegeven regelnummer is groter dan het aantal regels in de tabel.");
            if (column < 0) throw new ArgumentOutOfRangeException("column", "Column cannot be less than 0.");
            if (column >= Columnnames.Count) throw new InvalidOperationException(String.Format("Kolom {0} is niet gevonden omdat de tabel niet meer dan {1} kolommen bevat.", column, Columnnames.Count));

            if (UseRowCaching)
            {
                // The cache only contains the data rows, s
                var cell = CachedCells[row][column];
                return cell;
            }
            else
            {
                // Fixup the row-index for column-header rows and get the index of the column.
                int rowIndex = row + NUMBER_OF_HEADERROWS;

                // Get the body of the table
                var tbody = CurrentTable.SelectSingleNode("tbody");
                var rowRoot = tbody ?? CurrentTable;
                var allRows = rowRoot.SelectNodes("tr");

                var allCells = allRows[rowIndex].SelectNodes("td");
                var cell = allCells[column];
                return cell;
            }
        }


        /// <summary>
        /// Read the columnnames from a (table header)row.
        /// </summary>
        /// <param name="tableRow">The row</param>
        /// <param name="isTableHeaderRow">Must be true if the table contains a TH for the header row. If false, we will be looking for ordinary TD tags and assume they represent the columnnames.</param>
        /// <returns>A list with one item for each datarow, if no datarows were found it will return an empty list.</returns>
        private List<string> GetAllColumnDataFromRow(HtmlNode tableRow, bool isTableHeaderRow)
        {
            if (tableRow == null) throw new ArgumentNullException("tableRow");

            // Used to store the data of this rows. This can be real data or columnnames.
            var rowValues = new List<string>();

            if (isTableHeaderRow)
            {
                foreach (HtmlNode e in tableRow.Elements("th"))
                {
                    rowValues.Add(e.InnerText);
                }
            }
            else
            {
                foreach (HtmlNode tc in tableRow.ChildNodes)
                {
                    if (String.IsNullOrEmpty(tc.InnerText))
                    {
                        rowValues.Add(String.Empty);
                    }
                    else
                    {
                        rowValues.Add(tc.InnerText);
                    }
                }
            }     
            
            // Fill up for the missing cells, if any, with blanks
            int actualCellsInRow = tableRow.Elements("td").Count();
            int expectedCellsInRow = this.TotalColumns;
            for (int colCounter = actualCellsInRow; colCounter < expectedCellsInRow; colCounter++)
            {
                rowValues.Add(String.Empty);
            }

            return rowValues;
        }


        /// <summary>
        /// Validate the names of the columns.
        /// </summary>
        /// <param name="columnnames">All column names</param>
        private void ValidateColumnnames(List<string> columnnames)
        {
            if (Columnnames.Distinct().Count() != Columnnames.Count)
                throw new InvalidOperationException("De tabel bevat dubbele kolomnamen (of meerdere kolommen zonder naam).");


            // Check for columns without a name or only spaces
            for (int i = 0; i < columnnames.Count; i++)
            {
                var columnName = columnnames[i];
                if (String.IsNullOrEmpty(columnName))
                    throw new FormatException(String.Format("Kolom {0} in tabel '{1}' heeft geen geldige naam", i, CurrentTable.Id));
            }
        }

        #endregion


        #region Implementation of IDisposable

        /// <summary>
        /// Standard implementation of Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Perform the real dispose
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                //if (localBrowser != null)
                //{
                //    localBrowser.Dispose();
                //    localBrowser = null;
                //}
            }
        }

        #endregion
    }

}
