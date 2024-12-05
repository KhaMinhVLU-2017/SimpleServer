using simpleServer.Https.Models;

namespace simpleServer.Pipelines
{

    public abstract class BaseMiddleware : IMiddleware
    {
        protected IMiddleware Next;

        public BaseMiddleware(IMiddleware next)
        {
            Next = next;
        }

        public abstract Task NextAsync(IMiddleware requestDelegate, HttpContext request);

        public async Task NextAsync(HttpContext request)
        {
            if (Next is not null)
                await NextAsync(Next, request);
        }

        public void AddMiddleware(IMiddleware middleware) => Next = middleware;
    }
}