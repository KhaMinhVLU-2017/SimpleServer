using simpleServer.Https.Models;

namespace simpleServer.Https.Methods
{
    public class PostMethod : BaseMethod
    {
        public PostMethod(string content) : base(content)
        {
        }

        public override HttpRequest Compile()
        {
            throw new NotImplementedException();
        }
    }
}