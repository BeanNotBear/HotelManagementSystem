using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    [Table("RoomStatus")]
    public class RoomStatus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String? Name { get; set; }
        public List<Room>? Rooms { get; set; }
    }
}
