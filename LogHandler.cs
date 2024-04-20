public class LogHandler{
    private ILogger _logger;

    public LogHandler(ILogger logger){
        _logger = logger;
    }

    public void AddLog(LogRecord log ,string filePath){
        _logger.Log(log, filePath);
    }
}