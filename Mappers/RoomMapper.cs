using HotelManagementSystem.Dto;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Mappers
{
    public static class RoomMapper
    {
        public static RoomListDTO ToRoomListDTO(this Room roomModel)
        {
            return new RoomListDTO
            {
                Id = roomModel.Id,
                RoomType = roomModel.Type.Name,
                Status = roomModel.Status.Name,
                TimeUsed = 0,
            };
        }
    }
}
