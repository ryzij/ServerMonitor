using System.Collections;
using System.Collections.ObjectModel;

namespace MonitorAgent.Core.Models;

public class RawCpuStatsCollection(RawCpuStats total, IEnumerable<RawCpuStats> cores)
{
    public readonly RawCpuStats Total = total;
    public readonly ReadOnlyCollection<RawCpuStats> Cores = new([.. cores]);
}