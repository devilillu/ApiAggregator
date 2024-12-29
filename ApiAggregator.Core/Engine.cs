namespace ApiAggregator.Core;

public class Engine
{
    internal static async Task<IList<IApiResult>> Run(IEnumerable<IApiFunction> functions, CancellationToken ct)
    {
        var callTasks = ToTasks(functions);
        Task.WaitAll([.. callTasks], ct);
        return await Task.FromResult(callTasks.Select(t => t.Result).ToList());
    }

    static IList<Task<IApiResult>> ToTasks(IEnumerable<IApiFunction> functions)
    {
        List<Task<IApiResult>> tasks = [];
        foreach (var func in functions)
            tasks.Add(ApiResultGeneric.CreateFrom(func.Pattern));
        return tasks;
    }
}
