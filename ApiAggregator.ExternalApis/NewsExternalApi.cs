using ApiAggregator.Core;
using ApiAggregator.ExternalApis.Core;

namespace ApiAggregator.ExternalApis;

public abstract class NewsApiFunctionBase : ExternalApiFunctionBase
{
    protected NewsApiFunctionBase(string apiKey) : base(apiKey) { }

    protected override string BasePath => @"https://newsapi.org";
}

public class NewsApiFunctionA : NewsApiFunctionBase
{
    public NewsApiFunctionA(DateTime date, string keyword, string APIKey) : base(APIKey)
    {
        Date = date;
        Keyword = keyword;
    }

    public override string Name => "keyword - from date";

    public DateTime Date { get; init; }
    
    public string Keyword { get; init; }

    protected override string PatternPart => @"/v2/everything?q=" + Keyword + @"&from=" + Date.ToString("yyyy-MM-dd") + @"&sortBy=publishedAt&apiKey=" + APIKey;
}
