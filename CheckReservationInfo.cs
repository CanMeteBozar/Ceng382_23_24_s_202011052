public static class CheckReservationInfo{

    public static bool CheckResInfo(Reservation User, RoomData roomData){

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
                            Console.Write($"Reservation could not be added for {User.reserverName}. Room {room.roomName} out of capacity.\n");
                            flag = false;
                            break;   
                        }
                        else if (User.date >= startDate && User.date <= endDate){
                            flag = true;
                            break;
                        }
                        else{
                            Console.Write($"Reservation could not be added for {User.reserverName}. The date does not fall between 08.04.2024 and 14.04.2024.\n");
                            flag = false;
                            break;
                        }
                    }
                }
                if(flagCheckExist==false)
                    Console.Write($"Reservation could not be added for {User.reserverName}. Room {User.room.roomName} / {User.room.roomId} does not exist.\n");
        }
        return flag;
    }
}