using LMS.Models.Books;

namespace LMS.Services.BookService
{
    public interface IBookServices
    {
        public IEnumerable<object> GetAllBooks();
        public void AddBook(Book book);
        public void DeleteBook(int id);
        public void UpdateBook(int id, Book book);
        public object GetBookByID(int id);
        public object GetBookByName(string name);
    }
}
