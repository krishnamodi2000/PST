using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models.Books
{
    [Table("Publication")]
   
    public class Publication
    {
        [Key]
        [Column("Publication ID")]
        public int PulicationId { get; set; }
        [Required]
        [DataType("varchar")]
        [Column("Publication Name")]
        [MaxLength(500, ErrorMessage = "Publisher cannot me more than 500 characters")]
        public string PublicationName{ get; set; }
    }
}
