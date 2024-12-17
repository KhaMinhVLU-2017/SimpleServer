using System.Net;
using System.Net.Sockets;
using simpleServer.Helpers;
using simpleServer.Options;

namespace SimpleServer.Protocols
{
    public class UdpProtocol : BaseProtocol
    {
        private UdpClient _listener;
        private IPEndPoint _remoteIPEndpoint;

        public UdpProtocol(ServerOption serverOption) : base(serverOption)
        {
        }

        public override void Close()
        {

        }

        public override Task<AppSocket> ConnectAsync()
        {
            _listener = new UdpClient(_serverOption.Port);
            _remoteIPEndpoint = new(IPAddress.Any, 0);
            LoggerHelper.DisplayServer(_listener.Client.LocalEndPoint.ToString());
            return Task.FromResult(new AppSocket(this));
        }

        public override void Dispose()
        {

        }

        public override Task<byte[]> ReceiveAsync()
        {
            var bytes = _listener.Receive(ref _remoteIPEndpoint);
            return Task.FromResult(bytes);
        }

        public override async Task SendAsync(byte[] payload)
        {
            await _listener.SendAsync(payload, payload.Length, _remoteIPEndpoint);
        }
    }
}