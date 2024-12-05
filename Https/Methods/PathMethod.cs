using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simpleServer.Https.Models;

namespace simpleServer.Https.Methods
{
    public class PathMethod : BaseMethod
    {
        public PathMethod(string content) : base(content)
        {
        }

        public override HttpRequest Compile()
        {
            throw new NotImplementedException();
        }
    }
}