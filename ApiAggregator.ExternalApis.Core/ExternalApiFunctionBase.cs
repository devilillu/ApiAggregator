using ApiAggregator.Core;

namespace ApiAggregator.ExternalApis.Core;

public abstract class ExternalApiFunctionBase : IApiFunction
{
    protected ExternalApiFunctionBase(string apiKey)
    {
        APIKey = apiKey;
    }

    public IEnumerable<KeyValuePair<string, string>> Headers => _headers;

    public string Pattern => BasePath + PatternPart;

    protected string APIKey { get; init; }

    public abstract string Name { get; }

    protected abstract string BasePath { get; }

    protected abstract string PatternPart { get; }

    protected readonly List<KeyValuePair<string, string>> _headers = [];
}
