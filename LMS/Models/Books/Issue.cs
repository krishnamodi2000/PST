using LMS.Models.Member;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LMS.Models.Books
{
    [Table("Issues")]
    public class Issue
    {
        [Key]
        [Column("Issue ID")]
        public int IssueId { get; set; }
        [DataType("date")]
        [Column("Issue Date")]
        [Required]
        public DateTime IssueDate { get; set; }
        [DataType("date")]
        [Column("Return Date")]
        [Required]
        public DateTime ReturnDate { get; set; } //add validation that return date>=issue date and if return dt is null then set it to 1 week
        [DataType("bool")]
        [Column("Return Satus")]
        public bool ReturnStatus { get; set; }
        [DataType("int")]
        [Column("Book Id")]
        [ForeignKey("Book")]
        public int? BookId { get; set; }
        public virtual Book? Book { get; set; }

        [ForeignKey("Members")]
        public int? MemberId { get; set; }
        public virtual Members? Members { get; set; }
        
        
    }
}
