using simpleServer.Constants;

namespace simpleServer.Models.Response
{
    public static class ResponseFactory
    {

        public static IResponse Create(HttpStatusCodeEnum statusCode, object content = null)
        {
            var status = (int)statusCode;
            IResponse response = status switch
            {
                >= 100 and < 200 => new InformationResponse(statusCode, content),
                >= 200 and < 300 => new SuccessResponse(statusCode, content),
                >= 300 and < 400 => new RedirectionResponse(statusCode, content),
                >= 400 and < 500 => new ClientErrorResponse(statusCode, content),
                >= 500 and < 600 => new ServerErrorResponse(statusCode, content),
                _ => new SuccessResponse(null, null)
            };
            return response;

        }

    }
}