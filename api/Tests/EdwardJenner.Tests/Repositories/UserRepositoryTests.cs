using System.Linq;
using System.Threading.Tasks;
using EdwardJenner.Domain.Interfaces.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EdwardJenner.Tests.Repositories
{
    [TestClass]
    public class UserRepositoryTests : BaseRepositoryTests
    {
        private static IUserRepository _userRepository;
        private static IRatingRepository _ratingRepository;

        public UserRepositoryTests()
        {
            _ratingRepository = MockUtils.MockRatingRepository().Object;
            _userRepository = MockUtils.MockUserRepository().Object;
        }

        [TestMethod]
        public async Task CreateTest()
        {
            var user = ObjectHelper.Users.FirstOrDefault();
            Assert.IsNotNull(user);

            await _userRepository.Insert(user);

            var rating = ObjectHelper.Ratings.FirstOrDefault();
            Assert.IsNotNull(rating);

            await _ratingRepository.Insert(rating);

            user = await _userRepository.FindBy(x => x.Id == user.Id);
            Assert.IsNotNull(user);
        }
    }
}
