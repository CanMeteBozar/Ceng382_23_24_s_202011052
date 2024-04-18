using System.ComponentModel;

public class ReservationHandler{
    private IReservationRepository _reservationRepository = new ReservationRepository();

    private LogHandler _logHandler = new LogHandler();

    private RoomHandler _roomHandler = new RoomHandler();

    public void AddReservation(Reservation reservation, string reserverName){
        
    }

    public void DeleteReservation(Reservation reservation){

    }

    public List<Reservation> GetAllReservations(){

    }


}