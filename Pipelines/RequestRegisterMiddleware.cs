using simpleServer.Https.Models;

namespace simpleServer.Pipelines
{
    public class RequestRegisterMiddleware : BaseMiddleware
    {
        private static long _sessionId;
        public RequestRegisterMiddleware() : this(null) { }

        public RequestRegisterMiddleware(IMiddleware next) : base(next)
        {
        }

        public override async Task NextAsync(IMiddleware requestDelegate, HttpContext content)
        {
            Interlocked.Increment(ref _sessionId);
            Console.WriteLine($"Request register request by sessionId {_sessionId}");
            content.Request.SessionId = _sessionId;
            content.CorrelationId = _sessionId;
            await requestDelegate.NextAsync(content);
            Console.WriteLine($"Request register response by sessionId {_sessionId}");
        }
    }
}