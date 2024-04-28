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
        
        ReservationService reservationService = new ReservationService();

        Reservation User1 = new Reservation();
        User1.reserverName = "Can Mete Bozar";
        User1.room = new Room{roomId = "011", roomName = "A-111", capacity = 20};
        User1.date = new DateTime(2024,04,13,15,0,0);
        reservationService.AddReservation(User1);

        // Someone who is already registered cannot be added.
        reservationService.AddReservation(User1);

        Reservation User2 = new Reservation();
        User2.reserverName = "Bilge Cetindere";
        User2.room = new Room{roomId = "012", roomName = "A-112", capacity = 25};
        User2.date = new DateTime(2024,04,12,12,30,0);
        reservationService.AddReservation(User2);

        // Registration will not be possible as more appointments are requested for the same room than its capacity.
        Reservation User3 = new Reservation();
        User3.reserverName = "Atacan Beyenir";
        User3.room = new Room{roomId = "012", roomName = "A-112", capacity = 25};
        User3.date = new DateTime(2024,04,08,17,15,0);
        reservationService.AddReservation(User3);

        // Registration will not be possible as reservations are made outside the required dates.
        Reservation User4 = new Reservation();
        User4.reserverName = "Timucin Eke";
        User4.room = new Room{roomId = "002", roomName = "A-102", capacity = 10};
        User4.date = new DateTime(2024,04,20,09,45,0);
        reservationService.AddReservation(User4);

        Reservation User5 = new Reservation();
        User5.reserverName = "Aysenaz Donmez";
        User5.room = new Room{roomId = "008", roomName = "A-108", capacity = 30};
        User5.date = new DateTime(2024,04,08,18,00,0);
        reservationService.AddReservation(User5);

        // Registration will not be possible because the room does not exist.
        Reservation User6 = new Reservation();
        User6.reserverName = "Dogan Ertunc";
        User6.room = new Room{roomId = "1234", roomName = "A-1234", capacity = 15};
        User6.date = new DateTime(2024,04,10,14,00,0);
        reservationService.AddReservation(User6);

        reservationService.DisplayWeeklySchedule();

        reservationService.DeleteReservation(User1);

        // Someone who is not registered cannot be deleted.
        reservationService.DeleteReservation(User4);

        reservationService.DisplayWeeklySchedule();

        // Save reservations into ReservationData.json file. 
        reservationService.SaveRooms();
    }
    
}

/*
        The Single Responsibility Principle (SRP) states that a class should have only one reason to change.
    In other words, each class should have a single responsibility or purpose. This helps in keeping the 
    codebase maintainable, flexible, and easier to understand.

        My code in lab6 is wasn't divided into classes and each class didn't have single responsibility
    or purpose. My code was not maintainable, flexible and easier to understand.

        Dependency Injection (DI) is a design pattern where the dependencies of a class are provided from 
    the outside, typically through constructor injection or method injection. This helps in making 
    classes loosely coupled, more testable, and easier to maintain.

        My code in lab6 didn't use any interface classes or methods that belongs to another class. 
    Every section tries to do some jobs on its own.

        For a few reasons like these, my code could not satisfy SRP and DI.

        
        In web applications, adhering to SRP and using DI is essential for several reasons:

        Organization and Ease of Maintenance: Websites have many parts like controllers, services, 
    and databases. Following SRP means each part has one job, making the code easier to understand,
    update, and fix.

        Testing: DI lets us easily test different parts of the website. This means we can check if 
    each part works correctly without needing other parts. It's like testing each ingredient of a recipe 
    separately to make sure it's good.

        Adapting and Growing: With DI, we can change parts of the website without affecting others. This helps
    the website adapt to new needs or grow bigger without breaking the existing code.

        Overall, sticking to SRP and using DI in websites helps keep the code neat, easier to work with, 
    and better quality.

*/