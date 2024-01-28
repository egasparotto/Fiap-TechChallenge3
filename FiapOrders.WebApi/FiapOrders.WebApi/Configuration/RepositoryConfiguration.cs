using FiapOrders.WebApi.Domain.Interfaces.Repositories.Orders;
using FiapOrders.WebApi.Infra.Orders;

namespace FiapOrders.WebApi.Configuration
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
