using ChatApp.DAL.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace ChatApp.DAL.Context
{
    public class MongoDbService
    {
        private readonly IMongoDatabase? _database;

        public MongoDbService()
        {
            var mongoDbServer = Environment.GetEnvironmentVariable("MONGO_DB_SERVER") ?? "mongo";
            var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "ChatAppDb";

            var connectionString = $"mongodb://{mongoDbServer}:27017/{dbName}";
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);

            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        public IMongoDatabase? Database => _database;

        public IMongoCollection<Image> Images => _database?.GetCollection<Image>("Images");
    }
}
