// This class contains variables and methods for making reservation properly.
// This class communicates with other required classes and owns and uses their objects.
using System.ComponentModel;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

public class ReservationHandler{
    private IReservationRepository _reservationRepository;

    private LogHandler _logHandler;

    LogRecord _logrecord;

    ILogger _logger;

    private RoomHandler _roomHandler;

    public RoomData roomData;

    string message;

    public ReservationHandler(){
        _reservationRepository  = new ReservationRepository();
        _logger  = new FileLogger();
        _logHandler = new LogHandler(_logger);
        _roomHandler  = new RoomHandler();
        roomData = GetRooms();
        message = "null";
    }

    public void AddReservation(Reservation reservation){
        if(CheckReservationInfo.CheckResInfo(reservation, roomData, ref message)){              // Checks whether the requested reservation is valid or not and returns true or false. If reservation valid, it adds reservation.
            _reservationRepository.AddReservation(reservation, ref message);                    // Stores requested reservation.
            _logrecord = new LogRecord(reservation.reserverName, reservation.room.roomName);    
            _logHandler.AddLog(_logrecord, "LogData.json", message);                            // Logs to LogData.json file.
        }
        else{                                                                                   // If requested reservation is not valid, it writes proper message to LogData.json file.
            _logrecord = new LogRecord(reservation.reserverName, reservation.room.roomName);
            _logHandler.AddLog(_logrecord, "LogData.json", message);                            // Logs to LogData.json file.
        }
    }

    public void DeleteReservation(Reservation reservation){
        _reservationRepository.DeleteReservation(reservation, ref message);                     // Deletes requested reservation.
        _logrecord = new LogRecord(reservation.reserverName, reservation.room.roomName);
        _logHandler.AddLog(_logrecord, "LogData.json", message);                                // Logs to LogData.json file.
    }

    public List<Reservation> GetAllReservations(){                                              // Get reservation list from Reservation Repository.
        return _reservationRepository.GetAllReservation();
    }

    public RoomData GetRooms(){                                                                 // Get Room's information from RoomHandler class, from Data.json file.
        return _roomHandler.GetRooms();
    }

    public void SaveRooms(){                                                                    // Save reservations into ReservationData.json file.
        string json = JsonConvert.SerializeObject(_reservationRepository.GetAllReservation(), Formatting.Indented);
        File.WriteAllText("ReservationData.json", json);
    }
}