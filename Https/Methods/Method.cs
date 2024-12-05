using simpleServer.Https.Models;

namespace simpleServer.Https.Methods
{
    public abstract class BaseMethod : IMethod
    {
        protected string Content;

        public BaseMethod(string content) => Content = content;

        public abstract HttpRequest Compile();
    }
}