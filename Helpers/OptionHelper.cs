using Newtonsoft.Json;
using simpleServer.Options;

namespace simpleServer.Helpers
{
    public class OptionHelper
    {
        private static object _lock = new object();
        private static ServersOption _serversOption = null;

        public static ServersOption GetServerSettings()
        {
            if (_serversOption is not null) return _serversOption;
            lock (_lock)
            {
                if (_serversOption is not null) return _serversOption;

                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "serverSettings.json");
                string serverSettingsText = File.ReadAllText(filePath);
                var serversOption = JsonConvert.DeserializeObject<ServersOption>(serverSettingsText);
                _serversOption = serversOption;
            }
            return _serversOption;
        }
    }
}