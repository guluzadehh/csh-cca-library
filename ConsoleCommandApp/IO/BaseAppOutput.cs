namespace ConsoleCommandApp.IO;

public class BaseAppOutput : IAppOutput
{
    public string WaitText { get; } = "Press enter to continue...";

    public void Write(string data)
    {
        Console.Write(data);
    }

    public void WriteAndWait(string data, bool clear = true)
    {
        Write(data);
        Wait(clear);
    }

    public void Wait(bool clear = true)
    {
        Write(WaitText);
        Console.ReadLine();
        if (clear)
        {
            Clear();
        }
    }

    public void WriteAt(string data, int x, int y)
    {
        if (x < 0 || y < 0) return;
        Console.SetCursorPosition(x, y);
        Write(data);
    }

    public void Clear()
    {
        Console.Clear();
    }
}
