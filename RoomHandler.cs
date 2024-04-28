// This class takes the rooms from the data.json file in a proper format and assigns them to roomData.
using System.Text.Json;
using System.Text.Json.Serialization;

public class RoomHandler{

    private string _filePath;

    public RoomHandler(){_filePath = "Data.json";}

    public RoomData GetRooms(){
        string jsonString = File.ReadAllText(_filePath);
        
        RoomData roomData = JsonSerializer.Deserialize<RoomData>(
                                jsonString, 
                                new JsonSerializerOptions()
        {
                NumberHandling = JsonNumberHandling.AllowReadingFromString | 
                JsonNumberHandling.WriteAsString
        });

        return roomData;
    }

}