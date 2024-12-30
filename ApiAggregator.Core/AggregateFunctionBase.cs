using Helper;
using Microsoft.AspNetCore.Http;

namespace ApiAggregator.Core;

public abstract class AggregateFunctionBase : IAggregationFunction
{
    public abstract string Name { get; }
    public abstract string Pattern { get; }

    public IEnumerable<KeyValuePair<string, string>> Headers => _headers;

    public async Task Handler(HttpContext context)
    {
        var cs = new CancellationTokenSource();
        var result = await ApiAggResultGeneric.CreateFrom(CreateFunctionList(context), cs.Token);
        await context.WriteToBodyAsync(result.RawFormat());
    }

    protected abstract IList<IApiFunction> CreateFunctionList(HttpContext context);

    protected readonly List<KeyValuePair<string, string>> _headers = [];
}
