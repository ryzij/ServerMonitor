namespace MonitorAgent.Core.Models;

public class ConnectionsCount(int tcp, int udp)
{
    public readonly int TcpCount = tcp;
    public readonly int UdpCount = udp;
}