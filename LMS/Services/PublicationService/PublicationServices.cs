using LMS.Context;
using LMS.Models.Books;

namespace LMS.Services.PublicationService
{
    public class PublicationServices : IPublicationServices
    {
        LibraryContext db;
        public PublicationServices(LibraryContext _db)
        {
            db = _db;
        }
        public void AddPublisher(Publication pub)
        {
            db.Add(pub);
            db.SaveChanges();
        }

        public void DeletePublisher(int id)
        {
            Publication pub = db.Publications.FirstOrDefault(p => p.PulicationId == id);
            Book book = db.Books.FirstOrDefault(b => b.PublicationId == id);//If the publisher is deleted then so will the books be
            if (pub != null)
            {
                db.Remove(pub);
                //db.Remove(book);
                db.SaveChanges();
            }
        }

        public IEnumerable<Publication> GetAllPublishers()
        {
            return (db.Publications.Select(p => p).ToList());
        }

        public Publication GetPublisherByID(int id)
        {
            return (db.Publications.Find(id));
        }

        public Publication GetPublisherByName(string name)
        {
            return (db.Publications.FirstOrDefault(p => p.PublicationName == name));
        }

        public void UpdatePublisher(int id, Publication pub)
        {
            var publisher = db.Publications.FirstOrDefault(p => p.PulicationId == id);//publisher id cannot be updated only publisher details
           //can be so we don't need to update the book table everytime a publisher is updated, that is the advantage of having book
           //and publisher table separate
            if (publisher != null)
            {
                db.Entry<Publication>(publisher).CurrentValues.SetValues(pub);
                db.SaveChanges();
            }
        }
    }
}
