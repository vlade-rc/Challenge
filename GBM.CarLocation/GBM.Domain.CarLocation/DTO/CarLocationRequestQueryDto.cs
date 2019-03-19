using GBM.CarLocation.Domain.Entities;
using GBM.CarLocation.Domain.Query.Filters;
using GBM.Infrastructure.COR;
using GBM.Infrastructure.Filter;

namespace GBM.CarLocation.Domain.DTO
{
    public class CarLocationRequestQueryDto : RequestQueryBaseDto<CarLocationFilter>
    {
    }
}
