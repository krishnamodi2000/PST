using LMS.Models.Books;
using LMS.Services.IssueService;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : Controller
    {
        IIssueServices _iss;
        public IssueController(IIssueServices iss)
        {
            _iss = iss;
        }
        [HttpGet]
        public IEnumerable<object> GetAllIssues()
        {
            return (_iss.GetAllIssues());
        }
        [HttpGet("{id}")]
        public object GetIssueByID(int id)
        {
            return _iss.GetIssueByID(id);
        }
        [HttpPost]
        public void AddIssue([FromBody] Issue issue)
        {
            _iss.AddIssue(issue);
        }
        [HttpPut("{id}")]
        public void UpdateIssue(int id, Issue issue)
        {
            _iss.UpdateIssue(id, issue);
        }
        [HttpDelete("{id}")]
        public void DeleteIssue(int id)
        {
            _iss.DeleteIssue(id);
        }
    }


}
