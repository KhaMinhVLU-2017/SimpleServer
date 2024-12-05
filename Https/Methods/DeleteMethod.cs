using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simpleServer.Https.Models;

namespace simpleServer.Https.Methods
{
    public class DeleteMethod : BaseMethod
    {
        public DeleteMethod(string content) : base(content)
        {
        }

        public override HttpRequest Compile()
        {
            // TODO logic
            return null;
        }
    }
}