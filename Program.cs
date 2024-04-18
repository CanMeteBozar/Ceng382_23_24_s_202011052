using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

class Program
{
    static void Main(String[]args)
    {
        
        string jsonString = File.ReadAllText("Data.json");
        
        var roomData = JsonSerializer.Deserialize<RoomData>(
                                jsonString, 
                                new JsonSerializerOptions()
        {
                NumberHandling = JsonNumberHandling.AllowReadingFromString | 
                JsonNumberHandling.WriteAsString
        });
    }
}