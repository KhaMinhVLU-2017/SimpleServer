using simpleServer.Https.Models;

namespace simpleServer.Https.Methods
{
    public class OptionMethod : BaseMethod
    {
        public OptionMethod(string content) : base(content)
        {
        }

        public override HttpRequest Compile()
        {
            throw new NotImplementedException();
        }
    }
}