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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        protected override string GetCollectionName()
        {
            return "users";
        }

        public UserRepository(MongoConnection mongoConnection) : base(mongoConnection)
        {
            var keys = Builders<User>.IndexKeys.Geo2DSphere(x => x.Location);
            var model = new CreateIndexModel<User>(keys);
            BaseCollection.Indexes.CreateOne(model);
        }

        public async Task<IList<User>> ListByNearAsync(double longitude, double latitude, int distance)
        {
            var point = GeoJson.Point(GeoJson.Geographic(longitude, latitude));
            var filter = Builders<User>.Filter.Near(x => x.Location, point, distance);
            var users = await BaseCollection.Find(filter).ToListAsync();
            foreach (var user in users)
            {
                user.Longitude = user.Location.Coordinates.Longitude;
                user.Latitude = user.Location.Coordinates.Latitude;
                user.Password = null;
            }
            return users;
        }

        public new async Task<User> FindBy(Expression<Func<User, bool>> filter)
        {
            var user = await BaseCollection.Find(filter).FirstOrDefaultAsync();
            user.Longitude = user.Location.Coordinates.Longitude;
            user.Latitude = user.Location.Coordinates.Latitude;
            user.Password = null;
            return user;
        }

        public new async Task<IList<User>> ListBy(Expression<Func<User, bool>> filter)
        {
            var users = await BaseCollection.Find(filter).ToListAsync();
            foreach (var user in users)
            {
                user.Longitude = user.Location.Coordinates.Longitude;
                user.Latitude = user.Location.Coordinates.Latitude;
                user.Password = null;
            }
            return users;
        }

        public new async Task Insert(User user)
        {
            user.UpdatedIn = DateTime.Now;
            user.Location =
                new GeoJsonPoint<GeoJson2DGeographicCoordinates>(
                    new GeoJson2DGeographicCoordinates(user.Longitude, user.Latitude));
            await BaseCollection.InsertOneAsync(user);
        }

        public new async Task<User> Update(User user)
        {
            user.UpdatedIn = DateTime.Now;
            user.Location =
                new GeoJsonPoint<GeoJson2DGeographicCoordinates>(
                    new GeoJson2DGeographicCoordinates(user.Longitude, user.Latitude));
            return await BaseCollection.FindOneAndReplaceAsync(x => x.Id == user.Id, user);
        }
    }
}
