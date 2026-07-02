namespace MonitorAgent.API.Contracts;

public class ConnectionsCountResponse
{
    public int Tcp {get;set;}
    public int Udp {get;set;}
}