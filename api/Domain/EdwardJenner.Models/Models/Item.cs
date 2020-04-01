using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace EdwardJenner.Models.Models
{
    public class Item : ModelBase
    {
        [StringLength(36, ErrorMessage = "A identificação do pedido deve conter 36 caracteres.")]
        [Required(ErrorMessage = "O pedido é obrigatório.")]
        [JsonProperty("orderId")]
        [BsonElement("orderId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OrderId { get; set; }

        [MinLength(2, ErrorMessage = "O nome do item deve conter ao menos 2 letras.")]
        [MaxLength(250, ErrorMessage = "O nome do item deve conter no máximo 250 letras.")]
        [Required(ErrorMessage = "O nome do item é obrigatório.")]
        [JsonProperty("name")]
        [BsonElement("name")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A quantidade do item é obrigatória.")]
        [JsonProperty("quantity")]
        [BsonElement("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("maximumPrice")]
        [BsonElement("maximumPrice")]
        public decimal MaximumPrice { get; set; }
    }
}
