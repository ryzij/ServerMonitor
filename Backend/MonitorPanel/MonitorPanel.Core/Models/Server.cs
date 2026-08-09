namespace MonitorPanel.Core.Models;

public class Server(
    Guid id,
    string name,
    string address,
    string? path = null,
    bool isHttps = true,
    int port = 443)
{
    public readonly Guid Id = id;
    public string Name { get; set; } = name;
    public bool IsHttps { get; set; } = isHttps;
    public string Address { get; set; } = address;
    public string? Path { get; set; } = path;
    public int Port { get; set; } = port;
}