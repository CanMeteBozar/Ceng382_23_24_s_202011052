// This class is interface for ReservationService.cs
using System.ComponentModel;

public interface IReservationService{

    public void AddReservation(Reservation reservation);

    public void DeleteReservation(Reservation reservation);

    public void DisplayWeeklySchedule();

    public void SaveRooms();
}