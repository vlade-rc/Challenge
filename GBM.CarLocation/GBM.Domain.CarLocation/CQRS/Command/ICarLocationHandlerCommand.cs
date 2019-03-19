using GBM.CarLocation.Domain.DTO;
using GBM.CarLocation.Domain.Entities;
using GBM.Infrastructure.COR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBM.CarLocation.Domain.Command
{
    
    public interface ICarLocationHandlerCommand : IHandlerCommand<CarLocationRequestCommandDto, Task<CarLocationResponseDto>, CarLocationEntity>
    {

    }
}
