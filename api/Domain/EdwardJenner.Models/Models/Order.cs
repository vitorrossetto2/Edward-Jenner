using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Driver.GeoJsonObjectModel;
using Newtonsoft.Json;

namespace EdwardJenner.Models.Models
{
    public class Order : ModelBase
    {
        [StringLength(36, ErrorMessage = "A identificação do usuário deve conter 36 caracteres.")]
        [Required(ErrorMessage = "O usuário é obrigatório.")]
        [JsonProperty("userId")]
        [BsonElement("userId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [JsonProperty("orderType")]
        [BsonElement("orderType")]
        public OrderType Type { get; set; }

        [JsonProperty("items")]
        [BsonIgnore]
        public IList<Item> Items { get; set; }

        [JsonProperty("status")]
        [BsonElement("status")]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public IDictionary<DateTime, OrderStatus> Status { get; set; }

        [JsonProperty("lastStatus")]
        [BsonElement("lastStatus")]
        public OrderStatus LastStatus { get; set; }

        [JsonProperty("longitude")]
        [BsonIgnore]
        public double Longitude { get; set; }

        [JsonProperty("latitude")]
        [BsonIgnore]
        public double Latitude { get; set; }

        [JsonIgnore]
        [BsonElement("location")]
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Location { get; set; }
    }

    public enum OrderType
    {
        [Description("Mercado")]
        [JsonProperty("market")]
        Market = 0,

        [Description("Farmácia")]
        [JsonProperty("drugstore")]
        Drugstore = 1,

        [Description("Padaria")]
        [JsonProperty("bakery")]
        Bakery = 2,

        [Description("Outro")]
        [JsonProperty("other")]
        Other = 99
    }

    public enum OrderStatus
    {
        [Description("Novo")]
        [JsonProperty("new")]
        New = 0,

        [Description("Confirmado")]
        [JsonProperty("confirmed")]
        Confirmed = 1,

        [Description("Em Andamento")]
        [JsonProperty("inProgress")]
        InProgress = 2,

        [Description("Finalizado")]
        [JsonProperty("finished")]
        Finished = 3,

        [Description("Cancelado")]
        [JsonProperty("canceled")]
        Canceled = 99
    }
}
