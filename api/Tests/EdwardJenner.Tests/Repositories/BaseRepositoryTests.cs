using System.Collections.Generic;
using EdwardJenner.Cross;
using EdwardJenner.Cross.Models;
using EdwardJenner.Domain.Services;
using EdwardJenner.Models.Models;
using EdwardJenner.Models.Settings;
using Microsoft.AspNetCore.Identity;

namespace EdwardJenner.Tests.Repositories
{
    public class BaseRepositoryTests
    {
        protected List<ApplicationUser> _users = new List<ApplicationUser>
        {
            new ApplicationUser()
            {
                UserName = "user",
                Email = "user",
                EmailConfirmed = true
            }
        };

        protected readonly MongoConnection _mongoConnection;

        protected readonly GoogleMapsApi _googleMapsApi;

        protected readonly UserManager<ApplicationUser> _userManager;

        protected readonly CacheService<GoogleGeocodeResult> _googleGeocodeResultCache;

        public BaseRepositoryTests()
        {
            _mongoConnection = new MongoConnection
            {
                ConnectionString = "mongodb://127.0.0.1:27017/edwardjenner",
                Database = "edwardjenner"
            };

            var googleSettings = new GoogleSettings
            {
                ApiKey = "AIzaSyA24yDHFfDuszVUomPTe8EiLTIdGjbESYc"
            };

            _googleMapsApi = new GoogleMapsApi(googleSettings);

            _userManager = MockUtils.MockUserManager<ApplicationUser>(_users).Object;

            var redisConnection = new RedisConnection
            {
                Host = "127.0.0.1",
                Port = 6379,
                Seconds = 60000
            };

            _googleGeocodeResultCache = new CacheService<GoogleGeocodeResult>(redisConnection);
        }
    }
}
