using LMS.Models.Member;
namespace LMS.Services.MemberService
{
    public interface IMemberServices
    {
        public IEnumerable<object> GetMembers();
        public void AddMember(Members members);
        public void DeleteMember(int id);
        public void UpdateMember(int id, Members members);
        public object GetMemberByID(int id);
        public object GetMemberByName(string Fname,string Lname);
    }
}
