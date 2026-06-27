namespace MonitorAgent.Core.Models;

public class MemoryInfo
{
    public int MemTotal { get; set; }
    public int MemFree { get; set; }
    public int MemAvailable { get; set; }
    public int SwapTotal { get; set; }
    public int SwapFree { get; set; }
}
