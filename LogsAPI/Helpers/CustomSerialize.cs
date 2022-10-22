using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json;

namespace LogsAPI.Helpers
{
    public class CustomSerialize : SerializerBase<object>
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            var json = JsonConvert.SerializeObject(value);
            context.Writer.WriteString(json);
        }

        public override object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var json = context.Reader.ReadString();
            return JsonConvert.DeserializeObject<object>(json);
        }
    }
}
