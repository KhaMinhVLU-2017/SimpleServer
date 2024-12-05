using simpleServer.Https.Models;

namespace simpleServer.Https.Methods
{
    public class HeadMethod : BaseMethod
    {
        public HeadMethod(string content) : base(content)
        {
        }

        public override HttpRequest Compile()
        {
            throw new NotImplementedException();
        }
    }
}