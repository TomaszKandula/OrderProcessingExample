namespace OrderProcessing.Infrastructure.Services.Abstractions;

public interface ILoggerService
{
    /// <summary>
    /// Prints an information message.
    /// </summary>
    /// <remarks>
    /// Uses white colour.
    /// </remarks>
    /// <param name="message">Message to be printed.</param>
    public void LogInfo(string message);

    /// <summary>
    /// Prints an error message.
    /// </summary>
    /// <remarks>
    /// Uses red colour.
    /// </remarks>
    /// <param name="message">Message to be printed.</param>
    /// <param name="exception">Received exception.</param>
    public void LogError(string message, Exception exception);
}