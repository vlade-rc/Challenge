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

    /// <summary>Clase de la unidad de trabajo de Ado Sql</summary>
    public class UnitOfWorkMongo : IUnitOfWork<IDbConnection>
    {
        /// <summary>Hace referencia al identificador de la transacción</summary>
        private Guid key;
        /// <summary>Hace referecia a la lista de operaciones</summary>
        private List<Operation> operations;

        /// <summary>Hace referencia al contexto de base de datos</summary>
        public IDbConnection Context { get; set; }
        /// <summary>Inicializa un objeto del tipo UnitOfWorkAdoSql</summary>
        public UnitOfWorkMongo()
        {
            this.key = Guid.NewGuid();
            this.operations = new List<Operation>();
        }       

        /// <summary>
        /// Registers an <see cref="IEntity" /> instance to be added through this <see cref="UnitOfWork" />.
        /// </summary>
        /// <param name="entity">The <see cref="IEntity" />.</param>
        /// <param name="repository">The <see cref="IUnitOfWorkRepository" /> participating in the transaction.</param>
        public void RegisterAdded(IEntity entity,
            IUnitOfWorkRepository repository)
        {
            this.operations.Add(
                new Operation
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
        public void RegisterChanged(IEntity entity,
            IUnitOfWorkRepository repository)
        {
            this.operations.Add(
                new Operation
                {
                    Entity = entity,
                    ProcessDate = DateTime.Now,
                    Repository = repository,
                    Type = TransactionType.Update
                });
        }

        /// <summary>
        /// Registers an <see cref="IEntity" /> instance to be removed through this <see cref="UnitOfWork" />.
        /// </summary>
        /// <param name="entity">The <see cref="IEntity" />.</param>
        /// <param name="repository">The <see cref="IUnitOfWorkRepository" /> participating in the transaction.</param>
        public void RegisterRemoved(IEntity entity,
            IUnitOfWorkRepository repository)
        {
            this.operations.Add(
                new Operation
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
            var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
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
                            await operation.Repository.PersistUpdatedItem(operation.Entity);
                            break;
                    }
                }
                // Commit the transaction
                scope.Complete();
            }
            finally
            {
                if(scope != null)
                {
                    scope.Dispose();
                }
                // Clear everything
                this.operations.Clear();
                this.key = Guid.NewGuid();
                if (Context != null)
                {
                    Context.Dispose();
                }
            }

        }

        /// <summary>Hace referencia al identificar de las transacciones</summary>
        public object Key
        {
            get { return this.key; }
        }
    }
}