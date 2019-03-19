using GBM.CarLocation.Domain.DTO;
using GBM.CarLocation.Domain.Entities;
using GBM.CarLocation.Domain.Query.Filters;
using GBM.Infrastructure.COR;
using GBM.Infrastructure.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBM.CarLocation.Domain.Query
{
    public interface ICarLocationHandlerQuery : IHandlerQuery<CarLocationRequestQueryDto, Task<CarLocationResponseDto>, CarLocationEntity, CarLocationFilter>
    {
    }
}
