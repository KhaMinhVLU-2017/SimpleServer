using System.Text;
using Newtonsoft.Json;
using simpleServer.Helpers;
using simpleServer.Https.Models;
using SimpleServer.Https.Models;

namespace simpleServer.Https.Methods
{
    public class PostMethod : BaseMethod
    {
        protected byte[] BytesContent;
        public PostMethod(string content) : base(content)
        {
        }

        public PostMethod(byte[] bytes, string content) : base(content)
        {
            BytesContent = bytes;
        }

        public override HttpRequest Compile()
        {
            var builder = new HttpRequestBuilder();
            using var memory = new MemoryStream(BytesContent);
            using var streamReader = new StreamReader(memory);
            BuildFirstLine(ref builder, streamReader.ReadLine());
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            string line = string.Empty;
            while (true)
            {
                line = streamReader.ReadLine();
                if (string.IsNullOrEmpty(line)) break;
                string[] arr = line.Split(':', 2);
                string key = arr[0].Trim();
                string value = arr[1].Trim();
                if (key.Equals("HOST", StringComparison.InvariantCultureIgnoreCase))
                {
                    builder.AddHost(value);
                    continue;
                }
                sb.Append($"\"{key}\":\"{value}\",");
            }
            sb.Append("}");
            var httpHeader = JsonConvert.DeserializeObject<HttpHeaderRequest>(sb.ToString());
            builder.AddHeaders(httpHeader);
            var bytesContent = StreamHelper.ConvertBianaries(streamReader);
            builder.AddParams(bytesContent);
            return builder.Build();
        }

        private void BuildFirstLine(ref HttpRequestBuilder builder, string firstLine)
        {
            string[] arr = firstLine.Split(' ');
            builder.AddMethod(arr[0].GetMethod());
            builder.AddPath(arr[1]);
            builder.AddProtocol(arr[2]);
        }
    }
}