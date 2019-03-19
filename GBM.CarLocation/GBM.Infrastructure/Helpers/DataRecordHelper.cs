namespace ERHANA.KRAKEN.Infrastructure.Helpers
{

    using System;
    using System.Data;
    /// <summary>Clase para validar los datos de un datareader</summary>
    public static class DataRecordHelper
    {
        /// <summary>Método para validar el nombre de la columna en el datareader</summary>
        /// <param name="dataReader">Hace referencia al datareader</param>
        /// <param name="columnName">Hace referencia al nombre de la columna a validar</param>
        public static bool HasColumn(this IDataRecord dataReader, string columnName)
        {
            for (int index = 0; index < dataReader.FieldCount; index++)
            {
                if (dataReader.GetName(index).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
