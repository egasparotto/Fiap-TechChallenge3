using FiapOrders.Core.Domain.Entities.Orders;
using FiapOrders.WebApi.Domain.DTO.Orders;
using FiapOrders.WebApi.Domain.Entities.Base;
using FiapOrders.WebApi.Domain.Interfaces.Repositories.Orders;
using FiapOrders.WebApi.Domain.Interfaces.Services.Orders;

namespace FiapOrders.WebApi.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<Order>> NewOrder(OrderDTO orderDTO)
        {
            var erros = Validate(orderDTO);
            if (erros.Any())
            {
                return new Result<Order>(erros);
            }

            var itens = orderDTO?.Items.Select(x => new Item()
            {
                Description = x.Description,
                Price = x.Price,
                Quantity = x.Quantity
            });

            var order = new Order()
            {
                Name = orderDTO?.Name,
                Email = orderDTO?.Email,
                Items = itens
            };

            await _orderRepository.NewOrder(order);

            return new Result<Order>(order);
        }

        private static IEnumerable<string> Validate(OrderDTO orderDTO)
        {
            var result = new List<string>();
            if (string.IsNullOrEmpty(orderDTO?.Name))
            {
                result.Add("O Nome deve ser informado.");
            }

            if (string.IsNullOrEmpty(orderDTO?.Email))
            {
                result.Add("O E-Mail deve ser informado.");
            }

            if (orderDTO.Items == null || !orderDTO.Items.Any())
            {
                result.Add("Deve ser informado ao menos um item");
            }
            else
            {

                foreach (var item in orderDTO.Items)
                {
                    var pos = orderDTO.Items.IndexOf(item) + 1;

                    if (string.IsNullOrEmpty(item.Description))
                    {
                        result.Add($"Deve ser informada a descri��o do item na posi��o {pos}");
                    }

                    if (item.Quantity <= 0)
                    {
                        result.Add($"A quantidade do item {pos} - {item.Description} deve ser maior que 0");
                    }

                    if (item.Price <= 0)
                    {
                        result.Add($"O valor do item {pos} - {item.Description} deve ser maior que 0");
                    }
                }
            }

            return result;

        }
    }
}
