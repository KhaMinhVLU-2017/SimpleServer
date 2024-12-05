using simpleServer.Constants;

namespace simpleServer.Https.Models
{
    public class HttpResponse
    {
        public string Protocol { get; set; } = "HTTP/1.1";
        public HttpStatusCodeEnum StatusCode { get; set; }
        public HttpHeaderResponse Header { get; set; }
        public HttpPayloadResponse Payload { get; set; }

        public HttpResponse()
        {
            Header = new HttpHeaderResponse();
            Payload = new HttpPayloadResponse();
        }
    }
}