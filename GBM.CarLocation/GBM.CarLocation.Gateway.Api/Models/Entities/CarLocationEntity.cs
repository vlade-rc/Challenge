using GBM.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBM.CarLocation.Domain.Entities
{

    public enum CarLocationActions
    {
        None = 0,
        Insert = 1,
        UpdateLocation = 2,
        DeleteLocation = 3,
        ChangeCarIdentifier = 4
    }
    public class CarLocationEntity: EntityBase
    {
        /// <summary>
        /// Geoposition
        /// </summary>
        public Localization Location { get; set; }


        public string CarIdentifier { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        /// <summary>
        /// Indica que acción se ejecutará con la entidad
        /// </summary>
        /// <param name="resourceAction"></param>
        public void SetAction(CarLocationActions locationAction)
        {
            action = locationAction;
        }

        /// <summary>
        /// Obtiene la accion que se ejecutara con la entidad
        /// </summary>
        /// <param name="resourceAction"></param>
        public CarLocationActions GetAction()
        {
            return action;
        }

        private CarLocationActions action;
       
    }
}
