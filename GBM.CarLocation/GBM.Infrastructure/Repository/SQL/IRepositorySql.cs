namespace ERHANA.KRAKEN.Infrastructure.Repository.SQL
{
    using GBM.Infrastructure.Domain;
    using GBM.Infrastructure.Repository;
    using System.Data;

    /// <summary>Contrato del repositorio de Sql</summary>
    /// <typeparam name="T">Hace referencia al tipo de entidad del repositorio</typeparam>
    public interface IRepositorySql<T> : IRepository<T, IDbConnection> where T : IEntity
    {
    }
}
