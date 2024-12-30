using ApiAggregator.ExternalApis.Core;

namespace ApiAggregator.ExternalApis.News;

public abstract class NewsApiFunctionBase : ExternalApiFunctionBase
{
    protected NewsApiFunctionBase(string apiKey) : base(apiKey) 
    {
        _headers.Add(new KeyValuePair<string, string>("user-agent", "News-API-csharp/0.1"));
    }

    protected override string BasePath => @"https://newsapi.org";
}