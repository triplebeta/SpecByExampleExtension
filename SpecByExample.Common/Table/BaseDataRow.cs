using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Data;

namespace SpecByExample.Common
{
    /// <summary>
    /// Base class for all the entities that wrap a DataRow
    /// </summary>
    /// <remarks>
    /// Original code comes from: http://www.eggheadcafe.com/articles/20040221.asp
    /// </remarks>
    public abstract class BaseDataRow<TEnum> : IBaseDataRow
    {
        // Info about all fields of this row and the enumerator items mapped to them.
        // All info is extracted from the attributes assigned to them.
        private static object[,] _enumMappingInfo;

        // Info about how a class-field is mapped onto a DataRow field.
        private static object[,] _fieldMappingInfo;

        /// <summary>
        /// Constructor. After calling the constructor, you MUST call Initialize.
        /// </summary>
        public BaseDataRow()
        {
            // Nothing to do here
        }

        // TODO Implement a check in this code to make sure Initialize was called properly

        /// <summary>
        /// Fieldmapping information from the BaseEnumMappingAttribute attributes.
        /// </summary>
        public object[,] EnumMappingInfo
        {
            get
            {
                if (_enumMappingInfo == null)
                    _enumMappingInfo = GetFieldsWithAttribute<BaseEnumMappingAttribute>();
                return _enumMappingInfo;
            }
        }

        /// <summary>
        /// Fieldmapping information from the FieldMappingAttribute attributes.
        /// </summary>
        protected object[,] FieldMappingInfo
        {
            get
            {
                if (_fieldMappingInfo == null)
                    _fieldMappingInfo = GetFieldsWithAttribute<FieldMappingAttribute>();
                return _fieldMappingInfo;
            }
        }


        /// <summary>
        /// Initialize the entity.
        /// </summary>
        /// <param name="row"></param>
        public void Initialize(DataRow row)
        {
            // Set all properties from the fields
            CurrentRow = row;
            SetFields(FieldMappingInfo, row);
        }


        /// <summary>
        /// The DataRow instance encapsulated in this class.
        /// </summary>
        public DataRow CurrentRow
        {
            private set;
            get;
        }

        /// <summary>
        /// Set the field
        /// </summary>
        /// <typeparam name="TEnumType">Column enumerator type.</typeparam>
        /// <param name="enumItem">Item of the column enumerator</param>
        /// <param name="value">Value to store in this field</param>
        public void SetValue<TEnumType>(TEnumType enumItem, object value)
        {
            // Set the field
            if (typeof(TEnum) != typeof(TEnumType))
                throw new InvalidOperationException("The call to SetValue<> must get the same enumerator type as its containing row instance.");
            if (CurrentRow == null) throw new InvalidOperationException("CurrentRow propery must be initialized before calling SetValue.");

            SetFieldValue<TEnumType>(EnumMappingInfo, enumItem.ToString(), value);
        }


        /// <summary>
        /// Get the Type of the field that's mapped to the given enumerator item.
        /// </summary>
        /// <param name="enumItem">Enumerator item that points to a field.</param>
        /// <returns>Datatype of the field mapped by this enumerator item.</returns>
        public Type GetFieldType<TEnumType>(TEnumType enumItem)
        {
            // Set the field
            if (typeof(TEnum) != typeof(TEnumType))
                throw new InvalidOperationException("The call to SetValue<> must get the same enumerator type as its containing row instance.");

            var field = GetFieldByEnum<TEnumType>(EnumMappingInfo, enumItem);
            if (field == null)
                throw new InvalidOperationException("Field not found!");
            else
            {
                return field.FieldType;
            }
        }



        #region Protected methods

        /// <summary>
        /// Get the values of all fields in this record
        /// </summary>
        /// <typeparam name="TAttr">Type of the attributes to search for.</typeparam>
        /// <returns>An array containing the fields and their attributes.</returns>
        protected object[,] GetFieldsWithAttribute<TAttr>() where TAttr: System.Attribute
        {
            FieldInfo[] oFields = this.GetType().GetFields();
            FieldInfo oField;
            Attribute[] attributes;
            object[,] StructureInfo = new object[oFields.Length, 2];

            try
            {
                for (int i = 0; i < oFields.Length; i++)
                {
                    oField = oFields[i];
                    attributes = Attribute.GetCustomAttributes(oField, typeof(TAttr), false);
                    StructureInfo[i, 0] = oField;
                    StructureInfo[i, 1] = attributes;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            return StructureInfo;
        }


        /// <summary>
        /// Set the value of the field of which the Enumerator-mapping attribute equals the given enumName.
        /// </summary>
        /// <param name="StructureInfo">All information of the fields</param>
        /// <param name="enumName">Enumerator-item as a string</param>
        /// <param name="value">Value to assign to this field.</param>
        /// <remarks>
        /// We have to use strings since generics are not supported.
        /// </remarks>
        protected void SetFieldValue<TEnumType>(object[,] StructureInfo, string enumName, object value)
        {
            // TODO Add support for explicitly clearing a field by assigning null to it.
            // If null: do not assign the field since we cannot detect its type
            if (value==null) return;

            bool found = false;
            FieldInfo oField;
            Attribute[] attributes;
            try
            {
                // Loop all fields of the given type
                for (int i = 0; i <= StructureInfo.GetUpperBound(0); i++)
                {
                    oField = (FieldInfo)StructureInfo[i, 0];
                    attributes = (Attribute[])StructureInfo[i, 1];
                    
                    // For each field: check all its attributes to see if it maps the field
                    // to the current enumerator item.
                    foreach (Attribute attribute in attributes)
                    {
                        var oColumnAttributeName = attribute as BaseEnumMappingAttribute;
                        if (oColumnAttributeName.IsEnumValueString(enumName))
                        {
                            // Get the column name. It's the name of the field OR the alternative columnname
                            // assigned by the FieldMapping attribute.
                            bool isStored = false;
                            string columnName = FindColumnNameByFieldname(_fieldMappingInfo, oField.Name);

                            // Set the underlying field AND the property
                            if (oField.FieldType == typeof(int))
                            {
                                CurrentRow[columnName] = (int)value;
                                oField.SetValue(this, (int)value);
                                isStored = true;
                            }
                            else if (oField.FieldType == typeof(uint))
                            {
                                CurrentRow[columnName] = (uint)value;
                                oField.SetValue(this, value);
                                isStored = true;
                            }
                            else if (oField.FieldType == typeof(string))
                            {
                                CurrentRow[columnName] = value;
                                oField.SetValue(this, value);
                                isStored = true;
                            }
                            else if (oField.FieldType == typeof(bool))
                            {
                                CurrentRow[columnName] = (bool)value;
                                oField.SetValue(this, (bool)value);
                                isStored = true;
                            }
                            else if (oField.FieldType == typeof(Uri))
                            {
                                Uri url = value as Uri;
                                CurrentRow[columnName] = url.OriginalString;
                                oField.SetValue(this, url);
                                isStored = true;
                            }
                            else if (oField.FieldType == typeof(double))
                            {
                                CurrentRow[columnName] = (double)value;
                                oField.SetValue(this, (double)value);
                                isStored = true;
                            }
                            else if (oField.FieldType == typeof(float))
                            {
                                CurrentRow[columnName] = (float)value;
                                oField.SetValue(this, (float)value);
                                isStored = true;
                            }
                            else if (oField.FieldType == typeof(DateTime) || oField.FieldType == typeof(DateTime?))
                            {
                                // If passing in a string: try to convert it.
                                DateTime? dt = null;
                                bool isOke = false;
                                if (value.GetType() == oField.FieldType)
                                {
                                    if (value!=null)
                                        dt = (DateTime?)value;
                                    isOke = true;
                                }
                                else
                                {
                                    if (value.GetType() == typeof(string))
                                    {
                                        DateTime convDateTime;
                                        isOke = DateTime.TryParse((string)value, out convDateTime);
                                        if (isOke)
                                            dt = convDateTime;
                                    }
                                }
                                if (isOke)
                                {
                                    CurrentRow[columnName] = dt;
                                    oField.SetValue(this, dt);
                                    isStored = true;
                                }
                            }
                            else
                                throw new NotImplementedException("Setting the value for fields of type " + oField.FieldType.Name + " is not yet implemented by BaseDataRow.");

                            if (isStored == false)
                            {
                                string error = "Failed to store value '{0}' of type {1} in field {2} of type {3} or column {4}, conversion not supported";
                                throw new NotSupportedException(String.Format(error, value, value.GetType().Name, oField.Name, oField.FieldType.Name, columnName));
                            }

                            // Register that we found at least one item with a matching attribute.
                            found = true;
                            break;
                        }
                    }
                }

                // If none of the fields in the entity were mapped to this enumerator-item: raise an exception
                if (found == false)
                    throw new InvalidOperationException(String.Format("Entity {0} does not contain any field with a mapping to enumerator item {1}. Use the appropriate ....EnumMappingAttribute to define the mapping.",typeof(TEnumType).Name, enumName));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR in SetFieldValue<TEnumType>: " + ex.Message);
                throw new FormatException("Failed to store the value in the field " + enumName + " of a row.",ex);
            }
            return;
        }


        /// <summary>
        /// Set the fields from the datarow according
        /// </summary>
        /// <param name="StructureInfo"></param>
        /// <param name="oRow"></param>
        protected void SetFields(object[,] StructureInfo, DataRow oRow)
        {
            FieldInfo oField;
            Attribute[] attributes;

            try
            {
                for (int i = 0; i <= StructureInfo.GetUpperBound(0); i++)
                {
                    oField = (FieldInfo)StructureInfo[i, 0];
                    attributes = (Attribute[])StructureInfo[i, 1];

                    string columnName = String.Empty;
                    foreach (Attribute attribute in attributes)
                    {
                        if (attribute is FieldMappingAttribute)
                        {
                            FieldMappingAttribute columnAttribute = (FieldMappingAttribute)attribute;
                            if (String.IsNullOrEmpty(columnAttribute.ColumnName))
                                columnName = oField.Name;
                            else
                                columnName = columnAttribute.ColumnName;
                        }
                    }

                    // At this point we should know the columnname as well as the enumerator-item
                    if (oRow[columnName] != System.DBNull.Value)
                    {
                        // Detect the datatype and convert the value to it
                        if (oField.FieldType==typeof(Uri))
                        {
                            oField.SetValue(this, new Uri(oRow[columnName] as string));
                        }
                        else
                            oField.SetValue(this, oRow[columnName]);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            return;
        }


        /// <summary>
        /// Loop all FieldMapping attributes
        /// </summary>
        /// <param name="fieldmappingInfo">Information about the FieldMapping attributes.</param>
        /// <param name="fieldname">Name of the field to lookup for.</param>
        /// <returns>Name of the column</returns>
        private string FindColumnNameByFieldname(object[,] fieldmappingInfo, string fieldname)
        {
            for (int i = 0; i <= fieldmappingInfo.GetUpperBound(0); i++)
            {
                var oField = (FieldInfo)fieldmappingInfo[i, 0];
                if (oField.Name == fieldname)
                {
                    // For each field: check all its attributes to see if it maps the field
                    // to the current enumerator item.
                    var attributes = (Attribute[])fieldmappingInfo[i, 1];
                    foreach (Attribute attribute in attributes)
                    {
                        var oColumnAttributeName = attribute as FieldMappingAttribute;
                        if (String.IsNullOrEmpty(oColumnAttributeName.ColumnName) == false)
                            return oColumnAttributeName.ColumnName;
                    }
                }
            }
            return fieldname;
        }

        
        /// <summary>
        /// Find the field that's mapped to the given attribute
        /// </summary>
        /// <param name="enumMappingInfo">Info about the mapping of enumerator items to fields.</param>
        /// <param name="enumName">Enumerator item to look for.</param>
        /// <remarks>
        /// We have to use strings since generics are not supported.
        /// </remarks>
        public FieldInfo GetFieldByEnum<TEnumType>(object[,] enumMappingInfo, TEnumType enumName)
        {
            FieldInfo oField;
            Attribute[] attributes;
            for (int i = 0; i <= enumMappingInfo.GetUpperBound(0); i++)
            {
                oField = (FieldInfo)enumMappingInfo[i, 0];
                attributes = (Attribute[])enumMappingInfo[i, 1];

                foreach (Attribute attribute in attributes)
                {
                    var oColumnAttributeName = attribute as BaseEnumMappingAttribute;
                    if (oColumnAttributeName.IsEnumValueString(enumName.ToString()))
                    {
                        return oField;
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
