using LMS.Context;
using LMS.Models.Books;

namespace LMS.Services.AuthorService
{
    public class AuthorServices : IAuthorServices
    {
        LibraryContext db;
        public AuthorServices(LibraryContext _db)
        {
            db = _db;
        }

        public void AddAuthor(Author author)
        {
            db.Add(author);
            db.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            Author author = db.Authors.FirstOrDefault(a => a.AuthorId == id);
            //Book book = db.Books.FirstOrDefault(b => b.BookAuthorID == id);
            if (author != null)
            {
                db.Remove(author);
               // db.Remove(book); //if author is no longer available in the library the book is very obviously disposed
                db.SaveChanges();
            }
        }

        public Author GetAauthorByName(string Fname,string Lname)
        {
            return (db.Authors.FirstOrDefault(a =>( a.AuthorFName == Fname && a.AuthorLName==Lname)));
        }

        public IEnumerable<Author> GetAllAuthors()
        {

            return (db.Authors.Select(a => a).ToList());
        }

        public Author GetAuthorByID(int id)
        {
            return (db.Authors.Find(id));
        }
       
        public void UpdateAuthor(int id, Author author)
        {
            var aut = db.Authors.FirstOrDefault(a => a.AuthorId == id);//author id will not be updated only author details can be
           //so we don't need to update the book table everytime a author is updated, that is the advantage of having book
           //and author table separate
            if (aut != null)
            {
                db.Entry<Author>(aut).CurrentValues.SetValues(author);
                db.SaveChanges();
            }
        }
    }
}
