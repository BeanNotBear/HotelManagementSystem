using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    [Table("RoomType")]
    public class RoomType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        public string? Description { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Column(TypeName ="decimal(10,2)")]        
        public decimal PricePerNight { get; set; }
        public List<Room>? Rooms { get; set; }

    }
}
