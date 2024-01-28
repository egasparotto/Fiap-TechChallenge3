namespace FiapOrders.Core.Domain.Entities.Orders
{
    public class Item
    {
        public required string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get => Quantity * Price; }
    }
}
