namespace ApiAggregator.ExternalApis.Dictionary;

public class DictionaryFunctionA : DictionaryApiFunctionBase
{
    public DictionaryFunctionA(string keyword)
    {
        Keyword = keyword;
    }

    public override string Name => "keyword";

    public string Keyword { get; init; }

    protected override string PatternPart => @"/api/v2/entries/en/" + Keyword;
}
