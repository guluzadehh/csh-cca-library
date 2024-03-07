namespace ConsoleCommandApp.IO;

public interface IAppInput
{
    string Read(Func<string?, bool>? validate = null, bool quittable = true, bool omitDefaultValidation = false);
    string ReadClear(Func<string?, bool>? validate = null, bool quittable = true, bool omitDefaultValidation = false);

    ReadResult TryRead(Func<string?, bool>? validate = null, bool quittable = true, bool omitDefaultValidation = false);
    ReadResult TryReadClear(Func<string?, bool>? validate = null, bool quittable = true, bool omitDefaultValidation = false);
}
