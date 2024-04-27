using System.Text.Json;
using System.Text.Json.Serialization;

public class RoomHandler{

    private string _filePath;

    public RoomHandler(){_filePath = "Data.json";}

    public RoomData GetRooms(){
        string jsonString = File.ReadAllText(_filePath);
        
        var roomData = JsonSerializer.Deserialize<RoomData>(
                                jsonString, 
                                new JsonSerializerOptions()
        {
                NumberHandling = JsonNumberHandling.AllowReadingFromString | 
                JsonNumberHandling.WriteAsString
        });

        return roomData;
    }

}