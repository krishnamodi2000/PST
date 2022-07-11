using LMS.Context;
using LMS.Models.Books;
using LMS.Models.Member;

namespace LMS.Services.IssueService
{
    public class IssueServices : IIssueServices
    {
        LibraryContext db;
        public IssueServices(LibraryContext _db)
        {
            db = _db;
        }
        public void AddIssue(Issue issue)
        {

            //var bk=

            //Members mem = db.Members.FirstOrDefault(i => i.MemberId == issue.MemberId);
            //if (mem != null)
            //{
            //    mem.IssueId = issue.IssueId;
            //    db.Entry(mem).Property(i => i.IssueId).IsModified = true;
            //    //db.SaveChanges();
            //}
            //Book bk = db.Books.FirstOrDefault(b => b.BookId == issue.BookId);
            //if (bk != null)
            //{
            //    bk.IssueId = issue.IssueId;
            //    db.Entry(bk).Property(b => b.IssueId).IsModified = true;
            //    //db.SaveChanges();
            //}
            db.Add(issue);

            db.SaveChanges();

        }

        public void DeleteIssue(int id)
        {
            Issue issue = db.Issues.FirstOrDefault(i => i.IssueId == id);
            if (issue != null)
            {
                //Book bk = db.Books.FirstOrDefault(b => b.BookId == issue.BookId);
                //Members mem=db.Members.FirstOrDefault(m=>m.MemberId==issue.MemberId);
                //if (bk != null)
                //{
                //    bk.IssueId = null;
                //    db.Entry(bk).Property(b => b.IssueId).IsModified = true;
                //}
                //if (mem != null)
                //{
                //    mem.IssueId = null;
                //    db.Entry(mem).Property(m => m.IssueId).IsModified = true;
                //}
                db.Remove(issue);

                db.SaveChanges();
            }
        }

        public IEnumerable<object> GetAllIssues()
        {
            var result = db.Issues.Select(x => new { x.IssueId, x.IssueDate, x.ReturnDate, x.ReturnStatus, x.BookId,x.MemberId });
            //return (db.Issues.Select(i => i).ToList());
            return result;
        }

        public object GetIssueByID(int id)
        {
            var result = db.Issues.Where(x => x.IssueId == id).Select(x => new { x.IssueId, x.IssueDate, x.ReturnDate, x.ReturnStatus, x.BookId,x.MemberId });
            return result;
        }

        public void UpdateIssue(int id, Issue issue)
        {
            var iss = db.Issues.FirstOrDefault(i => i.IssueId == id);
            if (iss!= null)
            {

                //Book bk = db.Books.FirstOrDefault(b => b.BookId == issue.BookId);
                //Book book = db.Books.FirstOrDefault(b => b.BookId == iss.BookId);
                //if (book != null)
                //{
                //  // book.IssueId = null;
                //   db.Entry(book).Reference(b => b.IssueId).CurrentValue=null;
                //}
                //if (bk != null && bk.IssueId == null)//add member conditions here as well
                //{
                //    bk.IssueId = issue.IssueId;
                //    db.Entry(bk).Property(b => b.IssueId).IsModified = true;
                //   // db.Entry<Issue>(iss).CurrentValues.SetValues(issue);
                //}
                ////change the paricular book issue id and particular mem issue id
                    db.Entry<Issue>(iss).CurrentValues.SetValues(issue);
                db.SaveChanges();

            }
        }
    }
}
