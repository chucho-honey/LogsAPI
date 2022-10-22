using LogsAPI.Interfeces;

namespace LogsAPI.Models
{
    public class MongodbSettings : IMongodbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
