using Newtonsoft.Json;
using System;

namespace LogsAPI.Models
{
    public class ConfigAuditFields
    {
        [JsonIgnore]
        public string UserCreationId { get; set; }
        [JsonIgnore]
        public DateTime CreationDate { get; set; }
        [JsonIgnore]
        public string UserLastModifiedId { get; set; }
        [JsonIgnore]
        public DateTime DateLastModificationId { get; set; }
        [JsonIgnore]
        public int IsActive { get; set; }

        public ConfigAuditFields() { }

        public ConfigAuditFields(string user, DateTime date)
        {
            UserCreationId = user;
            CreationDate = date;
            UserLastModifiedId = user;
            DateLastModificationId = date;
            IsActive = 1;
        }

        public ConfigAuditFields(string userLastModifiedId, DateTime dateLastModificationId, int isActive = 1)
        {
            UserLastModifiedId = userLastModifiedId;
            DateLastModificationId = dateLastModificationId;
            IsActive = isActive;
        }
    }
}
