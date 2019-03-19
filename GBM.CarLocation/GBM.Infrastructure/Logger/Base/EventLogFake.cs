namespace GBM.Infrastructure.Logger.Base
{
    using System;

    /// <summary>
    /// Administración de registro de excepciones  
    /// </summary>
    public class EventLogFake : ILogger<object>
    {
        public void LogAudit(object messageObject, string tag = "")
        {
            //To Implement
        }

        public void LogError(string Code, string message, object data)
        {
            //To Implement
        }

        public void LogException(Exception exception, object data)
        {
            //To Implement
        }

        public void LogInfo(string ContextIdentifier, string message)
        {
            //To Implement
        }

        public void LogWarning(string warningError, object data)
        {
            //To Implement
        }
    }
}
