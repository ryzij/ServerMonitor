using MonitorPanel.Core.Abstractions;
using MonitorPanel.Core.Models;
namespace MonitorPanel.DataAccess.Repositories;

public class ServersRepository : IServersRepository
{
    public Task AddServerAsync(Server server)
    {
        throw new NotImplementedException();
    }

    public Task DeleteServerAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Server>> GetAllServersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Server?> GetServerByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateServerAsync(Guid id, Server server)
    {
        throw new NotImplementedException();
    }
}