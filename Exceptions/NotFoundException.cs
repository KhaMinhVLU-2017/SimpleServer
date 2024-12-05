namespace simpleServer.Exceptions
{
    public class NotFoundException : System.Exception
    {
        public NotFoundException() : base("Not Found") { }
        public NotFoundException(string mgs) : base(mgs) { }
    }
}