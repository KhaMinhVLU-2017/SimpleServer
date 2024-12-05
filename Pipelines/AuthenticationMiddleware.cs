using simpleServer.Https.Models;

namespace simpleServer.Pipelines
{
    public class AuthenticationMiddleware : BaseMiddleware
    {
        public AuthenticationMiddleware() : this(null) { }
        public AuthenticationMiddleware(IMiddleware next) : base(next)
        {
        }

        public override async Task NextAsync(IMiddleware requestDelegate, HttpContext request)
        {
            Console.WriteLine("Authentication request");
            await requestDelegate.NextAsync(request);
            Console.WriteLine("Authentication response");
        }
    }
}