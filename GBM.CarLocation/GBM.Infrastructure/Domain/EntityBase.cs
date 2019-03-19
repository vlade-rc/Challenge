namespace GBM.Infrastructure.Domain
{
    using System;
    using System.Threading;

    /// <summary>
    ///     Clase base de Entidades
    /// </summary>
    public abstract class EntityBase : IEntity
    {
        /// <summary>Hace referencia al identificador del objeto, debe ser único</summary>
        private string identifier;

        /// <summary>
        ///     Representa el id único del objeto o evento
        /// </summary>
        public string Identifier
        {
            get
            {
                return identifier;
            }
            set
            {
                identifier = value;
            }
        }



        /// <summary>
        ///     Genera un nuevo identificador
        /// </summary>
        /// <returns></returns>
        public static object NewIdentifier()
        {
            return string.Concat(Guid.NewGuid().ToString(), Thread.CurrentThread.ManagedThreadId);
        }

       

    }
}
