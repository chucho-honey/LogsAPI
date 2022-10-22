using MongoDB.Bson;
using MongoDB.Driver;

namespace LogsAPI.Helpers
{
    public static class MongodbGenericHelper<T>
    {
        public static FilterDefinition<T> Filter(string id) => Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
        public static FilterDefinition<T> Filter(string columName, string value) => Builders<T>.Filter.Eq(columName, value);
    }
}
