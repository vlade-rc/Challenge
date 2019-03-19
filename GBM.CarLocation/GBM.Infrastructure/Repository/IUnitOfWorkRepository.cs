namespace GBM.Infrastructure.Repository
{
    using GBM.Infrastructure.Domain;
    using GBM.Infrastructure.Filter;
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    /// <summary>Contrato de operaciones del repositorio de la unidad de trabajo</summary>
    public interface IUnitOfWorkRepository
    {
        /// <summary>Hace la persistencia de un nuevo elemento</summary>
        /// <param name="item">Hace referencia a la entidad a persistir</param>
        Task PersistNewItem(IEntity item);
        /// <summary>Hace la persistencia de la actualización de un elemento</summary>
        /// <param name="item">Hace referencia a la entidad a actualizar</param>
        Task PersistUpdatedItem(IEntity item, IFilter teMatch = null);
        /// <summary>Hace la persistencia de la eliminación de un registro</summary>
        /// <param name="item">Hace referencia al elemento a eliminar</param>
        Task PersistDeletedItem(IEntity item);

       
    }
}
