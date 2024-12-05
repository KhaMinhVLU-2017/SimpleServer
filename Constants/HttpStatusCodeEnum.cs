using System.ComponentModel;

namespace simpleServer.Constants
{
    public enum HttpStatusCodeEnum
    {
        Continue = 100,

        Ok = 200,
        Created = 201,
        Accepted = 202,

        [Description("Non-Authoritative Information")]
        NonAuthoritativeInformation = 203,

        [Description("No Content")]
        NoContent = 204,

        [Description("Reset Content")]
        ResetContent = 205,

        [Description("Partial Content")]
        PartialContent = 206,

        [Description("Moved Permanently")]
        MovedPermanently = 301,

        [Description("Bad Request")]
        BadRequest = 400,

        Unauthorized = 401,

        [Description("Payment Required")]
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404,

        [Description("Method Not Allowed")]
        MethodNotAllowed = 405,

        [Description("Not Acceptable")]
        NotAcceptable = 406,

        [Description("Internal Server Error")]
        InternalServerError = 500,

        [Description("Not Implemented")]
        NotImplemented = 501,

        [Description("Bad Gateway")]
        BadGateway = 502,

        [Description("Service Unavailable")]
        ServiceUnavailable = 503,

        [Description("Gateway Timeout")]
        GatewayTimeout = 504

    }
}