using Microsoft.EntityFrameworkCore;
using LMS.Models.Books;
using LMS.Models.Member;

namespace LMS.Context
{
    public class LibraryContext: DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<MemberDesignation> Designations { get; set; }
    }
}
