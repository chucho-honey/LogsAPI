using LogsAPI.Entities;
using System.Collections.Generic;

namespace LogsAPI.Interfeces
{
    public interface ILogService
    {
        Log Create(Log log);
        void Update(string id, Log logIn);
        List<Log> Get();
        Log GetById(string id);
        void Remove(string id);
    }
}
