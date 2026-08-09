using Microsoft.EntityFrameworkCore;
using MonitorPanel.Core.Abstractions;
using MonitorPanel.Core.Models;
using MonitorPanel.DataAccess.Entities;
namespace MonitorPanel.DataAccess.Repositories;

public class ServersRepository(MonitorPanelDbContext db) : IServersRepository
{
    public async Task<Guid> AddServerAsync(Server server, CancellationToken cancellationToken = default)
    {
        var entity = new ServerEntity
        {
            Id = server.Id,
            Name = server.Name,
            IsHttps = server.IsHttps,
            Address = server.Address,
            Path = server.Path,
            Port = server.Port
        };
        
        await db.Servers.AddAsync(entity, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public async Task<Guid> DeleteServerAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await db.Servers.Where(s => s.Id == id).ExecuteDeleteAsync(cancellationToken);
        return id;
    }

    public async Task<IEnumerable<Server>> GetAllServersAsync(CancellationToken cancellationToken = default)
    {
        return await db.Servers.AsNoTracking()
            .Select(s => new Server(s.Id, s.Name, s.Address, s.Path, s.IsHttps, s.Port))
            .ToListAsync(cancellationToken);
    }

    public async Task<Server?> GetServerByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await db.Servers.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        return entity == null ? null : new Server(entity.Id, entity.Name, entity.Address, entity.Path, entity.IsHttps, entity.Port);
    }

    public async Task<Guid> UpdateServerAsync(Guid id, string name, bool isHttps, string address, string? path, int port, CancellationToken cancellationToken = default)
    {
        var entity = await db.Servers.FirstOrDefaultAsync(s => s.Id == id, cancellationToken)
            ?? throw new InvalidOperationException("Server not found");
        
        entity.Name = name;
        entity.IsHttps = isHttps;
        entity.Address = address;
        entity.Path = path;
        entity.Port = port;

        await db.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}