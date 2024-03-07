using ConsoleCommandApp.Command;
using ConsoleCommandApp.Exceptions;
using ConsoleCommandApp.Feature;
using ConsoleCommandApp.IO;
using ConsoleCommandApp.Router;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleCommandApp.App;

public class BaseApp : IApp
{
    public IConfiguration Config { get; }
    public HashSet<IConsoleCommand> Commands { get; } = [];
    public IRouter Router { get; }
    public IAppOutput Output { get; }
    public IAppInput Input { get; }
    public bool IsRunning { get; set; }

    public IConsoleCommandDisplay CommandDisplay { get; set; }

    public BaseApp(
        IConfiguration config,
        IRouter router,
        IAppOutput output,
        IAppInput input,
        IConsoleCommandDisplay commandDisplay
    )
    {
        Config = config;
        Router = router;
        Output = output;
        Input = input;
        CommandDisplay = commandDisplay;
        IsRunning = true;
    }

    public IApp Route(IConsoleCommand command, IFeature feature)
    {
        Commands.Add(command);

        feature.App = this;
        Router.Register(command.Value, feature);

        return this;
    }

    public static HostApplicationBuilder CreateDefaultBuilder()
    {
        var hostBuilder = Host.CreateApplicationBuilder();
        hostBuilder.Services.AddSingleton<IRouter, BaseRouter>();
        hostBuilder.Services.AddSingleton<IAppOutput, BaseAppOutput>();
        hostBuilder.Services.AddSingleton<IAppInput, BaseAppInput>();
        hostBuilder.Services.AddSingleton<IConsoleCommandDisplay, BaseConsoleCommandDisplay>();
        hostBuilder.Services.AddSingleton<IApp, BaseApp>(
            serviceProvider =>
            {
                var app = ActivatorUtilities.CreateInstance<BaseApp>(serviceProvider);
                app.Route(new QuitCommand(), new QuitFeature());
                return app;
            }
        );
        return hostBuilder;
    }

    public void Start()
    {
        while (IsRunning)
        {
            Output.Clear();

            CommandDisplay.ListCommands(Commands);

            var result = Input.TryReadClear(quittable: false);

            if (!result.IsValid)
            {
                continue;
            }

            try
            {
                Router.Dispatch(result.Value);
            }
            catch (CommandNotFoundException exc)
            {
                Output.WriteAndWait($"{exc.Message}\n");
            }
            catch (FeatureException exc)
            {
                Output.WriteAndWait($"Error: {exc.Message}\n");
            }
            catch (InputFormatException exc)
            {
                Output.WriteAndWait($"{exc.Message}\n");
            }
            catch (InputCancelException) { }
        }
    }
}
