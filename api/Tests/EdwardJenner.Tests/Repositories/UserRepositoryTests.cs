using System.Linq;
using System.Threading.Tasks;
using EdwardJenner.Data.Repositories;
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

            _userRepository = new UserRepository(connection);
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
                Username = "lennonalvesdias"
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
