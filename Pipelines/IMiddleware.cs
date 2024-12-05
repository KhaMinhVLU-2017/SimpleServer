using simpleServer.Https.Models;

namespace simpleServer.Pipelines
{
    public interface IMiddleware
    {
        Task NextAsync(HttpContext request);
    }
}