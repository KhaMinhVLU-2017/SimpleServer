using simpleServer.Https.Models;

namespace simpleServer.Pipelines
{
    public class AuthorizationMiddleware : BaseMiddleware
    {
        public AuthorizationMiddleware() : this(null) { }

        public AuthorizationMiddleware(IMiddleware next) : base(next)
        {
        }

        public override async Task NextAsync(IMiddleware requestDelegate, HttpContext request)
        {
            Console.WriteLine("Authorization request");
            await requestDelegate.NextAsync(request);
            Console.WriteLine("Authorization response");
        }
    }
}