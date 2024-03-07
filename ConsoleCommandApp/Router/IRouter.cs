using ConsoleCommandApp.Feature;

namespace ConsoleCommandApp.Router;

public interface IRouter
{
    void Register(string commandValue, IFeature feature);
    void Dispatch(string commandValue);
}
