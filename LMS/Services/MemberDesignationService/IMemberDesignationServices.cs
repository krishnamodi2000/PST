using LMS.Models.Member;

namespace LMS.Services.MemberDesignationService
{
    public interface IMemberDesignationServices
    {
        public IEnumerable<MemberDesignation> GetMemberDesignations();
        public void AddMemberDesignation(MemberDesignation designation);
        public void DeleteMemberDesignation(int id);
        public void UpdateMemberDesignation(int id, MemberDesignation designation);
        public MemberDesignation GetMemberDesignationByID(int id);
        public MemberDesignation GetMemberDesignationByName(string name);
    }
}
