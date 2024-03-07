using ConsoleCommandApp.App;

namespace ConsoleCommandApp.Feature;

public abstract class BaseFeature : IFeature
{
    private IApp? _app;
    public IApp App
    {
        get
        {
            if (_app == null) throw new NullReferenceException("App instance of Feature is null");
            return _app;
        }
        set
        {
            _app = value;
        }
    }

    public abstract void Run();

}
