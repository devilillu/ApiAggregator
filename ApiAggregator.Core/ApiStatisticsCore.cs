namespace ApiAggregator.Core;

public interface IStatistics
{
    IReadOnlyDictionary<string, IApiStatistics> Stats { get; }

    void Update(string id, TimeSpan runtime);
}

public interface IApiStatistics
{
    IReadOnlyCollection<TimeSpan> History { get; }

    IApiStatistics Add(TimeSpan timeSpan);
}

public enum HowFast
{
    Ultra,
    Fast,
    Medium,
    Slow,
    Turtle
}

