namespace ConsoleCommandApp.Feature;

public class QuitFeature : BaseFeature
{
    public override void Run()
    {
        App.IsRunning = false;
    }
}
