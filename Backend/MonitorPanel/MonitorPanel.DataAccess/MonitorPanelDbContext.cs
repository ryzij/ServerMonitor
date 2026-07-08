using Microsoft.EntityFrameworkCore;
using MonitorPanel.DataAccess.Entities;
namespace MonitorPanel.DataAccess;

public class MonitorPanelDbContext(DbContextOptions<MonitorPanelDbContext> options) : DbContext(options)
{
    public DbSet<ServerEntity> Servers => Set<ServerEntity>();
}
