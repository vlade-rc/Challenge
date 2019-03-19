
using GBM.Infrastructure.Enums;

namespace GBM.Infrastructure.Filter
{
 
    public interface IFilter
    {

        FilterModes FilterMode { get; set;  }
        /// <summary>
        /// Número de página
        /// </summary>
        int Page { get; set; }
        /// <summary>
        /// Items por página
        /// </summary>
        int PageSize { get; set; }
        /// <summary>
        /// Total de Items
        /// </summary>
        int Count { get; set; }
    }
}
