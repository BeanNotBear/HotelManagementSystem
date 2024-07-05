using HotelManagementSystem.Data;
using HotelManagementSystem.Dto;
using HotelManagementSystem.Interfaces;
using HotelManagementSystem.Mappers;
using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private HotelManagementDbContext _context;

        public RoomRepository(HotelManagementDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Room FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<RoomListDTO> GetAll()
        {
            // eger loading 
            // load room with room type and room status
            var rooms = _context.Rooms
                .Include(room => room.Type)
                .Include(room => room.Status)
                .AsSplitQuery()
                .Select(room => room.ToRoomListDTO())
                .ToList();
            return rooms;
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Room room)
        {
            throw new NotImplementedException();
        }
    }
}
