namespace test.Exceptions;

public class BadArgumentsException : Exception
{
    public BadArgumentsException(string message) : base(message)
    {
    }
}