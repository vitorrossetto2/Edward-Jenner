namespace EdwardJenner.Cross.Models
{
    public class BasicAuthentication : Interfaces.Models.IAuthenticationModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
