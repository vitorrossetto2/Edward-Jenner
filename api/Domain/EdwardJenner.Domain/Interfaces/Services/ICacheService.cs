using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdwardJenner.Domain.Interfaces.Services
{
    public interface ICacheService<TModel> where TModel : class
    {
        Task SetObjectCache(string key, TModel value, TimeSpan? timeOut = null);

        Task<TModel> GetObjectCache(string key);

        Task SetObjectListCache(string key, IList<TModel> value, TimeSpan? timeOut = null);

        Task<IList<TModel>> GetObjectListCache(string key);

        Task SetStringCache(string key, string value, TimeSpan? timeOut = null);

        Task<string> GetStringCache(string key);

        Task RemoveCache(string key);

        Task RemoveCacheByPattern(string key);

        Task RemoveAllCache();
    }
}
