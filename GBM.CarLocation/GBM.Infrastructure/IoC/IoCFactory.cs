using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBM.Infrastructure.IoC
{
    /// <summary>
    /// Clase que permite interactuar con el contenedor de ID
    /// </summary>
    public class IoCFactory 
    {

      
        protected static IoCProvider instance;

        public static IoCProvider Instance
        {
            get
            {
                
                return instance;
            }
        }

        public static void SetIoCProvider(IoCProvider provider)
        {
            if (instance != null)
            {
                instance.Dispose();
            }
            instance = provider;
            instance.Initialize();

        }

    }
}
