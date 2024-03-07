namespace ConsoleCommandApp.Command;

public interface IConsoleCommand
{
    string Value { get; set; }
    string? Description { get; set; }
}
