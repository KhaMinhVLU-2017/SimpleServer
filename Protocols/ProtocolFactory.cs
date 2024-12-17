using simpleServer.Options;
using SimpleServer.Constants;

namespace SimpleServer.Protocols
{
    public class ProtocolFactory
    {
        public static BaseProtocol Create(ServerOption option)
        {
            if (option.Protocol.Equals(ProtocolConstant.TCP, StringComparison.InvariantCultureIgnoreCase))
                return new TcpProtocol(option);

            return new UdpProtocol(option);
        }
    }
}