using Cart.DataModels.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Cart.DataModels.DwhEntities
{
    public class BaseDwhModel
    {
        [JsonConverter(typeof(ObjectIdConverter))]
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
