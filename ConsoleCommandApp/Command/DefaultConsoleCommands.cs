using System.Diagnostics.CodeAnalysis;

namespace ConsoleCommandApp.Command;

public class QuitCommand : BaseConsoleCommand
{
    [SetsRequiredMembers]
    public QuitCommand()
    {
        Value = "q!";
        Description = "Quit the app";
    }
}
