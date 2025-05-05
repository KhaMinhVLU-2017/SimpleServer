using simpleServer.Https.Models;
using SimpleServer.Https.Payloads;

namespace SimpleServer.Https.Models
{
    public class HttpRequestBuilder
    {
        private string _host;
        private string _path;
        private string _method;
        private string _protocol;
        private byte[] _bytesContent;
        private HttpHeaderRequest _header;

        public void AddHost(string host) => _host = host;
        public void AddPath(string path) => _path = path;
        public void AddMethod(string method) => _method = method;
        public void AddProtocol(string protocol) => _protocol = protocol;
        public void AddHeaders(HttpHeaderRequest httpHeader) => _header = httpHeader;
        public void AddParams(byte[] bytes) => _bytesContent = bytes;

        public HttpRequest Build()
        {
            var payload = _header.ContentType.CreatePayoad(_bytesContent);
            return new HttpRequest()
            {
                Host = _host,
                Header = _header,
                Path = _path,
                Protocol = _protocol,
                Method = _method,
                Params = payload.Combine()
            };
        }
    }
}