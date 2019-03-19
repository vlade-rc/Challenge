namespace GBM.Infrastructure.Repository
{
    using GBM.Infrastructure.Domain;
    using System.Data;

    /// <summary>Contrato del repositorio de Sql</summary>
    /// <typeparam name="T">Hace referencia al tipo de entidad del repositorio</typeparam>
    public interface IRepositoryIDbConnection<T> : IRepository<T, object> where T : IEntity
    {
    }
}
