using ApiAggregator.Core.Exceptions;
using Helper;
using System.Text;

namespace ApiAggregator.Core;

public class ApiResultGeneric : IApiResult
{
    public static async Task<IApiResult> CreateFrom(IApiFunction function) =>
        new ApiResultGeneric(await HttpClientHelper.SendAsync(function.Pattern, function.Headers), function);

    public ApiResultGeneric(HttpClientResult message, IApiFunction function)
    {
        Result = message;
        Function = function;
    }

    public HttpClientResult Result { get; }

    public IApiFunction Function { get; }
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
            foreach (var httpResult in Results)
            {
                sb.Append(httpResult.Result.Result);
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
