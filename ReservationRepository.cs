// This class stores wanted reservation into memory
public class ReservationRepository : IReservationRepository{

    private List<Reservation> _reservations = new List<Reservation>();

    // This method saves the requested reservation in the list. 
    public void AddReservation(Reservation reservation, ref string message){
        if(!_reservations.Contains(reservation)){       // Checks whether the requested reservation is in the list.
            _reservations.Add(reservation);
            message = " New Reservation Added.";
        }
        else message = $" AddReservation failed, because {reservation.reserverName} is already in the list.";
    }

    public void DeleteReservation(Reservation reservation, ref string message){
        if(_reservations.Contains(reservation)){        // Checks whether the reservation to be deleted is in the list.
           _reservations.Remove(reservation);
           message = " Reservation deleted.";
        }
        else message = $" DeleteReservation failed, because {reservation.reserverName} is not in the list.";
    }

    public List<Reservation> GetAllReservation(){       // returns reservation list.
        return _reservations;
    }
}