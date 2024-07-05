using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    [Table("Room")]
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TypeId { get; set; }
        [Required]
        public int StatusId { get; set; }
        public RoomType? Type { get; set; }
        public RoomStatus? Status { get; set; }

    }
}
