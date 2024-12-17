using System.Net;
using simpleServer.Options;

namespace SimpleServer.Protocols
{
    public abstract class BaseProtocol : IAppProtocol, IAppSocket
    {
        protected ServerOption _serverOption;
        public BaseProtocol(ServerOption serverOption)
        {
            _serverOption = serverOption;
        }

        protected async Task<IPAddress> GetLocalIPAddressAsync()
        {
            var hostName = _serverOption.HOST;
            if (string.IsNullOrEmpty(_serverOption.HOST))
                hostName = Dns.GetHostName();

            IPAddress[] localIpAddress = await Dns.GetHostAddressesAsync(hostName);
            return localIpAddress[0];
        }

        public abstract Task<AppSocket> ConnectAsync();
        public abstract Task<byte[]> ReceiveAsync();
        public abstract Task SendAsync(byte[] payload);
        public abstract void Close();
        public abstract void Dispose();

    }
}