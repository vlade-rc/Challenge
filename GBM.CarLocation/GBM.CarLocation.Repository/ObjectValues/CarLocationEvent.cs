using GBM.CarLocation.Repository.Data;
using GBM.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBM.CarLocation.Repository
{

  /// <summary>
  /// Información de los eventos asociados a la localización de los vehiculos
  /// </summary>
  /// <typeparam name="T"></typeparam>
  [RepositoryConfig( CollectionName ="CarLocationHistory")]
    public class CarLocationEvents<T> : EntityBase
    {


        public string CarIdentifier { get; set; }
        public DateTime InsertedDate { get; set; }

        public string Field { get; set; }

        public string Event { get; set; }      

        public T EventContent { get; set; }        

    }
}
