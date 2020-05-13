using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RuletaFinal.DAL.Interfaces;
using ServiceStack;
using ServiceStack.Text;
using System.Collections.Generic;

namespace RuletaFinal.DAL.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDistributedCache _cache;
        private readonly string _cacheKeyPrefix;

        public Repository(IDistributedCache cache, string cacheKeyPrefix) 
        {
            _cache = cache;
            _cacheKeyPrefix = cacheKeyPrefix;
        }

        // save 
        public void SetObjectAsync(string id, T objectToCache)
        {
            string cacheKey = $"{_cacheKeyPrefix}.{id}";
            string serializedObjectToCache = JsonConvert.SerializeObject(objectToCache);
            _cache.SetString(cacheKey, serializedObjectToCache);
        }

        // get
        public T GetObjectAsync(string id)
        {
            string cacheKey = $"{_cacheKeyPrefix}.{id}";
            string json = _cache.GetString(cacheKey);
            
            if (string.IsNullOrEmpty(json))
                return default(T);

            return JsonConvert.DeserializeObject<T>(json);
        }

        public List<T> GetList() 
        {
            var result = _cache.InList();
            return null;
        }
    }
}
