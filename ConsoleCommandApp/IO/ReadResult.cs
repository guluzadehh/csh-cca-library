
namespace ConsoleCommandApp.IO;

public enum ReadStatus
{
    IsValid,
    HasException,
    IsCancelled
}

public class ReadResult : IReadResult
{
    public string Value { get; } = string.Empty;
    public ReadStatus Status { get; }
    public Exception? Exception { get; }

    public bool HasException { get { return Status == ReadStatus.HasException; } }
    public bool IsValid { get { return Status == ReadStatus.IsValid; } }
    public bool IsCancelled { get { return Status == ReadStatus.IsCancelled; } }

    public ReadResult(string value, ReadStatus status)
    {
        Value = value;
        Status = status;
    }

    public ReadResult(Exception exc)
    {
        Exception = exc;
        Status = ReadStatus.HasException;
    }
}
