using System.Net;
using System.Text;
using System.Net.Sockets;
using simpleServer.Pipelines;
using simpleServer.Helpers;
using simpleServer.Options;
using simpleServer.Https.Models;

namespace simpleServer.Servers
{
    public class ServerApp : IMiniApp
    {
        private ServerOption _option;
        private string MESSAGE = @"
HTTP/1.1 400 Bad Request
Access-Control-Allow-Origin: localhost:5000, *
Content-Type: text/html
Date: 11/27/2024 6:58:11 AM
Last-Modified: 11/27/2024 6:58:11 AM
X-Kuma-Revision: 0
Content-Length: 10000" + "\r\n\r\n" +
@"<!DOCTYPE  html>
<html>
<body>
    <h1> Minh Nguyen </h1>
</body>
</html>
";


        //         private string MESSAGE = @"
        // HTTP/1.1 200 OK
        // Date: Sun, 10 Oct 2010 23:26:07 GMT
        // Server: Apache/2.2.8 (Ubuntu) mod_ssl/2.2.8 OpenSSL/0.9.8g
        // Last-Modified: Sun, 26 Sep 2010 22:04:35 GMT
        // ETag: '45b6-834-49130cc1182c0'
        // Accept-Ranges: bytes
        // Content-Length: 12
        // Connection: close
        // Content-Type: text/html
        // Location: http://example.com/users/123

        // Hello world!";



        public ServerApp(ServerOption option) => _option = option;

        private async Task<IPAddress> GetLocalIPAddressAsync()
        {
            var hostName = _option.HOST;
            if (string.IsNullOrEmpty(_option.HOST))
                hostName = Dns.GetHostName();

            IPAddress[] localIpAddress = await Dns.GetHostAddressesAsync(hostName);
            return localIpAddress[0];
        }

        public async Task StartAsync()
        {
            var ipAddress = await GetLocalIPAddressAsync();
            IPEndPoint ipEndPoint = new(ipAddress, _option.Port);
            using Socket listener = new(
                                        ipEndPoint.AddressFamily,
                                        SocketType.Stream,
                                        ProtocolType.Tcp);
            listener.Bind(ipEndPoint);
            listener.Listen(100);

            LoggerHelper.DisplayServer(ipEndPoint.ToString());

            while (true)
            {
                var handler = await listener.AcceptAsync();
                var contextBuilder = new HttpContextBuilder();
                contextBuilder.AddSocket(handler);
                contextBuilder.AddResponse(new());
                var buffer = new byte[8_024];
                var received = await handler.ReceiveAsync(buffer);
                if (received == 0)
                {
                    handler.Close();
                    continue;
                }
                var request = Encoding.ASCII.GetString(buffer, 0, received);

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