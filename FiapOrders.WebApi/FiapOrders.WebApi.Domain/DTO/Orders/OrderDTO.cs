namespace FiapOrders.WebApi.Domain.DTO.Orders
{
    public class OrderDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<ItemDTO> Items { get; set; }
    }
}
