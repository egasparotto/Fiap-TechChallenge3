using FiapOrders.Core.Domain.Entities.Orders;
using FiapOrders.WebApi.Domain.DTO.Orders;
using FiapOrders.WebApi.Domain.Entities.Base;

namespace FiapOrders.WebApi.Domain.Interfaces.Services.Orders
{
    public interface IOrderService
    {
        Task<Result<Order>> NewOrder(OrderDTO orderDTO);
    }
}
