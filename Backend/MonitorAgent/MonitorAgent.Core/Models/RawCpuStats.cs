namespace MonitorAgent.Core.Models;

public struct RawCpuStats
{
    public long User { get; set; }
    public long Nice { get; set; }
    public long System { get; set; }
    public long Idle { get; set; }
    public long Iowait { get; set; }
    public long Irq { get; set; }
    public long Softirq { get; set; }
    public long Steal { get; set; }
    public long Guest { get; set; }
    public long GuestNice { get; set; }

    public readonly long Total => User + Nice + System + Idle + Irq + Softirq + Steal;
    public readonly long TotalIdle => Idle + Iowait;

    public static RawCpuStats Parse(string s)
    {
        var stats = s.Split();
        if (!stats[0].StartsWith("cpu"))
            throw new FormatException($"The input string '{s}' was not in a correct format.");

        var longStats = new List<long>();
        for (int i = 1; i < stats.Length; i++)
        {
            if (!string.IsNullOrEmpty(stats[i]))
                longStats.Add(long.Parse(stats[i]));
        }

        return new RawCpuStats
        {
            User      = longStats[0],
            Nice      = longStats[1],
            System    = longStats[2],
            Idle      = longStats[3],
            Iowait    = longStats[4],
            Irq       = longStats[5],
            Softirq   = longStats[6],
            Steal     = longStats[7],
            Guest     = longStats[8],
            GuestNice = longStats[9]
        };
    }
}