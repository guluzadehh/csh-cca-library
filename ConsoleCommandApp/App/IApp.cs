using ConsoleCommandApp.Command;
using ConsoleCommandApp.Feature;
using ConsoleCommandApp.IO;
using ConsoleCommandApp.Router;
using Microsoft.Extensions.Configuration;

namespace ConsoleCommandApp.App;

public interface IApp
{
    bool IsRunning { get; set; }
    IConfiguration Config { get; }
    HashSet<IConsoleCommand> Commands { get; }
    IRouter Router { get; }
    IAppOutput Output { get; }
    IAppInput Input { get; }

    IApp Route(IConsoleCommand command, IFeature feature);
    void Start();
}
