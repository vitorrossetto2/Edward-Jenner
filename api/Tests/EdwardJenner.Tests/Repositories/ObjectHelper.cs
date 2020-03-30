using System;
using System.Collections.Generic;
using EdwardJenner.Cross.Models;
using EdwardJenner.Models.Interfaces.Models;
using EdwardJenner.Models.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EdwardJenner.Tests.Repositories
{
    public static class ObjectHelper
    {
        public static string UserId = "d7a0dfe41f004cf483f14acc2a3b5475";
        public static string OrderId = "1a3e6757844b44c890a1337c8180f903";

        public static List<ApplicationUser> ApplicationUsers => new List<ApplicationUser>
        {
            new ApplicationUser()
            {
                UserName = "user",
                Email = "user",
                EmailConfirmed = true
            }
        };

        public static List<Item> Items => new List<Item> {
            new Item
            {
                OrderId = OrderId,
                Nome = "Arroz",
                Quantity = 1,
                MaximumPrice = 10
            }
        };

        public static List<Order> Orders => new List<Order> {
            new Order
            {
                Id = OrderId,
                UserId = UserId,
                Type = OrderType.Market,
                LastStatus = OrderStatus.New,
                Longitude = -46.6688605,
                Latitude = -23.6104878
            }
        };

        public static List<Rating> Ratings => new List<Rating>
        {
            new Rating
            {
                Description = "Rating description.",
                Rate = 4,
                UserId = UserId
            }
        };

        public static List<User> Users => new List<User>
        {
            new User
            {
                Id = UserId,
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
            }
        };

        public static List<GoogleGeocodeResult> GoogleGeocodeResults => new List<GoogleGeocodeResult>
        {
            new GoogleGeocodeResult
            {
                GoogleGeocodeGeometry = new GoogleGeocodeGeometry
                {
                    GoogleGeocodeLocation = new GoogleGeocodeLocation
                    {
                        Lat = -23.6036901,
                        Lng = -46.6620627
                    }
                }
            }
        };
    }

    public static class ObjectHelper<TModel> where TModel : IModelBase
    {
        public static List<TModel> Models()
        {
            if (typeof(TModel) == typeof(Item))
            {
                return (List<TModel>)Convert.ChangeType(ObjectHelper.Items, typeof(List<TModel>));
            }

            if (typeof(TModel) == typeof(Order))
            {
                return (List<TModel>)Convert.ChangeType(ObjectHelper.Orders, typeof(List<TModel>));
            }

            if (typeof(TModel) == typeof(Rating))
            {
                return (List<TModel>)Convert.ChangeType(ObjectHelper.Ratings, typeof(List<TModel>));
            }

            if (typeof(TModel) == typeof(User))
            {
                return (List<TModel>)Convert.ChangeType(ObjectHelper.Users, typeof(List<TModel>));
            }

            return null;
        }
    }
}
