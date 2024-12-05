namespace simpleServer.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : this("Unauthorized") { }
        public UnauthorizedException(string mgs) : base(mgs) { }
    }
}