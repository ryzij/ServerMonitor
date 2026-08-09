using Microsoft.AspNetCore.Mvc;
using MonitorPanel.Core.Abstractions;
using MonitorPanel.Core.Models;
using MonitorPanel.API.Dto;

namespace MonitorPanel.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ServerController(IServerService serverService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ServerDto>>> GetAllServers(CancellationToken cancellationToken = default)
    {
        var servers = await serverService.GetAllServersAsync(cancellationToken);
        return Ok(servers.Select(s => new ServerDto
        {
            Id = s.Id,
            Name = s.Name,
            Address = s.Address,
            Path = s.Path,
            IsHttps = s.IsHttps,
            Port = s.Port
        }));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServerDto>> GetServerById(Guid id, CancellationToken cancellationToken = default)
    {
        var server = await serverService.GetServerByIdAsync(id, cancellationToken);
        if (server == null)
        {
            return NotFound();
        }
        return Ok(new ServerDto
        {
            Id = server.Id,
            Name = server.Name,
            Address = server.Address,
            Path = server.Path,
            IsHttps = server.IsHttps,
            Port = server.Port
        });
    }

    [HttpPost]
    public async Task<IActionResult> AddServer(ServerDto dto, CancellationToken cancellationToken = default)
    {
        var server = new Server(Guid.NewGuid(), dto.Name, dto.Address, dto.Path, dto.IsHttps, dto.Port);
        var id = await serverService.AddServerAsync(server, cancellationToken);
        return CreatedAtAction(nameof(GetServerById), new { id }, server);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateServer(Guid id, ServerDto dto, CancellationToken cancellationToken = default)
    {
        var updatedId = await serverService.UpdateServerAsync(id, dto.Name, dto.IsHttps, dto.Address, dto.Path, dto.Port, cancellationToken);
        return Ok(new { Id = updatedId });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteServer(Guid id)
    {
        var deletedId = await serverService.DeleteServerAsync(id);
        return Ok(new { Id = deletedId });
    }
}