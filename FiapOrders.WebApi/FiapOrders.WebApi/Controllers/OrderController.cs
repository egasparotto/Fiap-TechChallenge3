using FiapOrders.Core.Domain.Entities.Orders;
using FiapOrders.WebApi.Domain.DTO.Orders;
using FiapOrders.WebApi.Domain.Interfaces.Services.Orders;

using Microsoft.AspNetCore.Mvc;

namespace FiapOrders.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Order), 200)]
        [ProducesResponseType(typeof(IEnumerable<string>), 400)]
        public async Task<IActionResult> NewOrder([FromBody] OrderDTO orderDTO)
        {
            var result = await _orderService.NewOrder(orderDTO);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result.Data);
        }


    }
}
