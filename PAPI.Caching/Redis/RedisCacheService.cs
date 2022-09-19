using Newtonsoft.Json;

namespace PAPI.Caching.Redis
{
    public class RedisCacheService : ICacheService
    {
        private RedisServer _redisServer;

        public RedisCacheService(RedisServer redisServer)
        {
            _redisServer = redisServer;
        }

        public void Add(string key, object data, TimeSpan expiry)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            _redisServer.Database.StringSet(key, jsonData, expiry);
        }

        public void AddList(string key, object List, TimeSpan expiry)
        {
            string jsonData = JsonConvert.SerializeObject(List);
            _redisServer.Database.StringSet(key, jsonData, expiry);
        }


        public bool Any(string key)
        {
            return _redisServer.Database.KeyExists(key);
        }

        public T Get<T>(string key)
        {
            if (Any(key))
            {
                string jsonData = _redisServer.Database.StringGet(key);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }

            return default;
        }

        public void Remove(string key)
        {
            _redisServer.Database.KeyDelete(key);
        }

        public void Clear()
        {
            _redisServer.FlushDatabase();
        }
    }
}