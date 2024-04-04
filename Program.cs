using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;


public class RoomData
{
    [JsonPropertyName("Room")]
    public Room[] Rooms{get; set;}
}
public class Room
{
    [JsonPropertyName("roomId")]
    public string roomId {get; set;}

    [JsonPropertyName("roomName")]
    public string roomName {get; set;}

    [JsonPropertyName("capacity")]
    public int capacity{get; set;}
}

public class Reservation{
    public DateTime date{get; set;}

    public string reserverName{get; set;}

    public Room room{get; set;}

}

public class ReservationHandler{

    private Reservation[] reservations;
    private int i=0;
    public ReservationHandler(){reservations = new Reservation[10];}

    public void AddReservation(Reservation res){
        
        Reservation newRes = new Reservation();
        newRes.date = res.date;
        newRes.room = res.room;
        newRes.reserverName = res.reserverName;
        reservations[i] = newRes;
        i++;

        Console.Write($"A reservation for {res.reserverName} was successfully added.\n");
    } 

    public void deleteReservation(string res){
        int flag = 0;
        for(int j = 0;j<i;j++){
            if(res==reservations[j].reserverName){
                for(;j<i;j++){
                    reservations[j] = reservations[j+1];
                }
                i--;
                flag = 1;
                Console.Write($"A reservation for {res} was successfully deleted.\n");
                break;
            }
        }
        if(flag==0) Console.Write($"A reservation for {res} not found.\n");
    }

    public void displayWeeklySchedule(){

        Console.WriteLine("\nDisplay Weekly Schedule:");

        string[] headers = { "Reserver Name", "Room ID", "Room Name", "Date", "Time", "Capacity" };

        Console.WriteLine("+-----------------+----------+----------+--------------+--------+----------+");
        Console.WriteLine("|" + headers[0].PadRight(17) + "|" + headers[1].PadRight(10) + "|" + headers[2].PadRight(10) + "|" + headers[3].PadRight(14) + "|" + headers[4].PadRight(8) + "|" + headers[5].PadRight(10) + "|");
        Console.WriteLine("+-----------------+----------+----------+--------------+--------+----------+");

        for(int j=0;j<i;j++){
            Console.Write($"|{reservations[j].reserverName.PadRight(17)}");
            Console.Write($"|{reservations[j].room.roomId.PadRight(10)}");
            Console.Write($"|{reservations[j].room.roomName.PadRight(10)}");
            Console.Write($"|{reservations[j].date.Day.ToString("00").PadLeft(2)}-{reservations[j].date.Month.ToString("00").PadLeft(2)}-{reservations[j].date.Year.ToString().PadRight(8)}");
            Console.Write($"|{reservations[j].date.Hour.ToString().PadLeft(2)}:{reservations[j].date.Minute.ToString("00").PadRight(5)}");
            Console.Write($"|{reservations[j].room.capacity.ToString().PadRight(9)} |\n");
        }
        Console.WriteLine("+-----------------+----------+----------+--------------+--------+----------+\n");
    }
}

class Program
{

    static bool CheckResInfo(Reservation User, RoomData roomData){

        bool flag = false;
        bool flagCheckExist= false;
        DateTime startDate = new DateTime(2024, 4, 8);
        DateTime endDate = new DateTime(2024, 4, 14);

        if(roomData?.Rooms != null){
                foreach (var room in roomData.Rooms){
                    if(room.roomId == User.room.roomId && room.roomName == User.room.roomName){
                        flagCheckExist = true;
                        room.capacity -= User.room.capacity;
                        if(room.capacity < 0){
                            Console.Write($"Reservation could not be added for {User.reserverName}. Room {room.roomName} out of capacity.\n");
                            flag = false;
                            break;   
                        }
                        else if (User.date >= startDate && User.date <= endDate){
                            flag = true;
                            break;
                        }
                        else{
                            Console.Write($"Reservation could not be added for {User.reserverName}. The date does not fall between 08.04.2024 and 14.04.2024.\n");
                            flag = false;
                            break;
                        }
                    }
                }
                if(flagCheckExist==false)
                    Console.Write($"Reservation could not be added for {User.reserverName}. Room {User.room.roomName} / {User.room.roomId} does not exist.\n");
        }
        return flag;
    }
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


        ReservationHandler reservationData = new ReservationHandler();

        Console.Write("\nUser 1: \n");
        Reservation User1 = new Reservation();
        User1.reserverName = "Can Mete Bozar";
        User1.room = new Room{roomId = "011", roomName = "A-111", capacity = 20};
        User1.date = new DateTime(2024,04,13,15,0,0);
        if(CheckResInfo(User1, roomData)) reservationData.AddReservation(User1);
        
        Console.Write("User 2: \n");
        Reservation User2 = new Reservation();
        User2.reserverName = "Bilge Cetindere";
        User2.room = new Room{roomId = "012", roomName = "A-112", capacity = 25};
        User2.date = new DateTime(2024,04,12,12,30,0);
        if(CheckResInfo(User2, roomData)) reservationData.AddReservation(User2);
         
        // Registration will not be possible as more appointments are requested for the same room than its capacity.
        Console.Write("User 3: \n");
        Reservation User3 = new Reservation();
        User3.reserverName = "Atacan Beyenir";
        User3.room = new Room{roomId = "012", roomName = "A-112", capacity = 25};
        User3.date = new DateTime(2024,04,08,17,15,0); 
        if(CheckResInfo(User3, roomData)) reservationData.AddReservation(User3);

        // Registration will not be possible as reservations are made outside the required dates.
        Console.Write("User 4: \n");
        Reservation User4 = new Reservation();
        User4.reserverName = "Timucin Eke";
        User4.room = new Room{roomId = "002", roomName = "A-102", capacity = 10};
        User4.date = new DateTime(2024,04,20,09,45,0); 
        if(CheckResInfo(User4, roomData)) reservationData.AddReservation(User4);

        Console.Write("User 5: \n");
        Reservation User5 = new Reservation();
        User5.reserverName = "Aysenaz Donmez";
        User5.room = new Room{roomId = "008", roomName = "A-108", capacity = 30};
        User5.date = new DateTime(2024,04,08,18,00,0); 
        if(CheckResInfo(User5, roomData)) reservationData.AddReservation(User5);

        Console.Write("User 6: \n");
        Reservation User6 = new Reservation();
        User6.reserverName = "Dogan Ertunc";
        User6.room = new Room{roomId = "1234", roomName = "A-1234", capacity = 15};
        User6.date = new DateTime(2024,04,10,14,00,0); 
        if(CheckResInfo(User6, roomData)) reservationData.AddReservation(User6);

        reservationData.displayWeeklySchedule();
        reservationData.deleteReservation(User1.reserverName);
        // Someone who is not registered cannot be deleted
        reservationData.deleteReservation(User4.reserverName);
        reservationData.displayWeeklySchedule();



    
    }
}