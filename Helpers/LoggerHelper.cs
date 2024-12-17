namespace simpleServer.Helpers
{
    public class LoggerHelper
    {
        public static void WriteLine(string mgs)
        {
            WriteLine(ConsoleColor.Green, mgs);
        }

        public static void WriteLine(ConsoleColor color, string mgs)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(mgs);
            Console.ResetColor();
        }

        public static void DangerWriteLine(string mgs)
        {
            WriteLine(ConsoleColor.Red, mgs);
        }

        public static void DisplayServer(string host)
        {
            var option = OptionHelper.GetServerSettings().Servers;
            WriteLine("Welcome to Mini Server");
            WriteLine($"Server start at: {host} with Protocol: {option.Protocol.ToUpper()}");
        }
    }
}