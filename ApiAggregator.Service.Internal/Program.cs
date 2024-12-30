using ApiAggregator.Core;
using ApiAggregator.Service.Internal.Caching;
using ApiAggregator.Service.Internal.InternalApi;
using ApiAggregator.Service.Internal.Measurements;
using Helper;

namespace ApiAggregator.Service.Internal;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        IStatistics statistics = new Statistics();
        IApiMemoryCache apiCache = new ApiMemoryCache(
            TimeSpan.FromSeconds(builder.Configuration?.GetValue<double>("CacheExpirationPeriod") ?? 60));

        app.MapGet("/", (HttpContext context) => context.WriteToBodyAsync("Aggregator"));
        foreach (var apiMethod in BuildAggregatedApi(builder.Configuration, statistics, apiCache))
            app.MapGet(apiMethod.Pattern, apiMethod.Handler);

        app.MapGet("/stats/all", (HttpContext context) => context.WriteToBodyAsync(statistics.ToRaw()));
        app.MapGet("/stats/total", (HttpContext context) => context.WriteToBodyAsync(statistics.TotalCalls()));
        app.MapGet("/stats/averaged", (HttpContext context) => context.WriteToBodyAsync(statistics.ToAveraged()));
        app.MapGet("/stats/total_avg", (HttpContext context) => context.WriteToBodyAsync(statistics.ToTotalAndAvg()));

        app.Run();
    }

    static IList<IAggregationFunction> BuildAggregatedApi(ConfigurationManager? config,
        IStatistics statistics, IApiMemoryCache apiCache)
    {
        var aggFunctions = new List<IAggregationFunction>
        {
            new NewsWeatherAggregateFunction(
                config?.GetValue<string>("WeatherAPI") ?? string.Empty,
                config?.GetValue<string>("NewsAPI") ?? string.Empty,
                statistics, apiCache),
        };

        return aggFunctions;
    }
}
