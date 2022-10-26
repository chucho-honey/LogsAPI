using MongoDB.Driver;
using System;

namespace LogsAPI.Interfeces
{
    public interface IMongodbGeneric<T>
    {
        IMongoCollection<T> GetCollection(string collectionName);
    }
}
