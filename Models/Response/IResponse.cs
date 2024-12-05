using simpleServer.Https.Models;

namespace simpleServer.Models.Response
{
    public interface IResponse
    {
        Task RunAsync(HttpContext context);
    }
}