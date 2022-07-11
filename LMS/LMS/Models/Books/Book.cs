using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LMS.Models.Books
{
    public class Book
    {
        [Key]
        [Column("Book ID")]
        public int BookId { get; set; }
        [DataType("varchar")]
        [Column("Book Title")]
        [MaxLength(500, ErrorMessage = "Book Title cannot me more than 500 characters")]
        public string? BookTitle { get; set; }
        [ForeignKey("Author")]
        public int? AuthorId { get; set; }
        
        public virtual Author? Author { get; set; }
        [ForeignKey("Publication")]
        public int? PublicationId { get; set; }
        public virtual Publication? Publication { get; set; }
        //[ForeignKey("Issue")]
        //public int? IssueId { get; set; }
        //public virtual Issue? Issue { get; set; }
        //public int BookAuthorID { get; internal set; }
    }
}
