using MonitorPanel.Core.Models;
namespace MonitorPanel.Core.Abstractions;

public interface IServersRepository
{
    Task<IEnumerable<Server>> GetAllServersAsync();
    Task<Server?> GetServerByIdAsync(Guid id);
    Task AddServerAsync(Server server);
    Task UpdateServerAsync(Guid id, Server server);
    Task DeleteServerAsync(Guid id);
}