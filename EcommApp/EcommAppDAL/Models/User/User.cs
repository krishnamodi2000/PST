using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppDAL.Models
{/// <summary>
/// This is User EF Core for User Table.
/// </summary>
    public class User
    {
        [Key]
        [Column("ID")]
        public int UserId { get; set; } //autogenerated
        [Required]
        [DataType("varchar")]
        [Column("First Name")]
        [MaxLength(30, ErrorMessage = "User First Name cannot me more than 30 characters. Consider adding short names")]
        public string UserFName { get; set; }
        [DataType("varchar")]
        [Column("Last Name")]
        [MaxLength(30, ErrorMessage = "User Last Name cannot me more than 30 characters. Consider adding short names")]
        public string? UserLName { get; set; }
        [Required]
        [DataType("varchar")]
        [Column("Contact")]
        [MaxLength(10, ErrorMessage = "User Last Name cannot me more than 10 characters. Consider adding short names")]
        public string UserContact { get; set; }
        [Required]
        [DataType("varchar")]
        [Column("Email ID")]
        [MaxLength(254, ErrorMessage = "User Last Name cannot me more than 30 characters. Consider adding short names")]
        public string UserEmail { get; set; }

    }
}
