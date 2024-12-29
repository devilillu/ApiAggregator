using Helper;
using Microsoft.AspNetCore.Http;

namespace ApiAggregator.Core;

public abstract class AggregateFunctionBase : IAggregationFunction
{
    public abstract string Name { get; }

    public abstract string Pattern { get; }

    public async Task Handler(HttpContext context)
    {
        var cs = new CancellationTokenSource();
        var result = await AggApiResultGeneric.CreateFrom(CreateFunctionList(context), cs.Token);
        await context.WriteToBodyAsync(result.RawFormat());
    }

    protected abstract IList<IApiFunction> CreateFunctionList(HttpContext context);
}
