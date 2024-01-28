using FiapOrders.Core.Domain.Configurations;

using RabbitMQ.Client;

namespace FiapOrders.WebApi.Infra.Base
{
    public class RabbitMqService
    {
        public IConnection CreateConnection()
        {
            ConnectionFactory connection = new ConnectionFactory()
            {
                UserName = RabbitMqConfiguration.Username,
                Password = RabbitMqConfiguration.Password,
                HostName = RabbitMqConfiguration.HostName
            };
            var channel = connection.CreateConnection();
            return channel;
        }
    }
}
