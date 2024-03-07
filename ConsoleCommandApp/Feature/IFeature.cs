using ConsoleCommandApp.App;

namespace ConsoleCommandApp.Feature;

public interface IFeature
{
    IApp App { get; set; }
    void Run();
}
