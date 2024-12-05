using System.Text;
using simpleServer.Constants;
using simpleServer.Https.Models;

namespace simpleServer.Models.Results
{
    public class HtmlResult : BaseResult
    {
        private string _html;

        public HtmlResult(string html)
        {
            _html = html;
        }

        public override async Task RunAsync(HttpContext context)
        {
            var response = context.Response;
            response.Header.ContentType = MimeTypeConstant.HTML;
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html lang=\"en\">");
            sb.Append("<head>");
            sb.Append("<link rel=\"icon\" href=\"https://www.mnlifeblog.com/icon.ico\">");
            sb.Append("<meta name=\"description\" content=\"Server for learn\">");
            sb.Append("<title>");
            sb.Append("Welcome to mini server");
            sb.Append("</title>");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append(_html);
            sb.Append("</body>");
            sb.Append("</html>");
            string html = sb.ToString().Replace(Environment.NewLine, string.Empty);
            var bytes = Encoding.ASCII.GetBytes(html);
            response.Payload.Bytes = bytes;
            response.Header.ContentLength = bytes.Length;
        }
    }
}