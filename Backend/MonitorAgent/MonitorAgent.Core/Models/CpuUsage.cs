using System.Collections.ObjectModel;

namespace MonitorAgent.Core.Models;

public class CpuUsage(decimal totalUsagePercent, IEnumerable<decimal> coresUsagePercent)
{
    public readonly decimal TotalUsagePercent = totalUsagePercent;
    public readonly ReadOnlyCollection<decimal> CoresUsagePercent = new([.. coresUsagePercent]);
}