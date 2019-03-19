namespace GBM.Infrastructure.UnitOfWork
{
    using Domain;
    using GBM.Infrastructure.Repository;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using Enums;
    using System.Transactions;
    using System.Linq.Expressions;
    using GBM.Infrastructure.Filter;

    /// <summary>Clase de la unidad de trabajo de Ado Sql</summary>
    public abstract class  UnitOfWorkBase : IUnitOfWorkDbConnection
    {
        /// <summary>Hace referencia al identificador de la transacción</summary>
        private Guid key;
        /// <summary>Hace referecia a la lista de operaciones</summary>
        private List<Operation<IEntity>> operations;

        /// <summary>Hace referencia al contexto de base de datos</summary>
        public Object Context { get; set; }
        /// <summary>Inicializa un objeto del tipo UnitOfWorkAdoSql</summary>
        public UnitOfWorkBase()
        {
            this.key = Guid.NewGuid();
            this.operations = new List<Operation<IEntity>>();
        }

      

       
        /// <summary>
        /// Registers an <see cref="IEntity" /> instance to be added through this <see cref="UnitOfWork" />.
        /// </summary>
        /// <param name="entity">The <see cref="IEntity" />.</param>
        /// <param name="repository">The <see cref="IUnitOfWorkRepository" /> participating in the transaction.</param>
        public void RegisterAdded(IEntity entity, IUnitOfWorkRepository repository)
        {
            this.operations.Add(
                new Operation<IEntity>
                {
                    Entity = entity,
                    ProcessDate = DateTime.Now,
                    Repository = repository,
                    Type = TransactionType.Insert
                });
        }

       
        /// <summary>
        /// Registers an <see cref="IEntity" /> instance to be changed through this <see cref="UnitOfWork" />.
        /// </summary>
        /// <param name="entity">The <see cref="IEntity" />.</param>
        /// <param name="repository">The <see cref="IUnitOfWorkRepository" /> participating in the transaction.</param>
        public void RegisterChanged(IEntity entity, IUnitOfWorkRepository repository, IFilter predicateMatch = null)
        { 
            this.operations.Add(
                new Operation<IEntity>
                {
                    Entity = entity,
                    ProcessDate = DateTime.Now,
                    Repository = repository,
                    Type = TransactionType.Update,
                    predicateMatch = predicateMatch
                });
        }

        /// <summary>
        /// Registers an <see cref="IEntity" /> instance to be removed through this <see cref="UnitOfWork" />.
        /// </summary>
        /// <param name="entity">The <see cref="IEntity" />.</param>
        /// <param name="repository">The <see cref="IUnitOfWorkRepository" /> participating in the transaction.</param>
        public void RegisterRemoved(IEntity entity, IUnitOfWorkRepository repository) 
        {
            this.operations.Add(
                new Operation<IEntity>
                {
                    Entity = entity,
                    ProcessDate = DateTime.Now,
                    Repository = repository,
                    Type = TransactionType.Delete
                });
        }

        /// <summary>
        /// Commits all batched changes within the scope of a <see cref="TransactionScope" />.
        /// </summary>
        public async Task CommitAsync()
        {
         
                foreach (var operation in this.operations.OrderBy(operationItem => operationItem.ProcessDate))
                {
                    switch (operation.Type)
                    {
                        case TransactionType.Insert:
                            await operation.Repository.PersistNewItem(operation.Entity);
                            break;
                        case TransactionType.Delete:
                            await operation.Repository.PersistDeletedItem(operation.Entity);
                            break;
                        case TransactionType.Update:
                            await operation.Repository.PersistUpdatedItem(operation.Entity,operation.predicateMatch);
                            break;
                    }
                }
              

            

        }
        public  void Dispose()
        {
            // Clear everything
            this.operations.Clear();
            this.key = Guid.NewGuid();
            if (Context != null)
            {
                DisposeContext();
            }
        }
        public abstract void DisposeContext();



        /// <summary>Hace referencia al identificar de las transacciones</summary>
        public object Key
        {
            get { return this.key; }
        }
    }
}