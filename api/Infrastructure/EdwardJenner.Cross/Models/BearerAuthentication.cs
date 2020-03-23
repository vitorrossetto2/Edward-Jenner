namespace EdwardJenner.Cross.Models
{
    public class BearerAuthentication : Interfaces.Models.IAuthenticationModel
    {
        public string UrlAuthService { get; set; }
        public string ResourceAuthService { get; set; }
        public TokenSend TokenSend { get; set; }
    }
}
