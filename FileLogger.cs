// this class takes a log for that acton and update LogData.json.
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;
using System.IO;
using Newtonsoft.Json;

public class FileLogger : ILogger{

    public void Log(LogRecord log, string filePath, string message) {
            string logJson = JsonConvert.SerializeObject(log, Formatting.Indented);   
            File.AppendAllText(filePath, logJson + message + Environment.NewLine);
    }
}