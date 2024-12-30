namespace ApiAggregator.Core;

public class Engine
{
    internal static async Task<IList<IApiResult>> Run(IEnumerable<IApiFunction> functions, CancellationToken ct)
    {
        //TODO handle exceptions
        List<Task<IApiResult>> tasks = [];
        foreach (var func in functions)
            tasks.Add(ApiResultGeneric.CreateFrom(func.Pattern, func.Headers));
        Task.WaitAll([.. tasks], ct);
        return await Task.FromResult(tasks.Select(t => t.Result).ToList());
    }
}
