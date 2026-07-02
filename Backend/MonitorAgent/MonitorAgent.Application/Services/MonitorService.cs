using MonitorAgent.Core.Abstraction;
using MonitorAgent.Core.Models;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
namespace MonitorAgent.Application.Services;

public class MonitorService : IMonitorService
{
    // private static async Task<string> StartProcessAsync(
    //     string fileName, string arguments, CancellationToken cancellationToken = default)
    // {
    //     using var process = new Process
    //     {
    //         StartInfo = new ProcessStartInfo
    //         {
    //             FileName = fileName,
    //             Arguments = arguments,
    //             UseShellExecute = false,
    //             RedirectStandardOutput = true,
    //             RedirectStandardError = true
    //         }
    //     };

    //     process.Start();
        
    //     return await process.StandardOutput.ReadToEndAsync(cancellationToken);
    // }

    public async Task<decimal> GetUptimeAsync(CancellationToken cancellationToken = default)
    {
        var uptime = await File.ReadAllTextAsync("/proc/uptime", cancellationToken);
        return decimal.Parse(uptime.Split()[0], CultureInfo.InvariantCulture);
    }

    public async Task<MemoryInfo> GetMemoryInfoAsync(CancellationToken cancellationToken = default)
    {
        var memInfo = new MemoryInfo();

        var raw = (await File.ReadAllTextAsync("/proc/meminfo", cancellationToken)).Split(':', '\n');
        for (int i = 0; i < raw.Length - 1; i++)
        {
            switch (raw[i].ToLower())
            {
                case "memtotal":
                    memInfo.MemTotal = ParseInt(raw[i + 1]);
                    break;
                case "memfree":
                    memInfo.MemFree = ParseInt(raw[i + 1]);
                    break;
                case "memavailable":
                    memInfo.MemAvailable = ParseInt(raw[i + 1]);
                    break;
                case "swaptotal":
                    memInfo.SwapTotal = ParseInt(raw[i + 1]);
                    break;
                case "swapfree":
                    memInfo.SwapFree = ParseInt(raw[i + 1]);
                    break;
            }
        }

        return memInfo;
    }

    public async Task<decimal[]> GetLoadAverageAsync(CancellationToken cancellationToken = default)
    {
        var raw = (await File.ReadAllTextAsync("/proc/loadavg", cancellationToken)).Split();
        var loadavg = new decimal[3];

        for (int i = 0; i < loadavg.Length; i++)
            loadavg[i] = decimal.Parse(raw[i], CultureInfo.InvariantCulture);

        return loadavg;
    }

    // TODO: проверить на других системах
    public async Task<ConnectionsCount> GetConnectionsCountAsync(CancellationToken cancellationToken = default)
    {
        var sockstat = await File.ReadAllLinesAsync("/proc/net/sockstat", cancellationToken);
        
        return new ConnectionsCount(
            int.Parse(sockstat[0].Split()[2]),
            int.Parse(sockstat[1].Split()[2])
        );
    }
    
    public static int ParseInt(string str) => int.Parse(Regex.Match(str, @"\d+").Value);
}