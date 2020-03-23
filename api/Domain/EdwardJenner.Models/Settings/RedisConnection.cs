namespace EdwardJenner.Models.Settings
{
    public class RedisConnection
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public int Seconds { get; set; }
        public string ConnectionString { get; set; }
    }
}
