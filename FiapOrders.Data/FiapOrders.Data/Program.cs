using FiapOrders.Core.Domain.Configurations;
using FiapOrders.Data.Configuration;
using FiapOrders.Data.Events;
using MassTransit;

var builder = Host.CreateApplicationBuilder(args);
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
