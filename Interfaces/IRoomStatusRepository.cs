using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Interfaces
{
    public interface IRoomStatusRepository
    {
        void Insert(RoomStatus roomStatus);
        void Update(int id, RoomStatus roomStatus);
        void Delete(int id);
        List<RoomStatus> GetAll();
        RoomStatus FindRoomStatusById(int id);
    }
}
