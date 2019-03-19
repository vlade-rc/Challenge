using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Swashbuckle.Swagger.Annotations;

namespace GBM.HookProvider.Api.Controllers
{
    public class HookController : ApiController
    {

   
            [HttpPost]
            public async Task<IHttpActionResult> Submit(string carIdentifier)
            {
                await this.NotifyAsync("UpdatedLocation", new { Titulo = "Se actualizó la info" });

                return Ok();
            }
    }
}
