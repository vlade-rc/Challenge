namespace ERHANA.KRAKEN.Infrastructure.Repository.SQL
{
    using System.Collections.Generic;
    using System.Data.SqlClient;

    /// <summary>Clase de procedimientos almacenado</summary>
    /// <typeparam name="T">Hace referencia al tipo de entidad</typeparam>
    public class SQLProcedure<T> where T : class
    {

        /// <summary>Hace referencia al identificador del procedimiento almacenado</summary>
        public string StoredProcedureIdentifier { get; set; }

        /// <summary>Hace referencia a la lista de parámetros</summary>
       private List<SqlParameter> parameters { get; set; }

        /// <summary>Hace referencia a la lista de parámetros</summary>
        public List<SqlParameter> Parameters => parameters;
        /// <summary>Hace referencia al builder de la entidad</summary>
        private IEntityBuilder<T> builder;

        public IEntityBuilder<T> Builder => builder;       

        /// <summary>Agrega un parámetro a la lista</summary>
        /// <param name="name">Hace referencia al nombre del parámetro</param>
        /// <param name="value">Hace referencia al valor del parámetro</param>
        public void AddParameter(string name, object value)
        {
            parameters = parameters ?? new List<SqlParameter>();
            parameters.Add(new SqlParameter(name, value));
        }

        /// <summary>Agrega un builder</summary>
        /// <param name="builderIn">Hace referencia al tipo de entidad</param>
        public void AddBuilder(IEntityBuilder<T> builderIn)
        {
            this.builder = builderIn;
        }

        /// <summary>Agrega los parámetro de página de consulta</summary>
        /// <param name="page">Hace referencia al número de página</param>
        /// <param name="pageSize">Hace referencia al total de elementos por página</param>
        private void addPagingParameters(int page, int pageSize)
        {
            parameters = parameters ?? new List<SqlParameter>();
            parameters.Add(new SqlParameter(SqlProcedureResource.Page, page));
            parameters.Add(new SqlParameter(SqlProcedureResource.PageSize, pageSize));
        }

        /// <summary>Método que agrega los parámetros de página en la consulta</summary>
        /// <param name="filter">Hace referencia a la información del filtro</param>
        public void AddFilterType(IFilter filter)
        {
            if (filter.FilterType == FilterTypes.Paged)
            {
                addPagingParameters(filter.Page, filter.PageSize);
            }
        }
    }
}
