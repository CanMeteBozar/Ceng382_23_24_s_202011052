public class ReservationRepository : IReservationRepository{

    private List<Reservation> _reservations = new List<Reservation>();

    public void AddReservation(Reservation reservation){
        if(!_reservations.Contains(reservation))
            _reservations.Add(reservation);
        else Console.WriteLine($"AddReservation failed, because {reservation.reserverName} is already in the list.");
    }

    public void DeleteReservation(Reservation reservation){
        if(_reservations.Contains(reservation))
            _reservations.Remove(reservation);
        else Console.WriteLine($"DeleteReservation failed, because {reservation.reserverName} is not in the list.");
    }

    public List<Reservation> GetAllReservation(){
        return _reservations;
    }
}