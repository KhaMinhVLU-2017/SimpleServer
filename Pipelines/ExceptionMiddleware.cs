using simpleServer.Helpers;
using simpleServer.Constants;
using simpleServer.Exceptions;
using simpleServer.Https.Models;
using simpleServer.Models.Results;
using simpleServer.Models.Response;

namespace simpleServer.Pipelines
{
    public class ExceptionMiddleware : BaseMiddleware
    {
        public ExceptionMiddleware() : this(null) { }

        public ExceptionMiddleware(IMiddleware next) : base(next)
        {
        }

        public override async Task NextAsync(IMiddleware requestDelegate, HttpContext context)
        {
            try
            {
                await requestDelegate.NextAsync(context);
            }
            catch (Exception ex)
            {
                await ExceptionHandlerAsync(ex, context);
                return;
            }
        }

        public async Task ExceptionHandlerAsync(Exception ex, HttpContext context)
        {
            LoggerHelper.DangerWriteLine(ex.Message);
            string mgs = string.Empty;
            IResponse response = ResponseFactory.Create(HttpStatusCodeEnum.BadRequest);
            switch (ex)
            {
                case NotFoundException notFoundException:
                    mgs = notFoundException.Message;
                    response = ResponseFactory.Create(HttpStatusCodeEnum.NotFound);
                    break;
                case UnauthorizedException unauthorizedException:
                    mgs = unauthorizedException.Message;
                    response = ResponseFactory.Create(HttpStatusCodeEnum.Unauthorized);
                    break;
                case ForbiddenException forbiddenException:
                    mgs = forbiddenException.Message;
                    response = ResponseFactory.Create(HttpStatusCodeEnum.Forbidden);
                    break;
                case AppException appException:
                    mgs = appException.Message;
                    response = ResponseFactory.Create(HttpStatusCodeEnum.BadRequest);
                    break;
                default:
                    mgs = ex.Message;
                    break;
            }
            var result = ResultFactory.CreateJson(new { IsSuccess = false, Message = mgs });
            await result.RunAsync(context);
            await response.RunAsync(context);
        }
    }
}