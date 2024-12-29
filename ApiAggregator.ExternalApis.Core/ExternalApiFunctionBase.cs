using ApiAggregator.Core;

namespace ApiAggregator.ExternalApis.Core;

public abstract class ExternalApiFunctionBase : IApiFunction
{
    protected ExternalApiFunctionBase(string apiKey)
    {
        APIKey = apiKey;
    }

    protected string APIKey { get; init; }

    public abstract string Name { get; }

    public string Pattern => BasePath + PatternPart;

    protected abstract string BasePath { get; }

    protected abstract string PatternPart { get; }
}
