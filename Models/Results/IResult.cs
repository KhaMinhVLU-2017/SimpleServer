using simpleServer.Https.Models;

namespace simpleServer.Models.Results
{
    public interface IResult
    {
        Task RunAsync(HttpContext context);
    }
}