namespace ERHANA.KRAKEN.Infrastructure.Helpers
{
    using System.Data;

    /// <summary>Contrato para el builder de entidades</summary>
    /// <typeparam name="T">Hace referencia al tipo de entidad a construir</typeparam>
    public interface IEntityBuilder<T> where T : class
    {
        /// <summary>Método para crear una entidad</summary>
        /// <param name="reader">Hace referencia al datareader</param>
        T BuildEntity(IDataReader reader);
    }
}
