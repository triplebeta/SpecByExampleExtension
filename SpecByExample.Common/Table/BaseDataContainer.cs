using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;
using System.Data.Common;

namespace SpecByExample.Common
{
    /// <summary>
    /// Baseclass for all Containers that store information.
    /// Use this container for calling scenarios.
    /// Then, use the Adapter pattern to adapt the data to your own container format.
    /// For more information: http://www.dofactory.com/Patterns/PatternAdapter.aspx
    /// </summary>
    [System.ComponentModel.DesignerCategory("")]
    public abstract class BaseDataContainer<TRowType> : DataTable, IBaseDatacontainer<TRowType>
            where TRowType : IBaseDataRow, new()
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public BaseDataContainer()
        {
            ComposeColumns();
        }


        /// <summary>
        /// Returns a newly created empty instance of its row.
        /// </summary>
        /// <returns>A new instance of the entity that wraps a row of this container.</returns>
        public TRowType NewRowEntity()
        {
            var row = NewRow();
            var entity = new TRowType();
            entity.Initialize(row);
            return entity;
        }


        /// <summary>
        /// Adds the item to the container.
        /// </summary>
        public void AddRowEntity(TRowType entity)
        {
            // Append the row to the table
            Rows.Add(entity.CurrentRow);
        }


        /// <summary>
        /// Get an entity wrapping the row at the given index.
        /// </summary>
        /// <param name="index">Number of the row.</param>
        /// <returns>An instance of TRowType</returns>
        public TRowType GetRow(int index)
        {
            if (index >= Rows.Count) throw new IndexOutOfRangeException("Index of row is out of range.");
            TRowType entity = new TRowType();
            entity.Initialize(Rows[index]);
            return entity;
        }


        /// <summary>
        /// Creates a fully initialized instance of a DataAdapter to work with this dataset.
        /// </summary>
        /// <param name="connection">The connection to be used by the adapter.</param>
        /// <param name="tablename">Name of the table to work on.</param>
        /// <param name="transaction">Optional: the transaction to use for these commands.</param>
        /// <returns>A fully initialized instance of a data adapter.</returns>
        /// <remarks>
        /// The adapter only supports INSERT and SELECT since we do not know any keys.
        /// </remarks>
        public OleDbDataAdapter CreateDataAdapter(OleDbConnection connection, string tablename, DbTransaction transaction = null)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (tablename == null) throw new ArgumentNullException("tablename");

            var columnNames = new List<string>();
            foreach(DataColumn column in Columns)
                columnNames.Add(column.ColumnName);

            // Create a column mapping for the columns of this dataset.
            string fields = Join(",", columnNames.ToArray<string>());

            string sqlSelect = String.Format("SELECT {0} FROM [{1}]", fields, tablename);
            var sqlCmd = new OleDbCommand(sqlSelect,connection);

            // Create the adapter using the SQL Select command
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlCmd);

            // Transaction must be assigned before calling GetInsertCommand etc..
            if (transaction != null)
                adapter.SelectCommand.Transaction = transaction as OleDbTransaction;

            // Add the commands for INSERT, UPDATE and DELETE
            OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
            adapter.InsertCommand = builder.GetInsertCommand(true);
//            adapter.UpdateCommand = builder.GetUpdateCommand(true);
//            adapter.DeleteCommand = builder.GetDeleteCommand(true);

            if (transaction != null)
            {
                if (adapter.InsertCommand!=null) adapter.InsertCommand.Transaction = transaction as OleDbTransaction;
                if (adapter.UpdateCommand != null) adapter.UpdateCommand.Transaction = transaction as OleDbTransaction;
                if (adapter.DeleteCommand != null) adapter.DeleteCommand.Transaction = transaction as OleDbTransaction;
            }
            return adapter;
        }


        /// <summary>
        /// Creates a column for each field in the TRowType entity that has
        /// the Field mapping attribute.
        /// </summary>
        protected virtual void ComposeColumns()
        {
            Debug.WriteLine("Composing columns for container " + this.GetType().Name);
            Debug.Indent();
            try
            {
                // Get all fields, using reflection
                FieldInfo[] oFields = typeof(TRowType).GetFields();
                FieldInfo oField;
                Attribute[] attributes;
                try
                {
                    // Add a column for each field
                    for (int i = 0; i < oFields.Length; i++)
                    {
                        oField = oFields[i];
                        attributes = Attribute.GetCustomAttributes(oField, typeof(FieldMappingAttribute), false);
                        if (attributes.Count() == 1)
                        {
                            string columnName;
                            FieldMappingAttribute attr = (FieldMappingAttribute) attributes[0];
                            if (String.IsNullOrEmpty(attr.ColumnName))
                                columnName = oField.Name;
                            else
                                columnName = attr.ColumnName;

                            // TODO Implement a more robust check here.
                            // Set the type. If the field is of type Uri: store it in a string field.
                            Type columnType = oField.FieldType;
                            if (columnType == typeof(Uri))
                                columnType = typeof(string);

                            // Detect nullable types and in that case: use their base non-nullabel type
                            if (columnType.IsGenericType && columnType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            {
                                NullableConverter nc = new NullableConverter(columnType);
                                columnType = nc.UnderlyingType;
                            }
                            DataColumn column = new DataColumn(columnName, columnType);
                            this.Columns.Add(column);
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("BaseDataContainer.ComposeColumns: " + e.Message);
                    throw;
                }
            }
            finally
            {
                Debug.Unindent();
            }
        }


        #region Private helper routines

        /// <summary>
        /// Joins strings to one big string with separators between them.
        /// </summary>
        /// <param name="separator">Separator</param>
        /// <param name="items">All items to add.</param>
        /// <returns>One big string.</returns>
        public string Join(string separator, string[] items)
        {
            if (items.Length == 0) return "";

            StringBuilder sb = new StringBuilder();
            sb.Append(items[0]);
            for (int i = 1; i < items.Length; i++)
                sb.AppendFormat("{0}{1}", separator, items[i]);
            return sb.ToString();
        }

        #endregion
    }
}
