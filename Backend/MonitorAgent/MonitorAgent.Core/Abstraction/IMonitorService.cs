using MonitorAgent.Core.Models;

namespace MonitorAgent.Core.Abstraction;

public interface IMonitorService
{
    public Task<decimal> GetUptimeAsync(CancellationToken cancellationToken);
    
    public Task<MemoryInfo> GetMemoryInfoAsync(CancellationToken cancellationToken);

    public Task<decimal[]> GetLoadAverageAsync(CancellationToken cancellationToken);

    public Task<ConnectionsCount> GetConnectionsCountAsync(CancellationToken cancellationToken);
}