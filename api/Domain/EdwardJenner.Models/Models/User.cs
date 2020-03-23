using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using Newtonsoft.Json;

namespace EdwardJenner.Models.Models
{
    public class User : ModelBase
    {
        [MinLength(2, ErrorMessage = "O nome deve conter ao menos 2 letras.")]
        [MaxLength(250, ErrorMessage = "O nome deve conter no máximo 250 letras.")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [JsonProperty("name")]
        [BsonElement("name")]
        public string Name { get; set; }

        [MinLength(2, ErrorMessage = "O apelido deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "O apelido deve conter no máximo 50 letras.")]
        [Required(ErrorMessage = "O apelido é obrigatório.")]
        [JsonProperty("username")]
        [BsonElement("username")]
        public string Username { get; set; }

        [MinLength(2, ErrorMessage = "O e-mail deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "O e-mail deve conter no máximo 50 letras.")]
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [RegularExpression(".+\\@.+\\.com(\\.br)?$", ErrorMessage = "O seu e-mail não é valido.")]
        [JsonProperty("email")]
        [BsonElement("email")]
        public string Email { get; set; }

        [MinLength(2, ErrorMessage = "A senha deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "A senha deve conter no máximo 50 letras.")]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [JsonProperty("password")]
        [BsonElement("password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "A longitude é obrigatória.")]
        [JsonProperty("longitude")]
        [BsonIgnore]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "A latitude é obrigatória.")]
        [JsonProperty("latitude")]
        [BsonIgnore]
        public double Latitude { get; set; }

        [JsonIgnore]
        [BsonElement("location")]
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Location { get; set; }
    }
}
