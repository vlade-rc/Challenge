namespace GBM.Infrastructure.UnitOfWork
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Domain;
    using GBM.Infrastructure.Filter;
    using Repository;

    /// <summary>Contrato para la unidad de trabajo</summary>
    /// <typeparam name="TContext">Hace referencia al contexto de base de datos</typeparam>
    public interface IUnitOfWork<TContext> where TContext :class

    {
        /// <summary>Hace referencia al contexto de la base de datos</summary>
        TContext Context { get; set; }
        /// <summary>Método para el registro de una entidad</summary>
        /// <param name="entity">Hace referencia a la entidad</param>
        /// <param name="repository">Hace referencia al unidad de trAbajo</param>
        void RegisterAdded(IEntity entity, IUnitOfWorkRepository repository);
        /// <summary>Método que registro un cambio de una entidad</summary
        /// <param name="entity">Hace referencia a la entidad</param>
        /// <param name="repository">Hace referencia a la unidad de trabajo</param>
        void RegisterChanged(IEntity entity, IUnitOfWorkRepository repository, IFilter predicateMatch = null);
        /// <summary>Método que registra una eliminación</summary>
        /// <param name="entity">Hace referencia a la entidad</param>
        /// <param name="repository">Hace referencia a la unidad de trabajo</param>
        void RegisterRemoved(IEntity entity, IUnitOfWorkRepository repository);
        /// <summary>Método que realiza la ejecución de las operaciones</summary>
        Task CommitAsync();
        /// <summary>Hace referencia al identificador de la transacción</summary>
        object Key { get; }
        /// <summary>
        /// Liberación de recursos
        /// </summary>
        void Dispose();
    }
}
