using GBM.CarLocation.Domain.Entities;
using GBM.Domain.CarLocation.FilterQueries;
using GBM.Infrastructure.COR;
using GBM.Infrastructure.Filter;

namespace GBM.CarLocation.Domain.DTO
{
    public class CarLocationRequestQueryDto : RequestQueryBaseDto<CarLocationFilter>
    {
    }
}
