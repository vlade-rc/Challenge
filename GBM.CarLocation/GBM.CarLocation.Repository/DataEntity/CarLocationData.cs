using GBM.CarLocation.Domain.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBM.CarLocation.Respository.DataEntity
{
    [BsonIgnoreExtraElements]
    public class CarLocationData
    {
       public string Identifier { get; set; }
        public Localization Location { get; set; }

        public string CarIdentifier { get; set; }

        [BsonIgnoreIfNull]
        public DateTime LastUpdatedDate { get; set; }

      
    }
}
