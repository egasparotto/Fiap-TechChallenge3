using FiapOrders.Core.Domain.Entities.Orders;
using FiapOrders.Data.Domain.Interfaces.Repositories.Orders;
using FiapOrders.Data.Domain.Interfaces.Services.Orders;

namespace FiapOrders.Data.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task NewOrder(Order order)
        {
            await _orderRepository.NewOrder(order);
        }
    }
}
