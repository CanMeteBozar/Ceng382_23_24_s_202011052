using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;
using System.IO;
using Newtonsoft.Json;

public class FileLogger : ILogger{

    public void Log(LogRecord log, string filePath) {
            string logJson = JsonConvert.SerializeObject(log);
            File.AppendAllText(filePath, logJson + Environment.NewLine);
    }
}