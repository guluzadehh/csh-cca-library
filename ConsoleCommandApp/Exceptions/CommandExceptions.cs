namespace ConsoleCommandApp.Exceptions;

public class CommandExistsException(string message) : Exception
{
    public override string Message { get; } = $"Command `{message}` already exists.";
}

public class CommandNotFoundException(string message) : Exception
{
    public override string Message { get; } = $"Command `{message}` doesn't exist.";
}

public class InvalidCommandValueException : Exception
{
    public InvalidCommandValueException(string? message) : base(message)
    {
    }
}