// This class has an array for json datas about Room class.
using System.Text.Json.Serialization;

public class RoomData
{
    [JsonPropertyName("Room")]
    public Room[] Rooms{get; set;}
}