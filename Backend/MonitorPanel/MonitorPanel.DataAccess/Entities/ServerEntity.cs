using System.ComponentModel.DataAnnotations;
namespace MonitorPanel.DataAccess.Entities;

public class ServerEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsHttps { get; set; }
    [Required]
    public string Address { get; set; } = null!;
    public string? Path { get; set; }
    [Required]
    public int Port { get; set; }
}