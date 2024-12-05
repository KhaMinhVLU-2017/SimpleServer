using simpleServer.Constants;
using simpleServer.Https.Models;
using simpleServer.Models.Results;

namespace simpleServer.Controllers
{
    public abstract class BaseController
    {
        public HttpContext Context { get; set; }


        protected async Task OkAsync(object content)
        {
            var result = ResultFactory.CreateJson(content);
            Context.Response.StatusCode = HttpStatusCodeEnum.Ok;
            await result.RunAsync(Context);
        }

        protected IResult Ok(object content)
        {
            Context.Response.StatusCode = HttpStatusCodeEnum.Ok;
            var result = ResultFactory.CreateJson(content);
            return result;
        }

        protected IResult Created(object content, string location = default)
        {
            Context.Response.StatusCode = HttpStatusCodeEnum.Created;
            Context.Response.Header.Location = location;
            var result = ResultFactory.CreateJson(content);
            return result;
        }

        protected IResult BadObject(object content)
        {
            Context.Response.StatusCode = HttpStatusCodeEnum.BadRequest;
            var result = ResultFactory.CreateJson(content);
            return result;
        }

        protected IResult Accepted(object content)
        {
            Context.Response.StatusCode = HttpStatusCodeEnum.Accepted;
            var result = ResultFactory.CreateJson(content);
            return result;
        }

        protected IResult Html(string html)
        {
            Context.Response.StatusCode = HttpStatusCodeEnum.Ok;
            var result = ResultFactory.CreateHtml(html);
            return result;
        }

        protected IResult Image(string contentType, byte[] bytes)
        {
            Context.Response.StatusCode = HttpStatusCodeEnum.Ok;
            var result = new ImageResult(contentType, bytes);
            return result;
        }

        protected IResult Image(string contentType, string fileName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            var bytes = File.ReadAllBytes(filePath);
            return Image(contentType, bytes);
        }

        protected IResult View() => ResultFactory.CreateView();

    }
}