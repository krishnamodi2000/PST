using LMS.Context;
using LMS.Models.Member;

namespace LMS.Services.MemberService
{
    public class MemberServices : IMemberServices
    {
        LibraryContext db;
        public MemberServices(LibraryContext _db)
        {
            db = _db;
        }
        public void AddMember(Members members)
        {
            db.Add(members);
            db.SaveChanges();
        }

        public void DeleteMember(int id)
        {
            Members member = db.Members.FirstOrDefault(m => m.MemberId == id);
            if (member != null)
            {
                db.Remove(member); // allow only if issue id is null
                db.SaveChanges();
            }
        }

        public object GetMemberByID(int id)
        {
            var result = db.Members.Where(x => x.MemberId == id).Select(x => new { x.MemberId, x.MemberFName, x.MemberLName, x.MemberPhoneNumber });
            return result;
        }

        public object GetMemberByName(string Fname, string Lname)
        {
            var result = db.Members.Where(x => (x.MemberFName == Fname && x.MemberLName==Lname)).Select(x => new { x.MemberId, x.MemberFName, x.MemberLName, x.MemberPhoneNumber });
            return result;
        }

        public IEnumerable<object> GetMembers()
        {
            var result = db.Members.Select(x => new { x.MemberId, x.MemberFName, x.MemberLName, x.MemberPhoneNumber });
            return result;
            //return db.Members.Select(m => m).ToList();
        }

        public void UpdateMember(int id, Members members)
        {
            var mem = db.Members.FirstOrDefault(m => m.MemberId == id);
            if (mem != null)
            {
                db.Entry<Members>(mem).CurrentValues.SetValues(members);
                db.SaveChanges();
            }
            //change issue memeber id
        }
    }
}
