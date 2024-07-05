using HotelManagementSystem.Dto;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Interfaces
{
    public interface IRoomRepository
    {
        void Insert();
        void Update(int id, Room room);
        void Delete(int id);
        Room FindById(int id);
        List<RoomListDTO> GetAll();
    }
}
