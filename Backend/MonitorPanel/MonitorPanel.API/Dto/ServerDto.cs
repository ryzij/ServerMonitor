namespace MonitorPanel.API.Dto;

public class ServerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsHttps { get; set; }
    public string Address { get; set; } = string.Empty;
    public string? Path { get; set; }
    public int Port { get; set; }
}