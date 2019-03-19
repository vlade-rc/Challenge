using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBM.CarLocation.Domain.Entities
{
    public class Localization
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public float Altitude { get; set; }
    }
}
