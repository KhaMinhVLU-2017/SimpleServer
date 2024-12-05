namespace simpleServer.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException() : this("Forbidden") { }
        public ForbiddenException(string mgs) : base(mgs) { }
    }
}