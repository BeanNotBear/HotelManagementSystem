using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Dto
{
    public class RoomListDTO
    {
        public int Id { get; set; }
        public string? RoomType { get; set; }
        public string? Status { get; set; }
        public int TimeUsed { get; set; } = 0;
    }
}
