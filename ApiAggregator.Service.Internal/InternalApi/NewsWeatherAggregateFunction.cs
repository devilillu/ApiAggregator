using ApiAggregator.Core;
using ApiAggregator.ExternalApis;
using Helper;

namespace ApiAggregator.Service.Internal.InternalApi;

public class NewsWeatherAggregateFunction : AggregateFunctionBase
{
    public NewsWeatherAggregateFunction(string weatherAPI, string newsAPI)
    {
        _weatherAPI = weatherAPI;
        _newsAPI = newsAPI;
    }

    public override string Name => "News - Weather";

    public override string Pattern => "/api/nw/{DATE}/{LON}/{LAT}/{KEYWORD}";

    protected override IList<IApiFunction> CreateFunctionList(HttpContext context)
    {
        var date = Convert.ToDateTime(context.RetrieveFromUri("DATE"));
        var longtitude = context.RetrieveFromUri("LON");
        var latitude = context.RetrieveFromUri("LAT");
        var keyword = context.RetrieveFromUri("KEYWORD");

        return new List<IApiFunction>()
            {
                new WeatherApiFunctionA(latitude, longtitude, _weatherAPI),
                new NewsApiFunctionA(date, keyword, _newsAPI)
            };
    }

    readonly string _weatherAPI;

    readonly string _newsAPI;
}
