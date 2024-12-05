using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace simpleServer.Https.Models
{
    public class HttpHeaderRequest
    {
        [JsonProperty("User-Agent")]
        public string UserAgent { get; set; }
        public string Accept { get; set; }

        [JsonProperty("Content-Type")]
        public string ContentType { get; set; }

        [JsonProperty("Accept-Language")]
        public string AcceptLanguage { get; set; }

        [JsonProperty("Accept-Encoding")]
        public string AcceptEncoding { get; set; }

        public string Referer { get; set; }

        [JsonProperty("Upgrade-Insecure-Requests")]
        public int UpgradeInsecureRequests { get; set; }

        [JsonProperty("If-Modified-Since")]
        public DateTime IfModifiedSince { get; set; }

        [JsonProperty("If-None-Match")]
        public string IfNoneMatch { get; set; }

        [JsonProperty("Cache-Control")]
        public string CacheControl { get; set; }

        [JsonProperty("Origin")]
        public string Origin { get; set; }

        [JsonProperty("sec-ch-ua")]
        public string Secchua { get; set; }

        [JsonProperty("sec-ch-ua-mobile")]
        public string SecchuaMobile { get; set; }

        [JsonProperty("sec-ch-ua-platform")]
        public string SecchuaPlatform { get; set; }

        [JsonProperty("Sec-Fetch-Site")]
        public string SecFetchSite { get; set; }

        [JsonProperty("Sec-Fetch-Mode")]
        public string SecFetchMode { get; set; }

        [JsonProperty("Sec-Fetch-User")]
        public string SecFetchUser { get; set; }

        [JsonProperty("Sec-Fetch-Dest")]
        public string SecFetchDest { get; set; }
    }
}