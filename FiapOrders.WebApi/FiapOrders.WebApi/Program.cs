using FiapOrders.Core.Domain.Configurations;
using FiapOrders.WebApi.Configuration;
using MassTransit;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.AddLogSettings();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
