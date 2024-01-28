using FiapOrders.Core.Domain.Entities.Orders;
using FiapOrders.Data.Domain.Interfaces.Services.Orders;

using MassTransit;
using MassTransit.Transports;

namespace FiapOrders.Data.Events
{
    public class NewOrderEvent : IConsumer<Order>
    {
        private readonly IOrderService _orderService;

        public NewOrderEvent(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Consume(ConsumeContext<Order> context)
        {
            await _orderService.NewOrder(context.Message);
        }
    }
}
