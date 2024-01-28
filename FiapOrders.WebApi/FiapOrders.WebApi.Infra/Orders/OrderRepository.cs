using FiapOrders.Core.Domain.Entities.Orders;
using FiapOrders.WebApi.Domain.Interfaces.Repositories.Orders;

using MassTransit;

namespace FiapOrders.WebApi.Infra.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IBus _bus;

        public OrderRepository(IBus bus)
        {
            _bus = bus;
        }

        public async Task NewOrder(Order order)
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri("queue:Order.New"));
            await endpoint.Send(order);
        }
    }
}
