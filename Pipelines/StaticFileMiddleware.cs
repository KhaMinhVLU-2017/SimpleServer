using simpleServer.Https.Models;

namespace simpleServer.Pipelines
{
    public class StaticFileMiddleware : BaseMiddleware
    {
        public StaticFileMiddleware() : this(null) { }

        public StaticFileMiddleware(IMiddleware next) : base(next)
        {
        }

        public override async Task NextAsync(IMiddleware requestDelegate, HttpContext request)
        {
            Console.WriteLine("StaticFile request");
            await requestDelegate.NextAsync(request);
            Console.WriteLine("StaticFile response");
        }
    }
}