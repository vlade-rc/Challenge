namespace ERHANA.KRAKEN.Infrastructure.Helpers
{
    using GBM.Infrastructure.Domain;
    using GBM.Infrastructure.Resources;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    /// <summary>
    ///     Clase statica para facilitar la lectura de DataReaders desde ADO.NET
    /// </summary>
    public static class DataHelper
    {
        /// <summary>Hace referencia a una fecha predefinida como mínima</summary>
        private static readonly string MinSqlDateValue = SqlDataValues.MinSqlDateValue;

        #region "Métodos de ayuda de datos estáticos"

        /// <summary>Método para obtener un dato del tipo Datetime</summary>
        /// <param name="value">Hace referencia a un valor a convertir</param>
        public static DateTime GetDateTime(object value)
        {
            DateTime dateValue = DateTime.MinValue;
            if ((value != null) && (value != DBNull.Value))
            {
                if ((DateTime)value > DateTime.Parse(DataHelper.MinSqlDateValue))
                {
                    dateValue = (DateTime)value;
                }
            }
            return dateValue;
        }

        /// <summary>Método para obtener un valor del tipo DateTime?</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static DateTime? GetNullableDateTime(object value)
        {
            DateTime? dateTimeValue = null;
            DateTime dbDateTimeValue;
            if (value != null && !Convert.IsDBNull(value))
            {
                if (DateTime.TryParse(value.ToString(), out dbDateTimeValue))
                {
                    dateTimeValue = dbDateTimeValue;
                }
            }
            return dateTimeValue;
        }

        public static DateTimeOffset? GetNullableDateTimeOffset(object value)
        {
            DateTimeOffset? dateTimeValue = null;
            DateTimeOffset dbDateTimeValue;
            if (value != null && !Convert.IsDBNull(value))
            {
                if (DateTimeOffset.TryParse(value.ToString(), out dbDateTimeValue))
                {
                    dateTimeValue = dbDateTimeValue;
                }
            }
            return dateTimeValue;
        }

        /// <summary>Método para obtener un valor del tipo int</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static int GetInteger(object value)
        {
            int integerValue = 0;
            if (value != null && !Convert.IsDBNull(value))
            {
                int.TryParse(value.ToString(), out integerValue);
            }
            return integerValue;
        }

        /// <summary>Método para obtener un valor del tipo Nullable&lt;int&gt;</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static int? GetNullableInteger(object value)
        {
            int? integerValue = null;
            int parseIntegerValue = 0;
            if (value != null && !Convert.IsDBNull(value))
            {
                if (int.TryParse(value.ToString(), out parseIntegerValue))
                {
                    integerValue = parseIntegerValue;
                }
            }
            return integerValue;
        }

        /// <summary>Método para obtener un valor del tipo decimal</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static decimal GetDecimal(object value)
        {
            decimal decimalValue = 0;
            if (value != null && !Convert.IsDBNull(value))
            {
                decimal.TryParse(value.ToString(), out decimalValue);
            }
            return decimalValue;
        }

        /// <summary>Método para obtener un valor del tipo Nullable&lt;decimal&gt;</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static decimal? GetNullableDecimal(object value)
        {
            decimal? decimalValue = null;
            decimal parseDecimalValue = 0;
            if (value != null && !Convert.IsDBNull(value))
            {
                if (decimal.TryParse(value.ToString(), out parseDecimalValue))
                {
                    decimalValue = parseDecimalValue;
                }
            }
            return decimalValue;
        }

        /// <summary>Método para obtener un valor del tipo double</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static double GetDouble(object value)
        {
            double doubleValue = 0;
            if (value != null && !Convert.IsDBNull(value))
            {
                double.TryParse(value.ToString(), out doubleValue);
            }
            return doubleValue;
        }

        /// <summary>Método para obtener un valor del tipo Nullable&lt;double&gt;</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static double? GetNullableDouble(object value)
        {
            double? doubleValue = null;
            double parseDoubleValue = 0;
            if (value != null && !Convert.IsDBNull(value))
            {
                if (double.TryParse(value.ToString(), out parseDoubleValue))
                {
                    doubleValue = parseDoubleValue;
                }
            }

            return doubleValue;
        }

        /// <summary>Método para obtener un  valor del tipo Guid</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static Guid GetGuid(object value)
        {
            Guid guidValue = Guid.Empty;
            if (value != null && !Convert.IsDBNull(value))
            {
                guidValue = new Guid(value.ToString());

            }
            return guidValue;
        }

        /// <summary>Método para obtener un valor del tipo Nullable&lt;Guid&gt;</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static Guid? GetNullableGuid(object value)
        {
            Guid? guidValue = null;
            if (value != null && !Convert.IsDBNull(value))
            {

                guidValue = new Guid(value.ToString());

            }
            return guidValue;
        }

        /// <summary>Método para obtener un valor del tipo string</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static string GetString(object value)
        {
            string stringValue = string.Empty;
            if (value != null && !Convert.IsDBNull(value))
            {
                stringValue = value.ToString().Trim();
            }
            return stringValue;
        }

        /// <summary>Método para obtener un valor del tipo bool</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static bool GetBoolean(object value)
        {
            bool bReturn = false;
            if (value != null && value != DBNull.Value)
            {
                bReturn = Convert.ToBoolean(value);
            }
            return bReturn;
        }

        /// <summary>Método que obtiene un valor del tipo Nullable&lt;bool&gt;</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static bool? GetNullableBoolean(object value)
        {
            bool? bReturn = null;
            if (value != null && value != DBNull.Value)
            {
                bReturn = (bool)value;
            }

            return bReturn;
        }

        /// <summary>Método para obtener un valor del tipo Enum</summary>
        /// <typeparam name="T">Hace referencia al tipo de enumerador</typeparam>
        /// <param name="databaseValue">Hace referencia al valor a convertir</param>
        public static T GetEnumValue<T>(object databaseValue) where T : struct
        {
            T enumValue = default(T);

            if (databaseValue != null && databaseValue.ToString().Length > 0)
            {
                object parsedValue = Enum.Parse(typeof(T), databaseValue.ToString());
                if (parsedValue != null)
                {
                    enumValue = (T)parsedValue;
                }
            }

            return enumValue;
        }

        /// <summary>Método para obtener un arreglo del tipo byte</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static byte[] GetByteArrayValue(object value)
        {
            byte[] arrayValue = null;
            if (value != null && value != DBNull.Value)
            {
                arrayValue = (byte[])value;
            }
            return arrayValue;
        }

        /// <summary>Método para covertir una lista de entidades a un string</summary>
        /// <typeparam name="T">Hace referencia a la entidad  a convertir</typeparam>
        /// <param name="entities">Hace referencia a una lista de entidades a convertir</param>
        public static string EntityListToDelimited<T>(IList<T> entities) where T : IEntity
        {
            StringBuilder builder = new StringBuilder(20);
            if (entities != null)
            {
                for (int index = 0; index < entities.Count; index++)
                {
                    if (index > 0)
                    {
                        builder.Append(",");
                    }
                    builder.Append(entities[index].Identifier);
                }
            }
            return builder.ToString();
        }

        /// <summary>Método para validar si un reader contiene una columna</summary>
        /// <param name="schemaTable">Hace referencia al datatable</param>
        /// <param name="columnName">Hace referencia al nombre de la columna</param>
        public static bool ReaderContainsColumnName(DataTable schemaTable, string columnName)
        {
            bool containsColumnName = false;
            foreach (DataRow row in schemaTable.Rows)
            {
                if (row["ColumnName"].ToString() == columnName)
                {
                    containsColumnName = true;
                    break;
                }
            }
            return containsColumnName;
        }

        /// <summary>Método para obtener un valor del tipo object</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static object GetSqlValue(object value)
        {
            if (value != null)
            {
                if (value is Guid)
                {
                    return GetSqlValue((Guid)value);
                }
                else
                {
                    return value;
                }
            }
            else
            {
                return SqlDataValues.NULL;
            }
        }

        /// <summary>Método para obtener un valor del tipo object</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static object GetSqlValue(string value)
        {
            if (value != null)
            {
                return string.Format(SqlDataValues.NFormat, value.Replace("'", "''"));
            }
            else
            {
                return SqlDataValues.NULL;
            }
        }
        /// <summary>Método para obtener un valor del tipo object</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static object GetSqlValue(DateTime value)
        {
            if (value != null)
            {
                if (value == DateTime.MinValue)
                {
                    return string.Format(SqlDataValues.Format,
                        DataHelper.MinSqlDateValue);
                }
                return string.Format(SqlDataValues.Format, value.ToString());
            }
            else
            {
                return "NULL";
            }
        }
        /// <summary>Método para obtener un valor del tipo object</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static object GetSqlValue(DateTime? value)
        {
            if (value.HasValue)
            {
                return DataHelper.GetSqlValue(value.Value);
            }
            else
            {
                return SqlDataValues.NULL;
            }
        }
        /// <summary>Método para obtener un valor del tipo object</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static object GetSqlValue(bool value)
        {
            return value ? "1" : "0";
        }
        /// <summary>Método para obtener un valor del tipo object</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static object GetSqlValue(Guid value)
        {
            if (value != null)
            {
                return string.Format(SqlDataValues.Format, value.ToString());
            }
            else
            {
                return SqlDataValues.NULL;
            }
        }
        /// <summary>Método para obtener un valor del tipo object</summary>
        /// <param name="value">Hace referencia al valor a convertir</param>
        public static object GetSqlValue(Enum value)
        {
            if (value != null)
            {
                return DataHelper.GetSqlValue(value.ToString());
            }
            else
            {
                return "NULL";
            }
        }

        #endregion
    }
}
