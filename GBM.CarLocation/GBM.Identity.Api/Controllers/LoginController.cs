using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using GBM.Identity.Api.Models;
using GBM.Identity.Api.TokenService;
using Swashbuckle.Swagger.Annotations;

namespace GBM.Identity.Api.Controllers
{
    public class LoginController : ApiController
    {

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(Credentials login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //S evalida el usuario y se traerían sus accesos etc...
            bool isCredentialValid = (login.SecretId == "123456");
            if (isCredentialValid)
            {
                var token = Tokenizer.GenerateTokenJwt(login.SecretId, login.ClientId);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
