using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBM.CarLocation.Repository.Data
{

    /// <summary>
    /// Clase de atributos para la configuracion de repositorio
    /// </summary>
    [AttributeUsage(System.AttributeTargets.Class |
                      System.AttributeTargets.Struct)
   ]
    public class RepositoryConfig : Attribute
    {
        /// <summary>
        /// Nombre de la coleccion o tabla destino en la BD
        /// </summary>
        public string CollectionName = "";
    }
}
