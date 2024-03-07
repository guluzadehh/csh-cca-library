
using ConsoleCommandApp.IO;

namespace ConsoleCommandApp.Command;

public class BaseConsoleCommandDisplay : IConsoleCommandDisplay
{
    public IAppOutput Output { get; set; }

    public BaseConsoleCommandDisplay(IAppOutput output)
    {
        Output = output;
    }

    public void DisplayCommand(IConsoleCommand command)
    {
        Output.Write($"{command.Value} - {command.Description}\n");
    }

    public void ListCommands(IEnumerable<IConsoleCommand> commands)
    {
        foreach (var command in commands)
        {
            DisplayCommand(command);
        }

        Output.Write("\n");
    }
}
