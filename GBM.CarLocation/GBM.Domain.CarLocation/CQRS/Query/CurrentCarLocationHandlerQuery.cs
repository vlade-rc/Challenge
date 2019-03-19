using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GBM.CarLocation.Domain.DTO;
using GBM.CarLocation.Domain.Messages;
using GBM.CarLocation.Domain.Repository;
using GBM.Infrastructure.COR;
using GBM.Infrastructure.Specifications.Base;
using GBM.Infrastructure.UnitOfWork;

namespace GBM.CarLocation.Domain.Query.Filters
{
    public class CurrentCarLocationHandlerQuery : ICarLocationHandlerQuery
    {
        public List<ValidationMessage> ValidationMessages { get; set; }


        private readonly ICarLocationRepository carLocationRepository;

        public CurrentCarLocationHandlerQuery(ICarLocationRepository repository)
        {
            carLocationRepository = repository;
        }
        public async Task<CarLocationResponseDto> Execute(CarLocationRequestQueryDto request)
        {          
            var result = await carLocationRepository.GetCurrentCarLocationByCarIdentifier(request.Filter.CarIdentifier);
            return new CarLocationResponseDto { ResultItem = result };
        }

        public bool Validate(CarLocationRequestQueryDto request)
        {
            Specification<CarLocationRequestQueryDto> ValidCarIdentifier =
               new Specification<CarLocationRequestQueryDto>(x => x.Filter.CarIdentifier != null && x.Filter.CarIdentifier != string.Empty)
               .WithMessage(CarLocationMessageFactory.Instance.TryGetMessage("CarIdentifierError"));
            var fullSpecification = ValidCarIdentifier;


            if (!fullSpecification.ValidateModel(request))
            {
                ValidationMessages = fullSpecification.GetErrrors();
                return false;
            }
            return true;

        }
    }
}
