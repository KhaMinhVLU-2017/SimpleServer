using simpleServer.Helpers;
using simpleServer.Https.Models;

namespace simpleServer.Pipelines
{
    public class CorsMiddlware : BaseMiddleware
    {
        public CorsMiddlware() : this(null) { }

        public CorsMiddlware(IMiddleware next) : base(next)
        {
        }

        public override async Task NextAsync(IMiddleware requestDelegate, HttpContext content)
        {
            Console.WriteLine("Cors request");
            var serverOption = OptionHelper.GetServerSettings();
            var option = serverOption.Servers;
            var urls = option.Cors.Split(",");
            bool hasAllowAny = urls.Any(s => s.Trim() == "*");

            if (!hasAllowAny)
            {
                bool hasOrigin = urls.Any(s => s.Trim() == content.Request.Header.Origin);
                if (!hasOrigin) throw new Exception($"Cors not support origin: {content.Request.Header.Origin}");
            }

            await requestDelegate.NextAsync(content);
            Console.WriteLine("Cors response");
        }
    }
}