using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EdwardJenner.Cross.Interfaces;
using EdwardJenner.Cross.Models;
using EdwardJenner.Domain.Exceptions;
using EdwardJenner.Domain.Interfaces.Repositories;
using EdwardJenner.Domain.Interfaces.Services;
using EdwardJenner.Models.Models;
using EdwardJenner.Models.Security;
using EdwardJenner.Models.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;

namespace EdwardJenner.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IGoogleMapsApi _googleMapsApi;
        private readonly ICacheService<GoogleGeocodeResult> _cacheGoogleGeocodeService;
        private readonly UserManager<ApplicationUser> _userManager;

        protected override string GetCollectionName() => "users";

        public UserRepository(MongoConnection mongoConnection, IGoogleMapsApi googleMapsApi, ICacheService<GoogleGeocodeResult> cacheGoogleGeocodeService, UserManager<ApplicationUser> userManager) : base(mongoConnection)
        {
            _googleMapsApi = googleMapsApi;
            _cacheGoogleGeocodeService = cacheGoogleGeocodeService;
            _userManager = userManager;
            CreateIndexes();
        }

        private void CreateIndexes()
        {
            var keys = Builders<User>.IndexKeys.Text(x => x.Username);
            var model = new CreateIndexModel<User>(keys);
            BaseCollection.Indexes.CreateOne(model);
        }

        public new async Task<User> FindBy(Expression<Func<User, bool>> filter)
        {
            var user = await BaseCollection.Find(filter).FirstOrDefaultAsync();
            user.Password = null;
            return user;
        }

        public new async Task<IList<User>> ListBy(Expression<Func<User, bool>> filter)
        {
            var users = await BaseCollection.Find(filter).ToListAsync();
            foreach (var user in users)
            {
                user.Password = null;
            }
            return users;
        }

        public new async Task Insert(User order)
        {
            var applicationUser = CreateApplicationUser(new ApplicationUser
            {
                UserName = order.Username,
                Email = order.Email,
                EmailConfirmed = true
            }, order.Password, Roles.RoleApiEdwardJenner);

            order.ApplicationUserId = applicationUser.Id;
            order.UpdatedIn = DateTime.Now;

            foreach (var address in order.Adresses)
            {
                address.Location = await GetGeopointsByAddress(address);
            }

            await BaseCollection.InsertOneAsync(order);
        }

        public new async Task<User> Update(User order)
        {
            await _userManager.UpdateAsync(new ApplicationUser
            {
                Id = order.ApplicationUserId,
                Email = order.Email,
                EmailConfirmed = true
            });

            order.UpdatedIn = DateTime.Now;

            foreach (var address in order.Adresses)
            {
                address.Location = await GetGeopointsByAddress(address);
            }

            return await BaseCollection.FindOneAndReplaceAsync(x => x.Id == order.Id, order);
        }

        private ApplicationUser CreateApplicationUser(ApplicationUser user, string password, string initialRole = null)
        {
            if (_userManager.FindByNameAsync(user.UserName).Result != null) throw new BadRequestException("Já existe um usuário com esse username.");

            var result = _userManager.CreateAsync(user, password).Result;

            if (result.Succeeded && !string.IsNullOrWhiteSpace(initialRole))
            {
                _userManager.AddToRoleAsync(user, initialRole).Wait();
            }
            else
            {
                throw new Exception(result.ToString());
            }

            return user;
        }

        private async Task<GeoJsonPoint<GeoJson2DGeographicCoordinates>> GetGeopointsByAddress(Address address)
        {
            var formatAddress = $"{address.Street},{address.Number},{address.City},{address.State}".Replace(" ", "+");

            var homeLocation = await _cacheGoogleGeocodeService.GetObjectCache($"ej-{formatAddress}");
            if (homeLocation == null)
            {
                homeLocation = _googleMapsApi.GetGeocode(formatAddress)?.Results?.FirstOrDefault();
                await _cacheGoogleGeocodeService.SetObjectCache($"ej-{formatAddress}", homeLocation);
            }

            if (homeLocation != null)
            {
                return new GeoJsonPoint<GeoJson2DGeographicCoordinates>(
                    new GeoJson2DGeographicCoordinates(homeLocation.GoogleGeocodeGeometry.GoogleGeocodeLocation.Lng, homeLocation.GoogleGeocodeGeometry.GoogleGeocodeLocation.Lat));
            }
            else
            {
                return null;
            }
        }
    }
}
