using ERMX.Infrastructure.Utils.Serializer;
using GBM.CarLocation.Domain.Entities;
using GBM.CarLocation.Domain.Query.Filters;
using GBM.CarLocation.Domain.Repository;
using GBM.CarLocation.Repository.Data;
using GBM.CarLocation.Repository.ObjectValues;
using GBM.CarLocation.Repository.UnitOfWork.Mongo;
using GBM.CarLocation.Respository.DataEntity;
using GBM.Infrastructure.Filter;
using GBM.Infrastructure.IoC;
using GBM.Infrastructure.Repository;
using GBM.Infrastructure.UnitOfWork;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GBM.CarLocation.Repository
{
    public class CarLocationRepository : MongoRepositoryBase<CarLocationEntity>, ICarLocationRepository
    {

        public CarLocationRepository(IUnitOfWorkDbConnection unitOfWorkIn )
            : base(unitOfWorkIn)
        {           

        }

        /// <summary>
        /// Obtiene elemento por Id
        /// </summary>
        /// <param name="id">Id del elemento</param>
        /// <returns>Elemento encontrado</returns>
        public async Task<CarLocationEntity> GetCurrentCarLocationByCarIdentifier(string carIdentifier)
        {
            
            var filter = Builders<CarLocationData>.Filter.Eq(e => e.CarIdentifier, carIdentifier);
            var data = await ((IMongoDatabase)UnitOfWork.Context).GetCollection<CarLocationData>(_CollectionName).FindAsync(filter).ContinueWith(x=> { return x.Result.FirstOrDefault(); });

            return MapperHelper.MapCarLocationDataToEntity(data);
        }



     /// <summary>
     /// Inserta un registro y su histórico
     /// </summary>
     /// <param name="item"></param>
     /// <returns></returns>
        protected  async Task<bool> PersistNewCarLocationItem(CarLocationEntity item)
        {
            CarLocationData data = MapperHelper.MapCarLocationEntityToData(item);
            data.LastUpdatedDate = DateTime.Now;
            var repository = IoCFactory.Instance.Resolve<ICarLocationEventRepository>();
            await repository.PersistNewItem(new CarLocationEvents<string> { CarIdentifier = item.CarIdentifier, Event = item.GetAction().ToString(), EventContent = Serializers.JsonSerializer(item.Location), Identifier = Guid.NewGuid().ToString(), InsertedDate = DateTime.Now });

            return await ((IMongoDatabase)UnitOfWork.Context).GetCollection<CarLocationData>(_CollectionName).InsertOneAsync(data).ContinueWith(x => { return x.IsCompleted; });
        }

    

        public async Task UpdateCurrentCarLocationBySpecification( CarLocationEntity carLocation, IFilter filter)
        {
            CarLocationFilter filterQuery = (CarLocationFilter)filter;
           var update = Builders<CarLocationData>.Update.Set(x => x.Location, carLocation.Location).CurrentDate("LastUpdatedDate");
            var repository = IoCFactory.Instance.Resolve<ICarLocationEventRepository>();
            await repository.PersistNewItem(new CarLocationEvents<string> { CarIdentifier = carLocation.CarIdentifier, Event = carLocation.GetAction().ToString(), EventContent = Serializers.JsonSerializer(carLocation.Location), Identifier = Guid.NewGuid().ToString(), InsertedDate = DateTime.Now });
            
            await ((IMongoDatabase)UnitOfWork.Context).GetCollection<CarLocationData>(_CollectionName).UpdateOneAsync(x=> x.CarIdentifier == filterQuery.CarIdentifier, update);
            
        }

        protected override async Task PersistNewItem(CarLocationEntity item)
        {
            await PersistNewCarLocationItem(item);
        }

      

        protected override async Task PersistUpdatedItem(CarLocationEntity item, IFilter predicateMatch)
        {
            switch (item.GetAction())
            {
                case CarLocationActions.UpdateLocation:

                 
                    await UpdateCurrentCarLocationBySpecification(item, predicateMatch);

                    break;
                case CarLocationActions.DeleteLocation:
                    break;
                case CarLocationActions.ChangeCarIdentifier:
                    break;
            }
        }
    }
}
