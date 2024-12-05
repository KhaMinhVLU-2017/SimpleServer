using simpleServer.Https.Models;

namespace simpleServer.Pipelines
{
    public class DefaultMiddleware : BaseMiddleware
    {
        public DefaultMiddleware() : this(null) { }

        public DefaultMiddleware(IMiddleware next) : base(next)
        {
        }

        public override async Task NextAsync(IMiddleware requestDelegate, HttpContext request)
        {
            Console.WriteLine("Default request");
            await requestDelegate.NextAsync(request);
            Console.WriteLine("Default response");
        }
    }
}