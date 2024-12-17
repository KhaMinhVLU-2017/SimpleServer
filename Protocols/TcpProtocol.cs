using System.Net;
using System.Net.Sockets;
using simpleServer.Helpers;
using simpleServer.Options;

namespace SimpleServer.Protocols
{
    public class TcpProtocol : BaseProtocol
    {
        private Socket _listener;
        private Socket _socket;

        public TcpProtocol(ServerOption serverOption) : base(serverOption)
        {
        }

        public override void Close()
        {
            _socket.Close();
        }

        public override async Task<AppSocket> ConnectAsync()
        {
            var ipAddress = await GetLocalIPAddressAsync();
            IPEndPoint ipEndPoint = new(ipAddress, _serverOption.Port);
            _listener = new(
                                        ipEndPoint.AddressFamily,
                                        SocketType.Stream,
                                        ProtocolType.Tcp);
            _listener.Bind(ipEndPoint);
            _listener.Listen(100);
            LoggerHelper.DisplayServer(_listener.LocalEndPoint.ToString());
            return new AppSocket(this);
        }

        public override void Dispose()
        {
            _socket.Dispose();
        }

        public override async Task<byte[]> ReceiveAsync()
        {
            _socket = await _listener.AcceptAsync();
            var buffer = new byte[1_000_000];
            var received = await _socket.ReceiveAsync(buffer);
            if (received == 0) return default;
            Array.Resize(ref buffer, received);
            return buffer;
        }

        public override async Task SendAsync(byte[] payload)
        {
            await _socket.SendAsync(payload);
        }
    }
}