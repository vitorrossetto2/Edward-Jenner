using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace EdwardJenner.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://*:1337");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
