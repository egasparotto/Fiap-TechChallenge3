using FiapOrders.Data.Domain.Interfaces.Services.Orders;
using FiapOrders.Data.Services.Orders;

namespace FiapOrders.Data.Configuration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IOrderService, OrderService>();
            return services;
        }
    }
}
