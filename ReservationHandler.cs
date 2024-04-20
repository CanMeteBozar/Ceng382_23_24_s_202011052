using System.ComponentModel;

public class ReservationHandler{
    private IReservationRepository _reservationRepository = new ReservationRepository();

    //private LogHandler _logHandler = new LogHandler();

    private RoomHandler _roomHandler = new RoomHandler();

    public void AddReservation(Reservation reservation, string reserverName){
        _reservationRepository.AddReservation(reservation);
    }

    public void DeleteReservation(Reservation reservation){
        _reservationRepository.DeleteReservation(reservation);
    }

    // public List<Reservation> GetAllReservations(){

    // }

    // public List<Room> GetRooms(){
    //     return _roomHandler.GetRooms();
    // }

    public void SaveRooms(List<Room> rooms){
        
    }


}