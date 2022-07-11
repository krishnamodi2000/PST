using LMS.Models.Books;
using LMS.Services.AuthorService;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        IAuthorServices _iss;
        public AuthorController(IAuthorServices iss)
        {
            _iss = iss;
        }
        [HttpGet]
        public IEnumerable<Author> GetAllAuthor()
        {
            return (_iss.GetAllAuthors());
        }
        [HttpGet("{id}")]

        public Author GetAuthorByID(int id)
        {
            return _iss.GetAuthorByID(id);
        }

        [HttpGet]
        [Route("byName/{Fname}/{Lname}")]
        public ActionResult<Author> GetAuthorByName(string Fname, string Lname)
        {
            return _iss.GetAauthorByName(Fname, Lname);
        }

        [HttpPost]

        public void AddAuthor([FromBody] Author author)
        {
            _iss.AddAuthor(author);
        }

        [HttpPut("{id}")]
        public void UpdateAuthor(int id, Author author)
        {
            _iss.UpdateAuthor(id, author);

        }

        [HttpDelete("{id}")]

        public void DeleteAuthor(int id)
        {
            _iss.DeleteAuthor(id);
        }
    }
}
