using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EdwardJenner.Cross.Models;
using EdwardJenner.Data.Repositories;
using EdwardJenner.Domain.Services;
using EdwardJenner.Models.Interfaces.Models;
using EdwardJenner.Models.Models;
using EdwardJenner.Models.Settings;
using EdwardJenner.Tests.Repositories;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace EdwardJenner.Tests
{
    public static class MockUtils
    {
        public static MongoConnection MongoConnection = new MongoConnection
        {
            ConnectionString = "mongodb://127.0.0.1:27017/edwardjenner",
            Database = "edwardjenner"
        };

        public static RedisConnection RedisConnection = new RedisConnection
        {
            Host = "127.0.0.1",
            Port = 6379,
            Seconds = 60000
        };

        public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

            mgr.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<TUser, string>((x, y) => ls.Add(x));
            mgr.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);

            return mgr;
        }

        public static Mock<CacheService<GoogleGeocodeResult>> MockCacheService_GoogleGeocode()
        {
            var mgr = new Mock<CacheService<GoogleGeocodeResult>>(RedisConnection);

            mgr.Setup(x => x.GetObjectCache(It.IsAny<string>())).ReturnsAsync((string key) => ObjectHelper.GoogleGeocodeResults.FirstOrDefault());

            return mgr;
        }

        public static Mock<BaseRepository<TModel>> MockBaseRepository<TModel>() where TModel : IModelBase
        {
            var mgr = new Mock<BaseRepository<TModel>>();

            mgr.Setup(x => x.FindBy(It.IsAny<Expression<Func<TModel, bool>>>())).ReturnsAsync((Expression<Func<TModel, bool>> filter) => ObjectHelper<TModel>.Models().AsQueryable().Where(filter).FirstOrDefault());
            mgr.Setup(x => x.ListBy(It.IsAny<Expression<Func<TModel, bool>>>())).ReturnsAsync((Expression<Func<TModel, bool>> filter) => ObjectHelper<TModel>.Models().AsQueryable().Where(filter).ToList());
            mgr.Setup(x => x.Insert(It.IsAny<TModel>()));

            return mgr;
        }

        public static Mock<ItemRepository> MockItemRepository()
        {
            var mgr = new Mock<ItemRepository>(MongoConnection);
            return mgr;
        }

        public static Mock<OrderRepository> MockOrderRepository()
        {
            var mgr = new Mock<OrderRepository>(MongoConnection);

            mgr.Setup(x => x.FindBy(It.IsAny<Expression<Func<Order, bool>>>())).ReturnsAsync((Expression<Func<Order, bool>> filter) => ObjectHelper.Orders.AsQueryable().Where(filter).FirstOrDefault());
            mgr.Setup(x => x.ListBy(It.IsAny<Expression<Func<Order, bool>>>())).ReturnsAsync((Expression<Func<Order, bool>> filter) => ObjectHelper.Orders.AsQueryable().Where(filter).ToList());
            mgr.Setup(x => x.ListByNearAsync(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<int>())).ReturnsAsync((double longitude, double latitude, double distance) => ObjectHelper.Orders);
            mgr.Setup(x => x.Insert(It.IsAny<Order>()));

            return mgr;
        }

        public static Mock<RatingRepository> MockRatingRepository()
        {
            var mgr = new Mock<RatingRepository>(MongoConnection);
            return mgr;
        }

        public static Mock<UserRepository> MockUserRepository()
        {
            var mgr = new Mock<UserRepository>(MongoConnection);

            mgr.Setup(x => x.FindBy(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync((Expression<Func<User, bool>> filter) => ObjectHelper.Users.AsQueryable().Where(filter).FirstOrDefault());
            mgr.Setup(x => x.ListBy(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync((Expression<Func<User, bool>> filter) => ObjectHelper.Users.AsQueryable().Where(filter).ToList());
            mgr.Setup(x => x.Insert(It.IsAny<User>()));

            return mgr;
        }
    }
}
