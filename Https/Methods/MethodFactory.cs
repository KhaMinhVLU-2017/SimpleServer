using simpleServer.Constants;

namespace simpleServer.Https.Methods
{
    public static class MethodFactory
    {
        public static IMethod Create(string method, string content)
        {
            switch (method)
            {
                case HTTPConstant.GET_METHOD:
                    return new GetMethod(content);
                case HTTPConstant.POST_METHOD:
                    return new PostMethod(content);
                case HTTPConstant.DELETE_METHOD:
                    return new DeleteMethod(content);
                case HTTPConstant.PUT_METHOD:
                    return new PutMethod(content);
                case HTTPConstant.PATH_METHOD:
                    return new PathMethod(content);
                case HTTPConstant.OPTION_METHOD:
                    return new OptionMethod(content);
                case HTTPConstant.TRACE_METHOD:
                    return new TraceMethod(content);
                case HTTPConstant.HEAD_METHOD:
                    return new HeadMethod(content);
                default:
                    throw new Exception("Not support method");
            }
        }
    }
}