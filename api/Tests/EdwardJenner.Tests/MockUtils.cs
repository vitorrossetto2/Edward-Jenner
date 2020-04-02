using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EdwardJenner.Cross.Interfaces;
using EdwardJenner.Cross.Models;
using EdwardJenner.Domain.Interfaces.Repositories;
using EdwardJenner.Domain.Interfaces.Services;
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
            ConnectionString = "null",
            Database = "null"
        };

        public static RedisConnection RedisConnection = new RedisConnection
        {
            Host = "null",
            Port = 0,
            Seconds = 0
        };

        public static GoogleSettings GoogleSettings = new GoogleSettings
        {
            ApiKey = "null"
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

        public static Mock<IGoogleMapsApi> MockGoogleMapsApi()
        {
            var mgr = new Mock<IGoogleMapsApi>(GoogleSettings);

            mgr.Setup(x => x.GetGeocode(It.IsAny<string>())).Returns(new GoogleGeocodeResponse { Results = ObjectHelper.GoogleGeocodeResults });

            return mgr;
        }

        public static Mock<ICacheService<GoogleGeocodeResult>> MockCacheService_GoogleGeocode()
        {
            var mgr = new Mock<ICacheService<GoogleGeocodeResult>>();

            mgr.Setup(x => x.GetObjectCache(It.IsAny<string>())).ReturnsAsync((string key) => ObjectHelper.GoogleGeocodeResults.FirstOrDefault());

            return mgr;
        }

        public static Mock<IBaseRepository<TModel>> MockBaseRepository<TModel>() where TModel : IModelBase
        {
            var mgr = new Mock<IBaseRepository<TModel>>();

            mgr.Setup(x => x.FindBy(It.IsAny<Expression<Func<TModel, bool>>>())).ReturnsAsync((Expression<Func<TModel, bool>> filter) => ObjectHelper<TModel>.Models().AsQueryable().Where(filter).FirstOrDefault());
            mgr.Setup(x => x.ListBy(It.IsAny<Expression<Func<TModel, bool>>>())).ReturnsAsync((Expression<Func<TModel, bool>> filter) => ObjectHelper<TModel>.Models().AsQueryable().Where(filter).ToList());
            mgr.Setup(x => x.Insert(It.IsAny<TModel>()));

            return mgr;
        }

        public static Mock<IItemRepository> MockItemRepository()
        {
            var mgr = new Mock<IItemRepository>();

            mgr.Setup(x => x.FindBy(It.IsAny<Expression<Func<Item, bool>>>())).ReturnsAsync((Expression<Func<Item, bool>> filter) => ObjectHelper.Items.AsQueryable().Where(filter).FirstOrDefault());
            mgr.Setup(x => x.ListBy(It.IsAny<Expression<Func<Item, bool>>>())).ReturnsAsync((Expression<Func<Item, bool>> filter) => ObjectHelper.Items.AsQueryable().Where(filter).ToList());
            mgr.Setup(x => x.Insert(It.IsAny<Item>()));

            return mgr;
        }

        public static Mock<IOrderRepository> MockOrderRepository()
        {
            var mgr = new Mock<IOrderRepository>();

            mgr.Setup(x => x.FindBy(It.IsAny<Expression<Func<Order, bool>>>())).ReturnsAsync((Expression<Func<Order, bool>> filter) => ObjectHelper.Orders.AsQueryable().Where(filter).FirstOrDefault());
            mgr.Setup(x => x.ListBy(It.IsAny<Expression<Func<Order, bool>>>())).ReturnsAsync((Expression<Func<Order, bool>> filter) => ObjectHelper.Orders.AsQueryable().Where(filter).ToList());
            mgr.Setup(x => x.ListByNearAsync(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<int>())).ReturnsAsync((double longitude, double latitude, double distance) => ObjectHelper.Orders);
            mgr.Setup(x => x.Insert(It.IsAny<Order>()));

            return mgr;
        }

        public static Mock<IRatingRepository> MockRatingRepository()
        {
            var mgr = new Mock<IRatingRepository>();

            mgr.Setup(x => x.FindBy(It.IsAny<Expression<Func<Rating, bool>>>())).ReturnsAsync((Expression<Func<Rating, bool>> filter) => ObjectHelper.Ratings.AsQueryable().Where(filter).FirstOrDefault());
            mgr.Setup(x => x.ListBy(It.IsAny<Expression<Func<Rating, bool>>>())).ReturnsAsync((Expression<Func<Rating, bool>> filter) => ObjectHelper.Ratings.AsQueryable().Where(filter).ToList());
            mgr.Setup(x => x.Insert(It.IsAny<Rating>()));

            return mgr;
        }

        public static Mock<IUserRepository> MockUserRepository()
        {
            var mgr = new Mock<IUserRepository>();

            mgr.Setup(x => x.FindBy(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync((Expression<Func<User, bool>> filter) => ObjectHelper.Users.AsQueryable().Where(filter).FirstOrDefault());
            mgr.Setup(x => x.ListBy(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync((Expression<Func<User, bool>> filter) => ObjectHelper.Users.AsQueryable().Where(filter).ToList());
            mgr.Setup(x => x.Insert(It.IsAny<User>()));

            return mgr;
        }
    }
}
