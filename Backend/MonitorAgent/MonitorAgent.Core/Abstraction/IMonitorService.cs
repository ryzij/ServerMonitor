using MonitorAgent.Core.Models;

namespace MonitorAgent.Core.Abstraction;

public interface IMonitorService
{
    public Task<decimal> GetUptimeAsync(CancellationToken cancellationToken = default);
    
    public Task<MemoryInfo> GetMemoryInfoAsync(CancellationToken cancellationToken = default);

    public Task<decimal[]> GetLoadAverageAsync(CancellationToken cancellationToken = default);
}