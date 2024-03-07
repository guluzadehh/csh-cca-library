namespace ConsoleCommandApp.IO;

public interface IAppOutput
{
    void Write(string data);
    void WriteAndWait(string data, bool clear = true);
    void WriteAt(string data, int x, int y);
    void Wait(bool clear = true);
    void Clear();
}
