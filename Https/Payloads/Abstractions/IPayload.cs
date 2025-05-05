namespace SimpleServer.Https.Payloads.Abstractions
{
    public interface IPayload
    {
        IDictionary<string, object> Combine();
    }
}