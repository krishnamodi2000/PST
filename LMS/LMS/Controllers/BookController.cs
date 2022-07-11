using LMS.Models.Books;
using LMS.Services.BookService;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        IBookServices _iss;
        public BookController(IBookServices iss)
        {
            _iss = iss;
        }
        [HttpGet]
        public IEnumerable<object> GetAllBooks()
        {
            return (_iss.GetAllBooks());
        }
        [HttpGet("{id}")]
       
        public object GetBookByID(int id)
        {
            return _iss.GetBookByID(id);
        }

        [HttpGet]
        [Route("byName/{name}")]
        public ActionResult<object> GetBookByName(string name)
        {
            return _iss.GetBookByName(name);
        }
        
        [HttpPost]
        
        public void AddBook([FromBody] Book book)
        {
            _iss.AddBook(book);
        }

        [HttpPut("{id}")]   
        public void UpdateBook(int id, Book book)
        {
            _iss.UpdateBook(id, book);

        }
        
        [HttpDelete("{id}")]
       
        public void DeleteBook(int id)
        {
            _iss.DeleteBook(id);
        }
      
    }
}
