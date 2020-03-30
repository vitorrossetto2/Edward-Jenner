using System.Linq;
using System.Threading.Tasks;
using EdwardJenner.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EdwardJenner.Tests.Repositories
{
    [TestClass]
    public class UserRepositoryTests : BaseRepositoryTests
    {
        private static UserRepository _userRepository;
        private static RatingRepository _ratingRepository;

        public UserRepositoryTests()
        {
            _ratingRepository = MockUtils.MockRatingRepository().Object;
            _userRepository = MockUtils.MockUserRepository().Object;
        }

        [TestMethod]
        public async Task CreateTest()
        {
            var user = ObjectHelper.Users.FirstOrDefault();

            await _userRepository.Insert(user);

            var rating = ObjectHelper.Ratings.FirstOrDefault();

            await _ratingRepository.Insert(rating);

            user = await _userRepository.FindBy(x => x.Id == user.Id);

            Assert.IsNotNull(user.Ratings);
        }
    }
}
