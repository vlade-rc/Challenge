namespace GBM.Infrastructure.Logger.Base
{
    using System;

    /// <summary>
    /// Interfaz de administración de registro de excepciones  
    /// </summary>
    /// <typeparam name="T">Objeto inicializable a loggear</typeparam>
    public interface ILogger<in T> where T: class, new()
    {
        /// <summary>
        /// Registro de excepciones no controladas
        /// </summary>
        /// <param name="exception">excepción no controlada</param>
        /// <param name="Object">Objeto a loggear</param>
        void LogException(Exception exception, T data = null);

              
        
        /// <summary>
        /// Registro Errores
        /// </summary>
        /// <param name="errorKeyMessage">Mensaje de error customisado</param>
        void LogError(string Code, string message, T data);

        /// <summary>
        /// Registro de advertencias
        /// </summary>
        /// <param name="warningError"></param>
        /// <param name="Object"></param>
        void LogWarning(string warningError, T data);


      /// <summary>
      /// Loggea un mensaje de información indicando el contexto en el que se ejecuta
      /// </summary>
      /// <param name="ContextIdentifier"></param>
      /// <param name="message"></param>
        void LogInfo(string ContextIdentifier, string message);

        /// <summary>
        /// Loggea información de auditoría
        /// </summary>
        /// <param name="messageObject"></param>
        /// <param name="tag"></param>
        void LogAudit( T messageObject, string tag = "") ;

      
    }
}
