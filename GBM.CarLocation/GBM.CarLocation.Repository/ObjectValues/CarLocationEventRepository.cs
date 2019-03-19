using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GBM.CarLocation.Domain.Entities;
using GBM.CarLocation.Repository.ObjectValues;
using GBM.CarLocation.Repository.UnitOfWork.Mongo;
using GBM.Infrastructure.Domain;
using GBM.Infrastructure.Filter;
using GBM.Infrastructure.UnitOfWork;
using MongoDB.Driver;

namespace GBM.CarLocation.Repository
{
    public class CarLocationEventRepository : MongoRepositoryBase<CarLocationEvents<string>>, ICarLocationEventRepository
    {

        public CarLocationEventRepository(IUnitOfWorkDbConnection unitOfWorkIn)
            : base(unitOfWorkIn)
        {

        }

        protected override async Task PersistNewItem(CarLocationEvents<string> item)
        {
            await ((IMongoDatabase)UnitOfWork.Context).GetCollection<CarLocationEvents<string>>(_CollectionName).InsertOneAsync(item);
        }

        protected override Task PersistUpdatedItem(CarLocationEvents<string> item, IFilter predicateMatch)
        {
            throw new NotImplementedException();
        }
    }
}
