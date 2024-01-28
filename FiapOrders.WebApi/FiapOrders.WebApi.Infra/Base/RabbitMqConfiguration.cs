using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiapOrders.WebApi.Infra.Base
{
    public static class RabbitMqConfiguration
    {
        public static string HostName => Environment.GetEnvironmentVariable("RabbitMq.HostName");
        public static string Username => Environment.GetEnvironmentVariable("RabbitMq.Username");
        public static string Password => Environment.GetEnvironmentVariable("RabbitMq.Password");
    }
}
