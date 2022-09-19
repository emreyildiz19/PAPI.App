namespace PAPI.Caching
{
    public interface ICacheService
    {
        T Get<T>(string key);
        void Add(string key, object data, TimeSpan expiry);
        void Remove(string key);
        void Clear();
        bool Any(string key);

        void AddList(string key, object List, TimeSpan expiry);
    }
}
