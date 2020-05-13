using StackExchange.Redis;
using System.Threading.Tasks;

namespace RuletaFinal.Transversal.Services
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
            => _connectionMultiplexer = connectionMultiplexer;

        public async Task<string> GetCacheValueSync(string key) 
        {
            var db = _connectionMultiplexer.GetDatabase();
            return await db.StringGetAsync(key);
        }

        public async Task SetCacheValueSync(string key, string value) 
        {
            var db = _connectionMultiplexer.GetDatabase();
            await db.StringSetAsync(key, value);
        }
    }
}
