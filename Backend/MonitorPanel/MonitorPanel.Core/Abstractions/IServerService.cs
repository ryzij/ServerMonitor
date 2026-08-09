using MonitorPanel.Core.Models;

namespace MonitorPanel.Core.Abstractions;

public interface IServerService
{
    Task<Guid> AddServerAsync(Server server, CancellationToken cancellationToken = default);
    Task<Guid> DeleteServerAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Server>> GetAllServersAsync(CancellationToken cancellationToken = default);
    Task<Server?> GetServerByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> UpdateServerAsync(Guid id, string name, bool isHttps, string address, string? path, int port, CancellationToken cancellationToken = default);
}