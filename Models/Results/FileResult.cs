using simpleServer.Constants;
using simpleServer.Https.Models;

namespace simpleServer.Models.Results
{
    public class FileResult : BaseResult
    {
        private byte[] _bytes;
        private string _mimeType;
        private string _fileName;

        public FileResult(byte[] file, string mimeType, string fileName)
        {
            _bytes = file;
            _mimeType = mimeType;
            _fileName = fileName;
        }

        public override async Task RunAsync(HttpContext context)
        {
            var response = context.Response;
            response.Header.ContentType = string.IsNullOrEmpty(_mimeType) ? MimeTypeConstant.STREAM : _mimeType;
            response.Header.ContentDisposition = $" attachment; filename={_fileName}";
            response.Payload.Bytes = _bytes;
        }
    }
}