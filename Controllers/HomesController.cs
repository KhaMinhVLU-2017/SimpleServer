using simpleServer.Attributes;
using simpleServer.Constants;
using simpleServer.Helpers;
using simpleServer.Models.Requests;
using simpleServer.Models.Results;
using simpleServer.Options;

namespace simpleServer.Controllers
{
    public class HomesController : BaseController
    {
        private ServersOption _serversOption = OptionHelper.GetServerSettings();

        public async Task IndexAsync()
        {
            Console.WriteLine("Home index");
        }

        public IResult About()
        {
            return View();
        }

        public IResult Index()
        {
            var option = _serversOption.Servers;
            string html = @"
            <div>
                <h1>Welcome to mini server</h1> 
                <h5>Server run: @url </h5>
                <h5>Author: <strong>Minh Nguyen</strong></h5>
                <h5>Website: <a href='https://www.mnlifeblog.com'>https://www.mnlifeblog.com</a></h5>
            </div>
            ";
            html = html.Replace("@url", $"{option.HOST}:{option.Port}");
            Console.WriteLine("Home index");
            return Html(html);
        }

        [HttpPost]
        public async Task<IResult> CreateAsync(CreateProduct request)
        {
            Console.WriteLine($"Created");
            return Created(request, $"https://www.mnlifeblog.com/products/{request.UserName}");
        }

        public async Task<IResult> AcceptAsync(CreateProduct request)
        {
            Console.WriteLine($"Accepted");
            return Accepted(request);
        }

        public async Task<IResult> BadAsync(CreateProduct request)
        {
            Console.WriteLine($"Bad");
            return BadObject(request);
        }

        public IResult CreateResult(CreateProduct request)
        {
            Console.WriteLine($"Return object with specific IResult");
            return Ok(request);
        }
        public async Task<IResult> CreateResultTaskAsync(CreateProduct request)
        {
            Console.WriteLine($"Return object with specific Task<IResult>");
            return Ok(request);
        }

        public async Task<CreateProduct> CreateDynamicTaskAsync(CreateProduct request)
        {
            Console.WriteLine($"Return dynamic object with wrap task");
            return request;
        }
        public CreateProduct CreateDynamic(CreateProduct request)
        {
            Console.WriteLine($"Return dynamic object without wrap");
            return request;
        }


        public async Task<IResult> ImageAsync()
        {
            return Image(MimeTypeConstant.JPEG, "Files/avatar.jpg");
        }
    }
}