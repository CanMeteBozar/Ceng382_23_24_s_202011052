using System.Security.Cryptography;

public interface IReservationRepository{

    public void AddReservation(Reservation reservation);

    public void DeleteReservation(Reservation reservation);

    public List<Reservation> GetAllReservation();
}