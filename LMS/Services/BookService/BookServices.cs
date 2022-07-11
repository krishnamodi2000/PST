using LMS.Context;
using LMS.Models.Books;

namespace LMS.Services.BookService
{
    public class BookServices : IBookServices
    {
        LibraryContext db;
        public BookServices(LibraryContext _db)
        {
            db = _db;
        }
        public void AddBook(Book book)
        {
            db.Add(book);
            db.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            Book bk = db.Books.FirstOrDefault(b => b.BookId == id);
            if (bk != null)
            {
                db.Remove(bk);
                db.SaveChanges();
            }
        }

        public IEnumerable<object> GetAllBooks()
        {
           var result= db.Books.Select(x=> new {x.BookId,x.AuthorId,x.BookTitle,x.PublicationId});
            //return (db.Books.Select(b => b).ToList());
            return result.ToList();
        }

        public object GetBookByID(int id)
        {
            var result = db.Books.Where(x=>x.BookId==id).Select(x => new { x.BookId, x.AuthorId, x.BookTitle, x.PublicationId });
            return result; 
        }

        public object GetBookByName(string name)
        {
            var result = db.Books.Where(x => x.BookTitle == name).Select(x => new { x.BookId, x.AuthorId, x.BookTitle, x.PublicationId});
            return result;
        }

        public void UpdateBook(int id, Book book)
        {
            var bk = db.Books.FirstOrDefault(b => b.BookId == id);
            if (bk != null)
            {
                db.Entry<Book>(bk).CurrentValues.SetValues(book);
                db.SaveChanges();
            }
        }
    }
}
