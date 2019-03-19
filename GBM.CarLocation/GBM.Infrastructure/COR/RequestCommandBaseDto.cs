
using System.Collections.Generic;

namespace GBM.Infrastructure.COR
{
    public class RequestCommandBaseDto<T>
    { 
        /// <summary>Hace referencia a un elemento del tipo generico</summary>
        public T Item { get; set; }

        /// <summary>
        ///     Lista de elementos
        /// </summary>
        
        public List<T> ItemList { get; set; }



    }
}
