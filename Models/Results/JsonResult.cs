using Newtonsoft.Json;
using simpleServer.Constants;
using simpleServer.Https.Models;

namespace simpleServer.Models.Results
{
    public class JsonResult : BaseResult
    {
        private object _content;

        public JsonResult(object content)
        {
            _content = content;
        }

        public override async Task RunAsync(HttpContext context)
        {
            var response = context.Response;
            response.Header.ContentType = MimeTypeConstant.JSON;
            if (_content is not null)
            {
                string dataText = _content is null ? string.Empty : JsonConvert.SerializeObject(_content);
                response.Payload.Data = _content;
                response.Header.ContentLength = dataText.Length + 100;
            }
        }
    }
}