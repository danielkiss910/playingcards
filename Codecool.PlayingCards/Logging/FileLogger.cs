namespace Codecool.PlayingCards.Logging;

public class FileLogger : ILogger
{
    private readonly string _logFile;

    public FileLogger(string logFile)
    {
        _logFile = logFile;
    }
    
    public void LogInfo(string message)
    {
        LogMessage(message, "INFO");
    }

    public void LogError(string message)
    {
        LogMessage(message, "ERROR");
    }

    private void LogMessage(string message, string type)
    {
        var entry = $"[{DateTime.Now}] {type}: {message}";
        using var streamWriter = File.AppendText(_logFile);
        streamWriter.WriteLine(entry);
    }
}