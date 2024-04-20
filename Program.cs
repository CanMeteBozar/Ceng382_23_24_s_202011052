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

        Console.Write("\nUser 1: \n");
        Reservation User1 = new Reservation();
        User1.reserverName = "Can Mete Bozar";
        User1.room = new Room{roomId = "011", roomName = "A-111", capacity = 20};
        User1.date = new DateTime(2024,04,13,15,0,0);
        if(CheckReservationInfo.CheckResInfo(User1, roomData)){
            Console.WriteLine($"Reservername = {User1.reserverName} RoomName = {User1.room.roomName}");
            LogRecord logrecord = new LogRecord(User1.reserverName, User1.room.roomName);
            ILogger logger = new FileLogger();
            LogHandler logHandler = new LogHandler(logger);
            logHandler.AddLog(logrecord, "LogData.json");
        }
    }
    
}