using simpleServer.Constants;
using simpleServer.Exceptions;
using simpleServer.Https.Models;
using simpleServer.Https.Methods;
using System.Text.RegularExpressions;

namespace simpleServer.Helpers
{
    public static class HttpHelper
    {
        public static string GetMethod(this string method)
        {
            string methodClean = method.Trim().ToUpper();
            switch (methodClean)
            {
                case HTTPConstant.GET_METHOD:
                    return HTTPConstant.GET_METHOD;
                case HTTPConstant.DELETE_METHOD:
                    return HTTPConstant.DELETE_METHOD;
                case HTTPConstant.HEAD_METHOD:
                    return HTTPConstant.HEAD_METHOD;
                case HTTPConstant.PATH_METHOD:
                    return HTTPConstant.PATH_METHOD;
                case HTTPConstant.POST_METHOD:
                    return HTTPConstant.POST_METHOD;
                case HTTPConstant.PUT_METHOD:
                    return HTTPConstant.PUT_METHOD;
                case HTTPConstant.OPTION_METHOD:
                    return HTTPConstant.OPTION_METHOD;
                case HTTPConstant.TRACE_METHOD:
                    return HTTPConstant.TRACE_METHOD;
                default:
                    throw new Exception("Method not support");
            }
        }

        public static HttpRequest CreateHttpRequestFromText(this string content)
        {
            var method = GetMethodFromRequest(content);
            var requestInner = MethodFactory.Create(method, content);
            return requestInner.Compile();
        }

        private static string GetMethodFromRequest(string content)
        {
            string pattern = @"^[^\r\n]+";
            var matches = Regex.Matches(content, pattern, RegexOptions.Multiline);
            var firstLine = matches.First().Value.Trim();
            var method = firstLine.Split(" ").First();
            return method;
        }

        public static string GetActionFromPath(this string path)
        {
            var paths = path.Trim().Split("/").Where(s => !string.IsNullOrEmpty(s)).ToArray();
            if (paths.Length < 2) throw new NotFoundException("Path not found");
            string controllerText = paths[0].ToLower();
            string actionText = paths[1].ToLower();
            return actionText;
        }
    }
}