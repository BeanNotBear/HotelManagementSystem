using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        [Column("RoleId")]
        public int Id { get; set; }

        [Column("RoleName")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public List<User> Users { get; set; }
    }
}
