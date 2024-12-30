using Helper;
using Microsoft.AspNetCore.Http;

namespace ApiAggregator.Core;

public abstract class AggregateFunctionBase : IAggregationFunction
{
    public AggregateFunctionBase(IStatistics statistics, IApiMemoryCache apiCache)
    {
        _statistics = statistics;
        _apiCache = apiCache;
    }

    public abstract string Name { get; }

    public abstract string Pattern { get; }

    public string ApiName => "Internal aggregate";

    public IEnumerable<KeyValuePair<string, string>> Headers => _headers;

    public async Task Handler(HttpContext context)
    {
        var cs = new CancellationTokenSource();
        var aggResult = await ApiAggResultGeneric.CreateFrom(CreateFunctionList(context), _apiCache, cs.Token);
        foreach (var apiResult in aggResult.Results)
            _statistics.Update(apiResult.Function.ApiName, apiResult.Result.Ellapsed);
        await context.WriteToBodyAsync(aggResult.RawFormat());
    }

    protected abstract IList<IApiFunction> CreateFunctionList(HttpContext context);

    protected readonly List<KeyValuePair<string, string>> _headers = [];

    readonly IStatistics _statistics;

    readonly IApiMemoryCache _apiCache;
}
