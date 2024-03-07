namespace ConsoleCommandApp.IO;

public interface IReadResult
{
    string Value { get; }
    bool IsValid { get; }

    bool HasException { get; }
    Exception? Exception { get; }

    bool IsCancelled { get; }
}
