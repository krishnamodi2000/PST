using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using LMS.Models.Books;
namespace LMS.Models.Member
{
    [Table("Members")]
    public class Members
    {
        [Key]
        [Column("Member ID")]
        public int MemberId { get; set; }
        [Required]
        [DataType("varchar")]
        [Column("Member First Name")]
        [MaxLength(500, ErrorMessage = "First Name cannot me more than 500 characters. Consider adding short names")]
        public string MemberFName { get; set; }
        [DataType("varchar")]
        [Column("Member Surname")]
        [MaxLength(500, ErrorMessage = "Surname cannot me more than 500 characters. Consider adding short names")]
        public string? MemberLName { get; set; }
        [DataType("varchar(10)", ErrorMessage = "Phone Number cannot be more than 10 digits")] 
        [Column("Member Phone Number")]
        public string? MemberPhoneNumber { get; set; }
        
        [ForeignKey("MemberDesignation")]
        public int? MemberDesignationId { get; set; }
        public virtual MemberDesignation? MemberDesignation { get; set; }
    }
}
