using MonitorAgent.Core.Abstraction;
using MonitorAgent.Core.Models;

namespace MonitorAgent.Application.Services;

public class RawCpuMonitorService : ICpuMonitorService
{
    public async Task<RawCpuStatsCollection> ParseRawCpuStatsAsync(CancellationToken cancellationToken = default)
    {
        var raw = await File.ReadAllLinesAsync("/proc/stat", cancellationToken);
        
        var total = RawCpuStats.Parse(raw[0]);
        var cores = new List<RawCpuStats>();
        for (int i = 1; i < raw.Length && raw[i].StartsWith("cpu"); i++)
            cores.Add(RawCpuStats.Parse(raw[i]));

        return new RawCpuStatsCollection(total, cores);
    }
}