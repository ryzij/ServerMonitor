using MonitorAgent.Core.Abstraction;
using MonitorAgent.Application.Services;
using MonitorAgent.Application.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<CpuMonitorSettings>(builder.Configuration.GetSection("CpuMonitorSettings"));

builder.Services.AddScoped<IMonitorService, MonitorService>();
builder.Services.AddSingleton<RawCpuMonitorService>();
builder.Services.AddSingleton<CpuMonitorBackgroundService>();
builder.Services.AddHostedService(provider => provider.GetRequiredService<CpuMonitorBackgroundService>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger().UseSwaggerUI();

app.Run();
