using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models.Books
{
    [Table("Author")]
    public class Author
    {
        [Key]
        [Column("Author ID")]
        public int AuthorId { get; set; }
        [Required]
        [DataType("varchar")]
        [Column("Author First Name")]
        [MaxLength(500, ErrorMessage = "First Name cannot me more than 500 characters. Consider adding short names")]
        public string AuthorFName { get; set; }
        [DataType("varchar")]
        [Column("Author Surname")]
        [MaxLength(500, ErrorMessage = "Surname cannot me more than 500 characters. Consider adding short names")]
        public string? AuthorLName { get; set; }
    }
}
