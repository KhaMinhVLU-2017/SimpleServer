using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleServer.Servers
{
    public interface IMiniApp
    {
        Task StartAsync();
        Task StopAsync();
    }
}