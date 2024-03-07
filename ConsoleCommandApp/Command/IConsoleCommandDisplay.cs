using ConsoleCommandApp.IO;

namespace ConsoleCommandApp.Command;

public interface IConsoleCommandDisplay
{
    IAppOutput Output { get; set; }
    void ListCommands(IEnumerable<IConsoleCommand> commands);
    void DisplayCommand(IConsoleCommand commands);
}
