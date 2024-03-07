namespace ConsoleCommandApp.Exceptions;

public class InputFormatException : Exception
{
    public InputFormatException(string? message) : base(message)
    {
    }

    public InputFormatException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

public class InputCancelException : Exception
{

}
