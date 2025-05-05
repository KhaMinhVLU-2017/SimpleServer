namespace SimpleServer.Https.Payloads
{
    public class MultipartFormDataPayload : BasePayload
    {
        public MultipartFormDataPayload(byte[] bytes) : base(bytes)
        {
        }

        public override IDictionary<string, object> Combine()
        {
            throw new NotImplementedException();
        }
    }
}