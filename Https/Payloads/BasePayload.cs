using SimpleServer.Https.Payloads.Abstractions;

namespace SimpleServer.Https.Payloads
{
    public abstract class BasePayload : IPayload
    {
        protected byte[] BytesContent;

        public BasePayload(byte[] bytes) => BytesContent = bytes;

        public abstract IDictionary<string, object> Combine();
    }
}