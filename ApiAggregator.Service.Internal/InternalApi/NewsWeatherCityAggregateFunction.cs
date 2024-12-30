using ApiAggregator.Core;
using ApiAggregator.ExternalApis.Dictionary;
using ApiAggregator.ExternalApis.News;
using ApiAggregator.ExternalApis.Weather;
using Helper;

namespace ApiAggregator.Service.Internal.InternalApi;

public class NewsWeatherCityAggregateFunction : AggregateFunctionBase
{
    public NewsWeatherCityAggregateFunction(string weatherAPI, string newsAPI,
        IStatistics statistics, IApiMemoryCache apiCache)
        : base(statistics, apiCache)
    {
        _weatherAPI = weatherAPI;
        _newsAPI = newsAPI;
    }

    public override string Name => "News - Weather city - Dictionary";

    public override string Pattern => "/api/nwc/{DATE}/{CITY}/{KEYWORD}";

    protected override IList<IApiFunction> CreateFunctionList(HttpContext context)
    {
        var date = context.RetrieveFromUri("DATE");
        var city = context.RetrieveFromUri("CITY");
        var keyword = context.RetrieveFromUri("KEYWORD");

        return
            [
                new WeatherApiFunctionB(city, _weatherAPI),
                new NewsApiFunctionA(date, keyword, _newsAPI),
                new DictionaryFunctionA(keyword)
            ];
    }

    readonly string _weatherAPI;

    readonly string _newsAPI;
}
