namespace GBM.Infrastructure.Enums
{
    using System;
    /// <summary>Enumerador del tipo de filtro</summary>
    [Flags]
    public enum FilterModes
    {
        /// <summary>Paginado</summary>
        Paged = 0,
        /// <summary>Todo</summary>
        All = 1
    }
}
