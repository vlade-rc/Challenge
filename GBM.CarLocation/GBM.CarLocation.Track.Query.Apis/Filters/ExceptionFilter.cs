using GBM.Infrastructure.Logger;
using GBM.Infrastructure.Logger.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace GBM.CarLocation.Track.Query.Api.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            if (actionExecutedContext.Exception is NotImplementedException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }
            string data;
            using (var stream = actionExecutedContext.Request.Content.ReadAsStreamAsync().Result)
            {
                if (stream.CanSeek)
                {
                    stream.Position = 0;
                }
                data = actionExecutedContext.Request.Content.ReadAsStringAsync().Result;
            }

            string path = actionExecutedContext.Request.RequestUri.AbsolutePath;


            var context = new TraceLog<object>
            {
                
                Content = (data==null)?string.Empty: data,
                 Operation= actionExecutedContext.Request.RequestUri.Query,
                  ApplicationName = "GBM.CarLocation.Track.Command.Api",
                   Tag = "Exception"
            };

            Logger.Instance.LogException(actionExecutedContext.Exception, context);
            //We can log this exception message to logg system, syslog, file or database
            var response = new HttpResponseMessage(HttpStatusCode
                .InternalServerError)
            {
                Content = new StringContent("An unhandled exception was thrown by service."),
                ReasonPhrase = "Internal Server Error.Please Contact your Administrator."
            };
            actionExecutedContext.Response = response;
            base.OnException(actionExecutedContext);
        }



    }
}