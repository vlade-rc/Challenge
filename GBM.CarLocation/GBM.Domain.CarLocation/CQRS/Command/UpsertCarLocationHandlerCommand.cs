using GBM.CarLocation.Domain.DTO;
using GBM.CarLocation.Domain.Entities;
using GBM.CarLocation.Domain.Messages;
using GBM.CarLocation.Domain.Query.Filters;
using GBM.CarLocation.Domain.Repository;
using GBM.Infrastructure.COR;
using GBM.Infrastructure.Specifications.Base;
using GBM.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GBM.CarLocation.Domain.Command
{

    public class UpsertCarLocationHandlerCommand : ICarLocationHandlerCommand
    {

        private readonly ICarLocationRepository carLocationRepository;
        private readonly IUnitOfWorkDbConnection unitOfWork;
        public UpsertCarLocationHandlerCommand(ICarLocationRepository repository, IUnitOfWorkDbConnection unitOfWorkIn)
        {
            carLocationRepository = repository;
            unitOfWork = unitOfWorkIn;
        }
        public List<ValidationMessage> ValidationMessages
        {
            get; set;
        }
        public async Task<CarLocationResponseDto> Execute(CarLocationRequestCommandDto request)
        {
            CarLocationEntity currentItem = new CarLocationEntity { };
            try
            {
                carLocationRepository.SetUnitOfWork(unitOfWork);


                var item = await carLocationRepository.GetCurrentCarLocationByCarIdentifier(request.Item.CarIdentifier);


                if (item != null)
                {
                    request.Item.SetAction(Entities.CarLocationActions.UpdateLocation);
                    CarLocationFilter filter = new CarLocationFilter { CarIdentifier = request.Item.CarIdentifier };
                    carLocationRepository.Update(request.Item, filter);
                }
                else
                {
                    request.Item.SetAction(Entities.CarLocationActions.Insert);
                    carLocationRepository.Add(request.Item);
                }
                await unitOfWork.CommitAsync();

                 currentItem = await carLocationRepository.GetCurrentCarLocationByCarIdentifier(request.Item.CarIdentifier);
            }
            finally
            {
                unitOfWork.Dispose();
            }
            return new CarLocationResponseDto { ResultItem = currentItem };
        }

        public bool Validate(CarLocationRequestCommandDto request)
        {
            Specification<CarLocationRequestCommandDto> UniqueIdSpecification = 
                new Specification<CarLocationRequestCommandDto>(x => x.Item.Identifier != null && x.Item.Identifier.Trim() != string.Empty)
                .WithMessage(CarLocationMessageFactory.Instance.TryGetMessage("UniqueIdProcessError"));

            Specification<CarLocationRequestCommandDto> ValidLocationSpecification =
               new Specification<CarLocationRequestCommandDto>(x => x.Item.Location != null 
               && x.Item.Location.Altitude != default (float)
               && x.Item.Location.Longitude != default(float)
               && x.Item.Location.Altitude != default(float)
               ).WithMessage(CarLocationMessageFactory.Instance.TryGetMessage("LocalizationError"));

            var fullSpecification = UniqueIdSpecification.And(ValidLocationSpecification);

            if (!fullSpecification.ValidateModel(request))
            {
                ValidationMessages = fullSpecification.GetErrrors();
                return false;
            }
            return true;
        }
    }
}
