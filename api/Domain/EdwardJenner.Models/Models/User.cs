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
        [BsonIgnore]
        public string Password { get; set; }

        [Required(ErrorMessage = "O cpf é obrigatório.")]
        [RegularExpression("^\\d{11}$", ErrorMessage = "O cpf não é valido.")]
        [JsonProperty("cpf")]
        [BsonElement("cpf")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [JsonProperty("homeAddress")]
        [BsonElement("homeAddress")]
        public Address HomeAddress { get; set; }

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

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [JsonProperty("mobilePhone")]
        [BsonElement("mobilePhone")]
        public Phone MobilePhone { get; set; }

        [JsonProperty("applicationUserId")]
        [BsonElement("applicationUserId")]
        public string ApplicationUserId { get; set; }
    }

    public class Address
    {
        [Required(ErrorMessage = "O país é obrigatório.")]
        [JsonProperty("country")]
        [BsonElement("country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [JsonProperty("state")]
        [BsonElement("state")]
        public string State { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [JsonProperty("city")]
        [BsonElement("city")]
        public string City { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        [JsonProperty("neighborhood")]
        [BsonElement("neighborhood")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "A rua é obrigatória.")]
        [JsonProperty("street")]
        [BsonElement("street")]
        public string Street { get; set; }

        [JsonProperty("complement")]
        [BsonElement("complement")]
        public string Complement { get; set; }

        [JsonProperty("number")]
        [BsonElement("number")]
        public string Number { get; set; }

        [JsonIgnore]
        [BsonElement("location")]
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Location { get; set; }
    }

    public class Phone
    {
        [Required(ErrorMessage = "O DDD é obrigatório.")]
        [JsonProperty("ddd")]
        [BsonElement("ddd")]
        public string Ddd { get; set; }

        [Required(ErrorMessage = "O número é obrigatório.")]
        [JsonProperty("number")]
        [BsonElement("number")]
        public string Number { get; set; }
    }
}
