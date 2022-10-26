using LogsAPI.Entities;
using LogsAPI.Helpers.Enums;
using LogsAPI.Interfeces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace LogsAPI.Services
{
    public class LogService : ILogService
    {
        private readonly IMongoCollection<Log> collection;

        public LogService(IMongodbGeneric<Log> log)
        {
            collection = log.GetCollection(nameof(CollectionName.ProviderLog));
        }

        public Log Create(Log log)
        {
            DateTime date = DateTime.Now;
            string user = "LogService";

            log.CreationDate = date;
            log.UserCreationId = user;
            log.DateLastModificationId = date;
            log.UserLastModifiedId = user;
            log.IsActive = 1;

            collection.InsertOne(log);
            return log;
        }

        public void Update(string id, Log logIn)
        {
            DateTime date = DateTime.Now;
            logIn.DateLastModificationId = date;

            collection.ReplaceOne(log => log.Id == id, logIn);
        } 

        public List<Log> Get() => collection.Find(collect => true).ToList();
        public Log GetById(string id) => collection.Find(log => log.Id == id).FirstOrDefault();
        public void Remove(string id) => collection.DeleteOne(log => log.Id == id);
        public Log GetByServiceAndProvider(string service, string provider) => collection.Find(c => c.Service == service && c.Provider == provider).FirstOrDefault();
    }
}
