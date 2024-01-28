using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiapOrders.Data.Infra.Base
{
    public class MongoDbConnection
    {
        private readonly string _connectionString = Environment.GetEnvironmentVariable("MongoDb.ConnectionString");
        private readonly string _database = Environment.GetEnvironmentVariable("MongoDb.Database");

        protected IMongoDatabase GetDatabase()
        {
            var client = new MongoClient(_connectionString);
            return client.GetDatabase(_database);
        }
    }

}
