namespace GBM.Infrastructure.Enums
{
    using System;
    /// <summary>
    /// Enumerador tipo de recurso
    /// </summary>
    [Flags]
    public enum LogErrorSourceTypes
    {
        /// <summary>Archivo resx</summary>
        Resorce = 0,
        /// <summary>archivo json</summary>
        Json = 1
    }
}
