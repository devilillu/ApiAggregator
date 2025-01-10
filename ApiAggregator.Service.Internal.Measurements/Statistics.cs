using ApiAggregator.Core;

namespace ApiAggregator.Service.Internal.Measurements;

public class Statistics : IStatistics
{
    public void Update(string id, TimeSpan runtime)
    {
        if (_stats.TryGetValue(id, out var apiStatistics))
            apiStatistics.Add(runtime);
        else
            _stats.Add(id, new ApiStatistics(id).Add(runtime));
    }

    public IReadOnlyDictionary<string, IApiStatistics> Stats => _stats.ToDictionary();
    readonly Dictionary<string, IApiStatistics> _stats = [];
}
