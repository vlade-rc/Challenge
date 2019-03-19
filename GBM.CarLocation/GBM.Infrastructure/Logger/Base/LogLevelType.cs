namespace GBM.Infrastructure.Logger.Base
{
    /// <summary>
    /// Enumerador de nivel de excepciones configurado
    /// </summary>
    public enum LogLevelType:uint
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
