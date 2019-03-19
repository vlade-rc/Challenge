
using GBM.CarLocation.Domain.Entities;
using GBM.Infrastructure.Repository;
using System.Threading.Tasks;

namespace GBM.CarLocation.Domain.Repository
{
    /// <summary>
    /// Repositorio para la entidad de posicionamiento
    /// </summary>
    public interface ICarLocationRepository : IRepositoryIDbConnection<CarLocationEntity>
    {


        Task<CarLocationEntity> GetCurrentCarLocationByCarIdentifier(string carIdentifier);


    }
}
