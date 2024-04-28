// This class holds data from json file in proper format 
using System.Text.Json.Serialization;

public class Room
{
    [JsonPropertyName("roomId")]
    public string roomId {get; set;}

    [JsonPropertyName("roomName")]
    public string roomName {get; set;}

    [JsonPropertyName("capacity")]
    public int capacity{get; set;}
}