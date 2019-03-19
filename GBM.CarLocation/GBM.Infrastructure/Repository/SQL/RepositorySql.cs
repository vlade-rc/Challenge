namespace GBM.Infrastructure.Repository.SQL
{

    using System.Threading.Tasks;
    using Domain;
    using Filter;
    using UnitOfWork;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>Clase del Repositorio de Sql</summary>
    /// <typeparam name="T">Hace referencia al tipo de entidad</typeparam>
    public abstract class RepositorySql<T>
        : IRepository<T, IDbConnection>, IUnitOfWorkRepository where T : IEntity
    {

        /// <summary>Hace referencia a la unidad de trabajo</summary>
        private IUnitOfWork<IDbConnection> unitOfWork;

        /// <summary>Inicializa un objeto del tipo RepositorySql</summary>
        /// <param name="unitOfWork">Hace referencia a la unidad de trabajo</param>
        protected RepositorySql(IUnitOfWork<IDbConnection> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>Método para establecer la unidad de trabajo</summary>
        /// <param name="unitOfWork">Hace referencia a la unidad de trabajo</param>
        public void SetUnitOfWork(IUnitOfWork<IDbConnection> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary> Método para recuperar un registro desde la base de datos </summary>
        /// <param name="key">Hace referencia al filtro que se utilizara para recuperar el registro</param>
        /// <returns>Regresa el registro recuperado desde la base de datos</returns>
        public abstract Task<T> FindItemBy(IFilter key);

        /// <summary> Método para recuperar una lista de registros desde la base de datos </summary>
        /// <param name="key">Hace referencia al filtro que se utilizara para recuperar la lista de registros</param>
        /// <returns>Regresa la lista de registros recuperados desde la base de datos</returns>
        public abstract Task<List<T>> FindListBy(IFilter key);

      

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
        public void Update(T item)
        {
            if (this.unitOfWork != null)
            {
                this.unitOfWork.RegisterChanged(item, this);
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
        public virtual async Task PersistUpdatedItem(IEntity item)
        {
            await this.PersistUpdatedItem((T)item);
        }


        /// <summary>Método que persiste la eliminación de un registro</summary>
        /// <param name="item">Hace referencia al registro a eleminar</param>
        public virtual async Task PersistDeletedItem(IEntity item)
        {
            await this.PersistDeletedItem((T)item);
        }

        /// <summary>Hace referencia a la unidad de trabajo</summary>
        protected IUnitOfWork<IDbConnection> UnitOfWork
        {
            get { return this.unitOfWork; }
        }


        /// <summary>Método para persistir un nuevo elemento</summary>
        /// <param name="item">Hace referencia al objeto a insertar</param>
        protected abstract Task PersistNewItem(T item);
        /// <summary>Método que persiste la actualización de un registro</summary>
        /// <param name="item">Hace referencia al objeto a actualizar</param>
        protected abstract Task PersistUpdatedItem(T item);

        /// <summary>Método para persistir la eliminación de un registro</summary>
        /// <param name="item">Hace referencia al objeto a eliminar</param>
        protected abstract Task PersistDeletedItem(T item);
    }
}
