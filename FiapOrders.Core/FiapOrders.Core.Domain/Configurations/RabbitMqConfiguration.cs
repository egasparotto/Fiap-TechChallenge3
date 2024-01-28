namespace FiapOrders.Core.Domain.Configurations
{
    public static class RabbitMqConfiguration
    {
        public static string HostName => Environment.GetEnvironmentVariable("RabbitMq.HostName");
        public static string Username => Environment.GetEnvironmentVariable("RabbitMq.Username");
        public static string Password => Environment.GetEnvironmentVariable("RabbitMq.Password");
    }
}
