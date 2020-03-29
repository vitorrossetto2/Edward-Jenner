using Newtonsoft.Json;

namespace EdwardJenner.Models.DTO
{
    public class ErrorDetails
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("exceptionMessage")]
        public string ExceptionMessage { get; set; }

        [JsonProperty("exceptionType")]
        public string ExceptionType { get; set; }

        [JsonProperty("stackTrace")]
        public string StackTrace { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
