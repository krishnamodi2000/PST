using LMS.Models.Member;
using LMS.Services.MemberDesignationService;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberDesignationController : Controller
    {
        IMemberDesignationServices _iss;
        public MemberDesignationController(IMemberDesignationServices iss)
        {
            _iss = iss;
        }
        [HttpGet]
        public IEnumerable<MemberDesignation> GetAllMemberDesignations()
        {
            return (_iss.GetMemberDesignations());
        }
        [HttpGet("{id}")]

        public MemberDesignation GetMemberDesignationByID(int id)
        {
            return _iss.GetMemberDesignationByID(id);
        }

        [HttpGet]
        [Route("byName/{name}")]
        public ActionResult<MemberDesignation> GetMemberDesignationByName(string name)
        {
            return _iss.GetMemberDesignationByName(name);
        }

        [HttpPost]

        public void AddMemberDesignation([FromBody] MemberDesignation memberDesignation)
        {
            _iss.AddMemberDesignation(memberDesignation);
        }

        [HttpPut("{id}")]
        public void UpdateMemberDesignation(int id, MemberDesignation memberDesignation)
        {
            _iss.UpdateMemberDesignation(id, memberDesignation);

        }

        [HttpDelete("{id}")]

        public void DeleteMemberDesignation(int id)
        {
            _iss.DeleteMemberDesignation(id);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
