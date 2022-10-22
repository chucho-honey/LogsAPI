using LogsAPI.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace LogsAPI.Entities
{
    public class Log : ConfigAuditFields
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfNull]
        public string Id { get; set; }
        [JsonIgnore]
        public string Service { get; set; }
        [JsonIgnore]
        public string Provider { get; set; }
        [JsonIgnore]
        public string Method { get; set; }
        [JsonIgnore]
        public string Url { get; set; }
        [JsonIgnore]
        public string Headers { get; set; }
        [JsonIgnore]
        public string Request { get; set; }
        [JsonIgnore]
        public string Response { get; set; }
    }
}