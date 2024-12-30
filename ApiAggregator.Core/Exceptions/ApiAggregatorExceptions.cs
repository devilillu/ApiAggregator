namespace ApiAggregator.Core.Exceptions;

public class FormatingResultsException(string message, Exception inner) : Exception(message, inner) { }
