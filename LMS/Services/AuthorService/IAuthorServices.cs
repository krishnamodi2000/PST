using LMS.Models.Books;
namespace LMS.Services.AuthorService
{
    public interface IAuthorServices
    {
        public IEnumerable<Author> GetAllAuthors();
        public void AddAuthor(Author author);
        public void DeleteAuthor(int id);
        public void UpdateAuthor(int id, Author author);
        public Author GetAuthorByID(int id);
        public Author GetAauthorByName(string Fname,string Lname);
    }
}
