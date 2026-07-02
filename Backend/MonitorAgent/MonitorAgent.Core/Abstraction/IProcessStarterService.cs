namespace MonitorAgent.Core.Abstraction;

public interface IProcessStarterService
{
    Task<string> StartProcessAsync(string fileName, string arguments, CancellationToken cancellationToken);
}