using RabbitMQ.Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
