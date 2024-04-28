// This class is interface for ReservationRepository.cs
using System.Security.Cryptography;

public interface IReservationRepository{

    public void AddReservation(Reservation reservation, ref string message);

    public void DeleteReservation(Reservation reservation, ref string message);

    public List<Reservation> GetAllReservation();
}