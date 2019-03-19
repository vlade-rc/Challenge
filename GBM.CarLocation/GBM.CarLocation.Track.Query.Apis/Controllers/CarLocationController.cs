using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GBM.CarLocation.Domain.Command;
using GBM.CarLocation.Domain.DTO;
using GBM.CarLocation.Domain.Entities;
using GBM.CarLocation.Domain.Query;
using GBM.Infrastructure.IoC;
using Swashbuckle.Swagger.Annotations;

namespace GBM.CarLocation.Track.Query.Api.Controllers
{
    public class CarLocationController : ApiController
    {

        /// <summary>
        /// Realiza una operación al documento
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [SwaggerOperation("Query")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [SwaggerResponse(HttpStatusCode.NoContent)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.NotImplemented)]
        [SwaggerResponse(HttpStatusCode.OK)]
        [Route("CarLocation/Query")]
        [ResponseType(typeof(CarLocationResponseDto))]
        [HttpPost]
        public async Task<HttpResponseMessage> CarLocationCommand([FromBody]CarLocationRequestQueryDto value)
        {
            ICarLocationHandlerQuery command = IoCFactory.Instance.ResolveByName<ICarLocationHandlerQuery>(value.Filter.FilterOperation.ToString());
         
            CarLocationResponseDto response;
            if (command.Validate(value))
            {
                response = await command.Execute(value);
                if (response.ResultItem != null )
                {
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, response);
                }

            }
            else
            {
                response = new CarLocationResponseDto { Errors = command.ValidationMessages };
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }

        }
    }
}
