using LMS.Models.Books;
namespace LMS.Services.PublicationService
{
    public interface IPublicationServices
    {
        public IEnumerable<Publication> GetAllPublishers();
        public void AddPublisher(Publication pub);
        public void DeletePublisher(int id);
        public void UpdatePublisher(int id, Publication pub);
        public Publication GetPublisherByID(int id);
        public Publication GetPublisherByName(string name);
    }
}
