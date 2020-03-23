using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdwardJenner.Domain.Interfaces.Services;
using EdwardJenner.Models.Settings;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace EdwardJenner.Domain.Services
{
    public class CacheService<TModel> : ICacheService<TModel> where TModel : class
    {
        private readonly ConnectionMultiplexer _connection;
        private readonly IDatabase _cache;
        private readonly TimeSpan _cacheTimeout;

        public CacheService([FromServices]RedisConnection redisConnection)
        {
            try
            {
                var option = new ConfigurationOptions
                {
                    AbortOnConnectFail = false,
                    EndPoints = { $"{redisConnection.Host}:{redisConnection.Port}" }
                };
                _connection = ConnectionMultiplexer.Connect(option);
                _cache = _connection.GetDatabase();
                _cacheTimeout = TimeSpan.FromSeconds(redisConnection.Seconds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task SetObjectCache(string key, TModel value, TimeSpan? timeOut = null)
        {
            await _cache.StringSetAsync(key, JsonConvert.SerializeObject(value), timeOut ?? _cacheTimeout);
        }

        public async Task<TModel> GetObjectCache(string key)
        {
            var cacheResult = await _cache.StringGetAsync(key);
            return cacheResult.HasValue ? JsonConvert.DeserializeObject<TModel>(cacheResult.ToString()) : null;
        }

        public async Task SetObjectListCache(string key, IList<TModel> value, TimeSpan? timeOut = null)
        {
            await _cache.StringSetAsync(key, JsonConvert.SerializeObject(value), timeOut ?? _cacheTimeout);
        }

        public async Task<IList<TModel>> GetObjectListCache(string key)
        {
            var cacheResult = await _cache.StringGetAsync(key);
            return cacheResult.HasValue ? JsonConvert.DeserializeObject<IList<TModel>>(cacheResult.ToString()) : null;
        }

        public async Task SetStringCache(string key, string value, TimeSpan? timeOut = null)
        {
            await _cache.StringSetAsync(key, value, timeOut ?? _cacheTimeout);
        }

        public async Task<string> GetStringCache(string key)
        {
            var cacheResult = await _cache.StringGetAsync(key);
            return cacheResult.ToString();
        }

        public async Task RemoveCache(string key)
        {
            await _cache.KeyDeleteAsync(key);
        }

        public async Task RemoveCacheByPattern(string key)
        {
            var endpoints = _connection.GetEndPoints(true);
            foreach (var endpoint in endpoints)
            {
                var server = _connection.GetServer(endpoint);
                foreach (var patternKey in server.Keys(pattern: $"{key}.*"))
                {
                    await _cache.KeyDeleteAsync(patternKey);
                }
            }
        }

        public async Task RemoveAllCache()
        {
            var endpoints = _connection.GetEndPoints(true);
            foreach (var endpoint in endpoints)
            {
                var server = _connection.GetServer(endpoint);
                await server.FlushAllDatabasesAsync();
            }
        }
    }
}
