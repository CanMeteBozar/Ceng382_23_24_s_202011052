public class ReservationRepository : IReservationRepository{

    private List<Reservation> _reservations = new List<Reservation>();

    public void AddReservation(Reservation reservation){
        
    }

    public void DeleteReservation(Reservation reservation){

    }

    public List<Reservation> GetAllReservation(){
        return _reservations;
    }
}