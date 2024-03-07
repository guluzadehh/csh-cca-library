using ConsoleCommandApp.Exceptions;

namespace ConsoleCommandApp.Command;

public class BaseConsoleCommand : IConsoleCommand
{
    private string _value = string.Empty;

    public required string Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidCommandValueException("Wrong Command value format");
            }

            _value = value!;
        }
    }

    public string? Description { get; set; }
}