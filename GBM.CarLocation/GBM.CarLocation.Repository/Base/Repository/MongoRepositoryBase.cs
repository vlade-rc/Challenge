using GBM.CarLocation.Repository.Data;
using GBM.Infrastructure.Domain;
using GBM.Infrastructure.UnitOfWork;
using GBM.Repository.Mongo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBM.CarLocation.Repository.UnitOfWork.Mongo
{
    public abstract class MongoRepositoryBase<T> : RepositoryBase<T>  where T : IEntity
    {


        private readonly IUnitOfWorkDbConnection unitOfWork;
        protected readonly string _CollectionName;

        public MongoRepositoryBase(IUnitOfWorkDbConnection unitOfWorkIn)
            : base(unitOfWorkIn)
        {
            unitOfWork = unitOfWorkIn;
            _CollectionName = GetCollectionName<T>();

        }
        
        /// <summary>
        /// Obtiene el nombre de la coleccion que aplica para el modelo
        /// </summary>
        /// <returns>Nombre de la coleccion</returns>
        private string GetCollectionName<T>()
        {
            Attribute[] attrs = Attribute.GetCustomAttributes(typeof(T));
            foreach (Attribute attr in attrs)
            {
                if (attr is RepositoryConfig)
                {
                    var a = (RepositoryConfig)attr;
                    if (string.IsNullOrEmpty(a.CollectionName))
                        break;
                    return a.CollectionName;
                }
            }
            return typeof(T).Name + "s";
        }

    }
}
