namespace ApiAggregator.Core;

internal class Engine
{
    public static async Task<IList<IApiResult>> Run(IAggregationFunction aggFunction, CancellationToken ct)
    {
        var callTasks = await aggFunction.ToTasks();
        Task.WaitAll([.. callTasks], ct);
        return callTasks.Select(t => t.Result).ToList();
    }
}
