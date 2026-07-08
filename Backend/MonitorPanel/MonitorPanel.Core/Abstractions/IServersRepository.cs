using MonitorPanel.Core.Models;
namespace MonitorPanel.Core.Abstractions;

public interface IServersRepository
{
    Task<IEnumerable<Server>> GetAllServersAsync();
    Task<Server?> GetServerByIdAsync(Guid id);
    Task<Guid> AddServerAsync(Server server);
    Task<Guid> UpdateServerAsync(Guid id, string name, bool isHttps, string address, string? path, int port);
    Task<Guid> DeleteServerAsync(Guid id);
}