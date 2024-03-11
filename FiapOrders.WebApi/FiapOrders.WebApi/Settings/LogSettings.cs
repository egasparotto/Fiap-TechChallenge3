using System.Reflection;
using Serilog;

public static class LogSettings
{
    public static void AddLogSettings(this WebApplicationBuilder builder)
    {
        var sqlUrl = Environment.GetEnvironmentVariable("DatalustSeq.Url");

        builder.Logging.ClearProviders();
        var logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.WithProperty("Version", Assembly.GetEntryAssembly()!.GetName().Version)
            .Enrich.WithEnvironmentName()
            .Enrich.WithMachineName()
            .Enrich.WithProcessId()
            .Enrich.WithThreadId()
            .Enrich.WithMemoryUsage()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.Seq(sqlUrl)
            .CreateLogger();
        builder.Logging.AddSerilog(logger);
    }
}