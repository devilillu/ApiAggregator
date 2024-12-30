using ApiAggregator.Core;
using ApiAggregator.ExternalApis.Dictionary;
using ApiAggregator.ExternalApis.News;
using ApiAggregator.ExternalApis.Weather;
using Helper;

namespace ApiAggregator.Service.Internal.InternalApi;

public class NewsWeatherDictAggregateFunction : AggregateFunctionBase
{
    public NewsWeatherDictAggregateFunction(string weatherAPI, string newsAPI,
        IStatistics statistics, IApiMemoryCache apiCache)
        : base(statistics, apiCache)
    {
        _weatherAPI = weatherAPI;
        _newsAPI = newsAPI;
    }

    public override string Name => "News - Weather - Dictionary";

    public override string Pattern => "/api/nwd/{DATE}/{LON}/{LAT}/{KEYWORD}";

    protected override IList<IApiFunction> CreateFunctionList(HttpContext context)
    {
        var date = context.RetrieveFromUri("DATE");
        var longtitude = context.RetrieveFromUri("LON");
        var latitude = context.RetrieveFromUri("LAT");
        var keyword = context.RetrieveFromUri("KEYWORD");

        return
            [
                new WeatherApiFunctionA(latitude, longtitude, _weatherAPI),
                new NewsApiFunctionA(date, keyword, _newsAPI),
                new DictionaryFunctionA(keyword)
            ];
    }

    readonly string _weatherAPI;

    readonly string _newsAPI;
}
