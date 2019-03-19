

namespace GBM.Infrastructure.Messages
{
    /// <summary>
    /// Clase que permite inicializar la fabrica de mensajes de forma genérica
    /// </summary>
    /// <typeparam name="T">Clase constructora del contenedor de mensajes</typeparam>
    public  class MessageFactory<T>  where T:  MessageBuilder, new()
    {
        

        protected static T instance;        

        /// <summary>
        /// Instancia única de acceso a mensajes
        /// </summary>
        public  static  T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                    instance.Initialize();
                }

                return instance;
            }
        }
        /// <summary>
        /// Permite liberar los recursos, y reiniciar el contenedor
        /// </summary>
        public static void Clean()
        {
            instance.Clean();
        }

        public static void TryGetMessages(string key)
        {
            instance.TryGetMessage(key);
        }

    }
}
