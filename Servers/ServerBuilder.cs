using simpleServer.Helpers;
using simpleServer.Options;

namespace simpleServer.Servers
{
    public class ServerBuilder
    {
        private int _port;
        private string _url;
        private string _cors;
        private string _protocol;

        public ServerBuilder() : this(null) { }

        public ServerBuilder(ServerOption option)
        {
            if (option is null)
            {
                var serversOption = OptionHelper.GetServerSettings();
                option = serversOption.Servers;
            }
            _port = option.Port;
            _url = option.HOST;
            _cors = option.Cors;
            _protocol = option.Protocol;
        }

        public ServerBuilder AddPort(int port)
        {
            _port = port;
            return this;
        }

        public ServerBuilder AddURL(string url)
        {
            _url = url;
            return this;
        }

        public IMiniApp Build()
        {
            var option = new ServerOption
            {
                HOST = _url,
                Port = _port,
                Cors = _cors,
                Protocol = _protocol
            };
            return new ServerApp(option);
        }
    }
}