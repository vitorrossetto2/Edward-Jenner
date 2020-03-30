using System.Linq;
using System.Threading.Tasks;
using EdwardJenner.Data.Repositories;
using EdwardJenner.Models.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EdwardJenner.Tests.Repositories
{
    [TestClass]
    public class OrderRepositoryTests : BaseRepositoryTests
    {
        private static UserRepository _userRepository;

        private static OrderRepository _orderRepository;
        private static ItemRepository _itemRepository;
        private static RatingRepository _ratingRepository;

        public OrderRepositoryTests()
        {
            _itemRepository = new ItemRepository(_mongoConnection);
            _ratingRepository = new RatingRepository(_mongoConnection);
            _orderRepository = new OrderRepository(_mongoConnection, _itemRepository);
            _userRepository = new UserRepository(_mongoConnection, _googleMapsApi, _googleGeocodeResultCache, _userManager);
        }

        [TestMethod]
        public async Task CreateCompleteTest()
        {
            var user = await _userRepository.FindBy(x => x.Username == "lennonalvesdias");

            var order = new Order
            {
                UserId = user.Id,
                Type = OrderType.Market,
                LastStatus = OrderStatus.New,
                Longitude = -46.6688605,
                Latitude = -23.6104878
            };

            await _orderRepository.Insert(order);

            var item = new Item
            {
                OrderId = order.Id,
                Nome = "Arroz",
                Quantity = 1,
                MaximumPrice = 10
            };

            await _itemRepository.Insert(item);

            var orders = await _orderRepository.ListBy(x => true);
            Assert.IsNotNull(orders);
            Assert.IsNotNull(orders.FirstOrDefault()?.Items);

            await _itemRepository.Delete(x => x.Id == item.Id);
            await _orderRepository.Delete(x => x.Id == order.Id);
        }

        [TestMethod]
        public async Task ListNearTest()
        {
            //var longitude = -46.6620627; // lennon - 0km
            //var latitude = -23.6036901; // lennon - 0km
            var longitude = -46.6688605; // ibirapuera - 1km
            var latitude = -23.6104878; // ibirapuera - 1km
            var distanceInMeters = 1300;

            var orders = await _orderRepository.ListByNearAsync(longitude, latitude, distanceInMeters);
            Assert.IsTrue(orders.Any());
        }
    }
}
