using ApiAggregator.Core;
using Microsoft.Extensions.Caching.Memory;

namespace ApiAggregator.Service.Internal.Caching;

public class ApiMemoryCache : IApiMemoryCache
{
    public ApiMemoryCache(TimeSpan expirationPeriod) => _expirationPeriod = expirationPeriod;

    public bool Check(string key, out string? result) => _cache.TryGetValue(key, out result);

    public void Set(string key, string value)
    {
        if (_expirationPeriod == TimeSpan.Zero)
            _cache.Set(key, value);
        else
            _cache.Set(key, value, _expirationPeriod);
    }

    readonly TimeSpan _expirationPeriod;

    readonly MemoryCache _cache = new(new MemoryCacheOptions());
}
