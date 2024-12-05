using simpleServer.Constants;
using simpleServer.Https.Models;

namespace simpleServer.Models.Response
{
    public class ServerErrorResponse : BaseResponse
    {
        public ServerErrorResponse(HttpStatusCodeEnum? statusCode, object content = default) : base(statusCode, content)
        {
        }

        public override void Builder(HttpContext context)
        {
            if (StatusCode is null)
                StatusCode = HttpStatusCodeEnum.InternalServerError;
        }

    }
}