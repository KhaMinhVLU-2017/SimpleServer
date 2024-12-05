using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simpleServer.Https.Models;

namespace simpleServer.Https.Methods
{
    public interface IMethod
    {
        HttpRequest Compile();
    }
}