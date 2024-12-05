namespace simpleServer.Exceptions
{
    public class AppException : Exception
    {
        public AppException() : this("Bad request") { }
        public AppException(string mgs) : base(mgs) { }
    }
}