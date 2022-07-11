using EcommAppBLL.ModelViews;
using EcommAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommAppBLL.Repository.Comments
{
    public interface ICommentRepository
    {
        public List<CommentView1> GetAllCommentsByProductId(int productid);
        public List<CommentView1> GetCommentsByUserId(int userid);
        public List<CommentView1> GetCommentsByText(string comment);
        public void AddComments(CommentView comments);
        public void UpdateComments(CommentView comments);
        public void RemoveCommentsByCommentId(int commentid);
        //public CommentView GetCommentById(int id);

    }
}
