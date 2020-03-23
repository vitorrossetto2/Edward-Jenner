using System.Linq;
using System.Threading.Tasks;
using EdwardJenner.Cross;
using EdwardJenner.Cross.Models;
using EdwardJenner.Data.Repositories;
using EdwardJenner.Domain.Services;
using EdwardJenner.Models.Models;
using EdwardJenner.Models.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EdwardJenner.Tests.Repositories
{
    [TestClass]
    public class UserRepositoryTests
    {
        private static UserRepository _userRepository;

        public UserRepositoryTests()
        {
            var connection = new MongoConnection
            {
                ConnectionString = "mongodb://127.0.0.1:27017/edwardjenner",
                Database = "edwardjenner"
            };

            var googleSettings = new GoogleSettings
            {
                ApiKey = "AIzaSyA24yDHFfDuszVUomPTe8EiLTIdGjbESYc"
            };

            var googleMapsApi = new GoogleMapsApi(googleSettings);

            var redisConnection = new RedisConnection
            {
                Host = "127.0.0.1",
                Port = 6379,
                Seconds = 60000
            };

            var cacheGoogleGeocodeService = new CacheService<GoogleGeocodeResult>(redisConnection);

            _userRepository = new UserRepository(connection, googleMapsApi, cacheGoogleGeocodeService);
        }

        [TestMethod]
        public async Task CreateTest()
        {
            var user = new User
            {
                Email = "lennonalvesdias@gmail.com",
                Longitude = -46.6620627,
                Latitude = -23.6036901,
                Name = "Lennon Dias",
                Password = "abc123",
                Username = "lennonalvesdias",
                Cpf = "01234567890",
                HomeAddress = new Address
                {
                    Country = "BR",
                    State = "SP",
                    City = "São Paulo",
                    Neighborhood = "Planalto Paulista",
                    Street = "Avenida Moema",
                    Number = "84",
                    Complement = null
                },
                MobilePhone = new Phone
                {
                    Number = "14",
                    Ddd = "997210201"
                }
            };
            await _userRepository.Insert(user);
        }

        [TestMethod]
        public async Task ListNearTest()
        {
            //var longitude = -46.6620627; // lennon - 0km
            //var latitude = -23.6036901; // lennon - 0km
            var longitude = -46.6688605; // ibirapuera - 1km
            var latitude = -23.6104878; // ibirapuera - 1km
            var distanceInMeters = 1300;

            var users = await _userRepository.ListByNearAsync(longitude, latitude, distanceInMeters);
            Assert.IsTrue(users.Any());
        }
    }
}
