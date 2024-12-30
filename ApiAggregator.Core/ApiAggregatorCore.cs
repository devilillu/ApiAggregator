using Helper;
using Microsoft.AspNetCore.Http;

namespace ApiAggregator.Core;

public interface IApiFunction
{
    string Name { get; }

    string ApiName { get; }

    string Pattern { get; }

    IEnumerable<KeyValuePair<string, string>> Headers { get; }
}

public interface IAggregationFunction : IApiFunction
{
    Task Handler(HttpContext context);
}

public interface IApiResult
{
    HttpClientResult Result { get; }

    IApiFunction Function { get; }
}

public interface IAggResult
{
    List<IApiResult> Results { get; }

    string RawFormat();
}

public interface IApiMemoryCache
{
    bool Check(string key, out string? result);

    void Set(string key, string value);
}
