public class ReservationService : IReservationService{

    private ReservationHandler _reservationHandler;

    public ReservationService(){
        _reservationHandler = new ReservationHandler();
    }

    public void AddReservation(Reservation reservation){        // Goes to the method in the reservationhandler to add reservation
        _reservationHandler.AddReservation(reservation);
    }

    public void DeleteReservation(Reservation reservation){     // Goes to the method in the reservationhandler to delete reservation
        _reservationHandler.DeleteReservation(reservation);
    }

    public void DisplayWeeklySchedule(){            // Dislays Reservation List in proper table.
        
        List<Reservation> reservation = new List<Reservation>(_reservationHandler.GetAllReservations());

         Console.WriteLine("\nDisplay Weekly Schedule:");

        string[] headers = { "Reserver Name", "Room ID", "Room Name", "Date", "Time", "Capacity" };

        Console.WriteLine("+-----------------+----------+----------+--------------+--------+----------+");
        Console.WriteLine("|" + headers[0].PadRight(17) + "|" + headers[1].PadRight(10) + "|" + headers[2].PadRight(10) + "|" + headers[3].PadRight(14) + "|" + headers[4].PadRight(8) + "|" + headers[5].PadRight(10) + "|");
        Console.WriteLine("+-----------------+----------+----------+--------------+--------+----------+");

        foreach(Reservation res in reservation){
            Console.Write($"|{res.reserverName.PadRight(17)}");
            Console.Write($"|{res.room.roomId.PadRight(10)}");
            Console.Write($"|{res.room.roomName.PadRight(10)}");
            Console.Write($"|{res.date.Day.ToString("00").PadLeft(2)}-{res.date.Month.ToString("00").PadLeft(2)}-{res.date.Year.ToString().PadRight(8)}");
            Console.Write($"|{res.date.Hour.ToString().PadLeft(2)}:{res.date.Minute.ToString("00").PadRight(5)}");
            Console.Write($"|{res.room.capacity.ToString().PadRight(9)} |\n");
        }
        Console.WriteLine("+-----------------+----------+----------+--------------+--------+----------+\n");
    }

    public void SaveRooms(){            // Goes to the method in the reservationhandler to save rooms into json file.
        _reservationHandler.SaveRooms();
    }
    
}