using ApiAggregator.Core;
using ApiAggregator.Service.Internal.InternalApi;
using Helper;

namespace ApiAggregator.Service.Internal;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", (HttpContext context) => context.WriteToBodyAsync("Aggregator"));

        foreach (var apiMethod in BuildAggregatedApi(builder.Configuration))
            app.MapGet(apiMethod.Pattern, apiMethod.Handler);

        app.Run();
    }

    static IList<IAggregationFunction> BuildAggregatedApi(ConfigurationManager config)
    {
        var aggFunctions = new List<IAggregationFunction>
        {
            new NewsWeatherAggregateFunction(
                config?.GetValue<string>("WeatherAPI") ?? string.Empty, 
                config?.GetValue<string>("NewsAPI") ?? string.Empty)
        };

        return aggFunctions;
    }
}
