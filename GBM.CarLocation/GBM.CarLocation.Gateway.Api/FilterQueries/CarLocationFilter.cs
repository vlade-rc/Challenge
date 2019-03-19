using GBM.Infrastructure.Enums;
using GBM.Infrastructure.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBM.Domain.CarLocation.FilterQueries
{
    public class CarLocationFilter : IFilter
    {
        public string CarIdentifier { get; set; }
        public FilterModes FilterMode { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
    }
}
