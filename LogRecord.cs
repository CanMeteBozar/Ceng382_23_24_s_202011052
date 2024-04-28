// This class contains a record definiton for reserver information.
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

public class LogRecord{
    public DateTime Timestamp{get; set;}

    public string ReserverName{get; set;}

    public string RoomName{get; set;}

    public LogRecord(string reserverName, string roomName){
        Timestamp = DateTime.Now;
        ReserverName = reserverName;
        RoomName = roomName;
    }

}