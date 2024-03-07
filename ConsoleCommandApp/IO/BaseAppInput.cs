using ConsoleCommandApp.Exceptions;

namespace ConsoleCommandApp.IO;

public class BaseAppInput : IAppInput
{
    private readonly IAppOutput _output;
    public string InfoText { get; set; } = ":";
    public string CancelCommand { get; set; } = "q!";

    public BaseAppInput(IAppOutput output)
    {
        _output = output;
    }

    public static bool DefaultValidation(string? value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    public string Read(
        Func<string?, bool>? validate = null,
        bool quittable = true,
        bool omitDefaultValidation = false)
    {
        _output.Write(InfoText + " ");

        string value = Console.ReadLine()
            ?? throw new InputFormatException("Input value can't be null");

        if (quittable && string.Equals(value, CancelCommand))
            throw new InputCancelException();

        if (!omitDefaultValidation)
            validate ??= DefaultValidation;

        if (validate != null && !validate(value))
            throw new InputFormatException($"Wrong Input value format\n\t----> `{value}`");

        return value;
    }

    public ReadResult TryRead(
        Func<string?, bool>? validate = null,
        bool quittable = true,
        bool omitDefaultValidation = false)
    {
        try
        {
            string value = Read(validate, quittable, omitDefaultValidation);
            return new ReadResult(value, ReadStatus.IsValid);
        }
        catch (InputFormatException exc)
        {
            return new ReadResult(exc);
        }
        catch (InputCancelException)
        {
            return new ReadResult(CancelCommand, ReadStatus.IsCancelled);
        }
    }

    public string ReadClear(
        Func<string?, bool>? validate = null,
        bool quittable = true,
        bool omitDefaultValidation = false)
    {
        string value = Read(validate, quittable, omitDefaultValidation);
        _output.Clear();
        return value;
    }

    public ReadResult TryReadClear(
        Func<string?, bool>? validate = null,
        bool quittable = true,
        bool omitDefaultValidation = false)
    {
        var res = TryRead(validate, quittable, omitDefaultValidation);
        _output.Clear();
        return res;
    }
}
