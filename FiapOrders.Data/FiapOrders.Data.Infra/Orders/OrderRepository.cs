using FiapOrders.Core.Domain.Entities.Orders;
using FiapOrders.Data.Domain.Interfaces.Repositories.Orders;
using FiapOrders.Data.Infra.Base;

namespace FiapOrders.Data.Infra.Orders
{
    public class OrderRepository : MongoDbConnection, IOrderRepository
    {
        private readonly string _collectionName = "Orders";

        public async Task NewOrder(Order order)
        {
            var database = GetDatabase();
            var collection = database.GetCollection<Order>(_collectionName);
            await collection.InsertOneAsync(order);
        }
    }
}
