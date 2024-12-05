namespace simpleServer.Pipelines
{
    public static class MiddlewareFactory
    {
        public static IMiddleware Create(IEnumerable<BaseMiddleware> middlewares)
        {
            BaseMiddleware pipe = new DefaultMiddleware();
            var reverse = middlewares.Reverse();
            foreach (var item in reverse)
            {
                item.AddMiddleware(pipe);
                pipe = item;
            }
            return pipe;
        }
    }
}