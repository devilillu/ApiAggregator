using ApiAggregator.Core;
using System.Text;

namespace ApiAggregator.Service.Internal.Measurements;

public static class MoreStatistics
{
    public static string ToRaw(this IStatistics statistics)
    {
        StringBuilder sb = new();

        foreach (var item in statistics.Stats)
        {
            sb.AppendLine().Append(item.Key).AppendLine(" : ");
            foreach (var entry in item.Value.History)
                sb.Append(entry.Milliseconds).AppendLine("ms");
        }

        return sb.ToString();
    }

    public static string TotalCalls(this IStatistics statistics)
    {
        StringBuilder sb = new();

        foreach (var item in statistics.Stats)
            sb.AppendLine()
                .Append(item.Key).AppendLine(" : ")
                .Append(item.Value.History.Count).AppendLine(" time(s)");

        return sb.ToString();
    }

    public static string ToAveraged(this IStatistics statistics)
    {
        StringBuilder sb = new();

        foreach (var item in statistics.Stats)
            sb.AppendLine().Append(item.Key).Append(" : ").Append("avg time: ")
                .AppendLine(item.Value.History.Average(a => a.Milliseconds).ToString("F2"));

        return sb.ToString();
    }

    public static string ToTotalAndAvg(this IStatistics statistics)
    {
        StringBuilder sb = new();

        foreach (var item in statistics.Stats)
        {
            sb.AppendLine()
                .Append(item.Key).Append(" : ")
                .Append(item.Value.History.Count).AppendLine(" time(s)");

            foreach (var group in item.Value.History.GroupBy(entry => entry.Categorize()))
                sb.Append(group.Key).Append(' ').Append(group.Count()).AppendLine(" time(s)");
        }

        return sb.ToString();
    }

    static HowFast Categorize(this TimeSpan span) =>
        span.Milliseconds switch
        {
            < 100 => HowFast.Ultra,
            < 200 => HowFast.Fast,
            < 350 => HowFast.Medium,
            < 700 => HowFast.Slow,
            _ => HowFast.Turtle
        };
}
