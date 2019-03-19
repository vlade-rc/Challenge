namespace GBM.Repository.Mongo
{

    using System.Threading.Tasks;
    using GBM.Infrastructure.UnitOfWork;
    using System.Collections.Generic;
    using System.Data;
    using GBM.Infrastructure.Repository;
    using GBM.Infrastructure.Domain;
    using GBM.Infrastructure.Filter;
    using System.Linq.Expressions;
    using System;

    /// <summary>Clase del Repositorio de Sql</summary>
    /// <typeparam name="T">Hace referencia al tipo de entidad</typeparam>
    public abstract class RepositoryBase<T> : IRepository<T, object>, IUnitOfWorkRepository where T: IEntity
    {

        /// <summary>Hace referencia a la unidad de trabajo</summary>
        private IUnitOfWork<object> unitOfWork;

        /// <summary>Inicializa un objeto del tipo RepositorySql</summary>
        /// <param name="unitOfWork">Hace referencia a la unidad de trabajo</param>
        protected RepositoryBase(IUnitOfWork<object> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>Método para establecer la unidad de trabajo</summary>
        /// <param name="unitOfWork">Hace referencia a la unidad de trabajo</param>
        public void SetUnitOfWork(IUnitOfWork<object> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

       

      

        /// <summary>Agrega nuevo elemento a la base de datos</summary>
        /// <param name="item">Hace referencia al  tipo de objeto</param>
        public void Add(T item)
        {
            if (this.unitOfWork != null)
            {
                this.unitOfWork.RegisterAdded(item, this);
            }
        }

        /// <summary>Elimina un registro de la base de datos</summary>
        /// <param name="item">Hace referencia al tipo de objeto</param>
        public void Remove(T item)
        {
            if (this.unitOfWork != null)
            {
                this.unitOfWork.RegisterRemoved(item, this);
            }
        }

        /// <summary>Método que actualiza un  registro</summary>
        /// <param name="item">Hace referencia al tipo de registro</param>
        public void Update(T item, IFilter predicateMatch = null) 
        {
            if (this.unitOfWork != null)
            {
                this.unitOfWork.RegisterChanged(item, this, predicateMatch);
            }
        }


        /// <summary>método para persistir un nuevo elemento</summary>
        /// <param name="item">Hace refenrecia al objeto a insertar</param>
        public virtual async Task PersistNewItem(IEntity item)
        {
            await this.PersistNewItem((T)item);
        }

        /// <summary>Método que persiste la actualización del registro</summary>
        /// <param name="item">Hace referencia al objeto a actualizar</param>
        public virtual async Task PersistUpdatedItem(IEntity item, IFilter predicateMatch)
        {
            await this.PersistUpdatedItem((T)item, predicateMatch);
        }


        /// <summary>Método que persiste la eliminación de un registro</summary>
        /// <param name="item">Hace referencia al registro a eleminar</param>
        public virtual async Task PersistDeletedItem(IEntity item)
        {
            await this.PersistDeletedItem(item);
        }

        /// <summary>Hace referencia a la unidad de trabajo</summary>
        protected IUnitOfWork<object> UnitOfWork
        {
            get { return this.unitOfWork; }
        }


        /// <summary>Método para persistir un nuevo elemento</summary>
        /// <param name="item">Hace referencia al objeto a insertar</param>
        protected abstract Task PersistNewItem(T item);


        protected abstract Task PersistUpdatedItem(T item, IFilter predicateMatch);
      

    }
}
