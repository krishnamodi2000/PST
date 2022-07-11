using LMS.Models.Books;
using LMS.Services.PublicationService;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : Controller
    {
        IPublicationServices _iss;
        public PublicationController(IPublicationServices iss)
        {
            _iss = iss;
        }
        [HttpGet]
        public IEnumerable<Publication> GetAllPublishers()
        {
            return (_iss.GetAllPublishers());
        }
        [HttpGet("{id}")]

        public Publication GetPublisherByID(int id)
        {
            return _iss.GetPublisherByID(id);
        }

        [HttpGet]
        [Route("byName/{Fname}/{Lname}")]
        public ActionResult<Publication> GetPublisherByName(string name)
        {
            return _iss.GetPublisherByName(name);
        }

        [HttpPost]

        public void AddPublisher([FromBody] Publication publisher)
        {
            _iss.AddPublisher(publisher);
        }

        [HttpPut("{id}")]
        public void UpdatePublisher(int id, Publication publisher)
        {
            _iss.UpdatePublisher(id, publisher);

        }

        [HttpDelete("{id}")]

        public void DeletePublisher(int id)
        {
            _iss.DeletePublisher(id);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
