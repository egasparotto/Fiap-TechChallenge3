using FiapOrders.Core.Domain.Entities.Orders;
using FiapOrders.WebApi.Domain.Interfaces.Repositories.Orders;
using FiapOrders.WebApi.Infra.Base;

using System.Text;
using System.Text.Json;

namespace FiapOrders.WebApi.Infra.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RabbitMqService _rabbitMqService;

        public OrderRepository(RabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        public Task NewOrder(Order order)
        {
            using var connection = _rabbitMqService.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "Order.New",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var message = JsonSerializer.Serialize(order);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                exchange: "",
                routingKey: "Order.New",
                basicProperties: null,
                mandatory: false,
                body: body);

            return Task.CompletedTask;
        }
    }
}
