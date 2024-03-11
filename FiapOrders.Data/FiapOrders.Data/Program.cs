using FiapOrders.Core.Domain.Configurations;
using FiapOrders.Data.Configuration;
using FiapOrders.Data.Events;
using MassTransit;
using Serilog;
using System.Reflection;

var builder = Host.CreateApplicationBuilder(args);

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


builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(RabbitMqConfiguration.HostName, "/", h =>
        {
            h.Username(RabbitMqConfiguration.Username);
            h.Password(RabbitMqConfiguration.Password);
        });

        cfg.ReceiveEndpoint("Order.New", e =>
        {
            e.ConfigureConsumer<NewOrderEvent>(context);
        });

        cfg.ConfigureEndpoints(context);
    });

    x.AddConsumer<NewOrderEvent>();
});

var host = builder.Build();
host.Run();
