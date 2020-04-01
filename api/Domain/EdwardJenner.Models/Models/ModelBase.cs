using System;
using EdwardJenner.Models.Interfaces.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace EdwardJenner.Models.Models
{
    public abstract class ModelBase : IModelBase
    {
        [JsonProperty("id")]
        [BsonElement("id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [JsonProperty("updatedIn")]
        [BsonElement("updatedIn")]
        public DateTime UpdatedIn { get; set; }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}
