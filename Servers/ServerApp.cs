using System.Text;
using simpleServer.Helpers;
using simpleServer.Options;
using SimpleServer.Protocols;
using simpleServer.Pipelines;
using simpleServer.Https.Models;

namespace simpleServer.Servers
{
    public class ServerApp : IMiniApp
    {
        private ServerOption _option;

        public ServerApp(ServerOption option) => _option = option;

        public async Task StartAsync()
        {
            var server = ProtocolFactory.Create(_option);
            var socket = await server.ConnectAsync();
            while (true)
            {
                var contextBuilder = new HttpContextBuilder();
                contextBuilder.AddSocket(socket);
                contextBuilder.AddResponse(new());
                var buffer = await socket.ReceiveAsync();
                if (buffer is null)
                {
                    socket.Close();
                    continue;
                }
                var request = Encoding.ASCII.GetString(buffer);

                contextBuilder.AddRequest(request.CreateHttpRequestFromText());
                await ConfigureAsync(contextBuilder.Build());
            }
        }

        public async Task ConfigureAsync(HttpContext context)
        {
            var caller = MiddlewareFactory.Create(new BaseMiddleware[] {
                                                    new ExceptionMiddleware(),
                                                    new ResponseMiddleware(),
                                                    new RequestRegisterMiddleware(),
                                                    new TransformMiddleware(),
                                                    new CorsMiddlware(),
                                                    new StaticFileMiddleware(),
                                                    new AuthenticationMiddleware(),
                                                    new AuthorizationMiddleware(),
                                                    new RoutingMiddleware(),
                                                });
            await caller.NextAsync(context);
        }

        public Task StopAsync()
        {
            throw new NotImplementedException();
        }
    }
}