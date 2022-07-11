using LMS.Models.Books;

namespace LMS.Services.IssueService
{
    public interface IIssueServices
    {
        public IEnumerable<object> GetAllIssues();
        public void AddIssue(Issue issue);
        public void DeleteIssue(int id);
        public void UpdateIssue(int id, Issue issue);
        public object GetIssueByID(int id);
        
    }
}
