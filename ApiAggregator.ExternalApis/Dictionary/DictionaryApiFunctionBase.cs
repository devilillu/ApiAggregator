using ApiAggregator.ExternalApis.Core;

namespace ApiAggregator.ExternalApis.Dictionary;

public abstract class DictionaryApiFunctionBase : ExternalApiFunctionBase
{
    protected DictionaryApiFunctionBase() : base(string.Empty) { }

    protected override string BasePath => @"https://api.dictionaryapi.dev";
}