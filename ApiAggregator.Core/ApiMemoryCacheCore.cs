namespace ApiAggregator.Core;

public interface IApiMemoryCache
{
    bool Check(string key, out string? result);

    void Set(string key, string value);
}
