using FiapOrders.Data.Domain.Interfaces.Repositories.Orders;
using FiapOrders.Data.Infra.Orders;

namespace FiapOrders.Data.Configuration
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
