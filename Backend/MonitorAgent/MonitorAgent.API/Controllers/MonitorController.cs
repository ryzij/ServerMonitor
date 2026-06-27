using Microsoft.AspNetCore.Mvc;
using MonitorAgent.API.Contracts;
using MonitorAgent.Core.Abstraction;
namespace MonitorAgent.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MonitorController(IMonitorService monitorService) : ControllerBase
{
    [HttpGet("uptime")]
    public async Task<ActionResult<decimal>> GetUptimeAsync(CancellationToken cancellationToken = default)
    {
        var uptime = await monitorService.GetUptimeAsync(cancellationToken);
        return Ok(uptime);
    }

    [HttpGet("memory")]
    public async Task<ActionResult<MemoryResponse>> GetMemoryAsync(CancellationToken cancellationToken = default)
    {
        var memInfo = await monitorService.GetMemoryInfoAsync(cancellationToken);
        var response = new MemoryResponse(
            memInfo.MemTotal,
            memInfo.MemFree,
            memInfo.MemAvailable,
            memInfo.SwapTotal,
            memInfo.SwapFree
        );

        return Ok(response);
    }
    
    [HttpGet("loadavg")]
    public async Task<ActionResult<LoadAverageResponse>> GetActionResultAsync(CancellationToken cancellationToken = default)
    {
        var response = new LoadAverageResponse(await monitorService.GetLoadAverageAsync(cancellationToken));
        return Ok(response);
    }
}