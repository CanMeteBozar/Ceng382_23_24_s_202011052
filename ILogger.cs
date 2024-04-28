// This class is interface for FileLogger.cs
using System.ComponentModel;

public interface ILogger{
    public void Log(LogRecord log, string filePath, string message);
}