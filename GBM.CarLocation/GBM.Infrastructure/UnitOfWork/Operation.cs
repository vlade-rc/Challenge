namespace GBM.Infrastructure.UnitOfWork
{
    using Domain;
    using Enums;
    using Repository;
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Proporciona una instantánea de una entidad y la referencia del repositorio a la que pertenece
    /// </summary>
    public sealed class Operation<T> where T: IEntity 
    {
        /// <summary>Hace referencia a la entidad con la que se realizara la operación</summary>
        public IEntity Entity { get; set; }

        /// <summary>Hace referencia a la fecha de la operación</summary>
        public DateTime ProcessDate { get; set; }

        /// <summary>Hace referencia a al repositorio que realiara la operación</summary>
        public IUnitOfWorkRepository Repository { get; set; }

        /// <summary>Hace referencia al tipo de transacción</summary>
        public TransactionType Type { get; set; }

        /// <summary>
        /// Expresión de consulta
        /// </summary>
        public dynamic predicateMatch
        { get; set; }

    }
}
