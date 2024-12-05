using System.Text;
using simpleServer.Https.Models;

namespace simpleServer.Models.Results
{
    public abstract class BaseResult : IResult
    {
        public abstract Task RunAsync(HttpContext context);
    }
}