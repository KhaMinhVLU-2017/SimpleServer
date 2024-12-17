using SimpleServer.Protocols;

namespace simpleServer.Https.Models
{
    public class HttpContext
    {
        public long CorrelationId { get; set; }
        public IAppSocket Socket { get; set; }
        public HttpRequest Request { get; set; }
        public HttpResponse Response { get; set; }
        public Exception Exception { get; set; }

        public HttpContext(long correlationId, IAppSocket socket, HttpRequest request, HttpResponse response)
        {
            CorrelationId = correlationId;
            Socket = socket;
            Request = request;
            Response = response;
        }
    }
}