using GBM.Infrastructure.Logger;

using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace GBM.CarLocation.Track.Command.Api.Filters
{
    public class TraceExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            base.Handle(context);


            context.Result = new TextPlainErrorResult
            {
                Request = context.ExceptionContext.Request,
                Content = "Oops! Sorry! Something went wrong." +
                          "Please contact your platform administraor "
            };

           // Logger.Instance.LogException(context.Exception);
        }

        private class TextPlainErrorResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }

            public string Content { get; set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                HttpResponseMessage response =
                                 new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(Content);
                response.RequestMessage = Request;
                return Task.FromResult(response);
            }
        }
    }
}