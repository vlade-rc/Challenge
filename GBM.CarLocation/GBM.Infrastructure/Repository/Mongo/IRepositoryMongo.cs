namespace GBM.Infrastructure.Repository.Mongo
{
    using GBM.Infrastructure.Domain;
    using System.Data;

    /// <summary>Contrato del repositorio de Sql</summary>
    /// <typeparam name="T">Hace referencia al tipo de entidad del repositorio</typeparam>
    public interface IRepositoryMongo<T> : IRepository<T, IMongoDatabase> where T : IEntity
    {
    }
}
