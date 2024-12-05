using simpleServer.Https.Models;
using simpleServer.Models.Response;

namespace simpleServer.Pipelines
{
    public class ResponseMiddleware : BaseMiddleware
    {
        public ResponseMiddleware() : this(null) { }

        public ResponseMiddleware(IMiddleware next) : base(next)
        {
        }

        public override async Task NextAsync(IMiddleware requestDelegate, HttpContext context)
        {
            await requestDelegate.NextAsync(context);
            IResponse response = ResponseFactory.Create(context.Response.StatusCode);
            await response.RunAsync(context);

        }
    }
}