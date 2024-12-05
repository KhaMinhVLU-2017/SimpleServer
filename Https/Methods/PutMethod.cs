using simpleServer.Https.Models;

namespace simpleServer.Https.Methods
{
    public class PutMethod : BaseMethod
    {
        public PutMethod(string content) : base(content)
        {
        }

        public override HttpRequest Compile()
        {
            throw new NotImplementedException();
        }
    }
}