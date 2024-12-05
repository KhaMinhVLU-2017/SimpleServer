using simpleServer.Helpers;
using simpleServer.Https.Models;

namespace simpleServer.Pipelines
{
    public class TransformMiddleware : BaseMiddleware
    {
        public TransformMiddleware() : this(null) { }

        public TransformMiddleware(IMiddleware next) : base(next)
        {
        }

        public override async Task NextAsync(IMiddleware requestDelegate, HttpContext content)
        {
            Console.WriteLine("Transform request");
            var serverOption = OptionHelper.GetServerSettings();
            var option = serverOption.Servers;
            content.Response.Header.AccessControlAllowOrigin = option.Cors;
            await requestDelegate.NextAsync(content);
            Console.WriteLine("Transform response");
        }
    }
}