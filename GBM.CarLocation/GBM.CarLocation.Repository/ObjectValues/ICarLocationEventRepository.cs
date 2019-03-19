
using GBM.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBM.CarLocation.Repository.ObjectValues
{
    public interface ICarLocationEventRepository : IRepositoryIDbConnection<CarLocationEvents<string>>, IUnitOfWorkRepository
    {
    }
}
