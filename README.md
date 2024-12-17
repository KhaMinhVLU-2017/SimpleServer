# Simple Server

I rebuild a web server similar ASP.NET for learning purposes but it's simple than it.    
It created by __C# and Socket__.  
I simulate ASP.NET behavior the way I think.  
Let's study together, let's goooooooooooooooooooooo.  

## Agenda
* Features
* Technologies & Pattern
* How to use it?
* Reference


## Features
✅ Features deployed on simple servers:  
* Socket
* Protocol: Http1.1
* Pipeline ordering
  * Exception
  * CORS
  * StaticFile
  * Authentication
  * Authorization
  * Routing
* REST API
  * Request
     * Query params
  * Response
     * Informational responses (100 – 199)
     * Successful responses (200 – 299)
     * Redirection messages (300 – 399)
     * Client error responses (400 – 499)
     * Server error responses (500 – 599)
* MVC
  * Controllers and Views folders

❌ Pending features:
* __REST API__: POST, PUT, DELETE, PATH, OPTION, HEAD
* __Protocol__: Http2.0

## Technologies & Pattern
### Technologies
Framework: .Net 8  
Main nuget: __Socket__ and Newtonsoft.Json  

__First__, I learned what the HTTP protocol is and how to build it. Luckily, it is very easy; it just transfers text between networks. Let's focus on the data transmission encoding method. I chose __ASCII__.  
__Second__, the foundation of HTTP is built from a __socket__. It is like a place where you can send and receive data between programs in a network. But how to send and receive? You probably heard of __TCP or UDP__. It helps to transmit data. I chose __TCP__ for more __reliability__.  
__Third__, Implement it by code C#. I recommend `TCP/IP Sockets in C#`'s book for you.

### Pattern
There are patterns I used on simple server.  
__Buider pattern__: I apply for build context (request/response).  
__Strategy pattern__: 
* HTTP Methods: GET, PUT, DELETE, POST, HEAD, PATH, OPTION, etc...
* Result: View (MVC), JSON, HTML, IMAGE, FILE, etc...
* Response status: from status code 1xx --> 5xx

__Pipeline pattern__: use for ordering middleware of simple server.

### How to use it?
Access to simpleServer then run cli: `dotnet run`
You will see results similar below it.
![StreamConsole](/Files/console.jpg)

You can navigate to `HomesController` and then use Postman to test it.  

__Sample__:  
__CreateProduct: GET {{host}}/homes/create__ 
![Json](/Files/create.jpg)

__BadRequest: GET {{host}}/homes/xxx__ 
![BadRequest](/Files/badrequest.jpg)

__Return Image: GET {{host}}/homes/image__ 
![Image](/Files/image.jpg)

__MVC - View: GET {{host}}/homes/about__
![View](/Files/view.jpg)


## Reference
https://developer.mozilla.org/en-US/docs/Web/HTTP/Messages
https://datatracker.ietf.org/doc/html/rfc2616
https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/sockets/socket-services  
Book: __TCP/IP Sockets in C#__

## Release
### Version 1.0.1 - 12-17-2024
The Simple Server support __TCP and UDP__ protocol.  
The user can config at `serverSetting.json` with values: `udp` or `tcp` on protocol property.  
```
{
    "servers": {
        "host": "localhost",
        "port": 5000,
        "cors": "*",
        "protocol": "udp"  
    }
}
```
See more [TCP](/Protocols/TcpProtocol.cs) or [UDP](/Protocols/UdpProtocol.cs) protocol.


*Thanks for watching*