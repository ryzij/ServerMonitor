using MonitorAgent.Core.Abstraction;
using System.Diagnostics;

namespace MonitorAgent.Application.Services;

public class ProcessStarterService : IProcessStarterService
{
    public async Task<string> StartProcessAsync(
        string fileName, string arguments, CancellationToken cancellationToken = default)
    {
        using var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            }
        };

        process.Start();
        
        return await process.StandardOutput.ReadToEndAsync(cancellationToken);
    }
}