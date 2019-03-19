namespace GBM.Infrastructure.Repository
{
    using UnitOfWork;
    using Domain;
    using Filter;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    using System;

    /// <summary>Contrato para el Repositorio generico</summary>
    /// <typeparam name="T">Hace referencia al tipo de entidad</typeparam>
    /// <typeparam name="TContext">Hace referencia al contexto de la base de datos</typeparam>
    public interface IRepository<T, TContext>   where T: IEntity where TContext : class
    {
        /// <summary>Método para establecer la unidad de trabajo</summary>
        /// <param name="unitOfWork">Hace referencia al contexto de la base de datos</param>
        void SetUnitOfWork(IUnitOfWork<object> unitOfWork);
      

        /// <summary>Método para agregar un registro a la base de datos</summary>
        /// <param name="item">Hace referencia al objeto que se agregara a la base de datos</param>
        void Add(T item);

        /// <summary> Método para eliminar un registro de la base de datos </summary>
        /// <param name="item">Hace referencia al registro que se eliminara de la base de datos</param>
        void Remove(T item);

        /// <summary>
        /// Permite actualizar una entidad
        /// </summary>
        /// <param name="item"></param>
        /// <param name="filterMatch">Expresión para filtrar el registro a actualizar</param>
        void Update(T item, IFilter filterMatch = null);

    }
}
