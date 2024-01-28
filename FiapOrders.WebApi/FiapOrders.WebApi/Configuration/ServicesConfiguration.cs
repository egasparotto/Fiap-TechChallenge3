using FiapOrders.WebApi.Domain.Interfaces.Services.Orders;
using FiapOrders.WebApi.Services.Orders;

namespace FiapOrders.WebApi.Configuration
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
