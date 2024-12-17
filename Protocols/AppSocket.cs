namespace SimpleServer.Protocols
{

    public class AppSocket : IAppSocket
    {
        private IAppSocket _socket;

        public AppSocket(IAppSocket socket) => _socket = socket;

        public void Close() => _socket.Close();
        public void Dispose() => _socket.Dispose();
        public Task<byte[]> ReceiveAsync() => _socket.ReceiveAsync();
        public Task SendAsync(byte[] payload) => _socket.SendAsync(payload);
    }
}