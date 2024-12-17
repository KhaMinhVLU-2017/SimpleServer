using System.Net.Sockets;
using SimpleServer.Protocols;

namespace simpleServer.Https.Models
{
    public class HttpContextBuilder
    {
        private HttpRequest _request;
        private HttpResponse _response;
        private long _correlationId;
        private IAppSocket _socket;

        public HttpContextBuilder AddRequest(HttpRequest request)
        {
            _request = request;
            return this;
        }

        public HttpContextBuilder AddResponse(HttpResponse response)
        {
            _response = response;
            return this;
        }

        public HttpContextBuilder AddCorrelationId(long id)
        {
            _correlationId = id;
            return this;
        }

        public HttpContextBuilder AddSocket(IAppSocket socket)
        {
            _socket = socket;
            return this;
        }

        public HttpContext Build()
        {
            return new HttpContext(_correlationId, _socket, _request, _response);
        }
    }
}