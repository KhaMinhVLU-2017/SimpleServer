using Newtonsoft.Json;

namespace simpleServer.Https.Models
{
    public class HttpHeaderResponse
    {
        [JsonProperty("Access-Control-Allow-Origin")]
        public string AccessControlAllowOrigin { get; set; }
        public string Connection { get; set; }

        [JsonProperty("Content-Encoding")]
        public string ContentEncoding { get; set; }

        [JsonProperty("Content-Type")]
        public string ContentType { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string ETag { get; set; }

        [JsonProperty("Keep-Alive")]
        public string KeepAlive { get; set; }

        [JsonProperty("Last-Modified")]
        public DateTime LastModified { get; set; } = DateTime.UtcNow;

        public string Server { get; set; }

        [JsonProperty("Set-Cookie")]
        public string SetCookie { get; set; }

        [JsonProperty("Transfer-Encoding")]
        public string TransferEncoding { get; set; }

        public string Vary { get; set; }

        [JsonProperty("X-BackEnd-Server")]
        public string XBackEndServer { get; set; }

        [JsonProperty("X-Cache-Info")]
        public string XCacheInfo { get; set; }

        [JsonProperty("X-Kuma-Revision")]
        public int XKumaRevision { get; set; }

        [JsonProperty("X-Frame-Options")]
        public string XFrameOptions { get; set; }

        [JsonProperty("Accept-Ranges")]
        public string AcceptRanges { get; set; }

        [JsonProperty("Content-Length")]
        public int ContentLength { get; set; }

        [JsonProperty("Content-Disposition")]
        public string ContentDisposition { get; set; }

        public string Location { get; set; }

    }
}