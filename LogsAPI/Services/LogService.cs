using LogsAPI.Context;
using LogsAPI.Entities;
using LogsAPI.Helpers.Enums;
using LogsAPI.Interfeces;
using System;
using System.Collections.Generic;

namespace LogsAPI.Services
{
    public class LogService : ILogService
    {
        private readonly MongodbGeneric<Log> log;

        public LogService(IMongodbSettings settings)
        {
            log = new MongodbGeneric<Log>(settings, nameof(CollectionName.ProviderLog));
        }

        public Log Create(Log logReq)
        {
            DateTime date = DateTime.Now;
            string user = "LogService";

            logReq.CreationDate = date;
            logReq.UserCreationId = user;
            logReq.DateLastModificationId = date;
            logReq.UserLastModifiedId = user;
            logReq.IsActive = 1;

            return log.Create(logReq);
        }

        public void Update(string id, Log logIn)
        {
            DateTime date = DateTime.Now;

            logIn.DateLastModificationId = date;
            log.Update(id, logIn);
        } 

        public List<Log> Get() => log.Get();
        public Log GetById(string id) => log.GetById(id);
        public void Remove(string id) => log.Remove(id);
    }
}
