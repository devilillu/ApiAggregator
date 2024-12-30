using ApiAggregator.Core.Exceptions;
using Helper;
using System.Text;

namespace ApiAggregator.Core;

public class ApiResultGeneric : IApiResult
{
    public static async Task<IApiResult> CreateFrom(string uri, IEnumerable<KeyValuePair<string, string>> headers) =>
        new ApiResultGeneric(await HttpClientHelper.SendAsync(uri, headers));

    public ApiResultGeneric(string message)
    {
        Result = message;
    }

    public string Result { get; }
}

public class ApiAggResultGeneric : IAggResult
{
    public static async Task<IAggResult> CreateFrom(IEnumerable<IApiFunction> functions, CancellationToken ct) =>
        new ApiAggResultGeneric(await Engine.Run(functions, ct));

    public ApiAggResultGeneric(IList<IApiResult> results)
    {
        Results = [.. results];
    }

    public List<IApiResult> Results { get; }

    public string RawFormat()
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            foreach (var result in Results)
            {
                sb.Append(result.Result);
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
        catch (ArgumentOutOfRangeException ex)
        {
            throw new FormatingResultsException("Exception formatting result data", ex);
        }
    }
}
