using simpleServer.Constants;
using SimpleServer.Https.Payload;
using SimpleServer.Https.Payloads.Abstractions;

namespace SimpleServer.Https.Payloads
{
    public static class PayloadFactory
    {
        public static IPayload CreatePayoad(this string contentType, byte[] bytes)
        {
            if (MimeTypeConstant.JSON.Equals(contentType, StringComparison.InvariantCultureIgnoreCase))
                return new ApplicationJsonPayload(bytes);
            if (MimeTypeConstant.MULTIPART_FORMDATA.Equals(contentType, StringComparison.InvariantCultureIgnoreCase))
                return new MultipartFormDataPayload(bytes);

            throw new Exception("MimeType not support!");
        }
    }
}