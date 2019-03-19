using GBM.Infrastructure.Enums;
using GBM.Infrastructure.Filter;

namespace GBM.CarLocation.Domain.Query.Filters
{
    public enum FilterOperations
    {
        LocationForCarIdentifier = 0
    }
    public class CarLocationFilter : IFilter
    {

        public string CarIdentifier { get; set; }
        public FilterOperations FilterOperation { get; set; }
        public FilterModes FilterMode { get; set; }
        public int Page { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; }
    }
}
