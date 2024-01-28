using System.Text.Json;
using System.Text;
using RabbitMQ.Client;
using FiapOrders.Core.Domain.Configurations;
using RabbitMQ.Client.Events;
using FiapOrders.Core.Domain.Entities.Orders;
using FiapOrders.Data.Domain.Interfaces.Services.Orders;

namespace FiapOrders.Data.Workers
{
    public class NewOrderWorker : BackgroundService
    {
        private readonly IOrderService _orderService;

        public NewOrderWorker(IOrderService orderService)
        {
            _orderService = orderService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                ConnectionFactory factory = new ConnectionFactory()
                {
                    UserName = RabbitMqConfiguration.Username,
                    Password = RabbitMqConfiguration.Password,
                    HostName = RabbitMqConfiguration.HostName
                };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(
                    queue: "Order.New",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (sender, args) =>
                {
                    var body = args.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var order = JsonSerializer.Deserialize<Order>(message);

                    _orderService.NewOrder(order);
                };

                channel.BasicConsume(
                    queue: "Order.New",
                    autoAck: true,
                    consumer: consumer);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
