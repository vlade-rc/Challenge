namespace GBM.Infrastructure.Enums
{
    using System;
    /// <summary>
    /// Enumerador de administrador de registros
    /// </summary>
    [Flags]
    public enum LogTargetType
    {
        /// <summary>
        /// Loggeo a EventLog
        /// </summary>
        EventLog = 0,
        /// <summary>
        /// Loggeo a Splunk
        /// </summary>
        Service = 1,
        /// <summary>
        /// Loggeo a archivo
        /// </summary>
        File = 2
    }
}
