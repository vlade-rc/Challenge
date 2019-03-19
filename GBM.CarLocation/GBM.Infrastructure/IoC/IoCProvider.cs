using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBM.Infrastructure.IoC
{
    
    /// <summary>Clase para el provedor de inversión de control</summary>

    public abstract class IoCProvider
    {/// <summary>Método que inicializa al provedor</summary>
        public abstract void Initialize();
        /// <summary>Método para resolver la implementación de una interface</summary>
        /// <typeparam name="TDefinition">Hace referencia a la interface</typeparam>
        public abstract TDefinition Resolve<TDefinition>();
      
        /// <summary>Método para resolver una implementación de una interface por nombre</summary>
        /// <typeparam name="TDefinition">Hace referencia al nombre de la interface</typeparam>
        /// <param name="Name">Hace referencia al nombre asignado a la inversión de control</param>
        public abstract TDefinition ResolveByName<TDefinition>(string Name);
      
        /// <summary>Método para liberar los el objeto de la memoria</summary>
        public abstract void Dispose();
    }
}
