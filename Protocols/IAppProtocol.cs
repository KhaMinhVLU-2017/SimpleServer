namespace SimpleServer.Protocols
{
    public interface IAppProtocol
    {
        Task<AppSocket> ConnectAsync();
    }
}