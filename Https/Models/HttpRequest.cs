namespace simpleServer.Https.Models
{
    public class HttpRequest
    {
        public long SessionId { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public string Method { get; set; }
        public string Protocol { get; set; }
        public IDictionary<string, object> Params { get; set; }

        public HttpHeaderRequest Header { get; set; }
    }
}