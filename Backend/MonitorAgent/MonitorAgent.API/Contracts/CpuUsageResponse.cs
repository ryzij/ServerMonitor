namespace MonitorAgent.API.Contracts;

public class CpuUsageResponse(decimal total, IEnumerable<decimal> cores)
{
    public decimal Total { get; set; } = total;
    public List<decimal> Cores { get; set; } = new([.. cores]);
}