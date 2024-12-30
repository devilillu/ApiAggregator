namespace ApiAggregator.ExternalApis.News;

public class NewsApiFunctionA : NewsApiFunctionBase
{
    public NewsApiFunctionA(string date, string keyword, string APIKey) : base(APIKey)
    {
        Date = date;
        Keyword = keyword;
    }

    public override string Name => "keyword - from date";

    public string Date { get; init; }
    
    public string Keyword { get; init; }

    protected override string PatternPart => @"/v2/everything?q=" + Keyword + @"&from=" + Date + @"&sortBy=publishedAt&apiKey=" + APIKey;
}
