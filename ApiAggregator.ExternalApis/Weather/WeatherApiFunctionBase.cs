using ApiAggregator.ExternalApis.Core;

namespace ApiAggregator.ExternalApis.Weather;

public abstract class WeatherApiFunctionBase : ExternalApiFunctionBase
{
    protected WeatherApiFunctionBase(string apiKey) : base(apiKey) { }

    protected override string BasePath => @"https://api.openweathermap.org";
}
