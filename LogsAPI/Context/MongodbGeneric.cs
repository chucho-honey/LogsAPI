using LogsAPI.Helpers;
using LogsAPI.Interfeces;
using MongoDB.Driver;
using System.Collections.Generic;

namespace LogsAPI.Context
{
    public class MongodbGeneric<T> where T : class
    {
        private readonly IMongoCollection<T> generic;

        public MongodbGeneric(IMongoDBSettings settings, string collectionName)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            generic = database.GetCollection<T>(collectionName);
        }

        public T Create(T gen)
        {
            generic.InsertOne(gen);
            return gen;
        }

        public List<T> Get() => generic.Find(gen => true).ToList();
        public T GetById(string id) => generic.Find(MongodbGenericHelper<T>.Filter(id)).FirstOrDefault();
        public T GetByField(string columName, string id) => generic.Find(MongodbGenericHelper<T>.Filter(columName, id)).FirstOrDefault();
        public void Update(string id, T genIn) => generic.ReplaceOne(MongodbGenericHelper<T>.Filter(id), genIn);
        public void Remove(string id) => generic.DeleteOne(MongodbGenericHelper<T>.Filter(id));
    }
}
