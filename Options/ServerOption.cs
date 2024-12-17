namespace simpleServer.Options
{
    public class ServerOption
    {
        public string Cors { get; set; }
        public string HOST { get; set; }
        public int Port { get; set; }
        public string Protocol { get; set; } = "TCP";
    }
}