using System.Text;
using System.Text.RegularExpressions;
using simpleServer.Helpers;
using simpleServer.Https.Models;
using Newtonsoft.Json;

namespace simpleServer.Https.Methods
{
    public class GetMethod : BaseMethod
    {
        public GetMethod(string content) : base(content)
        {
        }

        public override HttpRequest Compile()
        {
            var request = GetHttpRequest();
            return request;
        }

        private HttpRequest GetHttpRequest()
        {
            string pattern = @"^[^\r\n]+";
            var matches = Regex.Matches(Content, pattern, RegexOptions.Multiline);

            var firstLine = matches[0].Value.Trim();
            var secondLine = matches[1].Value.Trim().Split(" ")[1];

            var informations = firstLine.Split(" ");
            var request = new HttpRequest
            {
                Method = informations[0].GetMethod(),
                Path = GetPath(informations[1]),
                Protocol = informations[2],
                Host = secondLine,
                Params = GetPararms(informations[1]),
            };

            var lines = matches.Select(s => s.Value.Trim()).ToList();
            lines.RemoveAt(0);
            lines.RemoveAt(0);

            string propertyPattern = @"^((.+):\s+)(.*)";
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line)) continue;
                var matcheGroups = Regex.Matches(line, propertyPattern);
                var groups = matcheGroups[0].Groups;
                string property = groups[2].Value;
                string value = groups[3].Value.Trim('"').Replace('"', '\'');
                string newLine = $"\"{property}\": \"{value}\",";
                sb.Append(newLine);
            }
            sb.Append("}");

            string jsonText = sb.ToString();
            var header = JsonConvert.DeserializeObject<HttpHeaderRequest>(jsonText);
            request.Header = header;
            return request;
        }

        private string GetPath(string path)
        {
            string pattern = @".*\?";
            Regex rg = new Regex(pattern);
            var match = rg.Match(path);
            if (match.Success)
                return match.Value.Trim('?');

            string urlPattern = @".*";
            Regex originRg = new Regex(urlPattern);
            var originMatch = originRg.Match(path);
            return originMatch.Value;
        }

        private IDictionary<string, object> GetPararms(string path)
        {
            string paramsPattern = @"\?.*";
            Regex paramsRg = new Regex(paramsPattern);
            string paramsPath = paramsRg.Match(path).Value.Trim('?');
            string pattern = @"[\w+=\w+]+";
            Regex rg = new Regex(pattern);
            var matches = rg.Matches(paramsPath).ToArray();
            var kv = new List<KeyValuePair<string, object>>();
            foreach (var match in matches)
            {
                var arr = match.Value.Split("=");
                string key = arr[0];
                object value = arr[1];
                kv.Add(new KeyValuePair<string, object>(key, value));
            }

            return kv.ToDictionary();
        }
    }
}