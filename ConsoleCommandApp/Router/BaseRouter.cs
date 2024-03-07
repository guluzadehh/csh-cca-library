using ConsoleCommandApp.Exceptions;
using ConsoleCommandApp.Feature;
using ConsoleCommandApp.Router;

namespace ConsoleCommandApp;

public class BaseRouter : IRouter
{
    private readonly Dictionary<string, IFeature> _routes = [];

    public void Dispatch(string commandValue)
    {
        IFeature feature = FindFeature(commandValue);
        feature.Run();
    }

    protected IFeature FindFeature(string commandValue)
    {
        return _routes.GetValueOrDefault(commandValue) ?? throw new CommandNotFoundException(commandValue);
    }

    public void Register(string commandValue, IFeature feature)
    {
        if (_routes.ContainsKey(commandValue))
        {
            throw new CommandExistsException($"Command with {commandValue} already exists");
        }

        _routes.Add(commandValue, feature);
    }
}
