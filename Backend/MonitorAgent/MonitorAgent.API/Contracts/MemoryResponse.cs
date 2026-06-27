namespace MonitorAgent.API.Contracts;

public record class MemoryResponse
(
    int MemTotal,
    int MemFree,
    int MemAvailable,
    int SwapTotal,
    int SwapFree
);