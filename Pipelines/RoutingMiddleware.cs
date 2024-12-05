using simpleServer.Helpers;
using System.Reflection;
using simpleServer.Exceptions;
using simpleServer.Controllers;
using simpleServer.Https.Models;
using System.Text.RegularExpressions;
using simpleServer.Models.Results;
using System.ComponentModel.DataAnnotations;

namespace simpleServer.Pipelines
{
    public class RoutingMiddleware : BaseMiddleware
    {
        private string CONTROLLER_PATTERN = @"^.*(?=[c|C]ontroller)";
        private string ACTION_PATTERN = @"^.*(?=[a|A]sync)|^.*";

        public RoutingMiddleware() : this(null) { }

        public RoutingMiddleware(IMiddleware next) : base(next)
        {
        }

        public override async Task NextAsync(IMiddleware requestDelegate, HttpContext context)
        {
            Console.WriteLine("Routing request");
            await RoutingInvokeAsync(context);
            await requestDelegate.NextAsync(context);
            Console.WriteLine("Routing response");
        }

        private async Task RoutingInvokeAsync(HttpContext context)
        {
            var request = context.Request;
            Type baseControllerType = typeof(BaseController);
            var implements = Assembly.GetEntryAssembly().GetTypes().Where(s => s.IsSubclassOf(baseControllerType));
            Regex rg = new Regex(CONTROLLER_PATTERN);
            var controllerDic = implements.ToDictionary(s => rg.Match(s.Name).Value.ToLower());

            var paths = request.Path.Trim().Split("/").Where(s => !string.IsNullOrEmpty(s)).ToArray();
            if (paths.Length < 2) throw new NotFoundException("Path not found");
            string controllerText = paths[0].ToLower();
            string actionText = paths[1].ToLower();

            bool isMatchController = controllerDic.ContainsKey(controllerText);
            if (!isMatchController) throw new NotFoundException("Path not found");

            var controllerType = controllerDic[controllerText];
            Regex actionRg = new Regex(ACTION_PATTERN);
            // TODO need parse request by method: GET, POST, PUT, etc...
            var methodDic = controllerType.GetMethods().ToDictionary(s => s.Name.ToLower());
            bool isMatchAction = methodDic.ContainsKey(actionText);
            MethodInfo method = null;
            if (isMatchAction)
            {
                method = methodDic[actionText];
            }
            else
            {
                string actionAsyncText = $"{actionText}async";
                bool isMatchActionAsync = methodDic.ContainsKey(actionAsyncText);
                if (!isMatchActionAsync) throw new NotFoundException("Path not found");
                method = methodDic[actionAsyncText];
            }

            ParameterInfo[] parameters = method.GetParameters();
            object classInstance = Activator.CreateInstance(controllerType, null);
            PropertyInfo prop = controllerType.GetProperty("Context");
            prop.SetValue(classInstance, context, null);
            IResult result = null;
            if (parameters.Any())
            {
                object args = request.Params.CastToObject(parameters[0].ParameterType);
                result = await CastToResultAsync(method.Invoke(classInstance, [args]));
            }
            else
                result = await CastToResultAsync(method.Invoke(classInstance, null));


            // TODO Get Result from action of controller then build response HTTP/1.1
            if (result is not null)
                await result?.RunAsync(context);
        }

        private async Task<IResult> CastToResultAsync(object request)
        {
            if (request is null) return null;
            if (request is IResult) return (IResult)request;
            if (request is Task<IResult>)
            {
                var task = (Task<IResult>)request;
                var result = await task;
                return result;
            }
            if (request is not null)
            {
                // TODO Check normal object not task
                bool isObject = request.GetType().BaseType == typeof(object);
                if (isObject)
                    return new JsonResult(request);
                var hasTask = request.GetType().GetGenericTypeDefinition() == typeof(Task<>);
                if (hasTask)
                {
                    var result = await request.GetResultFromTaskAsync<object>();
                    return new JsonResult(result);
                }

            }
            return null;
        }
    }
}