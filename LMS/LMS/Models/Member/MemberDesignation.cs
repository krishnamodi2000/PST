using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models.Member
{
    [Table("Designations")]
    public class MemberDesignation
    {
        [Key]
        [Column("Designation ID")]
        public int DesgnationId { get; set; }
        [Required]
        [DataType("varchar")]
        [Column("Designation Title")]
        [MaxLength(500, ErrorMessage = "Designation cannot me more than 500 characters. Consider adding shortform")]
        public string DesgnationTitle { get; set; }
    }
}
