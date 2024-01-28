using FiapOrders.Core.Domain.Entities.Orders;

namespace FiapOrders.Data.Domain.Interfaces.Services.Orders
{
    public interface IOrderService
    {
        Task NewOrder(Order order);
    }
}
