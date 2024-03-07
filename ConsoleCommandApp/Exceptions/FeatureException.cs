namespace ConsoleCommandApp.Exceptions;

public class FeatureException : Exception
{
    public FeatureException(string? message) : base(message)
    {
    }

    public FeatureException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}