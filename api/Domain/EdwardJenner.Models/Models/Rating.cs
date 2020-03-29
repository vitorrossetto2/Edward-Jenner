using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace EdwardJenner.Models.Models
{
    public class Rating : ModelBase
    {
        [StringLength(36, ErrorMessage = "A identificação do usuário deve conter 36 caracteres.")]
        [Required(ErrorMessage = "O usuário é obrigatório.")]
        [JsonProperty("userId")]
        [BsonElement("userId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [JsonProperty("rate")]
        [BsonElement("rate")]
        public int Rate { get; set; }

        [JsonProperty("description")]
        [BsonElement("description")]
        public string Description { get; set; }
    }
}
