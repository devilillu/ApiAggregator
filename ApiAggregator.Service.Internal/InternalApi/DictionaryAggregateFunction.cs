using ApiAggregator.Core;
using ApiAggregator.ExternalApis.Dictionary;
using Helper;

namespace ApiAggregator.Service.Internal.InternalApi;

public class DictionaryAggregateFunction : AggregateFunctionBase
{
    public DictionaryAggregateFunction(IStatistics statistics, IApiMemoryCache apiCache)
        : base(statistics, apiCache)
    { }

    public override string Name => "just dictionary";

    public override string Pattern => "/api/d/{KEYWORD}";

    protected override IList<IApiFunction> CreateFunctionList(HttpContext context)
    {
        var keyword = context.RetrieveFromUri("KEYWORD");

        return
            [
                new DictionaryFunctionA(keyword)
            ];
    }
}
