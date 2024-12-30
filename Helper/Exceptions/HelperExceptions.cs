namespace Helper.Exceptions;

public class RetrieveUriInfoException : Exception
{
    public RetrieveUriInfoException(string message, Exception inner) : base(message, inner) { }

    public RetrieveUriInfoException(string message) : base(message) { }
}
