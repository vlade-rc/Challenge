namespace GBM.Infrastructure.Enums
{
    using System;
    /// <summary>
    /// Enumerador de nivel de excepciones configurado
    /// </summary>
    [Flags]
    public enum LogLevelType
    {
        /// <summary>
        /// Logs informativos
        /// </summary>
        Message = 0,
        /// <summary>
        /// Errores en plataforma
        /// </summary>
        Error = 1,
        /// <summary>
        /// Excepciones en plataforma
        /// </summary>
        Exception = 2,
        /// <summary>
        /// Trazabilidad, Input Output en servicios
        /// </summary>
        Info = 3,
        /// <summary>
        /// Debug Loggea todos los niveles
        /// </summary>
        Audit = 4
    }
}
