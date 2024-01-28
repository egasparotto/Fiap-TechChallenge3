namespace FiapOrders.Core.Domain.Entities.Orders
{
    public class Order
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public decimal Total { get => (Items?.Sum(x => x.Total)).GetValueOrDefault(0); }
        public required IEnumerable<Item> Items { get; set; }
    }
}
