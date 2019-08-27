using System;
using Microsoft.Extensions.Caching.Memory;

namespace Demo.Microservices.Core.Cache
{
  public  class MemCacheProvider:ICache
  {
      private readonly IMemoryCache _cache;
        public MemCacheProvider(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void Store(string key, object data)
        {
    
                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                // Save data in cache.
           _cache.Set(key, data, cacheEntryOptions);
            
        }

        public T Retrieve<T>(string storageKey)
        {
            // Look for cache key.
            return !_cache.TryGetValue(storageKey, out T cacheEntry) ? default(T) : cacheEntry;
        }
    }
}
