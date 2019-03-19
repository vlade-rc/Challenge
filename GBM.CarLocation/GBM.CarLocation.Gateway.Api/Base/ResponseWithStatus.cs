using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace GBM.CarLocation.Gateway.Api.Base
{
    public class ResponseWithStatus<TResponse>
    {
        public TResponse Response { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}