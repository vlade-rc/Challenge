
using GBM.Infrastructure.Logger.Base;

namespace GBM.Infrastructure.Logger
{
    /// <summary>
    /// Clase que permite el loggeo de la aplicación 
    /// </summary>
    public static class Logger
    {

        public static ILogger<TraceLog<object>> instance;
        /// <summary>
        /// Instancia única de registro
        /// </summary>
        public static ILogger<TraceLog<object>> Instance
        {
            get
            {
                if(instance== null)
                {
                    instance = IoC.IoCFactory.Instance.Resolve<ILogger<TraceLog<object>>>();
                }

                return instance;
            }
        }

        
    }
}
