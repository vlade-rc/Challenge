namespace GBM.Infrastructure.Helpers
{
    using GBM.Infrastructure.Repository.SQL;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    /// <summary>
    ///     Helper para persistencia de datos
    /// </summary>
    public static class AdoHelper
    {

        /// <summary>Método para recuperar una lista de registros</summary>
        /// <typeparam name="T">Hace referencia al tipo de registro</typeparam>
        /// <param name="procedure">Hace referencia al procedimiento almacenado a ejecutar </param>
        /// <param name="connection">Hace referencia al sql conection</param>
        public static async Task<List<T>> FindList<T>(SQLProcedure<T> procedure, SqlConnection connection) where T : class
        {
            return await buildEntityListFromQuery(procedure, connection);
        }


        /// <summary>Método para recuperar un registro</summary>
        /// <typeparam name="T">Hace referencia al tipo de objeto a devolver</typeparam>
        /// <param name="procedure">Hace referencia al procedimiento almacenado a ejecutar</param>
        /// <param name="connection">Hace referencia al sql connection</param>
        public static async Task<T> FindItem<T>(SQLProcedure<T> procedure, SqlConnection connection) where T : class
        {

            return await buildEntityItemFromQuery(procedure, connection);
        }


        /// <summary>Método que ejecuta un query asíncrono</summary>
        /// <param name="procedure">Hace referencia al procedimiento almacenado a ejecutar</param>
        /// <param name="parameters">Hace referencia a la lista de parámetros</param>
        /// <param name="connection">Hace referencia al sql connection</param>
        public async static Task<int> ExecuteNonQueryAsync(string procedure, List<SqlParameter> parameters, SqlConnection connection)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand(procedure, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters.ToArray());
                return await command.ExecuteNonQueryAsync();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>Método que ejecuta el execute reader de forma asíncrona</summary>
        /// <typeparam name="T">Hace referencia al tipo de registro a devolver</typeparam>
        /// <param name="procedure">Hace referencia al procedimiento almacenado a ejecutar</param>
        /// <param name="connection">Hace referencia al sql connection</param>
        private static async Task<IDataReader> executeReaderAsync<T>(SQLProcedure<T> procedure, SqlConnection connection) where T : class
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand command = new SqlCommand(procedure.StoredProcedureIdentifier, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(procedure.Parameters.ToArray());
            return await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);
        }


        /// <summary>Método que crea una entidad tomando los datos del query</summary>
        /// <typeparam name="T">Hace referencia al tipo de entidad a devolver</typeparam>
        /// <param name="procedure">Hace referencia al procedimiento almacenado a ejecutar</param>
        /// <param name="connection">Hace referencia al sql connection</param>
        private static async Task<T> buildEntityItemFromQuery<T>(SQLProcedure<T> procedure, SqlConnection connection) where T : class
        {
            IDataReader reader = null;
            try
            {
                T entity = default(T);
                reader = await executeReaderAsync(procedure, connection);
                if (reader.Read())
                {
                    entity = BuildEntityFromReader(procedure.Builder, reader);
                }
                return entity;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }

                if (connection != null)
                {
                    connection.Dispose();
                }
            }

        }
        /// <summary>Método que crea una lista de entidades</summary>
        /// <typeparam name="T">Hace referencia a la entidad a devolver</typeparam>
        /// <param name="procedure">Hace referencia al procedimiento almacenado a ejecutar</param>
        /// <param name="connection">Hace referencia al sql connection</param>
        private static async Task<List<T>> buildEntityListFromQuery<T>(SQLProcedure<T> procedure, SqlConnection connection) where T : class
        {
            IDataReader reader = null;
            try
            {
                List<T> entities = new List<T>();
                reader = await executeReaderAsync(procedure, connection);

                while (reader.Read())
                {
                    entities.Add(BuildEntityFromReader(procedure.Builder, reader));
                }

                return entities;
            }
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }

                if (connection != null)
                {
                    connection.Dispose();
                }
            }

        }

        /// <summary>Método que crea un objeto desde un reader</summary>
        /// <typeparam name="T">Hace referencia al tipo de entifad a devolver</typeparam>
        /// <param name="builder">Hace referencia al builder</param>
        /// <param name="reader">Hace referencia al dataReader</param>
        private static T BuildEntityFromReader<T>(IEntityBuilder<T> builder, IDataReader reader) where T : class
        {
            return builder.BuildEntity(reader);
        }
    }
}
