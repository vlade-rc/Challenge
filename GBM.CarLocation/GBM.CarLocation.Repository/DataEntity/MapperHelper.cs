using GBM.CarLocation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBM.CarLocation.Respository.DataEntity
{
    /// <summary>
    /// Helpper para mapeo de entidades al modelo de datos
    /// </summary>
    public static class MapperHelper
    {

        /// <summary>
        /// Mapeo de CarLocationENtity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CarLocationData MapCarLocationEntityToData(CarLocationEntity entity)
        {
            if (entity != null)
            {
                return new CarLocationData
                {
                    CarIdentifier = entity.CarIdentifier,
                    Location = entity.Location,
                     Identifier = entity.Identifier,
                      LastUpdatedDate = entity.LastUpdatedDate
                };
            }
            else return null;
        }

        public static CarLocationEntity MapCarLocationDataToEntity(CarLocationData entity)
        {
            if (entity != null)
            {
                return new CarLocationEntity
                {
                    CarIdentifier = entity.CarIdentifier,
                    Location = entity.Location,
                    Identifier = entity.Identifier,
                    LastUpdatedDate = entity.LastUpdatedDate
                };
            }
            else return null;
        }
    }
}
