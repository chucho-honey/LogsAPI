using LogsAPI.Interfeces;
using MongoDB.Driver;

namespace LogsAPI.Context
{
    public class MongodbGeneric<T> : IMongodbGeneric<T> where T : class
    {
        private readonly IMongoDatabase database;
        private readonly MongoClient client;

        public MongodbGeneric(IMongodbSettings settings)
        {
            client = new MongoClient(settings.ConnectionString);
            database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<T> GetCollection(string collectionName) => database.GetCollection<T>(collectionName);
    }
}
