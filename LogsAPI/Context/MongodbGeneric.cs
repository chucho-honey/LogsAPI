using LogsAPI.Helpers;
using LogsAPI.Interfeces;
using MongoDB.Driver;
using System.Collections.Generic;

namespace LogsAPI.Context
{
    public class MongodbGeneric<T> where T : class
    {
        private readonly IMongoCollection<T> collection;

        public MongodbGeneric(IMongodbSettings settings, string collectionName)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            collection = database.GetCollection<T>(collectionName);
        }

        public T Create(T collect)
        {
            collection.InsertOne(collect);
            return collect;
        }

        public List<T> Get() => collection.Find(collect => true).ToList();
        public T GetById(string id) => collection.Find(MongodbGenericHelper<T>.Filter(id)).FirstOrDefault();
        public T GetByField(string columName, string id) => collection.Find(MongodbGenericHelper<T>.Filter(columName, id)).FirstOrDefault();
        public void Update(string id, T collect) => collection.ReplaceOne(MongodbGenericHelper<T>.Filter(id), collect);
        public void Remove(string id) => collection.DeleteOne(MongodbGenericHelper<T>.Filter(id));
    }
}
