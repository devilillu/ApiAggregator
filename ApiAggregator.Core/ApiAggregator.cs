using Microsoft.AspNetCore.Http;

namespace ApiAggregator.Core;

public interface IApiFunction
{
    string Name { get; }

    string Pattern { get; }

    IEnumerable<KeyValuePair<string, string>> Headers { get; }
}

public interface IAggregationFunction : IApiFunction
{
    Task Handler(HttpContext context);
}

public interface IApiResult
{
    string Result { get; }
}

public interface IAggResult
{
    List<IApiResult> Results { get; }

    string RawFormat();
}
