using System.Text;
using simpleServer.Constants;
using simpleServer.Https.Models;

namespace simpleServer.Models.Results
{
    public class ImageResult : BaseResult
    {
        private byte[] _bytes;
        private string _contentType;

        public ImageResult(string contentType, byte[] bytes)
        {
            _contentType = contentType;
            _bytes = bytes;
        }


        public override async Task RunAsync(HttpContext context)
        {
            var response = context.Response;
            response.Header.ContentType = _contentType;
            response.Header.ContentLength = _bytes.Length;
            response.Payload.Bytes = _bytes;
        }
    }
}