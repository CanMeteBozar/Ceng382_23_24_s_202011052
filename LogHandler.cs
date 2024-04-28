// This class has a single method for ILogger class.
using System.ComponentModel;

public class LogHandler{
    private ILogger _logger;

    public LogHandler(ILogger logger){
        _logger = logger;
    }

    public void AddLog(LogRecord log ,string filePath, string message){     // Goes to ILogger's Log method.
        _logger.Log(log, filePath, message);
    }
}