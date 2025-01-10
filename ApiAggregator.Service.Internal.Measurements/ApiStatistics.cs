using ApiAggregator.Core;
using System.Collections.Concurrent;

namespace ApiAggregator.Service.Internal.Measurements;

public class ApiStatistics : IApiStatistics
{
    public ApiStatistics(string id)
    {
        Id = id;
    }

    public readonly string Id;

    public IReadOnlyCollection<TimeSpan> History => [.. _history];

    public IApiStatistics Add(TimeSpan timeSpan)
    {
        _history.Add(timeSpan);
        return this;
    }

    readonly ConcurrentBag<TimeSpan> _history = [];
}
