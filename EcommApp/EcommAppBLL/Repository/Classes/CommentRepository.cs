using EcommAppBLL.ModelViews;
using EcommAppBLL.Utility;
using EcommAppDAL.Context;
using EcommAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLL.Repository.Comments
{
    public class CommentRepository : ICommentRepository
    {
        DatabaseContext db;
        Comment comments1;
        List<CommentView> views;
        List<CommentView1> views1;
        public CommentRepository(DatabaseContext _db)
        {
            db = _db;
            comments1 = new Comment();
        }
        public void AddComments(CommentView comments)
        {
            var user1 = db.Users.FirstOrDefault(c => c.UserId == comments.UserId);
            var prod1 = db.Products.FirstOrDefault(c => c.ProductId == comments.ProductId);
            var comm = db.Comments.FirstOrDefault(c => c.ParentCommentId == comments.CommentId);

            if (user1 != null && prod1 != null)
            {

                PropertyCopy<CommentView, Comment>.Copy(comments, comments1);
                db.Comments.Add(comments1);
                db.SaveChanges();


            }

        }

        public List<CommentView1> GetAllCommentsByProductId(int productid)
        {

            List<Comment> comments = db.Comments.Where(c => c.ProductId == productid).ToList();
            if (comments != null)
            {
                views1 = comments.Where(c => c.ParentCommentId == 0).Select(c => new CommentView1
                {
                    CommentId = c.CommentId,
                    ProductId = c.ProductId,
                    UserId = c.UserId,
                    CommentDate = c.CommentDate,
                    CommentDetails = c.CommentDetails,
                    ParentCommentId = c.ParentCommentId,
                    Reply = GetChildren(comments, c.CommentId)
                }).ToList();
            }
            return views1;

        }
        public List<CommentView1> GetChildren(List<Comment> comments, int parentId)
        {
            return comments.Where(c => c.ParentCommentId == parentId)
                .Select(c => new CommentView1
                {
                    CommentId = c.CommentId,
                    CommentDate = c.CommentDate,
                    CommentDetails = c.CommentDetails,
                    ParentCommentId = c.ParentCommentId,
                    ProductId = c.ProductId,
                    UserId = c.UserId,
                    Reply = GetChildren(comments, c.CommentId)
                }).ToList();

        }
        public List<CommentView1> GetCommentsByText(string comment)
        {
            List<Comment> comments = db.Comments.Where(c => c.CommentDetails.Contains(comment)).ToList();

            return views1 = comments.Select(c => new CommentView1
            {
                CommentId = c.CommentId,
                ProductId = c.ProductId,
                UserId = c.UserId,
                CommentDate = c.CommentDate,
                CommentDetails = c.CommentDetails,
                ParentCommentId = c.ParentCommentId,
                Reply = GetChildren(comments, c.CommentId)
            }).ToList();

        }

        public List<CommentView1> GetCommentsByUserId(int userid)
        {
            List<Comment> comments = db.Comments.Where(c => c.UserId == userid).ToList();
            if (comments != null)
            {
                views1 = comments.Select(c => new CommentView1
                {
                    CommentId = c.CommentId,
                    ProductId = c.ProductId,
                    UserId = c.UserId,
                    CommentDate = c.CommentDate,
                    CommentDetails = c.CommentDetails,
                    ParentCommentId = c.ParentCommentId,
                    Reply = GetChildren(comments, c.CommentId)
                }).ToList();
            }
            return views1;
        }

        public void RemoveCommentsByCommentId(int commentid)
        {

            // List<Comment> comm = db.Comments.Where(c => c.ParentCommentId == commentid || c.CommentId==commentid).Select(c=>c).ToList();

            var comm = (from comment in db.Comments
                            //where (comment.CommentId == commentid)
                        join comment2 in db.Comments on comment.ProductId equals comment2.ProductId
                        select (comment)).ToList();

            List<Comment> tree1 = new List<Comment>();
            var parentcomment = db.Comments.Where(c => c.CommentId == commentid).Select(c => c).FirstOrDefault();
            tree1.Add(parentcomment);
            var comm1 = ToTree(comm, tree1, commentid);

            db.Comments.RemoveRange(comm1);
            db.SaveChanges();


        }
        public static List<Comment> ToTree(IEnumerable<Comment> flatList, List<Comment> tree1, int commentid = 0)
        {
            var tree = flatList
               .Where(m => m.ParentCommentId == commentid)
                .ToList();
            tree1.AddRange(tree);
            if (tree != null && tree.Count > 0)
            {
                tree1.AddRange(ToTree(flatList, tree1, tree.FirstOrDefault<Comment>().CommentId));
            }
            else
            {
                return tree1;
            }

            return tree1;
        }

        public void UpdateComments(CommentView comments)
        {
            var user1 = db.Users.FirstOrDefault(c => c.UserId == comments.UserId);
            var prod1 = db.Products.FirstOrDefault(c => c.ProductId == comments.ProductId);
            var comm = db.Comments.FirstOrDefault(c => c.ParentCommentId == comments.CommentId);
            var oldcomment = db.Comments.FirstOrDefault(c => c.CommentId == comments.CommentId);
            if (user1 != null && prod1 != null && comm == null && oldcomment != null)
            {
                PropertyCopy<CommentView, Comment>.Copy(comments, comments1);
                db.Entry<Comment>(oldcomment).CurrentValues.SetValues(comments1);
                db.SaveChanges();

            }

        }
        public CommentView GetCommentById(int id)
        {
            var comm = db.Comments.FirstOrDefault(c => c.CommentId == id);
            CommentView views1 = new CommentView();
            if (comm != null)
            {
                views1 = (from _comment in db.Comments
                          where _comment.CommentId == id
                          select new CommentView
                          {
                              CommentId = _comment.CommentId,
                              UserId = _comment.UserId,
                              ProductId = _comment.ProductId,
                              CommentDetails = _comment.CommentDetails,
                              CommentDate = _comment.CommentDate,
                              ParentCommentId = _comment.ParentCommentId
                          }).FirstOrDefault();

            }
            return views1;
        }
    }
}