using SimpleServer.Https.Payloads;

namespace SimpleServer.Https.Payload
{
    public class ApplicationJsonPayload : BasePayload
    {

        public ApplicationJsonPayload(byte[] bytes) : base(bytes)
        {
        }

        public override IDictionary<string, object> Combine()
        {
            var dic = new Dictionary<string, object>();
            using (var sr = new StreamReader(new MemoryStream(BytesContent)))
            {
                string line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Equals("{") || line.Equals("}")) continue;
                    string[] arr = line.Split(':', 2);
                    string key = arr[0].Trim(['"', '\\', ',', ' ']);
                    string value = arr[1].Trim(['"', '\\', ',', ' ']);
                    if (dic.ContainsKey(key)) continue;
                    dic.Add(key, value);
                }
            }
            return dic;
        }
    }
}