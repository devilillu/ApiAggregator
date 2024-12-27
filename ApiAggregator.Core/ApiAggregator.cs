namespace ApiAggregator.Core;

public interface IExternalApi
{
    IList<IApiFunction> Functions { get; }
}

public interface IApiFunction
{
    string Name { get; }

    string Pattern { get; }
}

public interface IAggregationFunction
{
    string Name { get; }

    IList<IApiFunction> Functions { get; }

    Task<IList<Task<IApiResult>>> ToTasks();
}

public interface IInternalApi
{
    IList<IAggregationFunction> AggFunctions { get; }
}

public interface IApiResult
{

}
