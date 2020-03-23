using System.Collections.Generic;
using Newtonsoft.Json;

namespace EdwardJenner.Cross.Models
{
    public class JwtAuthentication : Interfaces.Models.IAuthenticationModel
    {
        public string UrlAuthService { get; set; }
        public string ResourceAuthService { get; set; }
        public string PrivateKey { get; set; }
        public IDictionary<string, string> Claims { get; set; }
        public JwtSend JwtSend { get; set; }
        public int ExpireInSeconds { get; set; }
    }

    public class JwtSend
    {
        [JsonProperty("grant_type")]
        public string GrantType { get; set; } = "urn:ietf:params:oauth:grant-type:jwt-bearer";
        [JsonProperty("assertion")]
        public string Assertion { get; set; }
    }
}
