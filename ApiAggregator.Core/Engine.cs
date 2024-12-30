namespace ApiAggregator.Core;

public class Engine
{
    internal static async Task<IList<IApiResult>> Run(IEnumerable<IApiFunction> functions, IApiMemoryCache cache, CancellationToken ct)
    {
        //TODO handle exceptions
        List<Task<IApiResult>> tasks = [];
        foreach (var func in functions)
        {
            if (cache.Check(func.Pattern, out string? result) && result != null)
                tasks.Add(ApiResultGeneric.CreateFrom(func, result));
            else
                tasks.Add(ApiResultGeneric.CreateFrom(func));
        }
        Task.WaitAll([.. tasks], ct);

        foreach (var task in tasks)
            cache.Set(task.Result.Function.Pattern, task.Result.Result.Result);

        return await Task.FromResult(tasks.Select(t => t.Result).ToList());
    }
}
