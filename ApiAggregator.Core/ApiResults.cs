using Helper;
using System.Text;

namespace ApiAggregator.Core;

public class ApiResultGeneric : IApiResult
{
    public static async Task<IApiResult> CreateFrom(string uri) =>
        new ApiResultGeneric(await HttpClientHelper.GetAsync(uri));

    public ApiResultGeneric(string message)
    {
        Result = message;
    }

    public string Result { get; }
}

public class AggApiResultGeneric : IAggResult
{
    public static async Task<IAggResult> CreateFrom(IEnumerable<IApiFunction> functions, CancellationToken ct) =>
        new AggApiResultGeneric(await Engine.Run(functions, ct));

    public AggApiResultGeneric(IList<IApiResult> results)
    {
        Results = [.. results];
    }

    public List<IApiResult> Results { get; }

    public string RawFormat()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var result in Results)
            sb.Append(result.Result);

        return sb.ToString();
    }
}
