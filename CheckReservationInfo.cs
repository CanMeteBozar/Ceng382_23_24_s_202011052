// This class checks whether the requested reservation is valid or not and returns true or false.
public static class CheckReservationInfo{

    public static bool CheckResInfo(Reservation User, RoomData roomData, ref string message){

        bool flag = false;
        bool flagCheckExist= false;
        DateTime startDate = new DateTime(2024, 4, 8);
        DateTime endDate = new DateTime(2024, 4, 14);

        if(roomData?.Rooms != null){
                foreach (var room in roomData.Rooms){
                    if(room.roomId == User.room.roomId && room.roomName == User.room.roomName){
                        flagCheckExist = true;
                        room.capacity -= User.room.capacity;
                        if(room.capacity < 0){
                            message = $" Reservation could not be added for {User.reserverName}. Room {room.roomName} out of capacity.";
                            flag = false;
                            break;   
                        }
                        else if (User.date >= startDate && User.date <= endDate){
                            flag = true;
                            break;
                        }
                        else{
                            message = $" Reservation could not be added for {User.reserverName}. The date does not fall between 08.04.2024 and 14.04.2024.";
                            flag = false;
                            break;
                        }
                    }
                }
                if(flagCheckExist==false)
                    message = $" Reservation could not be added for {User.reserverName}. Room {User.room.roomName} / {User.room.roomId} does not exist.";
        }
        return flag;
    }
}