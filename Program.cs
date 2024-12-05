using simpleServer.Servers;

var builder = new ServerBuilder();
var app = builder.Build();
await app.StartAsync();