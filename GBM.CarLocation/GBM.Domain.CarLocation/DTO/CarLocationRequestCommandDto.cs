using GBM.CarLocation.Domain.Entities;
using GBM.Infrastructure.COR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBM.CarLocation.Domain.DTO
{
    /// <summary>
    /// Enumeradorde comandos disponibles a realizar con la entidad 
    /// </summary>
    public enum CommandOperation
    {
        UpdateLocation = 0
    }
    /// <summary>
    /// DTO de transporte
    /// </summary>
    public class CarLocationRequestCommandDto : RequestCommandBaseDto<CarLocationEntity>
    {
        /// <summary>
        /// Command to perform with CarLocation Entity
        /// </summary>
        public CommandOperation operation { get; set; }
    }
}
