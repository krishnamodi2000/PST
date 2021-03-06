using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppDAL.Models
{/// <summary>
/// This is State EF Core for State table.
/// </summary>
    [Table("State")]
    public class State
    {

        [Key]
        [Column("ID")] //autogenerated
        public int StateId { get; set; } //refereed in address tale
        [Required]
        [DataType("varchar")]
        [Column("Name")]
        [MaxLength(30, ErrorMessage = "Name cannot me more than 30 characters. Consider adding shortform")]
        public string StateName { get; set; }
    }
}
