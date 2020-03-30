using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdwardJenner.Data.Repositories;
using EdwardJenner.Models.Models;
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
            _ratingRepository = new RatingRepository(_mongoConnection);
            _userRepository = new UserRepository(_mongoConnection, _googleMapsApi, _googleGeocodeResultCache, _userManager, _ratingRepository);
        }

        [TestMethod]
        public async Task CreateTest()
        {
            var user = new User
            {
                Email = "lennonalvesdias@gmail.com",
                Name = "Lennon Dias",
                Password = "abc123",
                Username = "lennonalvesdias",
                Cpf = "01234567890",
                Adresses = new List<Address>
               {
                   new Address
                   {
                           Country = "BR",
                           State = "SP",
                           City = "São Paulo",
                           Neighborhood = "Planalto Paulista",
                           Street = "Avenida Moema",
                           Number = "84",
                           Complement = null,
                           Type = AddressType.Home
                   }
               },
                Phones = new List<Phone>
                {
                    new Phone
                    {
                        Number = "14",
                        Ddd = "997210201"
                    }
                },
                Type = UserType.Helper,
                About = null,
                ApplicationUserId = null,
                Avatar = null,
                Birthday = new DateTime(1994, 7, 18),
                Distance = 2000
            };

            await _userRepository.Insert(user);

            var rating = new Rating
            {
                Description = "Rating description.",
                Rate = 4,
                UserId = user.Id
            };

            await _ratingRepository.Insert(rating);

            user = await _userRepository.FindBy(x => x.Id == user.Id);

            Assert.IsNotNull(user.Ratings);

            //await _ratingRepository.Delete(x => x.Id == rating.Id);

            //await _userRepository.Delete(x => x.Id == user.Id);
        }
    }
}
