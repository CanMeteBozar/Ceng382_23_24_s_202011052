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
        
        RoomHandler roomHandler= new RoomHandler();
        var roomData = roomHandler.GetRooms();

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
            //logHandler.AddLog(logrecord, "LogData.json");
        }

        Console.Write("\nUser 2: \n");
        Reservation User2 = new Reservation();
        User2.reserverName = "Bilge Cetindere";
        User2.room = new Room{roomId = "012", roomName = "A-112", capacity = 25};
        User2.date = new DateTime(2024,04,12,12,30,0);
        if(CheckReservationInfo.CheckResInfo(User2, roomData)){
            Console.WriteLine($"Reservername = {User2.reserverName} RoomName = {User2.room.roomName}");
            LogRecord logrecord = new LogRecord(User2.reserverName, User2.room.roomName);
            ILogger logger = new FileLogger();
            LogHandler logHandler = new LogHandler(logger);
            //logHandler.AddLog(logrecord, "LogData.json");
        }

        ReservationRepository reservationRepository= new ReservationRepository();
        reservationRepository.AddReservation(User1);
        List<Reservation> myList = new List<Reservation>(reservationRepository.GetAllReservation());
        foreach (var item in myList)
        {
            Console.WriteLine($"String: {item.reserverName}, DateTime: {item.date}, Room: {item.room.roomName}, RoomId: {item.room.roomId}, capacity: {item.room.capacity}");
        }
        reservationRepository.AddReservation(User1);
        reservationRepository.DeleteReservation(User1);
        reservationRepository.AddReservation(User2);
        myList = reservationRepository.GetAllReservation();
        foreach (var item in myList)
        {
            Console.WriteLine($"String: {item.reserverName}, DateTime: {item.date}, Room: {item.room.roomName}, RoomId: {item.room.roomId}, capacity: {item.room.capacity}");
        }
        reservationRepository.AddReservation(User1);
        foreach (var item in myList)
        {
            Console.WriteLine($"String: {item.reserverName}, DateTime: {item.date}, Room: {item.room.roomName}, RoomId: {item.room.roomId}, capacity: {item.room.capacity}");
        }
        reservationRepository.AddReservation(User1);
        reservationRepository.AddReservation(User1);
        reservationRepository.AddReservation(User2);
        reservationRepository.AddReservation(User1);
        reservationRepository.DeleteReservation(User2);
        reservationRepository.DeleteReservation(User2);
        foreach (var item in myList)
        {
            Console.WriteLine($"String: {item.reserverName}, DateTime: {item.date}, Room: {item.room.roomName}, RoomId: {item.room.roomId}, capacity: {item.room.capacity}");
        }

    }
    
}