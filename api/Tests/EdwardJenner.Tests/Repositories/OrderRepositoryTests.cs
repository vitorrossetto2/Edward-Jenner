using System.Linq;
using System.Threading.Tasks;
using EdwardJenner.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EdwardJenner.Tests.Repositories
{
    [TestClass]
    public class OrderRepositoryTests : BaseRepositoryTests
    {
        private static UserRepository _userRepository;
        private static OrderRepository _orderRepository;
        private static ItemRepository _itemRepository;

        public OrderRepositoryTests()
        {
            _itemRepository = MockUtils.MockItemRepository().Object;
            _orderRepository = MockUtils.MockOrderRepository().Object;
            _userRepository = MockUtils.MockUserRepository().Object;
        }

        [TestMethod]
        public async Task CreateCompleteTest()
        {
            var user = await _userRepository.FindBy(x => x.Username == "lennonalvesdias");

            var order = ObjectHelper.Orders.FirstOrDefault();

            await _orderRepository.Insert(order);

            var item = ObjectHelper.Items.FirstOrDefault();

            await _itemRepository.Insert(item);

            var orders = await _orderRepository.ListBy(x => true);

            Assert.IsNotNull(orders);
            Assert.IsNotNull(orders.FirstOrDefault()?.Items);
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
