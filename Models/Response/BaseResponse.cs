using System.Text;
using Newtonsoft.Json;
using simpleServer.Helpers;
using simpleServer.Constants;
using Newtonsoft.Json.Linq;
using simpleServer.Https.Models;

namespace simpleServer.Models.Response
{
    public abstract class BaseResponse : IResponse
    {
        protected HttpStatusCodeEnum? StatusCode;
        protected object Content;

        public BaseResponse(HttpStatusCodeEnum? statusCode, object content = default)
        {
            StatusCode = statusCode;
            Content = content;
        }


        public async Task RunAsync(HttpContext context)
        {
            Builder(context);

            context.Response.StatusCode = StatusCode.Value;
            if (Content is not null)
                context.Response.Payload.Data = Content;

            byte[] content = await CompileAsync(context);
            await context.Socket.SendAsync(content);
            context.Socket.Dispose();
            context.Socket.Close();
        }

        public abstract void Builder(HttpContext context);

        protected async Task<byte[]> CompileAsync(HttpContext context)
        {
            var response = context.Response;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{response.Protocol} {(int)response.StatusCode} {response.StatusCode.DescriptionAttr()}");

            JObject jObject = JObject.FromObject(response.Header);
            foreach (var p in jObject.Properties())
            {
                string value = p.Value.ToString();
                if (!string.IsNullOrWhiteSpace(value) && value != "0")
                    sb.AppendLine($"{p.Name}: {p.Value}");
            }

            sb.AppendLine();
            string dataText = response.Payload.Data is null ? string.Empty : JsonConvert.SerializeObject(response.Payload.Data);
            if (!string.IsNullOrEmpty(dataText))
                sb.Append(dataText);

            string result = sb.ToString();
            var bytes = Encoding.ASCII.GetBytes(result);

            if (response.Payload.Bytes is not null && response.Payload.Bytes.Any())
                bytes = StreamHelper.Combine(bytes, response.Payload.Bytes);

            return bytes;
        }

    }
}