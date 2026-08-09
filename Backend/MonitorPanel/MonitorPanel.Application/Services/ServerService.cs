using MonitorPanel.Core.Abstractions;
using MonitorPanel.Core.Models;

namespace MonitorPanel.Application.Services;

public class ServerService(IServersRepository serversRepository) : IServerService
{
    public Task<Guid> AddServerAsync(Server server, CancellationToken cancellationToken = default)
    {
        return serversRepository.AddServerAsync(server, cancellationToken);
    }

    public Task<Guid> DeleteServerAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return serversRepository.DeleteServerAsync(id, cancellationToken);
    }

    public Task<IEnumerable<Server>> GetAllServersAsync(CancellationToken cancellationToken = default)
    {
        return serversRepository.GetAllServersAsync(cancellationToken);
    }

    public Task<Server?> GetServerByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return serversRepository.GetServerByIdAsync(id, cancellationToken);
    }

    public Task<Guid> UpdateServerAsync(Guid id, string name, bool isHttps, string address, string? path, int port, CancellationToken cancellationToken = default)
    {
        return serversRepository.UpdateServerAsync(id, name, isHttps, address, path, port, cancellationToken);
    }
}