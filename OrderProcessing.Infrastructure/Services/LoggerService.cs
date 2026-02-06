using OrderProcessing.Infrastructure.Services.Abstractions;

namespace OrderProcessing.Infrastructure.Services;

public class LoggerService : ILoggerService
{
    private const string LogInfoTemplate = "[{0}]: {1}";

    private const string LogErrorTemplate = "[{0}]: {1} {2}";

    private static DateTime Now => DateTime.UtcNow;

    /// <inheritdoc/>
    public void LogInfo(string message)
    {
        var info = string.Format(LogInfoTemplate, Now, message);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(info);
    }

    /// <inheritdoc/>
    public void LogError(string message, Exception exception)
    {
        var error = string.Format(LogErrorTemplate, Now,  message, exception.Message);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(error);
    }
}