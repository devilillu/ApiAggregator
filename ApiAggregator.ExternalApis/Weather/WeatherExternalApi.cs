namespace ApiAggregator.ExternalApis.Weather;

public class WeatherApiFunctionA : WeatherApiFunctionBase
{
    public WeatherApiFunctionA(string latitude, string longitude, string APIKey) : base(APIKey)
    {
        Longitude = longitude;
        Latitude = latitude;
    }

    public override string Name => "lat - lon - appid";

    public string Latitude { get; init; }

    public string Longitude { get; init; }

    protected override string PatternPart => @"/data/2.5/weather?lat=" + Latitude + "&lon=" + Longitude + "&appid=" + APIKey;
}
