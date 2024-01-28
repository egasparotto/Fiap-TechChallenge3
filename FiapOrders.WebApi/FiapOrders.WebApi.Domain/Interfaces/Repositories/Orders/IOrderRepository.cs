using FiapOrders.Core.Domain.Entities.Orders;

namespace FiapOrders.WebApi.Domain.Interfaces.Repositories.Orders
{
    public interface IOrderRepository
    {
        Task NewOrder(Order order);
    }
}
