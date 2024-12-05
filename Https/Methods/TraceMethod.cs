using simpleServer.Https.Models;

namespace simpleServer.Https.Methods
{
    public class TraceMethod : BaseMethod
    {
        public TraceMethod(string content) : base(content)
        {
        }

        public override HttpRequest Compile()
        {
            throw new NotImplementedException();
        }
    }
}