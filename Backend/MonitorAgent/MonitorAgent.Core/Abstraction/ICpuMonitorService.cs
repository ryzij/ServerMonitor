using MonitorAgent.Core.Models;

namespace MonitorAgent.Core.Abstraction;

public interface ICpuMonitorService
{
    public Task<RawCpuStatsCollection> ParseRawCpuStatsAsync(CancellationToken cancellationToken = default);
}
