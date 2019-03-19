using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GBM.CarLocation.Domain.DTO;
using GBM.CarLocation.Gateway.Api.Base;
using Swashbuckle.Swagger.Annotations;

namespace GBM.CarLocation.Gateway.Api.Controllers
{
    [Authorize]
    public class LocationTrackController : ApiController
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
        [HttpPut]
        public async Task<HttpResponseMessage> CarLocationQuery([FromBody]CarLocationRequestQueryDto data)
        {
            

            var client = new HttpClientWrapper<CarLocationRequestQueryDto, ResponseWithStatus<CarLocationResponseDto>>();
            HttpStatusCode status = HttpStatusCode.OK;
            var response = await client.PostJsonAsync(new Uri(ConfigurationManager.AppSettings["CarLocationQueryServiceUri"]), "Query",data);

            return  Request.CreateResponse(response.StatusCode, response.Response);

        }


        /// <summary>
        /// Realiza una operación al documento
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [SwaggerOperation("Command")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [SwaggerResponse(HttpStatusCode.NoContent)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.NotImplemented)]
        [SwaggerResponse(HttpStatusCode.OK)]
        [Route("CarLocation/Command")]
        [ResponseType(typeof(CarLocationResponseDto))]
        [HttpPut]
        public async Task<HttpResponseMessage> CarLocationCommand([FromBody]CarLocationRequestCommandDto data)
        {


            var client = new HttpClientWrapper<CarLocationRequestCommandDto, ResponseWithStatus<CarLocationResponseDto>>();
            var response = await client.PutJsonAsync(new Uri(ConfigurationManager.AppSettings["CarLocationCommandServiceUri"]), "Command", data);

            return Request.CreateResponse(response.StatusCode, response.Response);

        }

        
        [SwaggerOperation("TestLogged")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public void Post([FromBody]string value)
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
               string data =  identity.FindFirst("ClientId").Value;
                Request.CreateResponse(HttpStatusCode.OK, data);
            }


        }

      
    }
}
