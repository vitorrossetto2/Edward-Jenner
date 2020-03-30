using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EdwardJenner.Domain.Interfaces.Repositories;
using EdwardJenner.Models.Models;
using EdwardJenner.Models.Settings;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;

namespace EdwardJenner.Data.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly IItemRepository _itemRepository;

        protected override string GetCollectionName() => "orders";

        public OrderRepository(MongoConnection mongoConnection, IItemRepository itemRepository) : base(mongoConnection)
        {
            _itemRepository = itemRepository;
            CreateIndexes();
        }

        private void CreateIndexes()
        {
            var keys = Builders<Order>.IndexKeys.Geo2DSphere(x => x.Location);
            var model = new CreateIndexModel<Order>(keys);
            BaseCollection.Indexes.CreateOne(model);
        }

        public async Task<IList<Order>> ListByNearAsync(double longitude, double latitude, int distance)
        {
            var point = GeoJson.Point(GeoJson.Geographic(longitude, latitude));
            var filter = Builders<Order>.Filter.Near(x => x.Location, point, distance);
            var orders = await BaseCollection.Find(filter).ToListAsync();
            foreach (var order in orders)
            {
                order.Longitude = order.Location.Coordinates.Longitude;
                order.Latitude = order.Location.Coordinates.Latitude;
            }
            return orders;
        }

        public new async Task<Order> FindBy(Expression<Func<Order, bool>> filter)
        {
            var order = await BaseCollection.Find(filter).FirstOrDefaultAsync();
            order.Latitude = order.Location.Coordinates.Latitude;
            order.Longitude = order.Location.Coordinates.Longitude;
            order.Items = await _itemRepository.ListBy(x => x.OrderId == order.Id);
            return order;
        }

        public new async Task<IList<Order>> ListBy(Expression<Func<Order, bool>> filter)
        {
            var orders = await BaseCollection.Find(filter).ToListAsync();
            foreach (var order in orders)
            {
                order.Latitude = order.Location.Coordinates.Latitude;
                order.Longitude = order.Location.Coordinates.Longitude;
                order.Items = await _itemRepository.ListBy(x => x.OrderId == order.Id);
            }
            return orders;
        }

        public new async Task Insert(Order order)
        {
            order.UpdatedIn = DateTime.Now;
            order.Location = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(
                new GeoJson2DGeographicCoordinates(order.Longitude, order.Latitude));
            await BaseCollection.InsertOneAsync(order);
        }

        public new async Task<Order> Update(Order order)
        {
            order.UpdatedIn = DateTime.Now;
            order.Location = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(
                new GeoJson2DGeographicCoordinates(order.Longitude, order.Latitude));
            return await BaseCollection.FindOneAndReplaceAsync(x => x.Id == order.Id, order);
        }
    }
}
