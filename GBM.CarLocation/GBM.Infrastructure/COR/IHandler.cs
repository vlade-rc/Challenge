
using System.Collections.Generic;

namespace GBM.Infrastructure.COR
{
    /// <summary>
    /// Interfaz de hanlder BASE
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// Mensajes de validación 
        /// </summary>
        List<ValidationMessage> ValidationMessages { get; set; }


    }
}
