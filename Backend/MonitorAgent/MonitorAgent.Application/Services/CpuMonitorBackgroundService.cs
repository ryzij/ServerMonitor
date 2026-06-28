using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MonitorAgent.Application.Settings;
using MonitorAgent.Core.Models;

namespace MonitorAgent.Application.Services;

public class CpuMonitorBackgroundService(
    RawCpuMonitorService cpuMonitorService,
    IOptions<CpuMonitorSettings> options,
    ILogger<CpuMonitorBackgroundService> logger) : BackgroundService
{
    private RawCpuStatsCollection? _prevStats;
    private RawCpuStatsCollection? _nextStats;

    public async Task<CpuUsage> GetCpuUsageAsync(CancellationToken cancellationToken = default)
    {
        RawCpuStatsCollection prev, next;
        if (_prevStats != null)
            prev = _prevStats;
        else
            prev = await cpuMonitorService.ParseRawCpuStatsAsync(cancellationToken);
        if (_nextStats != null)
            next = _nextStats;
        else
            next = await cpuMonitorService.ParseRawCpuStatsAsync(cancellationToken);

        var total = CalcUsage(prev.Total, next.Total);
        var cores = new List<decimal>(prev.Cores.Count);
        for (int i = 0; i < prev.Cores.Count; i++)
            cores.Add(CalcUsage(prev.Cores[i], next.Cores[i]));

        return new CpuUsage(total, cores);
    }
    
    private decimal CalcUsage(RawCpuStats prev, RawCpuStats next)
    {
        decimal deltaTotal = next.Total - prev.Total;
        decimal deltaIdle = next.Idle - prev.Idle;

        return (1 - deltaIdle / deltaTotal) * 100;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _prevStats = _nextStats;
                _nextStats = await cpuMonitorService.ParseRawCpuStatsAsync(stoppingToken);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
            finally
            {
                await Task.Delay(options.Value.DelayTime, stoppingToken);
            }
        }
    }
}