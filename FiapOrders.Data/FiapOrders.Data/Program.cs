using FiapOrders.Data.Workers;
using FiapOrders.Data.Configuration;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<NewOrderWorker>();
builder.Services.AddRepositories();
builder.Services.AddServices();

var host = builder.Build();
host.Run();
