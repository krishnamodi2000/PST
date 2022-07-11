using LMS.Models.Member;
using LMS.Services.MemberService;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : Controller
    {
        IMemberServices _iss;
        public MemberController(IMemberServices iss)
        {
            _iss = iss;
        }
        [HttpGet]
        public IEnumerable<object> GetAllMembers()
        {
            return (_iss.GetMembers());
        }
        [HttpGet("{id}")]

        public object GetMemberByID(int id)
        {
            return _iss.GetMemberByID(id);
        }

        [HttpGet]
        [Route("byName/{Fname}/{Lname}")]
        public ActionResult<object> GetMembersByName(string Fname,string Lname)
        {
            return _iss.GetMemberByName(Fname,Lname);
        }

        [HttpPost]

        public void AddMember([FromBody] Members member)
        {
            _iss.AddMember(member);
        }

        [HttpPut("{id}")]
        public void UpdateMember(int id, Members member)
        {
            _iss.UpdateMember(id, member);

        }

        [HttpDelete("{id}")]

        public void DeleteMembet(int id)
        {
            
            _iss.DeleteMember(id);
        }
    }
}
