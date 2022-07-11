using LMS.Context;
using LMS.Models.Member;

namespace LMS.Services.MemberDesignationService
{
    public class MemberDesignationServices : IMemberDesignationServices
    {
        LibraryContext db;
        public MemberDesignationServices(LibraryContext _db)
        {
            db = _db;
        }
        public void AddMemberDesignation(MemberDesignation designation)
        {
            db.Add(designation);
            db.SaveChanges();
        }

        public void DeleteMemberDesignation(int id)
        {
            //var idNew = 100;
            MemberDesignation designation = db.Designations.FirstOrDefault(d => d.DesgnationId == id); 
            //List<Members> member = db.Members.Where(m => (m.MemberDesignationID==id)).ToList(); //NEED TO CHECK THE FUNCTIONALITY
            if (designation != null)
            {
                //foreach(Members m in member)
                //{
                //    m.MemberDesignationID=idNew;
                //}
                db.Remove(designation);
                
                db.SaveChanges();
            }
        }

        public MemberDesignation GetMemberDesignationByID(int id)
        {
            return (db.Designations.Find(id));
        }

        public MemberDesignation GetMemberDesignationByName(string name)
        {
            return (db.Designations.FirstOrDefault(a => (a.DesgnationTitle == name)));
        }

        public IEnumerable<MemberDesignation> GetMemberDesignations()
        {
            return (db.Designations.Select(a => a).ToList());
        }

        public void UpdateMemberDesignation(int id, MemberDesignation designation)
        {
            var des = db.Designations.FirstOrDefault(a => a.DesgnationId == id);
            if (des != null)
            {
                db.Entry<MemberDesignation>(des).CurrentValues.SetValues(designation);
                db.SaveChanges();
            }
        }
    }
}
