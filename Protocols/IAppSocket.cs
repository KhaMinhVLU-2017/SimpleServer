namespace SimpleServer.Protocols
{
    public interface IAppSocket : IDisposable
    {
        Task<byte[]> ReceiveAsync();
        Task SendAsync(byte[] payload);
        void Close();
    }
}